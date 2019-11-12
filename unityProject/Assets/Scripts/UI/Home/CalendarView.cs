using GameMgr;
using Helper;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using AudioMgr;
using System.Runtime.InteropServices;

public class CalendarView : MonoBehaviour
{
    public Button BtnBack;
    public Button BtnDelete;
    public Button BtnDefault;
    public CanvasGroup ListMaskCG;
    public RectTransform ListContent;
    public Text TxtPage;
    public Button BtnPre;
    public Button BtnNext;
    public Button BtnDetailBack;
    public Button BtnDetailDownload;
    public Button BtnDetailEdit;
    public Button BtnDetailGame;
    public Transform LeftFlag;
    public Transform RightFlag;
    public Transform DetailView;

    private List<CalendarPage> pageList = new List<CalendarPage>();
    private GameObject DetailItem;
    private Vector3 OriDetailPosition;
    private CalenderItem CurSelectItem;
    private CalendarPage CurCalendarPage;
    private int lastIndex = -1;
    private int fixedPageCount;//固定页面数

    [DllImport("__Internal")]
    private static extern void UnityToIOS_SavePhotoToAlbum(string path);

    void Start()
    {
        //app使用时长开始计时
        lastIndex = PersonManager.instance.CurPersonPageIndex;
        CallManager.instance.UnityToPlatform_ResumeTime();
        pageList.Clear();
        AddBtnListener();
        AddEventListener();
        InitPageContent();
        LoadPages();
        SetPageText();
        SetPageSwitchBtn();
        SwitchDelBtn(true);
        HideDetail();
    }

    void AddEventListener()
    {
        GameOperDelegate.pianoBegin += PlayGame;
        GameOperDelegate.cardBegin += PlayGame;
        CalenderController.deleteItemComplete += DeleteItemComplete;
        CalenderController.chooseOneItem += ChooseOneItem;
    }

    void RemoveEventListener()
    {
        GameOperDelegate.pianoBegin -= PlayGame;
        GameOperDelegate.cardBegin -= PlayGame;
        CalenderController.deleteItemComplete -= DeleteItemComplete;
        CalenderController.chooseOneItem -= ChooseOneItem;
    }

    private void InitPageContent()
    {
        Vector2 realScreen = UIHelper.instance.GetRealScreen();
        CalenderController.instance.PerPageWidth = realScreen.x;
        CalenderController.instance.PerPageHeight = realScreen.y;
    }

    private void LoadPages()
    {
        fixedPageCount = Math.Min(3, PersonManager.instance.PageCount);//PageNum是在controller.awake里赋值的
        for (int i = 0; i < fixedPageCount; i++)
        {
            LoadOnePage(i);
        }
        PageScrollEndFunc(PersonManager.instance.CurPersonPageIndex, (int)ListContent.anchoredPosition.x,true);//首先进来就执行一次
    }

    /// <summary>
    /// 创建一个页面
    /// </summary>
    private void LoadOnePage(int i,Action cb = null)
    {
        GameObject page = UIHelper.instance.LoadPrefab("Prefabs/calendar|calendar_page", ListContent, Vector3.zero, Vector3.one, false);
        page.name = i.ToString();
        page.GetComponent<RectTransform>().sizeDelta = new Vector2(CalenderController.instance.PerPageWidth, CalenderController.instance.PerPageHeight);
        CalendarPage calendarPage = page.GetComponent<CalendarPage>();
        calendarPage.LoadSixItems();
        pageList.Add(calendarPage);
        if (cb != null)
        {
            cb();
        }
    }

    private void SetPageText()
    {
        TxtPage.text = (PersonManager.instance.CurPersonPageIndex + 1).ToString() + " / " + PersonManager.instance.PageCount.ToString();
    }

    private void SetPageSwitchBtn()
    {
        if (PersonManager.instance.CurPersonPageIndex == 0)
        {
            BtnPre.gameObject.SetActive(false);
        }
        else
        {
            BtnPre.gameObject.SetActive(true);
        }
        if (PersonManager.instance.CurPersonPageIndex == PersonManager.instance.PageCount - 1)
        {
            BtnNext.gameObject.SetActive(false);
        }
        else
        {
            BtnNext.gameObject.SetActive(true);
        }
    }

    void ChooseOneItem(CalenderItem item)
    {
        Debug.Log("choose one item:");
        if (item==null)
        {
            Debug.Log("choose item is null");
        }
        else
        {
            Debug.Log("choose item is not null");
        }
        Debug.Log("index:" + item.Index);
        PersonManager.instance.CurPersonIndex = item.Index;
        CalenderController.instance.SelectItemId = item.Index;
        CurSelectItem = item;
        ShowDetail(item);
    }

