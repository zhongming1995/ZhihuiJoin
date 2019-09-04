using System;
using System.Collections;
using System.Runtime.InteropServices;
using AudioMgr;
using DataMgr;
using GameMgr;
using Helper;
using UnityEngine;
using UnityEngine.UI;

public class DisplayView : MonoBehaviour
{
    public Button BtnHome;
    public Button BtnBack;
    public Button BtnSave;
    public Button BtnGame;
    public Transform ImgDisplay;
    public Transform PosFlag1;//左上角截屏定位点
    public Transform PosFlag2;//右下角截屏定位点
    public Transform ImgMask;//保存图片时的mask

    public ParticleSystem PSDisplay;//展示彩带

    private JoinMainView joinMainView;
    private Transform displayItem;//展示界面的物体
    private Vector2 rectImgDisplay;
    private Vector2 screenPosFlag1;
    private Vector2 screenPosFlag2;

    private int radius = 80;//参考半径 和texWidth有点关系
    private int referenceWidth = 1206;//参考的图片宽
    private int texWidth = 0;
    private int texHeight = 0;
    private Texture2D staticTexture;//静态展示图片
    private DisplayPartItem[] lstDisplayItem;

    public delegate void RefreshCalendar(int index);
    public static event RefreshCalendar refreshCalendar;

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
        ShowMask(false);
    }

    private void ShowMask(bool show)
    {
        ImgMask.gameObject.SetActive(show);
    }

    private void OnEnable()
    {
        //GameOperDelegate.pianoBegin += JumpToGameCB;
        //GameOperDelegate.cardBegin += JumpToGameCB;
        //GameOperDelegate.fruitBegin += JumpToGameCB;
        CallManager.savePhotoCallBack += SavePhotoCallBack;
        FadeIn.fadeOutComplete += TransitionFadeOutComplete;
    }

    private void SavePhotoCallBack(string result)
    {
        Debug.Log("Display SavePhotoCallBack===========");
        ShowMask(false);
    }

    private void OnDisable()
    {
        //GameOperDelegate.pianoBegin -= JumpToGameCB;
        //GameOperDelegate.cardBegin -= JumpToGameCB;
        //GameOperDelegate.fruitBegin -= JumpToGameCB;
        CallManager.savePhotoCallBack -= SavePhotoCallBack;
        FadeIn.fadeOutComplete -= TransitionFadeOutComplete;
    }

    private void TransitionFadeOutComplete(PanelEnum panelEnum)
    {
        StartCoroutine(CutScreen());
    }

    //弃用
    private void PlayPiano()
    {
        HideDisplayView();
    }

    //弃用
    private void PlayCard()
    {
        HideDisplayView();
    }

    public void HideDisplayView()
    {
        gameObject.SetActive(false);
    }

    private void AddEvent()
    {
        BtnHome.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            if (GameManager.instance.openType == OpenType.FirstEdit || GameManager.instance.openType == OpenType.BackEdit)
            {
                //PanelManager.instance.BackToView(PanelName.HomeView);
                //GameManager.instance.SetNextViewPath(PanelName.HomeView);
                //UIHelper.instance.LoadPrefab(PanelName.TransitionView, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
                GameManager.instance.SetNextSceneName(SceneName.Home);
                TransitionView.instance.OpenTransition();
            }
            else
            {
                //GameManager.instance.SetNextViewPath(PanelName.CalendarView);
                //UIHelper.instance.LoadPrefab(PanelName.TransitionView, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
                GameManager.instance.SetNextSceneName(SceneName.Calendar);
                TransitionView.instance.OpenTransition();
                //刷新修改的人物
                if (refreshCalendar!=null)
                {
                    refreshCalendar(CalendarDetailController.instance.curDetailIndex);
                }
            }
        });

        BtnBack.onClick.AddListener(delegate
        {
            Debug.Log("nac");
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            //AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            PartDataWhole whole = GameManager.instance.curWhole;
            //GameManager.instance.homeSelectIndex = whole.ModelIndex;
            GameManager.instance.SetOpenType(OpenType.BackEdit);
            //GameManager.instance.SetNextViewPath(PanelName.JoinMainView);
            //UIHelper.instance.LoadPrefab(PanelName.TransitionView, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
            GameManager.instance.SetNextSceneName(SceneName.Join);
            TransitionView.instance.OpenTransition();
        });
        /*目前没有此按钮
        BtnSave.onClick.AddListener(delegate {
#if !UNITY_EDITOR
            ShowMask(false);
#endif
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            SavePic();
        });
        */
        BtnGame.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            UIHelper.instance.LoadPrefab("Prefabs/game/window|window_choosegame", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
        });
    }

    public void Display()
    {
        if (GameManager.instance.curWhole!=null)
        {
            GameObject person = DataManager.instance.GetPersonObj(GameManager.instance.curWhole.partDataList);
            person.transform.SetParent(ImgDisplay);
            person.transform.localScale = new Vector3(0.83f, 0.83f, 0.83f);
            person.transform.localPosition = Vector3.zero;

            //加上按钮
            Button btn = person.gameObject.AddComponent<Button>();
            btn.onClick.AddListener(Greeting);

            lstDisplayItem = DataManager.instance.GetListDiaplayItem(person.transform);

            //生成静态展示图片
            //StartCoroutine(CutScreen());
        }
    }

    IEnumerator CutScreen()
    {
        yield return new WaitForSeconds(0.8f);
        //图片大小
        texWidth = (int)(screenPosFlag2.x - screenPosFlag1.x);
        texHeight = (int)(screenPosFlag1.y - screenPosFlag2.y);
        staticTexture = new Texture2D(texWidth, texHeight,TextureFormat.RGBA32,true);
        //计算四个角要裁切的圆半径
        radius = (int)((decimal)radius / referenceWidth * texWidth);
        //左下角是0，0
        Rect rect = new Rect((int)screenPosFlag1.x, Screen.height - (int)(Screen.height - screenPosFlag2.y),texWidth,texHeight);
        yield return new WaitForEndOfFrame();
        //截屏
        staticTexture.ReadPixels(rect, 0, 0, true);
        Color32 color = new Color32(0,0,0,0);
        staticTexture.Apply();
        BtnSave.interactable = true;//保存按钮才可以用
        yield return staticTexture;
        SavePic();

        if (GameManager.instance.displayType==DisplayType.FirstDisplay)
        {
            PSDisplay.Play();
            AudioManager.instance.PlayOneShotAudio("Audio/bgm|show");
            Invoke("Greeting", 0f);
            Invoke("Greeting", 1.5f);
        }
    }

    void SavePic()
    {
        string savePath = PersonManager.instance.SaveImgPath+".png";
        FileHelper.ByteToFile(staticTexture.EncodeToPNG(), savePath);
        Debug.Log("图片保存的沙河地址：------------" + savePath);
        //UnityToIOS_SavePhotoToAlbum(savePath);//保存到相册
    }

    //public void EndWrite(IAsyncResult result)
    //{
    //    FileStream fileStream = (FileStream)result.AsyncState;
    //    fileStream.EndWrite(result);
    //    fileStream.Close();
    //    Debug.Log("异步保存图片字节完成------------");
    //}

    public void Greeting()
    {
        DataManager.instance.PersonJumpAndWave(lstDisplayItem);
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
