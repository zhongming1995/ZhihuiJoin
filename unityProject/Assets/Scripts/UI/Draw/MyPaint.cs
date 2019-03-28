using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum MyDrawMode
{
	Default,
	CustomBrush,
	Pattern,
	Eraser
}

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class MyPaint : MonoBehaviour {

	private Renderer myRenderer;
	private Camera cam; // main camera reference 主要相机参考
	public LayerMask paintLayerMask = 1 << 0; // to which layer our paint canvas is at (used in raycast) 我们的油漆画布(在raycast中使用)到哪一层  表示开启Layer0 0*2^1。
	private RaycastHit hit;//用于存储射线碰撞到的第一个对象信息
	private bool wentOutside = false;//true 没没碰撞到 false 碰撞到了

	private int brushSize = 24; // default brush size 默认的画笔大小
	private int brushSizeMin = 1; // default min brush size 默认最小画笔大小
	private int brushSizeMax = 64; // default max brush size 默认最大画笔大小

	//	*** Default settings ***
	public Color32 paintColor = new Color32(249, 47, 42, 255);

	[Header("Brush Settings")]
	public bool connectBrushStokes = true; // if brush moves too fast, then connect them with line. NOTE! Disable this if you are painting to custom mesh 如果刷移动太快，则将其与线连接。注意!如果你是自定义网格，禁用这个

	// cached calculations 缓存的计算
	public bool hiQualityBrush = false; // Draw more brush strokes when moving NOTE: this is slow on mobiles!  在移动提示时画更多的笔画:这在手机上是很慢的!
	private int brushSizeX1 = 48; // << 1
	private int brushSizeXbrushSize = 576; // x*x
	private int brushSizeX4 = 96; // << 2
	private int brushSizeDiv4 = 6; // >> 2 == /4

	private int texWidth;
	private int texHeight;

	public Vector2 canvasSizeAdjust = new Vector2(0, 0); // this means, "ScreenResolution.xy+screenSizeAdjust.xy" (use only minus values, to add un-drawable border on right or bottom)
	public string targetTexture = "_MainTex"; // target texture for this material shader (usually _MainTex) 这个材质着色器的目标纹理(通常是_MainTex) 用来作为画画区域的纹理
	public string drawTexture = "_DrawTex"; // 画画的纹理
	public FilterMode filterMode = FilterMode.Point; // 当该纹理由于3D变换进行拉伸时，它将如何被过滤插值。共有三种选择：Point 单点插值，纹理将变得块状化（blocky up close）；Bilinear 双线性插值，纹理将变得模糊（blurry up close）；Trilinear 三线性插值，类似Bilinear，但是纹理还会在不同的mip水平之间（between the different mip levels）进行模糊；


	private bool usingClearingImage = false; // did we have initial texture as maintexture, then use it as clear pixels array 我们是否有初始纹理作为主要纹理，然后使用它作为清除的像素数组

	private Texture2D drawingTexture; // texture that we paint into (it gets updated from pixels[] array when painted) 我们绘制的纹理(它在绘制时从像素[]数组中得到更新)

	// canvas clear color
	public Color32 clearColor = new Color32(255, 255, 255, 255);


	[Header("Options")]
	public MyDrawMode drawMode = MyDrawMode.Default; // drawing modes: 0 = Default, 1 = custom brush, 2 = eraser
	public bool useLockArea = false; // locking mask: only paint in area of the color that your click first 锁定掩码:只在你点击的颜色区域内绘制
	public byte paintThreshold = 128; // 0 = only exact match, 255 = match anything  0 =精确匹配，255 =匹配任何东西

	private bool getMaskAreaEnabled=true;

	// AREA FILL CALCULATIONS
	[Space(10)]
	public bool getAreaSize = true; // NOTE: to use this, someone has to listen the event AreaWasPainted (see scene "scene_MobilePaint_LockingMaskWithAreaCalculation")  使用这个,监听事件AreaWasPainted
	int initialX = 0;
	int initialY = 0;

	//private bool lockMaskCreated=false; //is lockmask already created for this click, not used yet 已经为这个点击创建了lockmask，现在还没有使用
	private byte[] lockMaskPixels; // locking mask pixels 锁定遮罩像素


	//	*** private variables, no need to touch ***
	public byte[] pixels; // byte array for texture painting, this is the image that we paint into. 纹理绘画的字节数组，这是我们绘制的图像。
	private byte[] maskPixels; // byte array for mask texture 掩码纹理的字节数组
	private byte[] clearPixels; // byte array for clearing texture 清除纹理的字节数组

	private Vector2 pixelUV; // with mouse
	private Vector2 pixelUVOld; // with mouse


	[Header("Custom Brushes")]
	public bool useCustomBrushes = false;
	public Texture2D[] customBrushes;
	public bool overrideCustomBrushColor = false; // uses paint color instead of brush texture color 使用油漆颜色代替画笔纹理颜色
	public bool useCustomBrushAlpha = true; // true = use alpha from brush, false = use alpha from current paint color 从画笔中使用alpha，从当前的颜色中使用alpha
	public int selectedBrush = 0; // currently selected brush index

	//private Color[] customBrushPixels;
	private byte[] customBrushBytes;
	private int customBrushWidth;
	private int customBrushHeight;
	private int customBrushWidthHalf;
	//		private int customBrushHeightHalf;
	private int texWidthMinusCustomBrushWidth;
	private int texHeightMinusCustomBrushHeight;

	[Header("Custom Patterns")]
	public bool useCustomPatterns = false;
	public Texture2D[] customPatterns;
	private byte[] patternBrushBytes;
	private int customPatternWidth;
	private int customPatternHeight;
	public int selectedPattern = 0;

	public bool useAdditiveColors = false; // true = alpha adds up slowly, false = 1 click will instantly set alpha to brush or paint color alpha value

	public float brushAlphaStrength = 0.01f; // multiplier to soften brush additive alpha, 0.1f is nice & smooth, 1 = faster
	private float brushAlphaStrengthVal = 0.01f; // cached calculation
	private float alphaLerpVal = 0.1f;
	private float brushAlphaLerpVal = 0.4f;

	[HideInInspector]
	public bool textureNeedsUpdate = false; // if we have modified texture 如果我们修改了纹理

	public bool realTimeTexUpdate = true; // if set to true, ignore textureUpdateSpeed, and always update when textureNeedsUpdate gets set to true when drawing 如果设置为true，忽略textureUpdateSpeed，并且在绘制时总是更新当textureNeedsUpdate被设置为true时
	public float textureUpdateSpeed = 0.1f; // how often texture should be updated (0 = no delay, 1 = every one seconds) 多久更新一次纹理(0 =不延迟，1 =每1秒)
	private float nextTextureUpdate = 0;


	private float resolutionScaler=1.0f;
	public int overrideWidth = 2208;
	public int overrideHeight = 1242;

	public float paintPercentage=0f;


	private Texture2D theTexture;
	void Awake(){
		cam = Camera.main;
		myRenderer = GetComponent<Renderer>();

		//InitAll ();
	}

	// Use this for initialization
	public void InitAll (int _brushSize,Texture2D _textrue) {
		if (Screen.width*1.0f / Screen.height > overrideWidth* 1.0f  / overrideHeight) {
			resolutionScaler = Screen.height * 1.0f / overrideHeight;
		} else {
			resolutionScaler = Screen.width * 1.0f / overrideWidth;
		}
//			
//		Debug.Log (resolutionScaler);
//		transform.localScale *= resolutionScaler;


		brushSize = (int)Mathf.Clamp(_brushSize, 1, 999);
		//brushSize = _brushSize;
		// cached calculations
		brushSizeX1 = brushSize << 1;
		brushSizeXbrushSize = brushSize * brushSize;
		brushSizeX4 = brushSizeXbrushSize << 2;

		brushSizeDiv4 = hiQualityBrush ? 0 : brushSize >> 2;
		//brushAlphaStrengthVal = 255f*brushAlphaStrength;

//		SetPaintColor(_color);

		theTexture = _textrue;

		// set texture
		myRenderer.material.mainTexture=_textrue;

		//CreateQuad ();

		transform.GetComponent<SpriteRenderer> ().sprite = Sprite.Create(_textrue, new Rect(0, 0, _textrue.width, _textrue.height),new Vector2(0.5f,0.5f));

		CreateCollider ();

		//创建纹理大小
//		texWidth = (int)((cam.pixelWidth-800) * resolutionScaler + canvasSizeAdjust.x);
//		texHeight = (int)((cam.pixelHeight-800) * resolutionScaler + canvasSizeAdjust.y);

		if (myRenderer.material.GetTexture(targetTexture) != null)
		{
			texWidth = myRenderer.material.GetTexture (targetTexture).width;
			texHeight = myRenderer.material.GetTexture (targetTexture).height;

		}
		else { // use screen size as texture size
			texWidth = (int)(Screen.width + canvasSizeAdjust.x);
			texHeight = (int)(Screen.height + canvasSizeAdjust.y);
		}

		//Graphics.Blit (,);


//		if (myRenderer.material.GetTexture(drawTexture) == null&&!usingClearingImage)
//		{
//			// create new texture 创建新的纹理
//			if (drawingTexture != null) Texture2D.DestroyImmediate(drawingTexture, true); // cleanup old texture  清理旧的纹理
//			drawingTexture = new Texture2D(texWidth, texHeight, TextureFormat.RGBA32, false); //创建一个新的纹理
//			myRenderer.material.SetTexture(targetTexture, drawingTexture);//设置纹理
//
//			// init pixels array 初始化纹理绘画的字节数组
//			pixels = new byte[texWidth * texHeight * 4];
//
//		}else { // we have canvas texture, then use that as clearing texture 我们有canvas纹理，然后使用它作为清理纹理
//			usingClearingImage = true;
//
//			if (overrideResolution) Debug.LogWarning("overrideResolution is not used, when canvas texture is assiged to material, we need to use the texture size");
//
//			texWidth = myRenderer.material.GetTexture(targetTexture).width;
//			texHeight = myRenderer.material.GetTexture(targetTexture).height;
//
//			// init pixels array
//			pixels = new byte[texWidth * texHeight * 4];
//
//			if (drawingTexture != null) Texture2D.DestroyImmediate(drawingTexture, true); // cleanup old texture
//			drawingTexture = new Texture2D(texWidth, texHeight, TextureFormat.RGBA32, false);
//
//			// we keep current maintex and read it as "clear pixels array" (so when "clear image" is clicked, original texture is restored 我们保留当前的maintex，并将其读取为“清除像素数组”(因此当“清除图片”被点击时，原始的纹理就被恢复了
//			ReadClearingImage();
//			myRenderer.material.SetTexture(drawTexture, drawingTexture);
//		}

		// init pixels array
		pixels = new byte[texWidth * texHeight * 4];
		maskPixels=new byte[texWidth*texHeight*4];

		if (drawingTexture != null) Texture2D.DestroyImmediate(drawingTexture, true); // cleanup old texture
		drawingTexture = new Texture2D(texWidth, texHeight, TextureFormat.RGBA32, false);

		//ClearImage(updateUndoBuffer: false);

		ReadMaskImage();//获取可画画区域
		myRenderer.material.SetTexture(drawTexture, drawingTexture);

		// set texture modes 设置纹理模式
		drawingTexture.filterMode = filterMode;
		drawingTexture.wrapMode = TextureWrapMode.Clamp;  //将纹理夹到边缘的最后一个像素。


		// locking mask enabled 启用锁定遮罩
		if (useLockArea)
		{
			lockMaskPixels = new byte[texWidth * texHeight * 4];
		}

		if (customPatterns != null && customPatterns.Length > 0) ReadCurrentCustomPattern();

		// init custom brush if used 如果使用，初始化自定义画笔
		if (useCustomBrushes && drawMode == MyDrawMode.CustomBrush) ReadCurrentCustomBrush();

		ClearImage(updateUndoBuffer: false);

//		var referenceTexture = myRenderer.material.GetTexture (targetTexture);
//		CreateAreaLockMask (referenceTexture.width / 2, referenceTexture.height / 2);
	}

	// call this to change color, so that other objects get the new color also 调用这个来改变颜色，这样其他的对象也能得到新的颜色
	public void SetPaintColor(Color32 newColor)
	{
		paintColor = newColor;
	}

	void CreateCollider(){
		// add mesh collider
		//var mesh_GO=transform.FindChild("PaintMesh").gameObject;
		if (gameObject.GetComponent<PolygonCollider2D>() == null) gameObject.AddComponent<PolygonCollider2D>();
	}

	//创建四边形
	void CreateQuad()
	{
		// create mesh plane, fits in camera view (with screensize adjust taken into consideration)  创建网格平面，适合于相机视图(考虑屏幕尺寸调整)
		Mesh go_Mesh = GetComponent<MeshFilter>().mesh;
		go_Mesh.Clear();
		Vector3[] referenceCorners = new Vector3[4];

		// just use full screen quad for main camera 使用全屏显示主摄像头

		if (myRenderer.material.GetTexture(targetTexture) != null)
		{
			var referenceTexture = myRenderer.material.GetTexture (targetTexture);
			var screenPoint = Camera.main.WorldToScreenPoint (transform.position);
			var localPoint = transform.position * 100f*resolutionScaler;
			Debug.Log (transform.position);
			Debug.Log (localPoint);

			referenceCorners[0] = new Vector3(screenPoint.x-referenceTexture.width/2-localPoint.x, screenPoint.y-referenceTexture.height/2-localPoint.y, cam.nearClipPlane); // bottom left
			referenceCorners[1] = new Vector3(screenPoint.x-referenceTexture.width/2-localPoint.x, screenPoint.y+referenceTexture.height/2-localPoint.y, cam.nearClipPlane); // top left
			referenceCorners[2] = new Vector3(screenPoint.x+referenceTexture.width/2-localPoint.x, screenPoint.y+referenceTexture.height/2-localPoint.y, cam.nearClipPlane); // top right
			referenceCorners[3] = new Vector3(screenPoint.x+referenceTexture.width/2-localPoint.x, screenPoint.y-referenceTexture.height/2-localPoint.y, cam.nearClipPlane); // bottom right

		}
		else { // use screen size as texture size
			referenceCorners[0] = new Vector3(0, canvasSizeAdjust.y, cam.nearClipPlane); // bottom left
			referenceCorners[1] = new Vector3(0, cam.pixelHeight + canvasSizeAdjust.y, cam.nearClipPlane); // top left
			referenceCorners[2] = new Vector3(cam.pixelWidth + canvasSizeAdjust.x, cam.pixelHeight + canvasSizeAdjust.y, cam.nearClipPlane); // top right
			referenceCorners[3] = new Vector3(cam.pixelWidth + canvasSizeAdjust.x, canvasSizeAdjust.y, cam.nearClipPlane); // bottom right

		}


		// move to screen 移动到屏幕
		float nearClipOffset = 0.01f; // otherwise raycast wont hit, if exactly at nearclip z 否则raycast不会被击中，如果恰好在附近的z


		for (int i = 0; i < referenceCorners.Length; i++)
		{
			referenceCorners[i].z = -cam.transform.position.z + nearClipOffset;
			referenceCorners[i] = cam.ScreenToWorldPoint(referenceCorners[i]);//屏幕坐标转世界坐标
		}


		go_Mesh.vertices = referenceCorners;

		go_Mesh.uv = new[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0) }; //赋予mesh自己的UV数组 物体网格对应贴图的UV坐标
		go_Mesh.triangles = new[] { 0, 1, 2, 0, 2, 3 }; //必须是三的倍数 创建三角形 新建三角形数组，在mesh中解读方式为三个一组，代表三角形三点 其中0,1,2......代表该mesh的点（vertices）数组的下标序号


		//重新计算网格和数组，但一般来说RecalculateBounds();方法应该放在 mesh.RecalculateNormals();之后
		go_Mesh.RecalculateNormals();
		go_Mesh.RecalculateBounds();

		go_Mesh.tangents = new[] { new Vector4(1.0f, 0.0f, 0.0f, -1.0f), new Vector4(1.0f, 0.0f, 0.0f, -1.0f), new Vector4(1.0f, 0.0f, 0.0f, -1.0f), new Vector4(1.0f, 0.0f, 0.0f, -1.0f) };



		// add mesh collider
		if (gameObject.GetComponent<MeshCollider>() == null) gameObject.AddComponent<MeshCollider>();
	}
	// this override can be called with bool, to disable undo buffer grab  这个覆盖可以用bool来调用，以禁用撤销缓冲区的抓取
	public void ClearImage(bool updateUndoBuffer)
	{

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
	} // clear image

	// reads original drawing canvas texture, so than when Clear image is called, we can restore the original pixels 读取原始绘制的画布纹理，所以当我们调用清晰的图像时，我们可以恢复原始的像素
	public void ReadMaskImage()
	{
		clearPixels = new byte[texWidth * texHeight * 4];

		//Debug.Log(myRenderer.material.HasProperty(targetTexture));
		//Debug.Log(myRenderer.material.GetTexture(targetTexture));

		// get our current texture into tex, is this needed?, also targettexture might be different..?  把我们当前的纹理输入到tex，这需要吗?另外，targettexture也可能不同。
		// FIXME: usually target texture is same as drawingTexture..?  通常目标纹理与绘制纹理相同。?
//		drawingTexture.SetPixels32(((Texture2D)myRenderer.material.GetTexture(targetTexture)).GetPixels32());
//		drawingTexture.Apply(false);

		int pixel = 0;
		Color32[] tempPixels = ((Texture2D)myRenderer.material.GetTexture (targetTexture)).GetPixels32 ();//获取mask纹理
		int tempCount = tempPixels.Length;

		for (int i = 0; i < tempCount; i++)
		{
			maskPixels[pixel] = tempPixels[i].r;
			maskPixels[pixel + 1] = tempPixels[i].g;
			maskPixels[pixel + 2] = tempPixels[i].b;
			maskPixels[pixel + 3] = tempPixels[i].a;
			pixel += 4;
		}
	}

	// get custom brush texture into custombrushpixels array, this needs to be called if custom brush is changed  将自定义的画笔纹理转换为custombrush像素数组，如果修改了自定义画笔，则需要调用此纹理
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

		// precalculate few brush size values 预计算很少的画笔大小值
		customBrushWidthHalf = (int)(customBrushWidth * 0.5f);
		texWidthMinusCustomBrushWidth = texWidth - customBrushWidth;
		texHeightMinusCustomBrushHeight = texHeight - customBrushHeight;
	}
	
	// Update is called once per frame
	void Update () {
		//MousePaint();
//		if (Input.GetMouseButtonUp (0)) {//在鼠标左键抬起的时候 计算绘画面积
//			Debug.Log("-------ButtonUp");
//			// calculate area size
//			if (getAreaSize && useLockArea)
//			{
//				LockAreaFillWithThresholdMaskOnlyGetArea(initialX, initialY, true);//计算填充区域占绘画区域的百分比
//			}
//		}

		if (textureNeedsUpdate && (realTimeTexUpdate || Time.time > nextTextureUpdate))
		{
			nextTextureUpdate = Time.time + textureUpdateSpeed;
			UpdateTexture();
		}
	}
	public void MousePaint(){

		// left button is held down, draw 左键按住，绘制
		if (Input.GetMouseButton(0))
		{
			// Only if we hit something, then we continue 只有击中了某物，我们才能继续
			//if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, paintLayerMask)) { wentOutside = true; return; }
//			//创建一个射线，该射线从主摄像机中发出，而发出点是鼠标
//			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
//			//创建一个射线信息集
//
//			if (hit.collider != null) {
//				Debug.Log (hit.collider.name);
//			}else {
//				Debug.Log ("没有检测到碰撞物体");
//				wentOutside = true; return;
//			}

			var textureCoord = TextureCoord (Input.mousePosition);
			// if lock area is used, we need to take full area before painting starts  如果使用锁区，我们需要在油漆开始前将其全部带出
			if (useLockArea)
			{
				if (getMaskAreaEnabled) {
					Debug.Log ("--------设置可绘制区域");
					CreateAreaLockMask((int)(textureCoord.x * texWidth), (int)(textureCoord.y * texHeight));
					//CreateAreaLockMask((int)(hit.textureCoord.x * texWidth), (int)(hit.textureCoord.y * texHeight));
				}

			}

			Debug.Log ("---------------TextureCoord:" + textureCoord);

			pixelUVOld = pixelUV; // take previous value, so can compare them 取之前的值，可以比较它们
			pixelUV = textureCoord;
			pixelUV.x *= texWidth;
			pixelUV.y *= texHeight;

			//if (wentOutside) { pixelUVOld = pixelUV; wentOutside = false; }
			//在出画画区域的时候 

			// lets paint where we hit
			switch (drawMode)
			{
				case MyDrawMode.Default: // brush
					DrawCircle((int)pixelUV.x, (int)pixelUV.y);
					break;

				case MyDrawMode.Pattern:
					DrawPatternCircle((int)pixelUV.x, (int)pixelUV.y);
					break;

				case MyDrawMode.CustomBrush:
					DrawCustomBrush((int)pixelUV.x, (int)pixelUV.y);
					break;

				case MyDrawMode.Eraser:
					EraseWithImage ((int)pixelUV.x, (int)pixelUV.y);
					break;
				default: // unknown DrawMode
					Debug.LogError("Unknown drawMode");
					break;
			}

			textureNeedsUpdate = true; //纹理需要更新
		}

		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("-------ButtonDown");
			// take this position as start position 把这个位置当作起始位置
			//if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, paintLayerMask)) return;
			//创建一个射线，该射线从主摄像机中发出，而发出点是鼠标
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			//创建一个射线信息集

			if (hit.collider != null) {
				Debug.Log (hit.collider.name);
			}else {
				Debug.Log ("没有检测到碰撞物体");
				wentOutside = true; return;
			}

			pixelUVOld = pixelUV;
		}

		// left mouse button released
		if (connectBrushStokes && textureNeedsUpdate)
		{
			switch (drawMode)
			{
			case MyDrawMode.Default: // drawing
				DrawLine(pixelUVOld, pixelUV);
				break;

			case MyDrawMode.Pattern:
				DrawLineWithPattern (pixelUVOld, pixelUV);
				break;

			case MyDrawMode.CustomBrush:
				DrawLineWithBrush(pixelUVOld, pixelUV);
				break;

			case MyDrawMode.Eraser:
				EraseWithImageLine(pixelUVOld, pixelUV);
				break;

			default: // other modes
				break;
			}
			pixelUVOld = pixelUV;
			textureNeedsUpdate = true;
		}


	}

	Vector2 TextureCoord(Vector3 mousePosition){

		var screenPoint = Camera.main.WorldToScreenPoint (transform.position);

		Debug.Log("transform.position-----------"+transform.position);

		Debug.Log("screenPoint-----------"+screenPoint);

		Debug.Log("mousePosition-----------"+mousePosition);

		Debug.Log("theTexture.width-----------"+theTexture.width*resolutionScaler);

		var msP = mousePosition - screenPoint;//手指和图片的距离

		var texSizeX = theTexture.width*resolutionScaler;//宽度

		var texSizeY = theTexture.height*resolutionScaler;//高度。

		var xiangsuPX = msP.x+ texSizeX / 2;
		var xiangsuPY =  msP.y+texSizeY / 2;

		Vector2 v = new Vector2 (xiangsuPX / texSizeX, xiangsuPY / texSizeY);

		return v;
	}

	void UpdateTexture()
	{
		textureNeedsUpdate = false;
		drawingTexture.LoadRawTextureData(pixels);//通过读取文件数据来加载纹理数据
		drawingTexture.Apply(false);
	}

	void CreateAreaLockMask(int x, int y)
	{
		Debug.Log ("---------------------------"+x);
		Debug.Log ("---------------------------"+y);
		initialX = x;
		initialY = y;

		LockAreaFillWithThresholdMaskOnlyGetArea(x, y, false);
	}

	// create locking mask floodfill, using threshold  使用阈值创建锁定掩膜

	void LockAreaFillWithThresholdMaskOnlyGetArea(int x, int y, bool getArea)
	{
		// temporary fix for IOS notification center pulldown crash
		if (x >= texWidth) x = texWidth - 1;
		if (y >= texHeight) y = texHeight - 1;

		int fullArea = 0;
		int alreadyFilled = 0;

		// get canvas color from this point
		byte hitColorR = maskPixels[(texWidth * y + x) * 4 + 0];
		byte hitColorG = maskPixels[(texWidth * y + x) * 4 + 1];
		byte hitColorB = maskPixels[(texWidth * y + x) * 4 + 2];
		byte hitColorA = maskPixels[(texWidth * y + x) * 4 + 3];

		if (hitColorA == 0) return;//透明区域不能画

		getMaskAreaEnabled = false;//创建绘制区域只需要一次，不然会造成卡顿

		// early exit if outside threshold  如果超出阈值，尽早退出
		//if (CompareThreshold(paintColor.r,hitColorR) && CompareThreshold(paintColor.g,hitColorG) && CompareThreshold(paintColor.b,hitColorB) && CompareThreshold(paintColor.b,hitColorA)) return;
		//if (paintColor.r == hitColorR && paintColor.g == hitColorG && paintColor.b == hitColorB && paintColor.a == hitColorA) return;

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
					&& maskPixels[pixel + 3]!=0)
				{
					fillPointX.Enqueue(ptsx);
					fillPointY.Enqueue(ptsy - 1);
					lockMaskPixels[pixel] = 1;
					fullArea++;

//					if (IsSameColor(paintColor, pixels[pixel + 0], pixels[pixel + 1], pixels[pixel + 2]))
//					{
//						alreadyFilled++;
//					}
					if(pixels[pixel + 3]!=0){
						alreadyFilled++;
					}

				}
			}

			if (ptsx + 1 < texWidth)
			{
				pixel = (texWidth * ptsy + ptsx + 1) * 4; // right
				if (lockMaskPixels[pixel] == 0
					&& maskPixels[pixel + 3]!=0)
				{
					fillPointX.Enqueue(ptsx + 1);
					fillPointY.Enqueue(ptsy);
					lockMaskPixels[pixel] = 1;
					fullArea++;
//					if (IsSameColor(paintColor, pixels[pixel + 0], pixels[pixel + 1], pixels[pixel + 2]))
//					{
//						alreadyFilled++;
//					}

					if(pixels[pixel + 3]!=0){
						alreadyFilled++;
					}

				}
			}

			if (ptsx - 1 > -1)
			{
				pixel = (texWidth * ptsy + ptsx - 1) * 4; // left
				if (lockMaskPixels[pixel] == 0
					&& maskPixels[pixel + 3]!=0)
				{
					fillPointX.Enqueue(ptsx - 1);
					fillPointY.Enqueue(ptsy);
					lockMaskPixels[pixel] = 1;
					fullArea++;
//					if (IsSameColor(paintColor, pixels[pixel + 0], pixels[pixel + 1], pixels[pixel + 2]))
//					{
//						alreadyFilled++;
//					}
					if(pixels[pixel + 3]!=0){
						alreadyFilled++;
					}
				}
			}

			if (ptsy + 1 < texHeight)
			{
				pixel = (texWidth * (ptsy + 1) + ptsx) * 4; // up
				if (lockMaskPixels[pixel] == 0
					&& maskPixels[pixel + 3]!=0)
				{
					fillPointX.Enqueue(ptsx);
					fillPointY.Enqueue(ptsy + 1);
					lockMaskPixels[pixel] = 1;
					fullArea++;
//					if (IsSameColor(paintColor, pixels[pixel + 0], pixels[pixel + 1], pixels[pixel + 2]))
//					{
//						alreadyFilled++;
//					}
					if(pixels[pixel + 3]!=0){
						alreadyFilled++;
					}
				}
			}
		} // while

		if (getArea)
		{
			//if (AreaPaintedEvent != null) AreaPaintedEvent(fullArea, alreadyFilled, alreadyFilled / (float)fullArea * 100f, PixelToWorld(x, y));
			if (fullArea != 0) {
				paintPercentage = alreadyFilled / (float)fullArea * 100f;
				//Debug.Log ("fullArea:" + fullArea + " | filledArea:" + alreadyFilled + " | percentageFilled:" + paintPercentage);

			} else {
				paintPercentage = 0;
			}
		}

	} // void

	// compares if two values are below threshold
	bool CompareThreshold(byte a, byte b)
	{
		//return Mathf.Abs(b-b)<=threshold;
		if (a < b) { a ^= b; b ^= a; a ^= b; } // http://lab.polygonal.de/?p=81
		return (a - b) <= paintThreshold;
	}


	bool IsSameColor(Color32 a, byte r, byte g, byte b)
	{
		//Debug.Log(b+" : "+r+","+g+","+b);
		return (a.r == r && a.g == g && a.b == b);
	}

	// converts pixel coordinate to world position 将像素坐标转换为世界位置
	public Vector3 PixelToWorld(int x, int y)
	{
		Vector3 pixelPos = new Vector3(x, y, 0); // x,y = texture pixel pos

		float planeWidth = myRenderer.bounds.size.x;
		float planeHeight = myRenderer.bounds.size.y;

		float localX = ((pixelPos.x / texWidth) - 0.5f) * planeWidth;
		float localY = ((pixelPos.y / texHeight) - 0.5f) * planeHeight;

		//			return transform.TransformPoint(new Vector3(localX,localY, 0));
		return new Vector3(localX, localY, 0);
	}

	// main painting function, modified from http://stackoverflow.com/b/24453110  主要绘画功能
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

			 // no additive, just paint my color
				if (!useLockArea || (useLockArea && lockMaskPixels[pixel] == 1))
				{
					pixels[pixel] = paintColor.r;
					pixels[pixel + 1] = paintColor.g;
					pixels[pixel + 2] = paintColor.b;
					pixels[pixel + 3] = paintColor.a;
				}
		} // for area
	} // DrawCircle()

	// draw line between 2 points (if moved too far/fast) 在两点之间画线(如果移动太远/太快)
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


	// actual custom brush painting function 实际自定义刷涂功能
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

		// could use this for speed (but then its box shaped..)  可以用它来加速(但它的盒子形状…)
		//System.Array.Copy(splatPixByte,0,data,4*(startY*startX),splatPixByte.Length);	

		int pixel = (texWidth * startY + startX) << 2;
		int brushPixel = 0;

		//
		for (int y = 0; y < customBrushHeight; y++)
		{
			for (int x = 0; x < customBrushWidth; x++)
			{
				brushPixel = (customBrushWidth * (y) + x) << 2;

				// we have some color at this brush pixel? 我们有一些颜色在这个画笔像素?
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
//								pixels [pixel] = paintColor.r;
//								pixels [pixel + 1] = paintColor.g;
//								pixels [pixel + 2] = paintColor.b;
								pixels[pixel] = ByteLerp(pixels[pixel], paintColor.r, brushAlphaLerpVal);
								pixels[pixel + 1] = ByteLerp(pixels[pixel + 1], paintColor.g, brushAlphaLerpVal);
								pixels[pixel + 2] = ByteLerp(pixels[pixel + 2], paintColor.b, brushAlphaLerpVal);

							}
							else { // use paint color instead of brush texture
								pixels[pixel] = customBrushBytes[brushPixel];
								pixels[pixel + 1] = customBrushBytes[brushPixel + 1];
								pixels[pixel + 2] = customBrushBytes[brushPixel + 2];
							}
							//pixels[pixel + 3] = customBrushBytes[brushPixel + 3];
							if (pixels [pixel + 3] < customBrushBytes [brushPixel + 3]) {
								pixels [pixel + 3] = ByteLerp (pixels [pixel + 3], customBrushBytes [brushPixel + 3], brushAlphaLerpVal);
							} else {
								pixels [pixel + 3] = (byte)(customBrushBytes [brushPixel + 3] + pixels [pixel + 3]-customBrushBytes [brushPixel + 3] * pixels [pixel + 3]);
							}
							//pixels[pixel + 3] = ByteLerp(pixels[pixel + 3], customBrushBytes[brushPixel + 3], brushAlphaLerpVal);
							//pixels[pixel + 3] = ByteLerp(pixels[pixel + 3],customBrushBytes[brushPixel+3], customBrushBytes[brushPixel+3]*1f/255);
							//pixels[pixel + 3] = (byte)((1 - (1 - customBrushBytes[brushPixel+3]/255) * ( 1 - pixels[pixel + 3]/255))*255);
							//pixels[pixel + 3] =(byte)(pixels[pixel + 3]+ customBrushBytes[brushPixel + 3]*(1-pixels[pixel + 3]/255));
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
//								pixels [pixel] = paintColor.r;
//								pixels [pixel + 1] = paintColor.g;
//								pixels [pixel + 2] = paintColor.b;
								pixels[pixel] = ByteLerp(pixels[pixel], paintColor.r, brushAlphaLerpVal);
								pixels[pixel + 1] = ByteLerp(pixels[pixel + 1], paintColor.g, brushAlphaLerpVal);
								pixels[pixel + 2] = ByteLerp(pixels[pixel + 2], paintColor.b, brushAlphaLerpVal);
							}
							else {
								pixels[pixel] = customBrushBytes[brushPixel];
								pixels[pixel + 1] = customBrushBytes[brushPixel + 1];
								pixels[pixel + 2] = customBrushBytes[brushPixel + 2];
							}
							pixels[pixel + 3] = ByteLerp(pixels[pixel + 3], paintColor.a, brushAlphaLerpVal);
						}
					}
				}
				pixel += 4;

			} // for x

			pixel = (texWidth * (startY == 0 ? 1 : startY + y) + startX + 1) * 4;
		} // for y
	} // DrawCustomBrush


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

	public void DrawPatternCircle(int x, int y)
	{
//		// clamp brush inside texture
//		if (createCanvasMesh) // TEMPORARY FIX: with b custom sphere mesh, small gap in paint at the end, so must disable clamp on most custom meshes
//		{
//			//x = PaintTools.ClampBrushInt(x,brushSize,texWidth-brushSize);
//			//y = PaintTools.ClampBrushInt(y,brushSize,texHeight-brushSize);
//		}
//
//		if (!canDrawOnBlack)
//		{
//			//				if (pixels[(texWidth*y+x)*4]==0 && pixels[(texWidth*y+x)*4+1]==0 && pixels[(texWidth*y+x)*4+2]==0 && pixels[(texWidth*y+x)*4+3]!=0) return;
//		}

		int pixel = 0;
		for (int i = 0; i < brushSizeX4; i++)
		{
			int tx = (i % brushSizeX1) - brushSize;
			int ty = (i / brushSizeX1) - brushSize;

			if (tx * tx + ty * ty > brushSizeXbrushSize) continue;
			if (x + tx < 0 || y + ty < 0 || x + tx >= texWidth || y + ty >= texHeight) continue; // temporary fix for corner painting

			pixel = (texWidth * (y + ty) + x + tx) << 2;

			//if (useAdditiveColors)
			//{
			// additive over white also
			//if (!useLockArea || (useLockArea && lockMaskPixels[pixel]==1))
			//{

			// TODO: take pattern texture as paint color
			/*
                Color32 patternColor = new Color(x,y,0,1);

                pixels[pixel] = (byte)Mathf.Lerp(pixels[pixel],patternColor.r,patternColor.b/255f*brushAlphaStrength);
                pixels[pixel+1] = (byte)Mathf.Lerp(pixels[pixel+1],patternColor.g,patternColor.b/255f*brushAlphaStrength);
                pixels[pixel+2] = (byte)Mathf.Lerp(pixels[pixel+2],patternColor.b,patternColor.b/255f*brushAlphaStrength);
                pixels[pixel+3] = (byte)Mathf.Lerp(pixels[pixel+3],patternColor.b,patternColor.b/255*brushAlphaStrength);
                */
			//}

			//}else{ // no additive, just paint my colors

			if (!useLockArea || (useLockArea && lockMaskPixels[pixel] == 1))
			{
				float yy = Mathf.Repeat(y + ty, customPatternWidth);
				float xx = Mathf.Repeat(x + tx,customPatternWidth);
				int pixel2 = (int)Mathf.Repeat((customPatternWidth * xx + yy) * 4, patternBrushBytes.Length);


				pixels[pixel] = patternBrushBytes[pixel2];
				pixels[pixel + 1] = patternBrushBytes[pixel2 + 1];
				pixels[pixel + 2] = patternBrushBytes[pixel2 + 2];
				pixels[pixel + 3] = patternBrushBytes[pixel2 + 3];
			}


			//} // if additive
		} // for area
	} // DrawPatternCircle()



	void DrawLineWithPattern(Vector2 start, Vector2 end)
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
				DrawPatternCircle(x0, y0);
			}
			else {
				pixelCount++;
				if (pixelCount > brushSizeDiv4)
				{
					pixelCount = 0;
					DrawPatternCircle(x0, y0);
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

	// reads current texture pattern into pixel array, NOTE: only works with square textures
	public void ReadCurrentCustomPattern()
	{
		if (customPatterns == null || customPatterns.Length == 0 || customPatterns[selectedPattern] == null) { Debug.LogError("Problem: No custom patterns assigned on " + gameObject.name); return; }

		customPatternWidth = customPatterns[selectedPattern].width;
		customPatternHeight = customPatterns[selectedPattern].height;
		patternBrushBytes = new byte[customPatternWidth * customPatternHeight * 4];

		int pixel = 0;
		Color32[] brushPixel = customPatterns[selectedPattern].GetPixels32();

		for (int x = 0; x < customPatternWidth; x++)
		{
			for (int y = 0; y < customPatternHeight; y++)
			{
				patternBrushBytes[pixel] = brushPixel[x + y * customPatternWidth].r;
				patternBrushBytes[pixel + 1] = brushPixel[x + y * customPatternWidth].g;
				patternBrushBytes[pixel + 2] = brushPixel[x + y * customPatternWidth].b;
				patternBrushBytes[pixel + 3] = brushPixel[x + y * customPatternWidth].a;

				pixel += 4;
			}
		}
	}


	//取决于混色方式。例如按最常用的不透明度计算，每个通道的计算公式是α*A+(1-α)*B，其中A、B分别是两个色层同一通道的灰度值，A层在B层之上。α是A色层的不透明度。
	byte ByteLerp(byte value1, byte value2, float amount)
	{
		return (byte)(value1 + (value2 - value1) * amount);
	}

	//橡皮擦
	public void EraseWithImage(int x, int y)
	{
//		int pixel = 0;
//		for (int i = 0; i < brushSizeX4; i++)
//		{
//			int tx = (i % brushSizeX1) - brushSize;
//			int ty = (i / brushSizeX1) - brushSize;
//
//			if (tx * tx + ty * ty > brushSizeXbrushSize) continue;
//			if (x + tx < 0 || y + ty < 0 || x + tx >= texWidth || y + ty >= texHeight) continue; // temporary fix for corner painting
//
//			pixel = (texWidth * (y + ty) + x + tx) << 2;
//
//			float xx = Mathf.Repeat(y + ty, texHeight);
//			float yy = Mathf.Repeat(x + tx, texWidth);
//			int pixel2 = (int)Mathf.Repeat((texWidth * xx + yy) * 4, clearPixels.Length);
//
////			pixels[pixel] = clearPixels[pixel2];
////			pixels[pixel + 1] = clearPixels[pixel2 + 1];
////			pixels[pixel + 2] = clearPixels[pixel2 + 2];
////			pixels[pixel + 3] = clearPixels[pixel2 + 3];
//			pixels[pixel] = clearColor.r;
//			pixels [pixel + 1] = clearColor.g;
//			pixels [pixel + 2] = clearColor.b;
//			pixels[pixel + 3] = clearColor.a;
//		} 

		int pixel = 0;

		for (int i = 0; i < brushSizeX4; i++)
		{
			int tx = (i % brushSizeX1) - brushSize;
			int ty = (i / brushSizeX1) - brushSize;

			if (tx * tx + ty * ty > brushSizeXbrushSize) continue;
			if (x + tx < 0 || y + ty < 0 || x + tx >= texWidth || y + ty >= texHeight) continue; // temporary fix for corner painting

			pixel = (texWidth * (y + ty) + x + tx) << 2;

			// no additive, just paint my color
			if (!useLockArea || (useLockArea && lockMaskPixels[pixel] == 1))
			{
				pixels[pixel] = clearColor.r;
				pixels[pixel + 1] = clearColor.g;
				pixels[pixel + 2] = clearColor.b;
				pixels[pixel + 3] = clearColor.a;
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

	public void SetDrawModeBrush()
	{
		drawMode = MyDrawMode.Default;
	}

	public void SetDrawModeShapes(int brushIndex)
	{
		selectedBrush = brushIndex;
		drawMode = MyDrawMode.CustomBrush;
		//selectedBrush = 1;
		ReadCurrentCustomBrush();
	}
	public void SetDrawModePattern(int _colorIndex)
	{
		selectedPattern = _colorIndex;
		ReadCurrentCustomPattern ();
		drawMode = MyDrawMode.Pattern;
	}

	public void SetDrawModeEraser()
	{
		drawMode = MyDrawMode.Eraser;
	}


	void OnDestroy()
	{
		if (drawingTexture != null) Texture2D.DestroyImmediate(drawingTexture, true);
		pixels = null;
		maskPixels = null;
		clearPixels = null;
		lockMaskPixels = null;
		//if (undoEnabled) undoPixels.Clear();

		// System.GC.Collect();
	}
}
