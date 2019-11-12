using System;
using System.Collections;
using AudioMgr;
using DataMgr;
using DG.Tweening;
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
    public ParticleSystem PSDisplay;//彩带粒子

    private JoinMainView joinMainView;
    private Transform displayItem;//展示界面的物体
    private Vector2 rectImgDisplay;
    private Vector2 screenPosFlag1;
    private Vector2 screenPosFlag2;

    private int referenceWidth = 1206;//参考的图片宽
    private int texWidth = 0;
    private int texHeight = 0;
    private Texture2D staticTexture;//静态展示图片
    private DisplayPartItem[] lstDisplayItem;
    private bool Loaded;
    private bool Fadeed;

    void Start()
    {
        ImgDisplay.transform.localScale = Vector3.zero;

        BtnGame.GetComponent<UIMove>().SetFromPosition();
        BtnBack.GetComponent<UIMove>().SetFromPosition();
        BtnHome.GetComponent<UIMove>().SetFromPosition();
        rectImgDisplay = ImgDisplay.GetComponent<RectTransform>().sizeDelta;
        joinMainView = transform.GetComponentInParent<Canvas>().gameObject.GetComponentInChildren<JoinMainView>(true);
     
        AddEvent();
        screenPosFlag1 = Camera.main.WorldToScreenPoint(PosFlag1.position);
        screenPosFlag2 = Camera.main.WorldToScreenPoint(PosFlag2.position);

        //Display();
    }

    private void OnEnable()
    {
        FadeIn.fadeOutComplete += TransitionFadeOutComplete;
    }

    private void OnDisable()
    {
        FadeIn.fadeOutComplete -= TransitionFadeOutComplete;
    }

    private void TransitionFadeOutComplete(PanelEnum panelEnum)
    {
        //StartCoroutine(CutScreen());
        Display();
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
        //返回按钮
        BtnHome.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            if (GameManager.instance.openType == OpenType.FirstEdit || GameManager.instance.openType == OpenType.BackEdit)
            {
                GameManager.instance.SetNextSceneName(SceneName.Home);
                TransitionView.instance.OpenTransition();
            }
            else
            {
                PersonManager.instance.CurPersonPageIndex = 0;//画册进入编辑进入保存，返回画册应该是第一页
                GameManager.instance.SetNextSceneName(SceneName.Calendar);
                TransitionView.instance.OpenTransition();
            }
        });

        //编辑按钮
        BtnBack.onClick.AddListener(delegate
        {
            PersonManager.instance.CurPersonPageIndex = 0;//画册进入编辑进入保存，返回画册应该是第一页
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            PartDataWhole whole = GameManager.instance.curWhole;
            if (GameManager.instance.openType!=OpenType.ReEdit)
            {
                GameManager.instance.SetOpenType(OpenType.BackEdit);
            }
            GameManager.instance.SetNextSceneName(SceneName.Join);
            TransitionView.instance.OpenTransition();
        });

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
            //加载人物
            GameObject person = DataManager.instance.GetPersonObj(GameManager.instance.curWhole);
            person.transform.SetParent(ImgDisplay);
            person.transform.localScale = new Vector3(0.83f, 0.83f, 0.83f);
            person.transform.localPosition = Vector3.zero;

            //加上按钮
            Button btn = person.gameObject.AddComponent<Button>();
            btn.onClick.AddListener(delegate {
                Greeting();
                Invoke("Greeting", 1.5f);
            });

            lstDisplayItem = DataManager.instance.GetListDiaplayItem(person.transform);

            //缩放动画
            Sequence mySequence = DOTween.Sequence();
            mySequence.AppendInterval(0.2f);
            mySequence.Append(ImgDisplay.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f));
            mySequence.Append(ImgDisplay.transform.DOScale(Vector3.one, 0.2f));

            mySequence.AppendCallback(() => {
                 StartCoroutine(CutScreen());//开始截屏
            });
        }
    }

    IEnumerator CutScreen()
    {
        //yield return new WaitForSeconds(0.8f);
        //图片大小
        texWidth = (int)(screenPosFlag2.x - screenPosFlag1.x);
        texHeight = (int)(screenPosFlag1.y - screenPosFlag2.y);
        staticTexture = new Texture2D(texWidth, texHeight,TextureFormat.RGBA32,true);
        //左下角是0，0
        Rect rect = new Rect((int)screenPosFlag1.x, Screen.height - (int)(Screen.height - screenPosFlag2.y),texWidth,texHeight);
        yield return new WaitForEndOfFrame();
        //截屏
        staticTexture.ReadPixels(rect, 0, 0, true);
        staticTexture.Apply();
        yield return staticTexture;
        SavePic();
        if (GameManager.instance.displayType==DisplayType.FirstDisplay)
        {
            PSDisplay.Play();
            AudioManager.instance.PlayOneShotAudio("Audio/effect|show");
            Greeting();
            Invoke("Greeting", 1.5f);
        }
        else
        {
            ShowButton();
        }
    }

    void SavePic()
    {
        string savePath = PersonManager.instance.PersonImgPath + PersonManager.instance.PersonFileName +".jpg";
        FileHelper.ByteToFile(staticTexture.EncodeToJPG(), savePath);
        Debug.Log("图片保存的沙河地址：------------" + savePath);
    }

    public void Greeting()
    {
        DataManager.instance.PersonJumpAndWave(lstDisplayItem);
        Invoke("ShowButton", 3f);
    }

    private void ShowButton()
    {
        BtnGame.GetComponent<UIMove>().MoveShow();
        BtnBack.GetComponent<UIMove>().MoveShow();
        BtnHome.GetComponent<UIMove>().MoveShow();
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
