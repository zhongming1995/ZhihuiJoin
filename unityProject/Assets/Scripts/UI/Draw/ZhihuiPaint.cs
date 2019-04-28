// Optimized Mobile Painter - Unitycoder.com

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Draw
{
	public enum DrawMode
	{
		Default,
		CustomBrush,
		FloodFill,
		Pattern,
		ShapeLines,
		Eraser
	}

	public enum EraserMode
	{
		Default,
		BackgroundColor
	}

	public class ZhihuiPaint : MonoBehaviour
	{
		
		[Header("Mouse or Touch")]
		public bool enableTouch = false;

		public RectTransform referenceArea; // we will match the size of this reference object
		private float canvasScaleFactor = 1; // canvas scaling factor (will be taken from Canvas)

		[Header("Brush Settings")]
		public bool connectBrushStokes = true; // if brush moves too fast, then connect them with line. NOTE! Disable this if you are painting to custom mesh

		//	*** Default settings ***
		public Color32 paintColor = new Color32(255, 0, 0, 255);



		public int brushSize = 24; // default brush size
		public int brushSizeMin = 1; // default min brush size
		public int brushSizeMax = 64; // default max brush size

		// cached calculations
		public bool hiQualityBrush = false; // Draw more brush strokes when moving NOTE: this is slow on mobiles!
		private int brushSizeX1 = 48; // << 1
		private int brushSizeXbrushSize = 576; // x*x
		private int brushSizeX4 = 96; // << 2
		private int brushSizeDiv4 = 6; // >> 2 == /4


		public bool realTimeTexUpdate = true; // if set to true, ignore textureUpdateSpeed, and always update when textureNeedsUpdate gets set to true when drawing
		public float textureUpdateSpeed = 0.1f; // how often texture should be updated (0 = no delay, 1 = every one seconds)
		private float nextTextureUpdate = 0;

		public bool useAdditiveColors = false; // true = alpha adds up slowly, false = 1 click will instantly set alpha to brush or paint color alpha value

		public float brushAlphaStrength = 0.01f; // multiplier to soften brush additive alpha, 0.1f is nice & smooth, 1 = faster
		private float brushAlphaStrengthVal = 0.01f; // cached calculation
		private float alphaLerpVal = 0.1f;
		private float brushAlphaLerpVal = 0.1f;

		//		public bool DontPaintOverBlack = true; // so that outlines are reserved when painting

		[Header("Options")]
		public DrawMode drawMode = DrawMode.Default; // drawing modes: 0 = Default, 1 = custom brush, 2 = floodfill
		public bool useLockArea = false; // locking mask: only paint in area of the color that your click first
		public bool smoothenMaskEdges = false; // less white edges with mask
		public bool useThreshold = false;
		public byte paintThreshold = 128; // 0 = only exact match, 255 = match anything

		// ERASER
		[Space(10)]
		public EraserMode eraserMode = EraserMode.BackgroundColor;
		//private int defaultEraserSize = 32; // default fixed size for eraser


		// AREA FILL CALCULATIONS
		[Space(10)]
		int initialX = 0;
		int initialY = 0;
		public delegate void AreaWasPainted(int fullArea, int filledArea, float percentageFilled, Vector3 point);
		public event AreaWasPainted AreaPaintedEvent;


		//private bool lockMaskCreated=false; //is lockmask already created for this click, not used yet
		private byte[] lockMaskPixels; // locking mask pixels


		public bool canDrawOnBlack = true; // to stop filling on mask black lines, FIXME: not working if its not pure black..


		//public bool drawAfterFill = true; // TODO: return to drawing mode after first fill?

		public Vector2 canvasSizeAdjust = new Vector2(0, 0); // this means, "ScreenResolution.xy+screenSizeAdjust.xy" (use only minus values, to add un-drawable border on right or bottom)
		public string targetTexture = "_MainTex"; // target texture for this material shader (usually _MainTex)
		public FilterMode filterMode = FilterMode.Point;

		// canvas clear color
		public Color32 clearColor = new Color32(255, 255, 255, 255);

		[Header("Custom Brushes")]
		public bool useCustomBrushes = false;
		public Texture2D[] customBrushes;
		public bool overrideCustomBrushColor = false; // uses paint color instead of brush texture color
		public bool useCustomBrushAlpha = true; // true = use alpha from brush, false = use alpha from current paint color
		public int selectedBrush = 0; // currently selected brush index

		//private Color[] customBrushPixels;
		private byte[] customBrushBytes;
		private int customBrushWidth;
		private int customBrushHeight;
		private int customBrushWidthHalf;
		//		private int customBrushHeightHalf;
		private int texWidthMinusCustomBrushWidth;
		private int texHeightMinusCustomBrushHeight;

		[Header("Line Drawing")]
		public Transform previewLineCircle;
		Transform previewLineCircleStart; // clone for start of circle
		Transform previewLineCircleEnd; // clone for end of circle
		bool haveStartedLine = false;
		int firstClickX = 0;
		int firstClickY = 0;
		LineRenderer lineRenderer;
		public bool snapLinesToGrid = false; // while drawing lines
		public int gridResolution = 128;
		int gridSize = 10;

		// for old GUIScaling
		private float scaleAdjust = 1.0f;
		private const float BASE_WIDTH = 800;
		private const float BASE_HEIGHT = 480;

		//	*** private variables, no need to touch ***
		private byte[] pixels; // byte array for texture painting, this is the image that we paint into.
		private byte[] maskPixels; // byte array for mask texture
		private byte[] clearPixels; // byte array for clearing texture

		private Texture2D drawingTexture; // texture that we paint into (it gets updated from pixels[] array when painted)

		[Header("Overrides")]
		public float resolutionScaler = 1.0f; // 1 means screen resolution, 0.5f means half the screen resolution
		public bool overrideResolution = false;
		public int overrideWidth = 1024;
		public int overrideHeight = 768;

		private int texWidth;
		private int texHeight;
		private Touch touch; // touch reference
		private bool wasTouching = false; // in previous frame we had touch
		private Camera cam; // main camera reference
		private RawImage myRenderer;
		//public RawImage myRawImage;

		private RaycastHit hit;
		private bool wentOutside = false;

		private bool usingClearingImage = false; // did we have initial texture as maintexture, then use it as clear pixels array

		private Vector2 pixelUV; // with mouse
		private Vector2 pixelUVOld; // with mouse

		private Vector2[] pixelUVs; // mobiles
		private Vector2[] pixelUVOlds; // mobiles

		[HideInInspector]
		public bool textureNeedsUpdate = false; // if we have modified texture

		// zoom pan
		private bool isZoomingOrPanning = false;

		RectTransform thisRectTrans;

		void Awake()
		{
			// cache components
			cam = Camera.main;
			myRenderer = GetComponent<RawImage>();
			thisRectTrans = this.GetComponent<RectTransform> ();
			StartupValidation();
			InitializeEverything();
		}



		// all startup validations will be moved here
		void StartupValidation()
		{
			if (cam == null) Debug.LogError("MainCamera not founded, you must have 1 camera active & tagged as MainCamera", gameObject);

			// Custom brushes validation
			if (useCustomBrushes && (customBrushes == null || customBrushes.Length < 1))
			{
				Debug.LogWarning("useCustomBrushes is enabled, but no custombrushes assigned to array, disabling customBrushes", gameObject);
				useCustomBrushes = false;
			}


			// check if target texture exists
			if (!myRenderer.material.HasProperty(targetTexture)) Debug.LogError("Fatal error: Current shader doesn't have a property: '" + targetTexture + "'", gameObject);

			// validate & clamp override resolution
			if (overrideResolution)
			{
				if (overrideWidth < 0 || overrideWidth > 8192) { Debug.LogWarning("Invalid overrideWidth:" + overrideWidth, gameObject); overrideWidth = Mathf.Clamp(0, 1, 8192); }
				if (overrideHeight < 0 || overrideHeight > 8192) { Debug.LogWarning("Invalid overrideHeight:" + overrideHeight, gameObject); overrideHeight = Mathf.Clamp(0, 1, 8192); }

				if (resolutionScaler != 1)
				{
					Debug.LogWarning("Cannot use resolutionScaler with OverrideResolution, setting resolutionScaler to default (1)");
					resolutionScaler = 1;
				}

			}

			// check eraser modes
			if (myRenderer.material.GetTexture(targetTexture) == null)
			{
				if (eraserMode == EraserMode.Default)
				{
					Debug.LogError("eraserMode is set to Default, but there is no texture assigned to " + targetTexture + ". Setting eraseMode to BackgroundColor");
					eraserMode = EraserMode.BackgroundColor;
				}
			}


		} // StartupValidation()

		// rebuilds everything and reloads masks,textures..
		public void InitializeEverything()
		{
			// cached calculations
			brushSizeX1 = brushSize << 1;
			brushSizeXbrushSize = brushSize * brushSize;
			brushSizeX4 = brushSizeXbrushSize << 2;

			SetBrushAlphaStrength(brushAlphaStrength);
			SetPaintColor(paintColor);

			// calculate scaling ratio for different screen resolutions
			float _baseHeightInverted = 1.0f / BASE_HEIGHT;
			float ratio = (Screen.height * _baseHeightInverted) * scaleAdjust;
			canvasSizeAdjust *= ratio;

			// WARNING: fixed maximum amount of touches, is set to 20 here. Not sure if some device supports more?
			pixelUVs = new Vector2[20];
			pixelUVOlds = new Vector2[20];

			// overriding will also ignore Resolution Scaler value
			if (overrideResolution)
			{
				var err = false;
				if (overrideWidth < 0 || overrideWidth > 4096) err = true;
				if (overrideHeight < 0 || overrideHeight > 4096) err = true;
				if (err) Debug.LogError("overrideWidth or overrideWidth is invalid - clamping to 4 or 4096");
				texWidth = (int)Mathf.Clamp(overrideWidth, 4, 4096);
				texHeight = (int)Mathf.Clamp(overrideHeight, 4, 4096);

			}
			else { // use screen size as texture size
				texWidth = (int)(Screen.width * resolutionScaler + canvasSizeAdjust.x);
				texHeight = (int)(Screen.height * resolutionScaler + canvasSizeAdjust.y);
			}
				
			// we have no texture set for canvas, FIXME: this returns true if called initialize again, since texture gets created after this
			if (myRenderer.material.GetTexture(targetTexture) == null && !usingClearingImage) // temporary fix by adding && !usingClearingImage
			{
				Debug.Log ("targetTexture) == null");
				// create new texture
				if (drawingTexture != null) Texture2D.DestroyImmediate(drawingTexture, true); // cleanup old texture
				drawingTexture = new Texture2D(texWidth, texHeight, TextureFormat.RGBA32, false);
				myRenderer.material.SetTexture(targetTexture, drawingTexture);


				// init pixels array
				pixels = new byte[texWidth * texHeight * 4];

			} else { // we have canvas texture, then use that as clearing texture

				usingClearingImage = true;

				if (overrideResolution) Debug.LogWarning("overrideResolution is not used, when canvas texture is assiged to material, we need to use the texture size");

				texWidth = myRenderer.material.GetTexture(targetTexture).width;
				Debug.Log ("a");
				texHeight = myRenderer.material.GetTexture(targetTexture).height;
				Debug.Log ("b");

				// init pixels array
				pixels = new byte[texWidth * texHeight * 4];

				if (drawingTexture != null) Texture2D.DestroyImmediate(drawingTexture, true); // cleanup old texture
				drawingTexture = new Texture2D(texWidth, texHeight, TextureFormat.RGBA32, false);

				// we keep current maintex and read it as "clear pixels array" (so when "clear image" is clicked, original texture is restored
				ReadClearingImage();
				myRenderer.material.SetTexture(targetTexture, drawingTexture);
			}


			// set texture modes
			drawingTexture.filterMode = filterMode;
			drawingTexture.wrapMode = TextureWrapMode.Clamp;


			// locking mask enabled
			if (useLockArea)
			{
				lockMaskPixels = new byte[texWidth * texHeight * 4];
			}

			// grid for line shapes
			gridSize = texWidth / gridResolution;

			// init custom brush if used
			if (useCustomBrushes && drawMode == DrawMode.CustomBrush) ReadCurrentCustomBrush();

			ClearImage(updateUndoBuffer: false);


		} // InitializeEverything


		public Vector2 CurrMousePosition()
		{
			Vector2 vecMouse;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(thisRectTrans, Input.mousePosition, cam, out vecMouse);
			return vecMouse;
		}

		// *** MAINLOOP ***
		void Update()
		{
			if (enableTouch)
			{
				TouchPaint();
			}
			else {
				MousePaint();
			}

			if (textureNeedsUpdate && (realTimeTexUpdate || Time.time > nextTextureUpdate))
			{
				nextTextureUpdate = Time.time + textureUpdateSpeed;
				UpdateTexture();
			}
		}

		bool point_down =false;

		// handle mouse events
		void MousePaint()
		{
			// catch first mousedown
			if (Input.GetMouseButtonDown (0)) {
				// if lock area is used, we need to take full area before painting starts
				if (useLockArea) {
                    if (!Physics.Raycast (cam.transform.position, cam.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 100)), out hit, Mathf.Infinity/*, paintLayerMask*/)) 
                    //if (!Physics.Raycast(cam.transform.position, cam.ScreenToWorldPoint(Input.mousePosition), out hit, Mathf.Infinity/*, paintLayerMask*/))
                    {
                        //Debug.DrawRay (cam.transform.position, cam.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 100)));
                        return;
					}

					if (hit.collider.name == "DrawingPlaneCanvas") {
						CreateAreaLockMask ((int)(cam.ScreenToViewportPoint (Input.mousePosition).x * texWidth), (int)(cam.ScreenToViewportPoint (Input.mousePosition).y * texHeight));
					}

				}
			}

			// left button is held down, draw
			if (Input.GetMouseButton(0))
			{
                // Only if we hit something, then we continue
                Debug.Log(transform.position.z);
                if (!Physics.Raycast (cam.transform.position,cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, transform.position.z)), out hit, Mathf.Infinity)) 
                //if (!Physics.Raycast(cam.transform.position, cam.ScreenToWorldPoint(Input.mousePosition), out hit, Mathf.Infinity/*, paintLayerMask*/))
                {
                    Debug.Log("outside");
                    wentOutside = true; return;
                }

				pixelUVOld = pixelUV; // take previous value, so can compare them
				Vector2 temp = CurrMousePosition();
                //pixelUV = new Vector2 ((temp.x + 300) / 600, (temp.y + 200) / 400);
                pixelUV = new Vector2 ((temp.x + 360) / 720, (temp.y + 364.5f) / 729);
                //pixelUV = cam.ScreenToViewportPoint (Input.mousePosition);
                pixelUV.x *= texWidth;
				pixelUV.y *= texHeight;

				if (wentOutside) { pixelUVOld = pixelUV; wentOutside = false; }


				// lets paint where we hit
				switch (drawMode)
				{
				case DrawMode.Default: // brush
					//Debug.Log ("DrawCircle");
					DrawCircle((int)pixelUV.x, (int)pixelUV.y);
					break;
				case DrawMode.CustomBrush:
					Debug.Log ("CustomBrush");
					DrawCustomBrush((int)pixelUV.x, (int)pixelUV.y);
					break;

				case DrawMode.FloodFill:
					if (pixelUVOld == pixelUV) break;
					CallFloodFill((int)pixelUV.x, (int)pixelUV.y);
					break;

				default: // unknown DrawMode
					Debug.LogError("Unknown drawMode");
					break;
				}

				textureNeedsUpdate = true;
			}


			if (Input.GetMouseButtonDown (0))
			{
				if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity)) return;

				pixelUVOld = pixelUV;
			}


			// check distance from previous drawing point and connect them with DrawLine
			//			if (connectBrushStokes && Vector2.Distance(pixelUV,pixelUVOld)>brushSize)
			if (connectBrushStokes && textureNeedsUpdate)
			{
				switch (drawMode)
				{
				case DrawMode.Default: // drawing
					DrawLine(pixelUVOld, pixelUV);
					break;

				case DrawMode.CustomBrush:
					DrawLineWithBrush(pixelUVOld, pixelUV);
					break;

				default: // other modes
					break;
				}
				pixelUVOld = pixelUV;
				textureNeedsUpdate = true;
			}

			// left mouse button released
			if (Input.GetMouseButtonUp(0))
			{
				

			}

		}

		// ** Main loop for touch paint **
		int i = 0;
		void TouchPaint()
		{
			// check if any touch is over UI objects, then early exit (dont paint)
			while (i < Input.touchCount)
			{
				touch = Input.GetTouch(i);
				i++;
			}

			i = 0;
			// loop until all touches are processed
			while (i < Input.touchCount)
			{

				touch = Input.GetTouch(i);
				if (touch.phase == TouchPhase.Began)
				{
					wasTouching = true;

					if (useLockArea)
					{
						if (!Physics.Raycast(cam.ScreenPointToRay(touch.position), out hit, Mathf.Infinity)) { wentOutside = true; return; }

						pixelUVs[touch.fingerId] = hit.textureCoord;
						pixelUVs[touch.fingerId].x *= texWidth;
						pixelUVs[touch.fingerId].y *= texHeight;
						if (wentOutside) { pixelUVOlds[touch.fingerId] = pixelUVs[touch.fingerId]; wentOutside = false; }
						CreateAreaLockMask((int)pixelUVs[touch.fingerId].x, (int)pixelUVs[touch.fingerId].y);
					}
				}
				// check state
				if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Began)
				{

					// do raycast on touch position
					if (Physics.Raycast(cam.ScreenPointToRay(touch.position), out hit, Mathf.Infinity))
					{
						// take previous value, so can compare them
						pixelUVOlds[touch.fingerId] = pixelUVs[touch.fingerId];
						// get hit texture coordinate
						pixelUVs[touch.fingerId] = hit.textureCoord;
						pixelUVs[touch.fingerId].x *= texWidth;
						pixelUVs[touch.fingerId].y *= texHeight;
						// paint where we hit
						switch (drawMode)
						{
						case DrawMode.Default:
							DrawCircle((int)pixelUVs[touch.fingerId].x, (int)pixelUVs[touch.fingerId].y);
							break;

						case DrawMode.CustomBrush:
							DrawCustomBrush((int)pixelUVs[touch.fingerId].x, (int)pixelUVs[touch.fingerId].y);
							break;

						case DrawMode.FloodFill:
							CallFloodFill((int)pixelUVs[touch.fingerId].x, (int)pixelUVs[touch.fingerId].y);
							break;

						default:
							// unknown mode
							break;
						}
						// set flag that texture needs to be applied
						textureNeedsUpdate = true;
					}
				}
				// if we just touched screen, set this finger id texture paint start position to that place
				if (touch.phase == TouchPhase.Began)
				{
					pixelUVOlds[touch.fingerId] = pixelUVs[touch.fingerId];
				}
				// check distance from previous drawing point
				//if (connectBrushStokes && Vector2.Distance (pixelUVs[touch.fingerId], pixelUVOlds[touch.fingerId]) > brushSize) 
				if (connectBrushStokes && textureNeedsUpdate)
				{
					switch (drawMode)
					{
					case DrawMode.Default:
						DrawLine(pixelUVOlds[touch.fingerId], pixelUVs[touch.fingerId]);
						break;

					case DrawMode.CustomBrush:
						DrawLineWithBrush(pixelUVOlds[touch.fingerId], pixelUVs[touch.fingerId]);
						break;

					default:
						// unknown mode
						break;
					}
					textureNeedsUpdate = true;

					pixelUVOlds[touch.fingerId] = pixelUVs[touch.fingerId];

				}
				// loop all touches
				i++;
			}

			// no touches
			if (wasTouching && Input.touchCount == 0)
			{
				wasTouching = false;
			}

		}

		void UpdateTexture()
		{
			Debug.Log ("UpdateTexture");
			textureNeedsUpdate = false;
			drawingTexture.LoadRawTextureData(pixels);
			drawingTexture.Apply(false);
		}


		void CreateAreaLockMask(int x, int y)
		{

			initialX = x;
			initialY = y;

			if (useThreshold)
			{
				Debug.Log ("useThreshold");
				LockMaskFillWithThreshold(x, y);
			}
		}

		// main painting function, modified from http://stackoverflow.com/b/24453110
		public void DrawCircle(int x, int y)
		{

			int pixel = 0;

			for (int i = 0; i < brushSizeX4; i++)
			{
				int tx = (i % brushSizeX1) - brushSize;
				int ty = (i / brushSizeX1) - brushSize;

				if (tx * tx + ty * ty > brushSizeXbrushSize) continue;
				if (x + tx < 0 || y + ty < 0 || x + tx >= texWidth || y + ty >= texHeight) continue; // temporary fix for corner painting

				pixel = (texWidth * (y + ty) + x + tx) << 2;

				if (useAdditiveColors)
				{
					//Debug.Log ("useAdditiveColors");
					if (!useLockArea || (useLockArea && lockMaskPixels[pixel] == 1))
					{
						pixels[pixel] = ByteLerp(pixels[pixel], paintColor.r, alphaLerpVal);
						pixels[pixel + 1] = ByteLerp(pixels[pixel + 1], paintColor.g, alphaLerpVal);
						pixels[pixel + 2] = ByteLerp(pixels[pixel + 2], paintColor.b, alphaLerpVal);
						pixels[pixel + 3] = ByteLerp(pixels[pixel + 3], paintColor.a, alphaLerpVal);
					}
				}
				else { // no additive, just paint my color
					//Debug.Log ("!useAdditiveColors");
					if (!useLockArea || (useLockArea && lockMaskPixels[pixel] == 1))
					{
						pixels[pixel] = paintColor.r;
						pixels[pixel + 1] = paintColor.g;
						pixels[pixel + 2] = paintColor.b;
						pixels[pixel + 3] = paintColor.a;
					}
				} // if additive
			} // for area
		} // DrawCircle()

		// Temporary basic eraser tool
		public void EraseWithBackgroundColor(int x, int y)
		{
			var origColor = paintColor;
			paintColor = clearColor;
			//var origSize = brushSize; // optional, have fixed eraser brush size temporarily while drawing
			//SetBrushSize(defaultEraserSize);
			DrawCircle(x, y);
			//SetBrushSize(origSize);
			paintColor = origColor;
		}


		public void EraseWithImage(int x, int y)
		{
			int pixel = 0;
			for (int i = 0; i < brushSizeX4; i++)
			{
				int tx = (i % brushSizeX1) - brushSize;
				int ty = (i / brushSizeX1) - brushSize;

				if (tx * tx + ty * ty > brushSizeXbrushSize) continue;
				if (x + tx < 0 || y + ty < 0 || x + tx >= texWidth || y + ty >= texHeight) continue; // temporary fix for corner painting

				pixel = (texWidth * (y + ty) + x + tx) << 2;

				float xx = Mathf.Repeat(y + ty, texHeight);
				float yy = Mathf.Repeat(x + tx, texWidth);
				int pixel2 = (int)Mathf.Repeat((texWidth * xx + yy) * 4, clearPixels.Length);

				pixels[pixel] = clearPixels[pixel2];
				pixels[pixel + 1] = clearPixels[pixel2 + 1];
				pixels[pixel + 2] = clearPixels[pixel2 + 2];
				pixels[pixel + 3] = clearPixels[pixel2 + 3];
			} 
		}
			

		// actual custom brush painting function
		void DrawCustomBrush(int px, int py)
		{
			// get position where we paint
			int startX = (int)(px - customBrushWidthHalf);
			int startY = (int)(py - customBrushWidthHalf);

			if (startX < 0)
			{
				startX = 0;
			}
			else {
				if (startX + customBrushWidth >= texWidth) startX = texWidthMinusCustomBrushWidth;
			}

			if (startY < 1)  // TODO: temporary fix, 1 instead of 0
			{
				startY = 1;
			}
			else {
				if (startY + customBrushHeight >= texHeight) startY = texHeightMinusCustomBrushHeight;
			}

			// could use this for speed (but then its box shaped..)
			//System.Array.Copy(splatPixByte,0,data,4*(startY*startX),splatPixByte.Length);	

			int pixel = (texWidth * startY + startX) << 2;
			int brushPixel = 0;

			//
			for (int y = 0; y < customBrushHeight; y++)
			{
				for (int x = 0; x < customBrushWidth; x++)
				{
					brushPixel = (customBrushWidth * (y) + x) << 2;

					// we have some color at this brush pixel?
					if (customBrushBytes[brushPixel + 3] > 0 && (!useLockArea || (useLockArea && lockMaskPixels[pixel] == 1)))
					{

						if (useCustomBrushAlpha) // use alpha from brush
						{
							if (useAdditiveColors)
							{

								brushAlphaLerpVal = customBrushBytes[brushPixel + 3] * brushAlphaStrength * 0.01f; // 0.01 is temporary fix so that default brush & custom brush both work

								if (overrideCustomBrushColor)
								{
									pixels[pixel] = ByteLerp(pixels[pixel], paintColor.r, brushAlphaLerpVal);
									pixels[pixel + 1] = ByteLerp(pixels[pixel + 1], paintColor.g, brushAlphaLerpVal);
									pixels[pixel + 2] = ByteLerp(pixels[pixel + 2], paintColor.b, brushAlphaLerpVal);
								}
								else { // use paint color instead of brush texture
									pixels[pixel] = ByteLerp(pixels[pixel], customBrushBytes[brushPixel], brushAlphaLerpVal);
									pixels[pixel + 1] = ByteLerp(pixels[pixel + 1], customBrushBytes[brushPixel + 1], brushAlphaLerpVal);
									pixels[pixel + 2] = ByteLerp(pixels[pixel + 2], customBrushBytes[brushPixel + 2], brushAlphaLerpVal);
								}
								pixels[pixel + 3] = ByteLerp(pixels[pixel + 3], paintColor.a, brushAlphaLerpVal);

							}
							else { // no additive colors
								if (overrideCustomBrushColor)
								{
									pixels[pixel] = ByteLerp(pixels[pixel], paintColor.r, brushAlphaLerpVal);
									pixels[pixel + 1] = ByteLerp(pixels[pixel + 1], paintColor.g, brushAlphaLerpVal);
									pixels[pixel + 2] = ByteLerp(pixels[pixel + 2], paintColor.b, brushAlphaLerpVal);
								}
								else { // use paint color instead of brush texture
									pixels[pixel] = customBrushBytes[brushPixel];
									pixels[pixel + 1] = customBrushBytes[brushPixel + 1];
									pixels[pixel + 2] = customBrushBytes[brushPixel + 2];
								}
								pixels[pixel + 3] = customBrushBytes[brushPixel + 3];
							}

						}
						else { // use paint color alpha

							if (useAdditiveColors)
							{
								if (overrideCustomBrushColor)
								{
									pixels[pixel] = ByteLerp(pixels[pixel], paintColor.r, brushAlphaLerpVal);
									pixels[pixel + 1] = ByteLerp(pixels[pixel + 1], paintColor.g, brushAlphaLerpVal);
									pixels[pixel + 2] = ByteLerp(pixels[pixel + 2], paintColor.b, brushAlphaLerpVal);
								}
								else {
									pixels[pixel] = ByteLerp(pixels[pixel], customBrushBytes[brushPixel], brushAlphaLerpVal);
									pixels[pixel + 1] = ByteLerp(pixels[pixel + 1], customBrushBytes[brushPixel + 1], brushAlphaLerpVal);
									pixels[pixel + 2] = ByteLerp(pixels[pixel + 2], customBrushBytes[brushPixel + 2], brushAlphaLerpVal);
								}
								pixels[pixel + 3] = ByteLerp(pixels[pixel + 3], paintColor.a, brushAlphaLerpVal);
							}
							else { // no additive colors
								if (overrideCustomBrushColor)
								{
									pixels[pixel] = ByteLerp(pixels[pixel], paintColor.r, brushAlphaLerpVal);
									pixels[pixel + 1] = ByteLerp(pixels[pixel + 1], paintColor.g, brushAlphaLerpVal);
									pixels[pixel + 2] = ByteLerp(pixels[pixel + 2], paintColor.b, brushAlphaLerpVal);
								}
								else {
									pixels[pixel] = customBrushBytes[brushPixel];
									pixels[pixel + 1] = customBrushBytes[brushPixel + 1];
									pixels[pixel + 2] = customBrushBytes[brushPixel + 2];
								}
								pixels[pixel + 3] = customBrushBytes[brushPixel + 3];
							}
						}
					}
					pixel += 4;

				} // for x

				pixel = (texWidth * (startY == 0 ? 1 : startY + y) + startX + 1) * 4;
			} // for y
		} // DrawCustomBrush
			
		void CallFloodFill(int x, int y)
		{
			if (useThreshold)
			{
				FloodFillWithTreshold(x, y);
			}
		}

		void FloodFillWithTreshold(int x, int y)
		{
			// get canvas hit color
			byte hitColorR = pixels[((texWidth * (y) + x) * 4) + 0];
			byte hitColorG = pixels[((texWidth * (y) + x) * 4) + 1];
			byte hitColorB = pixels[((texWidth * (y) + x) * 4) + 2];
			byte hitColorA = pixels[((texWidth * (y) + x) * 4) + 3];

			if (!canDrawOnBlack)
			{
				if (hitColorR == 0 && hitColorG == 0 && hitColorB == 0 && hitColorA != 0) return;
			}

			// early exit if outside threshold
			//if (CompareThreshold(paintColor.r,hitColorR) && CompareThreshold(paintColor.g,hitColorG) && CompareThreshold(paintColor.b,hitColorB) && CompareThreshold(paintColor.b,hitColorA)) return;
			if (paintColor.r == hitColorR && paintColor.g == hitColorG && paintColor.b == hitColorB && paintColor.a == hitColorA) return;

			Queue<int> fillPointX = new Queue<int>();
			Queue<int> fillPointY = new Queue<int>();
			fillPointX.Enqueue(x);
			fillPointY.Enqueue(y);

			int ptsx, ptsy;
			int pixel = 0;

			lockMaskPixels = new byte[texWidth * texHeight * 4];

			while (fillPointX.Count > 0)
			{

				ptsx = fillPointX.Dequeue();
				ptsy = fillPointY.Dequeue();

				if (ptsy - 1 > -1)
				{
					pixel = (texWidth * (ptsy - 1) + ptsx) * 4; // down
					if (lockMaskPixels[pixel] == 0
						&& CompareThreshold(pixels[pixel + 0], hitColorR)
						&& CompareThreshold(pixels[pixel + 1], hitColorG)
						&& CompareThreshold(pixels[pixel + 2], hitColorB)
						&& CompareThreshold(pixels[pixel + 3], hitColorA))
					{
						fillPointX.Enqueue(ptsx);
						fillPointY.Enqueue(ptsy - 1);
						DrawPoint(pixel);
						lockMaskPixels[pixel] = 1;
					}
				}

				if (ptsx + 1 < texWidth)
				{
					pixel = (texWidth * ptsy + ptsx + 1) * 4; // right
					if (lockMaskPixels[pixel] == 0
						&& CompareThreshold(pixels[pixel + 0], hitColorR)
						&& CompareThreshold(pixels[pixel + 1], hitColorG)
						&& CompareThreshold(pixels[pixel + 2], hitColorB)
						&& CompareThreshold(pixels[pixel + 3], hitColorA))
					{
						fillPointX.Enqueue(ptsx + 1);
						fillPointY.Enqueue(ptsy);
						DrawPoint(pixel);
						lockMaskPixels[pixel] = 1;
					}
				}

				if (ptsx - 1 > -1)
				{
					pixel = (texWidth * ptsy + ptsx - 1) * 4; // left
					if (lockMaskPixels[pixel] == 0
						&& CompareThreshold(pixels[pixel + 0], hitColorR)
						&& CompareThreshold(pixels[pixel + 1], hitColorG)
						&& CompareThreshold(pixels[pixel + 2], hitColorB)
						&& CompareThreshold(pixels[pixel + 3], hitColorA))
					{
						fillPointX.Enqueue(ptsx - 1);
						fillPointY.Enqueue(ptsy);
						DrawPoint(pixel);
						lockMaskPixels[pixel] = 1;
					}
				}

				if (ptsy + 1 < texHeight)
				{
					pixel = (texWidth * (ptsy + 1) + ptsx) * 4; // up
					if (lockMaskPixels[pixel] == 0
						&& CompareThreshold(pixels[pixel + 0], hitColorR)
						&& CompareThreshold(pixels[pixel + 1], hitColorG)
						&& CompareThreshold(pixels[pixel + 2], hitColorB)
						&& CompareThreshold(pixels[pixel + 3], hitColorA))
					{
						fillPointX.Enqueue(ptsx);
						fillPointY.Enqueue(ptsy + 1);
						DrawPoint(pixel);
						lockMaskPixels[pixel] = 1;
					}
				}
			}
		} // floodfillWithTreshold
			
		// compares if two values are below threshold
		bool CompareThreshold(byte a, byte b)
		{
			//return Mathf.Abs(b-b)<=threshold;
			if (a < b) { a ^= b; b ^= a; a ^= b; } // http://lab.polygonal.de/?p=81
			return (a - b) <= paintThreshold;
		}

		// create locking mask floodfill, using threshold
		void LockMaskFillWithThreshold(int x, int y)
		{
			Debug.Log("LockMaskFillWithTreshold");
			// get canvas color from this point
			byte hitColorR = pixels[((texWidth * (y) + x) * 4) + 0];
			byte hitColorG = pixels[((texWidth * (y) + x) * 4) + 1];
			byte hitColorB = pixels[((texWidth * (y) + x) * 4) + 2];
			byte hitColorA = pixels[((texWidth * (y) + x) * 4) + 3];

			if (!canDrawOnBlack)
			{
				Debug.Log("!canDrawOnBlack");
				if (hitColorR == 0 && hitColorG == 0 && hitColorB == 0 && hitColorA != 0) return;
			}

			Debug.Log("canDrawOnBlack");
			Queue<int> fillPointX = new Queue<int>();
			Queue<int> fillPointY = new Queue<int>();
			fillPointX.Enqueue(x);
			fillPointY.Enqueue(y);

			int ptsx, ptsy;
			int pixel = 0;

			lockMaskPixels = new byte[texWidth * texHeight * 4];

			while (fillPointX.Count > 0)
			{

				ptsx = fillPointX.Dequeue();
				ptsy = fillPointY.Dequeue();

				if (ptsy - 1 > -1)
				{
					pixel = (texWidth * (ptsy - 1) + ptsx) * 4; // down

					if (lockMaskPixels[pixel] == 0 // this pixel is not used yet
						//&& (CompareThreshold(pixels[pixel + 0], hitColorR) || CompareThreshold(pixels[pixel + 0], paintColor.r)) // if pixel is same as hit color OR same as paint color
						//&& (CompareThreshold(pixels[pixel + 1], hitColorG) || CompareThreshold(pixels[pixel + 1], paintColor.g))
						//&& (CompareThreshold(pixels[pixel + 2], hitColorB) || CompareThreshold(pixels[pixel + 2], paintColor.b))
						//&& (CompareThreshold(pixels[pixel + 3], hitColorA) || CompareThreshold(pixels[pixel + 3], paintColor.a)))
						&& (!CompareThreshold(pixels[pixel + 3], 0)))
					{
						fillPointX.Enqueue(ptsx);
						fillPointY.Enqueue(ptsy - 1);
						lockMaskPixels[pixel] = 1;
					}
				}

				if (ptsx + 1 < texWidth)
				{
					pixel = (texWidth * ptsy + ptsx + 1) * 4; // right
					if (lockMaskPixels[pixel] == 0
						//&& (CompareThreshold(pixels[pixel + 0], hitColorR) || CompareThreshold(pixels[pixel + 0], paintColor.r)) // if pixel is same as hit color OR same as paint color
						//&& (CompareThreshold(pixels[pixel + 1], hitColorG) || CompareThreshold(pixels[pixel + 1], paintColor.g))
						//&& (CompareThreshold(pixels[pixel + 2], hitColorB) || CompareThreshold(pixels[pixel + 2], paintColor.b))
						//&& (CompareThreshold(pixels[pixel + 3], hitColorA) || CompareThreshold(pixels[pixel + 3], paintColor.a)))
						&& (!CompareThreshold(pixels[pixel + 3], 0)))
					{
						fillPointX.Enqueue(ptsx + 1);
						fillPointY.Enqueue(ptsy);
						lockMaskPixels[pixel] = 1;
					}
				}

				if (ptsx - 1 > -1)
				{
					pixel = (texWidth * ptsy + ptsx - 1) * 4; // left
					if (lockMaskPixels[pixel] == 0
						//&& (CompareThreshold(pixels[pixel + 0], hitColorR) || CompareThreshold(pixels[pixel + 0], paintColor.r)) // if pixel is same as hit color OR same as paint color
						//&& (CompareThreshold(pixels[pixel + 1], hitColorG) || CompareThreshold(pixels[pixel + 1], paintColor.g))
						//&& (CompareThreshold(pixels[pixel + 2], hitColorB) || CompareThreshold(pixels[pixel + 2], paintColor.b))
						//&& (CompareThreshold(pixels[pixel + 3], hitColorA) || CompareThreshold(pixels[pixel + 3], paintColor.a)))
						&& (!CompareThreshold(pixels[pixel + 3], 0)))
					{
						fillPointX.Enqueue(ptsx - 1);
						fillPointY.Enqueue(ptsy);
						lockMaskPixels[pixel] = 1;
					}
				}

				if (ptsy + 1 < texHeight)
				{
					pixel = (texWidth * (ptsy + 1) + ptsx) * 4; // up
					if (lockMaskPixels[pixel] == 0
						//&& (CompareThreshold(pixels[pixel + 0], hitColorR) || CompareThreshold(pixels[pixel + 0], paintColor.r)) // if pixel is same as hit color OR same as paint color
						//&& (CompareThreshold(pixels[pixel + 1], hitColorG) || CompareThreshold(pixels[pixel + 1], paintColor.g))
						//&& (CompareThreshold(pixels[pixel + 2], hitColorB) || CompareThreshold(pixels[pixel + 2], paintColor.b))
						//&& (CompareThreshold(pixels[pixel + 3], hitColorA) || CompareThreshold(pixels[pixel + 3], paintColor.a)))
						&& (!CompareThreshold(pixels[pixel + 3], 0)))
					{
						fillPointX.Enqueue(ptsx);
						fillPointY.Enqueue(ptsy + 1);
						lockMaskPixels[pixel] = 1;
					}

				}
			}
		} // LockMaskFillWithTreshold


		// get custom brush texture into custombrushpixels array, this needs to be called if custom brush is changed
		public void ReadCurrentCustomBrush()
		{
			// NOTE: this works only for square brushes
			customBrushWidth = customBrushes[selectedBrush].width;
			customBrushHeight = customBrushes[selectedBrush].height;
			customBrushBytes = new byte[customBrushWidth * customBrushHeight * 4];

			int pixel = 0;
			Color32[] brushPixel = customBrushes[selectedBrush].GetPixels32();
			for (int y = 0; y < customBrushHeight; y++)
			{
				for (int x = 0; x < customBrushWidth; x++)
				{
					customBrushBytes[pixel] = brushPixel[x+y*customBrushWidth].r;
					customBrushBytes[pixel + 1] = brushPixel[x + y * customBrushWidth].g;
					customBrushBytes[pixel + 2] = brushPixel[x + y * customBrushWidth].b;
					customBrushBytes[pixel + 3] = brushPixel[x + y * customBrushWidth].a;
					pixel += 4;
				}
			}

			// precalculate few brush size values
			customBrushWidthHalf = (int)(customBrushWidth * 0.5f);
			texWidthMinusCustomBrushWidth = texWidth - customBrushWidth;
			texHeightMinusCustomBrushHeight = texHeight - customBrushHeight;
		}

		// draws single point to this pixel array index, with current paint color
		public void DrawPoint(int pixel)
		{
			pixels[pixel] = paintColor.r;
			pixels[pixel + 1] = paintColor.g;
			pixels[pixel + 2] = paintColor.b;
			pixels[pixel + 3] = paintColor.a;
		}


		// draw line between 2 points (if moved too far/fast)
		// http://en.wikipedia.org/wiki/Bresenham%27s_line_algorithm
		public void DrawLine(int startX, int startY, int endX, int endY)
		{
			int x1 = endX;
			int y1 = endY;
			int tempVal = x1 - startX;
			int dx = (tempVal + (tempVal >> 31)) ^ (tempVal >> 31); // http://stackoverflow.com/questions/6114099/fast-integer-abs-function
			tempVal = y1 - startY;
			int dy = (tempVal + (tempVal >> 31)) ^ (tempVal >> 31);


			int sx = startX < x1 ? 1 : -1;
			int sy = startY < y1 ? 1 : -1;
			int err = dx - dy;
			int pixelCount = 0;
			int e2;
			for (;;) // endless loop
			{
				if (hiQualityBrush)
				{
					DrawCircle(startX, startY);
				}
				else {
					pixelCount++;
					if (pixelCount > brushSizeDiv4) // might have small gaps if this is used, but its alot(tm) faster to skip few pixels
					{
						pixelCount = 0;
						DrawCircle(startX, startY);
					}
				}

				if (startX == x1 && startY == y1) break;
				e2 = 2 * err;
				if (e2 > -dy)
				{
					err = err - dy;
					startX = startX + sx;
				}
				else if (e2 < dx)
				{
					err = err + dx;
					startY = startY + sy;
				}
			}
		} // drawline

		public void DrawLine(Vector2 start, Vector2 end)
		{
			DrawLine((int)start.x, (int)start.y, (int)end.x, (int)end.y);
		}


		void DrawLineWithBrush(Vector2 start, Vector2 end)
		{
			int x0 = (int)start.x;
			int y0 = (int)start.y;
			int x1 = (int)end.x;
			int y1 = (int)end.y;
			int tempVal = x1 - x0;
			int dx = (tempVal + (tempVal >> 31)) ^ (tempVal >> 31); // http://stackoverflow.com/questions/6114099/fast-integer-abs-function
			tempVal = y1 - y0;
			int dy = (tempVal + (tempVal >> 31)) ^ (tempVal >> 31);
			int sx = x0 < x1 ? 1 : -1;
			int sy = y0 < y1 ? 1 : -1;
			int err = dx - dy;
			int pixelCount = 0;
			int e2;
			for (;;)
			{
				if (hiQualityBrush)
				{
					DrawCustomBrush(x0, y0);
				}
				else {
					pixelCount++;
					if (pixelCount > brushSizeDiv4)
					{
						pixelCount = 0;
						DrawCustomBrush(x0, y0);
					}
				}
				if (x0 == x1 && y0 == y1) break;
				e2 = 2 * err;
				if (e2 > -dy)
				{
					err = err - dy;
					x0 = x0 + sx;
				}
				else if (e2 < dx)
				{
					err = err + dx;
					y0 = y0 + sy;
				}
			}
		}
			

		void EraseWithImageLine(Vector2 start, Vector2 end)
		{
			int x0 = (int)start.x;
			int y0 = (int)start.y;
			int x1 = (int)end.x;
			int y1 = (int)end.y;
			int tempVal = x1 - x0;
			int dx = (tempVal + (tempVal >> 31)) ^ (tempVal >> 31); // http://stackoverflow.com/questions/6114099/fast-integer-abs-function
			tempVal = y1 - y0;
			int dy = (tempVal + (tempVal >> 31)) ^ (tempVal >> 31);
			int sx = x0 < x1 ? 1 : -1;
			int sy = y0 < y1 ? 1 : -1;
			int err = dx - dy;
			int pixelCount = 0;
			int e2;
			for (;;)
			{
				if (hiQualityBrush)
				{
					EraseWithImage(x0, y0);
				}
				else {
					pixelCount++;
					if (pixelCount > brushSizeDiv4)
					{
						pixelCount = 0;
						EraseWithImage(x0, y0);
					}
				}

				if ((x0 == x1) && (y0 == y1)) break;
				e2 = 2 * err;
				if (e2 > -dy)
				{
					err = err - dy;
					x0 = x0 + sx;
				}
				else if (e2 < dx)
				{
					err = err + dx;
					y0 = y0 + sy;
				}
			}
		}

		// if this is called, undo buffer gets updated
		public void ClearImage()
		{
			ClearImage(true);
		}

		// this override can be called with bool, to disable undo buffer grab
		public void ClearImage(bool updateUndoBuffer)
		{
			if (usingClearingImage)
			{
				ClearImageWithImage();
			}
			else {

				int pixel = 0;
				for (int y = 0; y < texHeight; y++)
				{
					for (int x = 0; x < texWidth; x++)
					{
						pixels[pixel] = clearColor.r;
						pixels[pixel + 1] = clearColor.g;
						pixels[pixel + 2] = clearColor.b;
						pixels[pixel + 3] = clearColor.a;
						pixel += 4;
					}
				}

				UpdateTexture();
			}
		} // clear image


		public void ClearImageWithImage()
		{
			// fill pixels array with clearpixels array
			System.Array.Copy(clearPixels, 0, pixels, 0, clearPixels.Length);


			// just assign our clear image array into tex
			drawingTexture.LoadRawTextureData(clearPixels);
			drawingTexture.Apply(false);
		} // clear image
			

		// reads original drawing canvas texture, so than when Clear image is called, we can restore the original pixels
		public void ReadClearingImage()
		{
			clearPixels = new byte[texWidth * texHeight * 4];

			// get our current texture into tex, is this needed?, also targettexture might be different..?
			// FIXME: usually target texture is same as drawingTexture..?
			drawingTexture.SetPixels32(((Texture2D)myRenderer.material.GetTexture(targetTexture)).GetPixels32());
			drawingTexture.Apply(false);

			int pixel = 0;
			Color32[] tempPixels = drawingTexture.GetPixels32();
			int tempCount = tempPixels.Length;

			for (int i = 0; i < tempCount; i++)
			{
				clearPixels[pixel] = tempPixels[i].r;
				clearPixels[pixel + 1] = tempPixels[i].g;
				clearPixels[pixel + 2] = tempPixels[i].b;
				clearPixels[pixel + 3] = tempPixels[i].a;
				pixel += 4;
			}
		}

		public void SetBrushSize(int newSize)
		{
			brushSize = (int)Mathf.Clamp(newSize, 1, 999);

			brushSizeX1 = brushSize << 1;
			brushSizeXbrushSize = brushSize * brushSize;
			brushSizeX4 = brushSizeXbrushSize << 2;
			brushSizeDiv4 = hiQualityBrush ? 0 : brushSize >> 2;
		}

		public void SetDrawModeBrush()
		{
			drawMode = DrawMode.Default;
		}

		public void SetDrawModeFill()
		{
			drawMode = DrawMode.FloodFill;
		}

		public void SetDrawModeShapes()
		{
			drawMode = DrawMode.CustomBrush;
		}
				

		// returns current image (later: including all layers) as Texture2D
		public Texture2D GetCanvasAsTexture()
		{
			var image = new Texture2D((int)(texWidth / resolutionScaler), (int)(texHeight / resolutionScaler), TextureFormat.RGBA32, false);

			// TODO: combine layers to single texture
			image.LoadRawTextureData(pixels);
			image.Apply(false);
			return image;
		}

		// call this to change color, so that other objects get the new color also
		public void SetPaintColor(Color32 newColor)
		{
			paintColor = newColor;

			SetBrushAlphaStrength(brushAlphaStrength);
			alphaLerpVal = paintColor.a / brushAlphaStrengthVal; // precalc	
		}

		// set alpha power, good values are usually between 0.1 to 0.001
		public void SetBrushAlphaStrength(float val)
		{
			brushAlphaStrengthVal = 255f / val;
		}

		byte ByteLerp(byte value1, byte value2, float amount)
		{
			return (byte)(value1 + (value2 - value1) * amount);
		}

		// cleaning up buffers - https://github.com/unitycoder/UnityMobilePaint/issues/10
		void OnDestroy()
		{
			if (drawingTexture != null) Texture2D.DestroyImmediate(drawingTexture, true);
			pixels = null;
			maskPixels = null;
			clearPixels = null;
			lockMaskPixels = null;

			// System.GC.Collect();
		}


	} // class
} // namespace
