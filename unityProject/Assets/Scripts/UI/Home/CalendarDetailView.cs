using GameMgr;
using Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AudioMgr;
using DataMgr;
using System.Runtime.InteropServices;

public class CalendarDetailView : MonoBehaviour
{
    public Transform ListContent;
    public Button BtnPre;
    public Button BtnNext;
    public Button BtnDownload;
    public Button BtnEdit;
    public Button BtnGame;
    public Button BtnBack;

    public Transform PosFlag1;//左上角截屏定位点
    public Transform PosFlag2;//右下角截屏定位点
    public Transform ImgMask;//保存图片时的mask

    private CalendarListDrag calendarListDrag;
    private List<CalendarDetailItem> detailList = new List<CalendarDetailItem>();

    //保存相册
    private Vector2 screenPosFlag1;
    private Vector2 screenPosFlag2;
    private int radius = 80;//参考半径 和texWidth有点关系
    private int referenceWidth = 1206;//参考的图片宽
    private int texWidth = 0;
    private int texHeight = 0;
    private Texture2D staticTexture;//静态展示图片
    private string savePath = String.Empty;

    [DllImport("__Internal")]
    private static extern void UnityToIOS_SavePhotoToAlbum(string path);

    private void OnEnable()
    {
        CallManager.savePhotoCallBack += SavePhotoCallBack;
    }
    
    private void OnDisable()
    {
        CallManager.savePhotoCallBack -= SavePhotoCallBack;
    }
    
    void Start()
    {
        GameManager.instance.displayType = DisplayType.NoDisplay;
        calendarListDrag = transform.GetComponentInChildren<CalendarListDrag>();
        StartCoroutine(LoadPersonList(PersonManager.instance.pathList, PersonManager.instance.CurPersonIndex));
        AddEventListener();
        AddBtnEvent();
        ShowMask(false);
        screenPosFlag1 = Camera.main.WorldToScreenPoint(PosFlag1.position);
        screenPosFlag2 = Camera.main.WorldToScreenPoint(PosFlag2.position);
    }

    void AddBtnEvent()
    {
        BtnBack.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            //GameManager.instance.SetNextViewPath(PanelName.CalendarView);
            //UIHelper.instance.LoadPrefab(PanelName.TransitionView, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
            GameManager.instance.SetNextSceneName(SceneName.Calendar);
            TransitionView.instance.OpenTransition();
        });

        BtnPre.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            int curIndex = CalendarDetailController.instance.PreDetail();
            PersonManager.instance.CurPersonIndex = curIndex;
            calendarListDrag.AniResetPosition(curIndex);
            calendarListDrag.AniResetScaleAndAlpha(curIndex);
            SetBtnActive(curIndex,CalenderController.instance.PersonNum);
        });

        BtnNext.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            int curIndex = CalendarDetailController.instance.NextDetail();
            PersonManager.instance.CurPersonIndex = curIndex;
            calendarListDrag.AniResetPosition(curIndex);
            calendarListDrag.AniResetScaleAndAlpha(curIndex);
            SetBtnActive(curIndex, CalenderController.instance.PersonNum);
        });

        BtnDownload.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
#if !UNITY_EDITOR
            ShowMask(true);
