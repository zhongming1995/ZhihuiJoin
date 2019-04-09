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
            //DataManager.instance.TransformToPartsList(joinMainView.DrawPanel);
            //DataManager.instance.SerializePersonData();
        });
    }

    public void Display()
    {
        Transform displayItem = (Transform)Instantiate(joinMainView.DrawPanel, ImgDisplay);
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
    }

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
