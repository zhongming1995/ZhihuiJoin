using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Helper;
using DataMgr;
using GameMgr;
using System.IO;
using System.Runtime.InteropServices;
using System;

public class DisplayView : MonoBehaviour
{
    public Button BtnHome;
    public Button BtnBack;
    public Button BtnSave;
    public Transform ImgDisplay;
    public Transform PosFlag1;//左上角截屏定位点
    public Transform PosFlag2;//右下角截屏定位点
    public Transform PosFlagLeftBottom;//左下角圆形裁切定位点
    public Transform PosFlagLeftTop;//左下角圆形裁切定位点
    public Transform PosFlagRightBottom;//左下角圆形裁切定位点
    public Transform PosFlagRightTop;//左下角圆形裁切定位点

    private JoinMainView joinMainView;
    private Vector2 rectImgDisplay;
    private Vector2 screenPosFlag1;
    private Vector2 screenPosFlag2;
    private string savePath = String.Empty;

    private int radius = 80;//参考半径 和texWidth有点关系
    private int referenceWidth = 1206;//参考的图片宽
    private int texWidth = 0;
    private int texHeight = 0;
    //private Camera ShotCamera;//截屏摄像机

    [DllImport("__Internal")]
    private static extern void UnityToIOS_SavePhotoToAlbum(string path);

    void Start()
    {
        rectImgDisplay = ImgDisplay.GetComponent<RectTransform>().sizeDelta;
        joinMainView = GameManager.instance.Root.GetComponentInChildren<JoinMainView>(true);
        AddEvent();
        Display();
        screenPosFlag1 = Camera.main.WorldToScreenPoint(PosFlag1.position);
        screenPosFlag2 = Camera.main.WorldToScreenPoint(PosFlag2.position);

       //ShotCamera = GameObject.Find("ShotScreen_Camera").GetComponent<Camera>();
    }

    private void AddEvent()
    {
        BtnHome.onClick.AddListener(delegate
        {
            UIHelper.instance.LoadPrefab("prefabs/home|select_item_view", GameManager.instance.Root, Vector3.zero, Vector3.one, true);
            Destroy(gameObject);
            Destroy(joinMainView.gameObject);
        });

        BtnBack.onClick.AddListener(delegate
        {
            Destroy(gameObject);
            joinMainView.gameObject.SetActive(true);
        });
        BtnSave.onClick.AddListener(delegate
        {
            StartCoroutine(CutScreen());
            /*摄像机截图
            int startX = (int)(Screen.width / 2 - rectImgDisplay.x/2);
            int startY = (int)(Screen.height / 2 - rectImgDisplay.y/2 * 0.7f);
            Debug.Log(startX + "," + startY);
            CaptureCamera(ShotCamera, new Rect(startX, startY, rectImgDisplay.x, rectImgDisplay.y));
            */           
            //DataManager.instance.TransformToPartsList(joinMainView.DrawPanel);
            //DataManager.instance.SerializePersonData();
        });
    }

    public void Display()
    {
        Transform displayItem = Instantiate(joinMainView.DrawPanel, ImgDisplay);
        Vector2 vDisplayItem = displayItem.GetComponent<RectTransform>().sizeDelta;
        float rate = rectImgDisplay.x / vDisplayItem.x;
        displayItem.localScale = new Vector3(rate, rate, rate);

        //隐藏带底图的
        displayItem.Find("group_body").GetChild(1).gameObject.SetActive(false);
        //显示自己画的部分
        RawImage draw = displayItem.Find("group_body/img_draw").GetComponent<RawImage>();
        draw.gameObject.SetActive(true);
        draw.texture = joinMainView.GetDrawTexture();
        draw.SetNativeSize();
        draw.transform.GetComponent<RectTransform>().localScale = new Vector3(rate, rate, rate);

        //复制到需要截屏的摄像机
        /*
        Transform copyParent = GameObject.Find("ShotScreen_Canvas").transform;
        Transform copyItem = Instantiate(ImgDisplay,copyParent);
        copyItem.localPosition = Vector3.zero;
        ChangeLayer(copyItem, "Draw");
        */       
    }

