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
using UnityEngine.SceneManagement;

public class DisplayView : MonoBehaviour
{
    public Button BtnHome;
    public Button BtnBack;
    public Button BtnSave;
    public Button BtnGame;
    public Transform ImgDisplay;
    public Transform PosFlag1;//左上角截屏定位点
    public Transform PosFlag2;//右下角截屏定位点

    private JoinMainView joinMainView;
    private Transform displayItem;//展示界面的物体
    private Vector2 rectImgDisplay;
    private Vector2 screenPosFlag1;
    private Vector2 screenPosFlag2;
    private string savePath = String.Empty;

    private int radius = 80;//参考半径 和texWidth有点关系
    private int referenceWidth = 1206;//参考的图片宽
    private int texWidth = 0;
    private int texHeight = 0;
    private Texture2D staticTexture;//静态展示图片
    private DisplayPartItem[] lstDisplayItem;

    [DllImport("__Internal")]
    private static extern void UnityToIOS_SavePhotoToAlbum(string path);

    void Start()
    {
        rectImgDisplay = ImgDisplay.GetComponent<RectTransform>().sizeDelta;
        joinMainView = transform.GetComponentInParent<Canvas>().gameObject.GetComponentInChildren<JoinMainView>(true);
     
        AddEvent();
        screenPosFlag1 = Camera.main.WorldToScreenPoint(PosFlag1.position);
        screenPosFlag2 = Camera.main.WorldToScreenPoint(PosFlag2.position);
        Display();
        BtnSave.interactable = false;
    }

    private void AddEvent()
    {
        BtnHome.onClick.AddListener(delegate
        {
            SceneManager.LoadScene("home");
        });

        BtnBack.onClick.AddListener(delegate
        {
            joinMainView.gameObject.SetActive(true);
            Destroy(gameObject);
            Resources.UnloadUnusedAssets();
            GC.Collect();
        });
        BtnSave.onClick.AddListener(SavePic);

        BtnGame.onClick.AddListener(delegate
        {
            gameObject.SetActive(false);
            UIHelper.instance.LoadPrefab("prefabs/game/piano|piano_view",joinMainView.CanvasTrans, Vector3.zero, Vector3.one, true);
            //UIHelper.instance.LoadPrefab("prefabs/game/card|card_view", joinMainView.CanvasTrans, Vector3.zero, Vector3.one, true);
        });
    }

    public void Display()
    {
        GameObject person = null;
        if (DataManager.instance.partDataList!=null)
        {
            person = DataManager.instance.GetPersonObj(DataManager.instance.partDataList);
        }
        person.transform.SetParent(ImgDisplay);
        person.transform.localScale = new Vector3(0.83f, 0.83f, 0.83f);
        person.transform.localPosition = Vector3.zero;

        //加上按钮
        Button btn = person.gameObject.AddComponent<Button>();
        btn.onClick.AddListener(Greeting);

        lstDisplayItem = DataManager.instance.GetListDiaplayItem(person.transform);

        //生成静态展示图片
        StartCoroutine(CutScreen());

        //播放打招呼的动画
        Invoke("Greeting", 0.5f);
    }

    IEnumerator CutScreen()
    {
        //图片大小
        texWidth = (int)(screenPosFlag2.x - screenPosFlag1.x);
        texHeight = (int)(screenPosFlag1.y - screenPosFlag2.y);
        staticTexture = new Texture2D(texWidth, texHeight,TextureFormat.RGBA32,true);
        //计算四个角要裁切的圆半径
        radius = (int)((decimal)radius / referenceWidth * texWidth);
        Debug.Log(texWidth + "," + texHeight);
        //左下角是0，0
        Rect rect = new Rect((int)screenPosFlag1.x, Screen.height - (int)(Screen.height - screenPosFlag2.y),texWidth,texHeight);
        yield return new WaitForEndOfFrame();
        //截屏
        staticTexture.ReadPixels(rect, 0, 0, true);
        Color32 color = new Color32(0,0,0,0);
        staticTexture.Apply();
        BtnSave.interactable = true;//保存按钮才可以用
        yield return staticTexture;
    }

    void SavePic()
    {
        byte[] b = staticTexture.EncodeToPNG();
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff").Replace(":", "-");
        string photoName = "MyPhoto_" + date + ".png";
        string folderPath = Application.persistentDataPath + "/image_shot";
        //File.WriteAllBytes(path +"/"+ photoName, byt);//同步方法
        if (!File.Exists(folderPath))
        {
            Debug.Log("文件夹不存在:" + folderPath);
            Directory.CreateDirectory(folderPath);
        }
        savePath = folderPath + "/" + photoName;

        FileStream fileStream = File.Open(savePath, FileMode.Create);
        fileStream.BeginWrite(b, 0, b.Length, new AsyncCallback(EndWrite), fileStream);//异步方法
        Debug.Log("图片保存的沙河地址：------------" + savePath);
    }

    public void EndWrite(IAsyncResult result)
    {
        FileStream fileStream = (FileStream)result.AsyncState;
        fileStream.EndWrite(result);
        Debug.Log("异步保存图片完成------------");
        UnityToIOS_SavePhotoToAlbum(savePath);
    }

    public void Greeting()
    {
        DataManager.instance.PersonGreeting(lstDisplayItem);
    }

}
