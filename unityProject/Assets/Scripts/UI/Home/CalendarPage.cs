using Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//画册页
public class CalendarPage:MonoBehaviour
{
    public Transform ItemContent;

    //本页面的人物列表
    [HideInInspector]
    public List<CalenderItem> personList = new List<CalenderItem>();
    //当前页面索引
    [HideInInspector]
    public int PageIndex;
    private int ItemCount = 6;//每页人物个数

    public bool ShouldRefresh = false;//前面页面删除了元素，本页需要刷新列表
    public bool isDeleting = false;//正在删除状态

    private int startItemIndex;
    private int endItemIndex;
    private int trueItemCount;

    public void LoadItems(int _index,bool first)
    {
        Debug.Log("LoadPageIndex：" + _index);
        if (_index < 0 || _index>CalenderController.instance.PageNum-1)
        {
            CalenderController.instance.DeletePageFunc(this);
            return;
        }
        StartCoroutine(Cor_LoadItems(_index,first));
    }

    IEnumerator Cor_LoadItems(int _index,bool first)
    {
        ShouldRefresh = false;
        Debug.Log("Cor_LoadItems===========================" + ItemContent.childCount);
        PageIndex = _index;
        trueItemCount = 0;
        
        for (int j = ItemContent.childCount-1; j >=  0; j--)
        {
            DestroyImmediate(ItemContent.GetChild(j).gameObject);
        }
        
        personList.Clear();
        startItemIndex = 6 * _index;
        endItemIndex = 6 * _index + 6;
        Debug.Log("star:" + startItemIndex + " end:" + endItemIndex);
        int i = startItemIndex;
        while (i < endItemIndex)
        {
            UIHelper.instance.LoadPrefabAsync("Prefabs/calendar|calendar_item", ItemContent, Vector3.zero, Vector3.one, false, null, (item) => {
                if (i<CalenderController.instance.PersonNum)
                {
                    trueItemCount++;
                    string path = CalenderController.instance.pathList[i];
                    PartDataWhole whole = PersonManager.instance.DeserializePerson(path);
                    CalenderItem calenderItem = item.GetComponent<CalenderItem>();
                    calenderItem.Init(PageIndex,i, path, whole);
                    personList.Add(calenderItem);
                }
                else
                {
                    CalenderItem calenderItem = item.GetComponent<CalenderItem>();
                    calenderItem.Init();
                }
                i++;
            });
            yield return new WaitForSeconds(0.01f); 
        }
        if (CalenderController.instance.IsDelete)
        {
            SetDeleteStatus(true);
        }

        if (trueItemCount==0)
        {
            CalenderController.instance.DeletePageFunc(this);
        }
    }

    public void RefreshList(int _index,CalenderItem deleteItem)
    {
        Debug.Log("RefreshList========================");
        PageIndex = _index;
        int index = endItemIndex - 1;
        personList.Remove(deleteItem);
        UIHelper.instance.LoadPrefabAsync("Prefabs/calendar|calendar_item", ItemContent, Vector3.zero, Vector3.one, false, null, (item) => {
            if (index < CalenderController.instance.PersonNum)
            {
                string path = CalenderController.instance.pathList[index];
                PartDataWhole whole = PersonManager.instance.DeserializePerson(path);
                CalenderItem calenderItem = item.GetComponent<CalenderItem>();
                calenderItem.Init(PageIndex, index, path, whole);
                personList.Add(calenderItem);
                if (CalenderController.instance.IsDelete)
                {
                    calenderItem.ShowDelete(true);
                }
            }
            else
            {
                trueItemCount -= 1; ;
                Debug.Log("load null:" + index + " count:" + trueItemCount);
                CalenderItem calenderItem = item.GetComponent<CalenderItem>();
                calenderItem.Init();
            }
            if (trueItemCount <= 0)
            {
                CalenderController.instance.DeletePageFunc(this);
            }
        });
        
    }

    public void SetDeleteStatus(bool isDelete)
    {
        for (int i = 0; i < personList.Count; i++)
        {
            personList[i].ShowDelete(isDelete);
        }
    }

    private void OnDestroy()
    {
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}