    void HideDetail()
    {
        float number = 0;
        Tween t = DOTween.To(() => number, x => number = x, 1, 0.2f);
        t.OnUpdate(() => {
            ListMaskCG.alpha = number;
        });
        DetailView.gameObject.SetActive(false);
        BtnDetailBack.GetComponent<UIMove>().MoveHide();
        BtnDetailDownload.GetComponent<UIMove>().MoveHide();
        BtnDetailEdit.GetComponent<UIMove>().MoveHide();
        BtnDetailGame.GetComponent<UIMove>().MoveHide();
        BtnDelete.GetComponent<UIMove>().MoveShow();
        BtnBack.GetComponent<UIMove>().MoveShow();
        if (DetailItem!=null)
        {
            DetailItem.transform.DOScale(Vector3.one, 0.3f);
            DetailItem.transform.DOMove(OriDetailPosition, 0.3f).OnComplete(() => {
                CurSelectItem.GetComponent<CanvasGroup>().alpha = 1;
                Destroy(DetailItem);
                DetailItem = null;
                CalenderController.instance.SelectItemId = -1;
            });
        }
    }

    void ShowDetail(CalenderItem item)
    {
        if (item==null)
        {
            Debug.Log("show is item null");
        }
        else
        {
            Debug.Log("show is item not null");
        }
        float number = 1;
        Tween t = DOTween.To(() => number, x => number = x, 0, 0.2f);
        t.OnUpdate(() => {
            ListMaskCG.alpha = number;
        });
        DetailView.gameObject.SetActive(true);
        OriDetailPosition = item.transform.position;
        DetailItem = Instantiate(item.gameObject,transform,true);
        Destroy(DetailItem.GetComponent<CalenderItem>());
        Destroy(DetailItem.transform.Find("btn_detail").GetComponent<ButtonScaleAni>());
        CurSelectItem.GetComponent<CanvasGroup>().alpha = 0;
        BtnDetailBack.GetComponent<UIMove>().MoveShow();
        BtnDetailDownload.GetComponent<UIMove>().MoveShow();
        BtnDetailEdit.GetComponent<UIMove>().MoveShow();
        BtnDetailGame.GetComponent<UIMove>().MoveShow();
        BtnDelete.GetComponent<UIMove>().MoveHide();
        BtnBack.GetComponent<UIMove>().MoveHide();
        DetailItem.transform.localScale = Vector3.one;
        DetailItem.transform.position = OriDetailPosition;
        DetailItem.transform.DOScale(new Vector3(1.5f,1.5f,1.5f), 0.3f);
        DetailItem.transform.DOLocalMove(Vector3.zero, 0.3f);
    }

