using Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//画册页
public class CalendarPage:MonoBehaviour
{
    public Transform ItemContent;
    public GameObject calendarItemTemplate;
    //本页面的人物列表
    [HideInInspector]
    public List<CalenderItem> PersonItemList = new List<CalenderItem>();
    //当前页面索引
    [HideInInspector]
    public int PageIndex;//页面索
    private int ItemCount = 6;//每页人物个数
    public bool HaveLoad = false;//加载过
    public bool ShouldRefresh = false;//前面页面删除了元素，本页需要刷新列表

    private int startItemIndex;
    private int endItemIndex;
    private int trueItemCount;

    //加载6个item
    public void LoadSixItems(Action cb = null)
    {
        PersonItemList.Clear();
        for (int i = 0; i < ItemCount; i++)
        {
            GameObject item = UIHelper.instance.ClonePrefab(calendarItemTemplate, ItemContent, Vector3.zero, Vector3.one, false);//加载的时候先不初始化，只加载预制
            CalenderItem calenderItem = item.GetComponent<CalenderItem>();
            calenderItem.ItemInit();
            PersonItemList.Add(calenderItem);
            if (cb != null)
            {
                cb();
            }
        }
    }
    public void RefreshPage(int _pageIndex,Action cb = null)
    {
        PageIndex = _pageIndex;
        startItemIndex = 6 * _pageIndex;
        endItemIndex = 6 * _pageIndex + 6;
        for (int i = startItemIndex; i < endItemIndex; i++)
        {
            if (i < PersonManager.instance.PersonCount)
            {
                string path = PersonManager.instance.PersonPathList[i];
                PersonItemList[i-startItemIndex].SetImage(PageIndex, i, path);
            }
            else
            {
                PersonItemList[i - startItemIndex].SetEmpty();
            }
        }
        //StartCoroutine(Cor_RefreshPage(_pageIndex, cb));
    }

    public IEnumerator Cor_RefreshPage(int _pageIndex,Action cb = null)
    {
        PageIndex = _pageIndex;
        startItemIndex = 6 * _pageIndex;
        endItemIndex = 6 * _pageIndex + 6;
        int i = startItemIndex;
        while (i<endItemIndex)
        {
            if (i < PersonManager.instance.PersonCount)
            {
                string path = PersonManager.instance.PersonPathList[i];
                PersonItemList[i - startItemIndex].SetImage(PageIndex, i, path);
            }
            else
            {
                PersonItemList[i - startItemIndex].SetEmpty();
            }
            i++;
            yield return null;
        }
    }

    public void SetDeleteStatus(bool isDelete)
    {
       for (int i = 0; i < PersonItemList.Count; i++)
        {
            PersonItemList[i].ShowDelete(isDelete);
        }
    }

    private void OnDestroy()
    {
        PersonItemList = null;
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}