    //修改层级
    void ChangeLayer(Transform trans, string targetLayer)
    {
        if (LayerMask.NameToLayer(targetLayer) == -1)
        {
            Debug.Log("Layer中不存在,请手动添加LayerName");

            return;
        }
        //遍历更改所有子物体layer
        trans.gameObject.layer = LayerMask.NameToLayer(targetLayer);
        foreach (Transform child in trans)
        {
            ChangeLayer(child, targetLayer);
            Debug.Log(child.name + "子对象Layer更改成功！");
        }
    }
    // <summary>
    /// 对相机截图。 
    /// </summary>
    /// <returns>The screenshot2.</returns>
    /// <param name="camera">Camera.要被截屏的相机</param>
    /// <param name="rect">Rect.截屏的区域</param>
    /*
    Texture2D CaptureCamera(Camera camera, Rect rect)
    {
        // 创建一个RenderTexture对象
        RenderTexture rt = new RenderTexture((int)Screen.width, (int)Screen.height, 0);
        // 临时设置相关相机的targetTexture为rt, 并手动渲染相关相机
        camera.targetTexture = rt;
        camera.Render();

        // 激活这个rt, 并从中中读取像素。
        RenderTexture.active = rt;
        Texture2D screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);
        screenShot.ReadPixels(rect, 0, 0);// 注：这个时候，它是从RenderTexture.active中读取像素
        screenShot.Apply();

        // 重置相关参数，以使用camera继续在屏幕上显示
        camera.targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        Destroy(rt);
        // 最后将这些纹理数据，成一个png图片文件
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = Application.persistentDataPath + "/Screenshot2.png";
        System.IO.File.WriteAllBytes(filename, bytes);
        Debug.Log(string.Format("截屏了一张照片: {0}", filename));

        return screenShot;
    }
    */

    IEnumerator CutScreen()
    {
        //图片大小
        texWidth = (int)(screenPosFlag2.x - screenPosFlag1.x);
        texHeight = (int)(screenPosFlag1.y - screenPosFlag2.y);
        Texture2D tex = new Texture2D(texWidth, texHeight,TextureFormat.RGBA32,true);
        //计算四个角要裁切的圆半径
        radius = (int)((decimal)radius / referenceWidth * texWidth);
        //左下角是0，0
        Rect rect = new Rect((int)screenPosFlag1.x, Screen.height - (int)(Screen.height - screenPosFlag2.y),texWidth,texHeight);
        yield return new WaitForEndOfFrame();
        //截屏
        tex.ReadPixels(rect, 0, 0, true);
        Color32 color = new Color32(0,0,0,0);
        //处理图片，裁切成圆角的
        /*
        //左下角（左下角的坐标是0，0）
        Vector2 leftBottom = new Vector2(radius, radius);
        for (int i = 0; i < radius; i++)
        {
            for (int j = 0; j < radius; j++)
            {
                Vector2 v = new Vector2(i, j);
                if (Vector2.Distance(v,leftBottom)>radius)
                {
                    tex.SetPixel(i, j, color);
                }
            }
        }
        //右下角
        Vector2 rightBottom = new Vector2(texWidth - radius, radius);
        for (int i = texWidth; i > texWidth-radius; i--)
        {
            for (int j = 0; j < radius; j++)
            {
                Vector2 v = new Vector2(i, j);
                if (Vector2.Distance(v,rightBottom)>radius)
                {
                    tex.SetPixel(i, j, color);
                }
            }
        }
        //左上角
        Vector2 leftTop = new Vector2(radius, texHeight - radius);
        for (int i = 0; i < radius; i++)
        {
            for (int j = texHeight; j > texHeight - radius; j--)
            {
                Vector2 v = new Vector2(i, j);
                if (Vector2.Distance(v,leftTop)>radius)
                {
                    tex.SetPixel(i, j, color);
                }
            }
        }
        //右上角
        Vector2 rightTop = new Vector2(texWidth - radius, texHeight - radius);
        for (int i = texWidth; i > texWidth - radius; i--)
        {
            for (int j = texHeight; j > texHeight-radius; j--)
            {
                Vector2 v = new Vector2(i, j);
                if (Vector2.Distance(v,rightTop)>radius)
                {
                    tex.SetPixel(i, j, color);
                }
            }
        }
        */

        tex.Apply();
        yield return tex;

        byte[] b = tex.EncodeToPNG();
        string date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff").Replace(":", "-");
        string photoName = "MyPhoto_" + date + ".png";
        savePath = Application.persistentDataPath + "/" + photoName;
        //File.WriteAllBytes(path +"/"+ photoName, byt);//同步方法
        FileStream fileStream = File.Open(savePath, FileMode.Create);
        fileStream.BeginWrite(b, 0, b.Length, new AsyncCallback(EndWrite), fileStream);//异步方法
        Debug.Log("保存的沙河地址：------------" + savePath);
    }


    public void EndWrite(IAsyncResult result)
    {
        FileStream fileStream = (FileStream)result.AsyncState;
        fileStream.EndWrite(result);
        Debug.Log("异步保存图片完成------------");
        UnityToIOS_SavePhotoToAlbum(savePath);
    }

}