    private void PageScrollEndFunc(int _curIndex,int curX,bool isFirst = false)
    {
        CalenderController.instance.IsScrolling = true;
        int perItemX = (int)CalenderController.instance.PerPageWidth;

        if (isFirst)
        {
            if (_curIndex == 0)//第一页
            {
                ListContent.anchoredPosition = new Vector2(0, 0);
            }else if (_curIndex == PersonManager.instance.PageCount-1)//最后一页
            {
                curX = -(fixedPageCount - 1) * perItemX;
                ListContent.anchoredPosition = new Vector2(-(fixedPageCount - 1) * perItemX, 0);
            }
            else
            {
                ListContent.anchoredPosition = new Vector2(-(fixedPageCount - 2) * perItemX, 0);
            }
        }
        SetPageSwitchBtn();
        BtnNext.interactable = false;
        BtnPre.interactable = false;

        int endPos = 0;
        if (lastIndex>_curIndex)
        {
            endPos = curX + perItemX;
        }
        else if (lastIndex < _curIndex)
        {
            endPos = curX - perItemX;
        }
        else
        {
            endPos = curX;
        }
        CalenderController.instance.ContentPosX = endPos;
        ListContent.DOAnchorPos(new Vector2(endPos, 0), 0.5f).OnComplete(() =>
        {
            lastIndex = _curIndex;
            SetPageText();
            //页面接续
            if (_curIndex != 0 && _curIndex != PersonManager.instance.PageCount - 1)//不是第一页，也不是最后一页
            {
                Debug.Log("非第一.非最后");
                int x = (int)Math.Ceiling(ListContent.anchoredPosition.x);
                if (x >= -0.5f * perItemX)
                {
                    Debug.Log("最后一个放到最前");
                    Transform t = ListContent.GetChild(2);
                    t.SetAsFirstSibling();
                }
                else if (x <= -1.5f * CalenderController.instance.PerPageWidth)
                {
                    Debug.Log("第一个放最后");
                    Transform t = ListContent.GetChild(0);
                    t.SetAsLastSibling();
                }
                ListContent.anchoredPosition = new Vector2(-CalenderController.instance.PerPageWidth, ListContent.localPosition.y);
            }
            else if (_curIndex == PersonManager.instance.PageCount - 1)
            {
                Debug.Log("最后一页");
                int positionX = (int)(ListContent.anchoredPosition.x);
                Debug.Log("fix:" + fixedPageCount);
                int flagPositionX = -(int)((fixedPageCount - 1) * CalenderController.instance.PerPageWidth);
                Debug.Log("positionX:" + positionX);
                Debug.Log("flagPositionX:" + flagPositionX);
                //if (positionX > flagPositionX + 100)
                //{
                    //Debug.Log(">");
                    //Debug.Log(fixedPageCount);
                    //Debug.Log(PersonManager.instance.PageCount);
                    if (fixedPageCount > PersonManager.instance.PageCount)
                    {
                        CalendarPage page = ListContent.GetChild(fixedPageCount - 1).GetComponent<CalendarPage>();
                        DestroyImmediate(ListContent.GetChild(fixedPageCount - 1).gameObject);
                        fixedPageCount--;
                        pageList.Remove(page);
                    }
                    else
                    {
                        if (positionX > flagPositionX + 100)
                        {
                            Transform t = ListContent.GetChild(fixedPageCount - 1);
                            t.SetAsFirstSibling();
                        }
                    ListContent.anchoredPosition = new Vector2(flagPositionX, ListContent.localPosition.y);
                }
                //}
            }

            //内容
            if (_curIndex == 0)
            {
                int startIndex = Math.Max(_curIndex, 0);
                int endIndex = Math.Min(2, PersonManager.instance.PageCount);
                for (int i = startIndex; i < endIndex; i++)
                {
                    ListContent.GetChild(i).GetComponent<CalendarPage>().RefreshPage(i);
                }
                Debug.Log("CurCalendarPage赋值 curIndex==0");
                CurCalendarPage = ListContent.GetChild(0).GetComponent<CalendarPage>();
            }
            else if (_curIndex == PersonManager.instance.PageCount - 1)
            {
                int startIndex = Math.Max(_curIndex - 2, 0);
                int endIndex = Math.Min(_curIndex, PersonManager.instance.PageCount - 1);
                int pageI = fixedPageCount - 1;
                for (int i = endIndex; i >= startIndex; i--)
                {
                    ListContent.GetChild(pageI).GetComponent<CalendarPage>().RefreshPage(i);
                    pageI--;
                }
                Debug.Log("CurCalendarPage赋值 curIndex2222");
                CurCalendarPage = ListContent.GetChild(fixedPageCount - 1).GetComponent<CalendarPage>();
            }
            else
            {
                int startIndex = Math.Max(0, _curIndex - 1);
                int endIndex = Math.Min(_curIndex + 1, PersonManager.instance.PageCount + 1);
                for (int i = startIndex; i <= endIndex; i++)
                {
                    ListContent.GetChild(i - startIndex).GetComponent<CalendarPage>().RefreshPage(i);
                }
                Debug.Log("CurCalendarPage赋值 curIndex333");
                CurCalendarPage = ListContent.GetChild(1).GetComponent<CalendarPage>();
            }
            Debug.Log("pageindex:" + CurCalendarPage.PageIndex);
            for (int i = 0; i < CurCalendarPage.PersonItemList.Count; i++)
            {
                Debug.Log("index:" + CurCalendarPage.PersonItemList[i].Index);
            }

            BtnNext.interactable = true;
            BtnPre.interactable = true;
            CalenderController.instance.IsScrolling = true;

            if (isFirst && GameManager.instance.CalendarDetailShow)
            {
                Invoke("DelayChooseOneItem", 0.2f);
            }

            Resources.UnloadUnusedAssets();
            GC.Collect();

            CalenderController.instance.IsScrolling = false;
        });
    }

    private void DelayChooseOneItem()
    {
        Debug.Log("DelayChooseOneItem:" + PersonManager.instance.CurPersonIndex);
        CalenderItem item = GetCalendarItemByIndex(PersonManager.instance.CurPersonIndex);
        if (item==null)
        {
            Debug.Log("item is null");
        }
        else
        {
            Debug.Log("item is not null");
        }
        ChooseOneItem(item);
    }

