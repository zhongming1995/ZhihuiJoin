﻿using DataMgr;
using GameMgr;
using Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CalendarView : MonoBehaviour
{
    public Button BtnBack;
    public Button BtnDelete;
    public Button BtnDefault;
    public RectTransform ListContent;
    public Text TxtPage;
    public Button BtnPre;
    public Button BtnNext;

    //当前页面的人物列表
    //private List<CalenderItem> personList = new List<CalenderItem>();

    private List<CalendarPage> pageList = new List<CalendarPage>();
    private float PageWidth;
    private float PageHeight;

    void Start()
    {
        AddBtnListener();
        AddEventListener();
        InitPageContent();
        InitPageList();
        SetPageText();
        SetPageSwitchBtn();
        //RefreshList();
        //SwitchDelBtn(true);
    }

    private void InitPageContent()
    {
        CanvasScaler canvas = GameManager.instance.GetCanvas().GetComponent<CanvasScaler>();
        float canvasScaler = canvas.matchWidthOrHeight;
        Vector2 referenceResolution = canvas.referenceResolution;
        if (canvasScaler == 1)//高适配
        {
            PageHeight = referenceResolution.y;
            PageWidth = 1.0f * Screen.width / Screen.height * referenceResolution.y;
        }
        else
        {
            PageWidth = referenceResolution.x;
            PageHeight = 1.0f * 2048 / (Screen.width / Screen.height);
        }

        CalenderController.instance.PerPageWidth = PageWidth;
        CalenderController.instance.PerPageHeight = PageHeight;

        /*
        int pageCount = Mathf.Min(CalenderController.instance.PageNum, 3);
        ListContent.sizeDelta = new Vector2(pageCount * PageWidth, PageHeight);
        
        LayoutRebuilder.ForceRebuildLayoutImmediate(ListContent);
        */
    }

    //初始化页面列表，最多3个
    private void InitPageList()
    {
        int endPage = Mathf.Min(CalenderController.instance.PageNum, 3);
        for (int i = 0; i < endPage; i++)
        {
            //GameObject page = UIHelper.instance.LoadPrefab("Prefabs/calendar|calendar_page", ListContent, Vector3.zero, Vector3.one, false);            CalendarPage calendarPage = page.transform.GetComponent<CalendarPage>();
            //calendarPage.LoadItems(i);
            AddOnePage(i);
        }
    }

    /// <summary>
    /// 增加一个页面
    /// </summary>
    /// <param name="_index">真实页面索引</param>
    private void AddOnePage(int _index)
    {
        UIHelper.instance.LoadPrefabAsync("Prefabs/calendar|calendar_page", ListContent, Vector3.zero, Vector3.one, false,null,(page)=> {
            page.name = _index.ToString();
            page.GetComponent<RectTransform>().sizeDelta = new Vector2(CalenderController.instance.PerPageWidth, CalenderController.instance.PerPageHeight);
            CalendarPage calendarPage = page.GetComponent<CalendarPage>();
            calendarPage.LoadItems(_index);
        });
    }

    /*
    private void GetPageList()
    {
        CalenderController.instance.PageList.Clear();
        if (CalenderController.instance.CurPageIndex == 0)
        {
            for (int i = 0; i < ListContent.childCount; i++)
            {
                Transform item = ListContent.GetChild(i);
                CalendarPage page = item.GetComponent<CalendarPage>();
                //当前是第一页
                page.LoadItems(i);
                CalenderController.instance.PageList.Add(page);
            }
        }
        else if (CalenderController.instance.CurPageIndex == CalenderController.instance.PageNum - 1)
        {
            int j = 0;
            for (int i = ListContent.childCount-1; i >= 0; i--)
            {
                Transform item = ListContent.GetChild(i);
                CalendarPage page = item.GetComponent<CalendarPage>();
                //当前是第一页
                page.LoadItems(CalenderController.instance.CurPageIndex-j);
                CalenderController.instance.PageList.Add(page);
                j++;
            }
        }
        else
        {
            for (int i = 0; i < ListContent.childCount; i++)
            {
                Transform item = ListContent.GetChild(i);
                CalendarPage page = item.GetComponent<CalendarPage>();
                //当前是第一页
                page.LoadItems(i);
                CalenderController.instance.PageList.Add(page);
            }
        }
    }
    */

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
    }

    private void RemoveEventListener()
    {
        CalenderController.deleteItemComplete -= DeleteItemComplete;
        CalendarPageScroll.pageScrollEnd -= PageScrollEndFunc;
    }

    public void RefreshList()
    {
        //StartCoroutine(LoadPersonList(CalenderController.instance.GetPersonList()));
    }

    private void PageScrollEndFunc(int _curIndex)
    {
        SetPageSwitchBtn();
        int perItemX = (int)CalenderController.instance.PerPageWidth;
        float endPos = -_curIndex * perItemX - perItemX / 2;
        ListContent.DOLocalMoveX(endPos, 0.3f).OnComplete(SetPageText);
        for (int i = _curIndex + 1; i < _curIndex + 2; i++)
        {
            if (i > ListContent.childCount -1)
            {
                AddOnePage(i);
            }
        }
    }

    private void AddBtnListener()
    {
        BtnBack.onClick.AddListener(delegate {
            Destroy(gameObject);
        });

        BtnDelete.onClick.AddListener(delegate {
            /*
            ShowDeleteBtn(true);
            SwitchDelBtn(false);
            */
        });

        BtnDefault.onClick.AddListener(delegate {
            /*
            ShowDeleteBtn(false);
            SwitchDelBtn(true);
            */
        });

        BtnPre.onClick.AddListener(delegate {
            CalenderController.instance.CurPageIndex = Mathf.Max(0, CalenderController.instance.CurPageIndex - 1);
            PageScrollEndFunc(CalenderController.instance.CurPageIndex);
        });

        BtnNext.onClick.AddListener(delegate {
            CalenderController.instance.CurPageIndex = Mathf.Min(CalenderController.instance.CurPageIndex + 1,CalenderController.instance.PageNum-1);
            PageScrollEndFunc(CalenderController.instance.CurPageIndex);
        });
    }
    /*
    IEnumerator LoadPersonList(List<string> pathList)
    {
        Debug.Log(pathList.Count);
        int index = 0;
        while (index < pathList.Count)
        {
            UIHelper.instance.LoadPrefabAsync("Prefabs/calendar|calendar_item", ListContent, Vector3.zero, Vector3.one, false, null, (item) => {
                Debug.Log(pathList[index]);
                PartDataWhole whole = PersonManager.instance.DeserializePerson(pathList[index]);
                item.name = pathList[index];
                CalenderItem calenderItem = item.GetComponent<CalenderItem>();
                calenderItem.Init(index,pathList[index],whole);
                personList.Add(calenderItem);
                index += 1;
            });
            yield return new WaitForSeconds(0.05f);
        }
    }
    */

    /*
    public void ShowDeleteBtn(bool show)
    {
        for (int i = 0; i < personList.Count; i++)
        {
            personList[i].ShowDelete(show);
        }
    }
    */

    /*
    public void SwitchDelBtn(bool isDelete)
    {
        BtnDelete.gameObject.SetActive(isDelete);
        BtnDefault.gameObject.SetActive(!isDelete);
    }
    */

    public void DeleteItemComplete(CalenderItem deleteItem)
    {/*
        if (deleteItem != null)
        {
            personList.Remove(deleteItem);
            DestroyImmediate(deleteItem.gameObject);
        }*/
    }

    private void OnDestroy()
    {
        RemoveEventListener();
    }
}