#endif
            string path = PersonManager.instance.PersonImgPath + "/" + PersonManager.instance.pathList[CalendarDetailController.instance.curDetailIndex] + ".png";
            UnityToIOS_SavePhotoToAlbum(path);
        });

        BtnEdit.onClick.AddListener(delegate {
            GameManager.instance.SetOpenType(OpenType.ReEdit);
            GameManager.instance.SetJoinShowAll(true);
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            string fileName = PersonManager.instance.pathList[CalendarDetailController.instance.curDetailIndex];
            PartDataWhole whole = PersonManager.instance.DeserializePerson(fileName);
            GameManager.instance.homeSelectIndex = whole.ModelIndex;
            GameManager.instance.SetOpenType(OpenType.ReEdit);
            GameManager.instance.SetCurPartDataWhole(whole);
            GameManager.instance.curJoinType = whole.JoinType;
            PersonManager.instance.PersonFileName = fileName;
            //PanelManager.instance.CloseTopPanel();
            //GameManager.instance.SetNextViewPath(PanelName.JoinMainView);
            //UIHelper.instance.LoadPrefab(PanelName.TransitionView, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
            GameManager.instance.SetNextSceneName(SceneName.Join);
            TransitionView.instance.OpenTransition();
        });
         
        BtnGame.onClick.AddListener(delegate {
            GameManager.instance.openType = OpenType.ReEdit;
            string fileName = PersonManager.instance.pathList[CalendarDetailController.instance.curDetailIndex];
            PartDataWhole whole = PersonManager.instance.DeserializePerson(fileName);
            DataManager.instance.partDataList = whole.partDataList;
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            UIHelper.instance.LoadPrefab("Prefabs/game/window|window_choosegame", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
        });
    }

    void AddEventListener()
    {
        calendarListDrag.detailSwitchIndex += SwitchIndexFunc;
    }

    void RemoveEventListener()
    {
        calendarListDrag.detailSwitchIndex -= SwitchIndexFunc;
    }

    private void SwitchIndexFunc(int _curIndex)
    {
        CalendarDetailController.instance.curDetailIndex = _curIndex;
        SetBtnActive(_curIndex, CalenderController.instance.PersonNum);
    }

    private void SetBtnActive(int _curIndex,int total)
    {
        Debug.Log("curindex:------" + _curIndex + "  :"+detailList.Count);
        if (_curIndex == 0)
        {
            BtnPre.gameObject.SetActive(false);
        }
        else
        {
            BtnPre.gameObject.SetActive(true);
        }
        if (_curIndex == total - 1)
        {
            BtnNext.gameObject.SetActive(false);
        }
        else
        {
            BtnNext.gameObject.SetActive(true);
        }
    }

    private void EnableBtn(bool enable)
    {
        BtnPre.interactable = enable;
        BtnNext.interactable = enable;
    }

    IEnumerator LoadPersonList(List<string> pathList,int curIndex)
    {
        int index = 0;
        SetBtnActive(curIndex, CalenderController.instance.PersonNum);
        EnableBtn(false);
        Vector2 realScreen = UIHelper.instance.GetRealScreen();
        ListContent.GetComponent<RectTransform>().sizeDelta = new Vector2(650 * pathList.Count, realScreen.y);
        calendarListDrag.ResetPosition(curIndex);
        WaitForSeconds delay = new WaitForSeconds(0.02f);
        while (index < pathList.Count)
        {
            int curI = index;
            GameObject item = UIHelper.instance.LoadPrefab("Prefabs/calendar|calendar_detail_item", ListContent, Vector3.zero, Vector3.one, false);
            item.name = pathList[curI];
            item.transform.localPosition = new Vector3(curI * 650, 0, 0);
            CalendarDetailItem detailItem = item.GetComponent<CalendarDetailItem>();
            if (curIndex == curI)
            {
                detailItem.Init(pathList[curI], true,index);
            }
            else
            {
                detailItem.Init(pathList[curI], false,index);
            }
            detailList.Add(detailItem);

            if (curI == pathList.Count - 1)
            {
                CalendarDetailController.instance.SetDetailList(detailList);
                CalendarDetailController.instance.curDetailIndex = curIndex;
            }
            index += 1;
            yield return delay;
        }
        EnableBtn(true);
    }

    private void SavePhotoCallBack(string result)
    {
        Debug.Log("Display SavePhotoCallBack===========");
        ShowMask(false);
    }

    private void ShowMask(bool show)
    {
        ImgMask.gameObject.SetActive(show);
    }

    private void OnDestroy()
    {
        for (int i = 0; i < detailList.Count; i++)
        {
            Destroy(detailList[i]);
            detailList[i] = null;
        }
        RemoveEventListener();
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