    private void AddBtnListener()
    {
        BtnBack.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            GameManager.instance.SetNextSceneName(SceneName.Index);
            TransitionView.instance.OpenTransition();
        });

        BtnDelete.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            ShowDeleteBtn(true);
            SwitchDelBtn(false);
        });

        BtnDefault.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            ShowDeleteBtn(false);
            SwitchDelBtn(true); 
        });

        BtnPre.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            PersonManager.instance.CurPersonPageIndex = Mathf.Max(0, PersonManager.instance.CurPersonPageIndex - 1);
            PageScrollEndFunc(PersonManager.instance.CurPersonPageIndex,(int)ListContent.anchoredPosition.x);
        });

        BtnNext.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            PersonManager.instance.CurPersonPageIndex = Mathf.Min(PersonManager.instance.CurPersonPageIndex + 1, PersonManager.instance.PageCount - 1);
            PageScrollEndFunc(PersonManager.instance.CurPersonPageIndex, (int)ListContent.anchoredPosition.x);
        });

        BtnDetailBack.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            HideDetail();
        });

        BtnDetailEdit.onClick.AddListener(delegate
        {
            GameManager.instance.SetOpenType(OpenType.ReEdit);
            GameManager.instance.SetJoinShowAll(true);
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            string fileName = PersonManager.instance.PersonPathList[CalenderController.instance.SelectItemId];
            PartDataWhole whole = PersonManager.instance.DeserializePerson(fileName);
            GameManager.instance.homeSelectIndex = whole.ModelIndex;
            GameManager.instance.SetOpenType(OpenType.ReEdit);
            GameManager.instance.SetCurPartDataWhole(whole);
            GameManager.instance.curJoinType = whole.JoinType;
            PersonManager.instance.PersonFileName = fileName;
            GameManager.instance.SetNextSceneName(SceneName.Join);
            GameManager.instance.CalendarDetailShow =false;
            TransitionView.instance.OpenTransition();
        });

        BtnDetailGame.onClick.AddListener(delegate
        {
            GameManager.instance.openType = OpenType.ReEdit;
            GameManager.instance.displayType = DisplayType.NoDisplay;//从画册进入，没有展示页
            string fileName = PersonManager.instance.PersonPathList[CalenderController.instance.SelectItemId];
            PartDataWhole whole = PersonManager.instance.DeserializePerson(fileName);
            GameManager.instance.SetCurPartDataWhole(whole);
            GameManager.instance.curJoinType = whole.JoinType;
            GameManager.instance.homeSelectIndex = whole.ModelIndex;
            //PersonManager.instance.PersonFileName = fileName;
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            UIHelper.instance.LoadPrefab("Prefabs/game/window|window_choosegame", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
        });

        BtnDetailDownload.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            string path = PersonManager.instance.PersonImgPath + "/" + PersonManager.instance.PersonPathList[CalenderController.instance.SelectItemId]+PersonManager.instance.PicPrefix;// + ".png";
            UnityToIOS_SavePhotoToAlbum(path);
        });
    }

    private void BackFunc()
    {
        AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
        GameManager.instance.SetNextSceneName(SceneName.Index);
        TransitionView.instance.OpenTransition();
    }

    public void ShowDeleteBtn(bool show)
    {
        for (int i = 0; i < pageList.Count; i++)
        {
            pageList[i].SetDeleteStatus(show);
        }
    }
   
    public void SwitchDelBtn(bool show)
    {
        CalenderController.instance.IsDelete = !show;
        BtnDelete.gameObject.SetActive(show);
        BtnDefault.gameObject.SetActive(!show);
    }
    
    private void DeleteItemComplete(CalenderItem deleteItem)
    {
        Debug.Log("111" + PersonManager.instance.PageCount);
        Debug.Log("222" + PersonManager.instance.CurPersonPageIndex);
        if (PersonManager.instance.PageCount == PersonManager.instance.CurPersonPageIndex)
        {
            PersonManager.instance.CurPersonPageIndex--;
        }
        Debug.Log("删除后当前页面:" + PersonManager.instance.CurPersonPageIndex);
        PageScrollEndFunc(PersonManager.instance.CurPersonPageIndex, (int)ListContent.anchoredPosition.x);

        if (PersonManager.instance.PersonCount == 0)
        {
            BackFunc();
        }
    }

    public CalenderItem GetCalendarItemByIndex(int itemIndex)
    {
        Debug.Log("itemindex:" + itemIndex);
        int curPageItemIndex = itemIndex % 6;
        Debug.Log("curPageItemIndex:" + curPageItemIndex);
        if (CurCalendarPage==null)
        {
            Debug.Log("page is null");
        }
        Debug.Log("curitempageIndex:" + CurCalendarPage.PageIndex);
        Debug.Log("count:" + CurCalendarPage.PersonItemList.Count);
        CalenderItem item = CurCalendarPage.PersonItemList[curPageItemIndex];
        Debug.Log("item.index:" + item.Index);
        if (item==null)
        {
            Debug.Log("item is null");
        }
        else
        {
            Debug.Log("item is not null");
        }
        return item;
        //return CurCalendarPage.PersonItemList[curPageItemIndex];
    }

    private void PlayGame()
    {
        GameManager.instance.CalendarDetailShow = true;
    }

    private void OnDestroy()
    {
        pageList = null;
        RemoveEventListener();
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
