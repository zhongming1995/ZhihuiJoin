﻿using System;
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
        //BtnSave.interactable = false;
        BtnGame.interactable = false;//保存按钮才可以用
        BtnBack.interactable = false;//保存按钮才可以用
        BtnHome.interactable = false;//保存按钮才可以用
        ShowMask(false);
    }

    private void ShowMask(bool show)
    {
        ImgMask.gameObject.SetActive(show);
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
                //刷新修改的人物
                if (refreshCalendar!=null)
                {
                    refreshCalendar(CalendarDetailController.instance.curDetailIndex);
                }
            }
        });

        //编辑按钮
        BtnBack.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            PartDataWhole whole = GameManager.instance.curWhole;
            if (GameManager.instance.openType!=OpenType.ReEdit)
            {
                GameManager.instance.SetOpenType(OpenType.BackEdit);
            }
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
            GameObject person = DataManager.instance.GetPersonObj(GameManager.instance.curWhole);
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
        //yield return new WaitForSeconds(0.8f);
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
        staticTexture.Apply();
        yield return staticTexture;
        SavePic();
        if (GameManager.instance.displayType==DisplayType.FirstDisplay)
        {
            PSDisplay.Play();
            AudioManager.instance.PlayOneShotAudio("Audio/effect|show");
            Invoke("Greeting", 0f);
            Invoke("Greeting", 1.5f);
        }
    }

    void SavePic()
    {
        string savePath = PersonManager.instance.SaveImgPath+".png";
        FileHelper.ByteToFile(staticTexture.EncodeToPNG(), savePath);
        Debug.Log("图片保存的沙河地址：------------" + savePath);
        BtnGame.interactable = true;//保存按钮才可以用
        BtnBack.interactable = true;//保存按钮才可以用
        BtnHome.interactable = true;//保存按钮才可以用
    }

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
