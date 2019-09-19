using GameMgr;
using Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using AudioMgr;
using System.Runtime.InteropServices;
using DataMgr;

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
    //public Transform DetailItem;
    //public RawImage DetailRawImage;
    public Button BtnDetailBack;
    public Button BtnDetailDownload;
    public Button BtnDetailEdit;
    public Button BtnDetailGame;
    public Transform LeftFlag;
    public Transform RightFlag;
    public Transform DetailView;

    private List<CalendarPage> pageList = new List<CalendarPage>();
    private float PageWidth;
    private float PageHeight;
    private GameObject DetailItem;
    private Vector3 OriDetailPosition;
    private CalenderItem CurSelectItem;

    [DllImport("__Internal")]
    private static extern void UnityToIOS_SavePhotoToAlbum(string path);

    void Start()
    {
        AddBtnListener();
        AddEventListener();
        InitPageContent();
        InitPageList();
        SetPageText();
        SetPageSwitchBtn();
        SwitchDelBtn(true);
        HideDetail();
    }

    private void InitPageContent()
    {
        Vector2 realScreen = UIHelper.instance.GetRealScreen();
        PageWidth = realScreen.x;
        PageHeight = realScreen.y;

        CalenderController.instance.PerPageWidth = PageWidth;
        CalenderController.instance.PerPageHeight = PageHeight;
    }

    private void InitPageList()
    {
        StartCoroutine(Cor_InitPageList());
    }

    IEnumerator Cor_InitPageList()
    {
        int endPage = Mathf.Min(CalenderController.instance.PageNum, 3);
        int i = 0; 
        WaitForSeconds delay = new WaitForSeconds(1.0f);
        while (i < endPage)
        {
            AddOnePage(i);
            i++;
            yield return delay;
        }
    }

    /// <summary>
    /// 增加一个页面
    /// </summary>
    /// <param name="_index">真实页面索引</param>
    private void AddOnePage(int _index,Action cb = null)
    {
        GameObject page = UIHelper.instance.LoadPrefab("Prefabs/calendar|calendar_page", ListContent, Vector3.zero, Vector3.one, false);
        page.name = _index.ToString();
        page.GetComponent<RectTransform>().sizeDelta = new Vector2(CalenderController.instance.PerPageWidth, CalenderController.instance.PerPageHeight);
        CalendarPage calendarPage = page.GetComponent<CalendarPage>();
        calendarPage.LoadItems(_index,true);
        pageList.Add(calendarPage);
        if (cb!=null)
        {
            cb();
        }
    }

    private void SetPageText()
    {
        TxtPage.text = (CalenderController.instance.CurPageIndex + 1).ToString() + " / " + CalenderController.instance.PageNum.ToString();
    }

    private void SetPageSwitchBtn()
    {
        if (CalenderController.instance.CurPageIndex == 0)
        {
            BtnPre.gameObject.SetActive(false);
        }
        else
        {
            BtnPre.gameObject.SetActive(true);
        }
        if (CalenderController.instance.CurPageIndex == CalenderController.instance.PageNum-1)
        {
            BtnNext.gameObject.SetActive(false);
        }
        else
        {
            BtnNext.gameObject.SetActive(true);
        }
    }

    private void AddEventListener()
    {
        CalenderController.deleteItemComplete += DeleteItemComplete;
        CalendarPageScroll.pageScrollEnd += PageScrollEndFunc;
        CalenderController.deletePageComplete += DeletePageComplete;
        CalenderController.chooseOneItem += ChooseOneItem;
    }

    private void RemoveEventListener()
    {
        CalenderController.deleteItemComplete -= DeleteItemComplete;
        CalendarPageScroll.pageScrollEnd -= PageScrollEndFunc;
        CalenderController.deletePageComplete -= DeletePageComplete;
        CalenderController.chooseOneItem -= ChooseOneItem;
    }

    void ChooseOneItem(CalenderItem item)
    {
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

    public void RefreshList(int index)
    {
        pageList.Clear();
        CalenderController.instance.GetPersonList();
        CalenderController.instance.CurPageIndex = 0;
        for (int i = ListContent.childCount-1; i >= 0; i--)
        {
            DestroyImmediate(ListContent.GetChild(i).gameObject);
        }
        InitPageList();
        SetPageText();
        SetPageSwitchBtn();
        PageScrollEndFunc(0);
    }

    public void RefreshPerson(int pageIndex,int itemIndex)
    {
        pageList[pageIndex].RefreshOneItem(pageIndex, itemIndex);
    }

    private void PageScrollEndFunc(int _curIndex)
    {
        SetPageSwitchBtn();
        int perItemX = (int)CalenderController.instance.PerPageWidth;
        float endPos = -_curIndex * perItemX - perItemX / 2;
        ListContent.DOLocalMoveX(endPos, 0.3f).OnComplete(SetPageText);
        for (int i = _curIndex + 1; i < _curIndex + 2; i++)
        {
            if (i <= CalenderController.instance.PageNum - 1)
            {
                if (i > ListContent.childCount - 1)
                {
                    AddOnePage(i);
                }
                else
                {
                    if (pageList[i].ShouldRefresh)
                    {
                        pageList[i].LoadItems(i, false);
                    }
                }
            }
        }
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
            CalenderController.instance.CurPageIndex = Mathf.Max(0, CalenderController.instance.CurPageIndex - 1);
            PageScrollEndFunc(CalenderController.instance.CurPageIndex);
        });

        BtnNext.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            CalenderController.instance.CurPageIndex = Mathf.Min(CalenderController.instance.CurPageIndex + 1,CalenderController.instance.PageNum-1);
            PageScrollEndFunc(CalenderController.instance.CurPageIndex);
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
            string fileName = PersonManager.instance.pathList[CalenderController.instance.SelectItemId];
            PartDataWhole whole = PersonManager.instance.DeserializePerson(fileName);
            GameManager.instance.homeSelectIndex = whole.ModelIndex;
            GameManager.instance.SetOpenType(OpenType.ReEdit);
            GameManager.instance.SetCurPartDataWhole(whole);
            GameManager.instance.curJoinType = whole.JoinType;
            PersonManager.instance.PersonFileName = fileName;
            GameManager.instance.SetNextSceneName(SceneName.Join);
            TransitionView.instance.OpenTransition();
        });

        BtnDetailGame.onClick.AddListener(delegate
        {
            GameManager.instance.openType = OpenType.ReEdit;
            string fileName = PersonManager.instance.pathList[CalenderController.instance.SelectItemId];
            PartDataWhole whole = PersonManager.instance.DeserializePerson(fileName);
            GameManager.instance.SetCurPartDataWhole(whole);
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            UIHelper.instance.LoadPrefab("Prefabs/game/window|window_choosegame", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
        });

        BtnDetailDownload.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            string path = PersonManager.instance.PersonImgPath + "/" + PersonManager.instance.pathList[CalenderController.instance.SelectItemId] + ".png";
            UnityToIOS_SavePhotoToAlbum(path);
        });
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
        if (deleteItem != null)
        {
            DestroyImmediate(deleteItem.gameObject);
            pageList[deleteItem.PageIndex].DeleteOneItem(deleteItem.PageIndex,deleteItem);

            for (int i = deleteItem.PageIndex + 1; i < pageList.Count; i++)
            {
                pageList[i].ShouldRefresh = true;
            }

            //后两页
            for (int i = deleteItem.PageIndex + 1; i <= deleteItem.PageIndex + 2; i++)
            {
                if (i >= pageList.Count)
                {
                    return;
                }
                pageList[i].LoadItems(i,false);
            }
            deleteItem = null;
            SetPageText();
        }
    }

    private void DeletePageComplete(CalendarPage deletePage)
    {
        Debug.Log("pre:" + CalenderController.instance.CurPageIndex);
        if (deletePage)
        {
            Debug.Log("deletePage");
            pageList.Remove(deletePage);
            DestroyImmediate(deletePage.gameObject);
            deletePage = null;
            if (CalenderController.instance.CurPageIndex == CalenderController.instance.PageNum)
            {
                Debug.Log("pageNum:" + CalenderController.instance.PageNum);
                CalenderController.instance.CurPageIndex -= 1;
            }
            Debug.Log("curPageIndex:" + CalenderController.instance.CurPageIndex);
            PageScrollEndFunc(CalenderController.instance.CurPageIndex);
            Debug.Log(CalenderController.instance.PersonNum);
            if (CalenderController.instance.PersonNum<=0)
            {
                GameManager.instance.SetNextSceneName(SceneName.Index);
                TransitionView.instance.OpenTransition();
            }
        }
    }

    private void OnDestroy()
    {
        pageList = null;
        RemoveEventListener();
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
