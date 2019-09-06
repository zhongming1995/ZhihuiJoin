using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using GameMgr;

public class CalenderController : SingletonMono<CalenderController>
{
    public delegate void DeleteItemComplete(CalenderItem item);
    public static event DeleteItemComplete deleteItemComplete;

    public delegate void DeletePageComplete(CalendarPage page);
    public static event DeletePageComplete deletePageComplete;

    [HideInInspector]
    public List<CalendarPage> PageList = new List<CalendarPage>();
    [HideInInspector]
    public List<string> pathList;//保存的人物的路径列表
    //public List<string> ImgPathList;//保存的人物的图片路径列表
    public int PersonNum { get; set; }//人物总数

    private int curPgeIndex;
    public int CurPageIndex {
        get 
        {
            return curPgeIndex;
        }
        set 
        {
            curPgeIndex = value;
            PersonManager.instance.CurPersonPageIndex = value;
        }
    }//真实页面索引，根据这个索引加载对应的人物列表
    public int PageNum{ get; set; }//总页数
    public float PerPageWidth{get;set; }
    public float PerPageHeight{get; set; }
    public bool IsDelete = false;//处于删除状态
    public bool HasDelete = false;//删除过元素

    private void Awake()
    {
        instance = this;
        GetPersonList();
    }

    public List<string> GetPersonList()
    {
        pathList = PersonManager.instance.GetPersonsList();
        PersonNum = pathList.Count;
        GetPageNum(PersonNum);
        return pathList;
    }

    public void GetPageNum(int personNum)
    {
        int lastNumber = pathList.Count % 6;
        if (lastNumber == 0)
        {
            PageNum = pathList.Count / 6;
        }
        else
        {
            PageNum = pathList.Count / 6 + 1;
        }
        Debug.Log("pageNum:" + PageNum);
    }

    public void DeleteComplete(CalenderItem item)
    {
        PersonManager.instance.DeletePerson(item.fileName);
        pathList.Remove(item.fileName);
        PersonNum--;
        GetPageNum(PersonNum);
        if (deleteItemComplete != null)
        {
            deleteItemComplete(item);
        }
    }

    public void DeletePageFunc(CalendarPage page)
    {
        if (deletePageComplete!=null)
        {
            deletePageComplete(page);
        }
    }
}