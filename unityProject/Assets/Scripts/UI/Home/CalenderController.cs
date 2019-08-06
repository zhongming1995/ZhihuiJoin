using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class CalenderController : SingletonMono<CalenderController>
{
    public delegate void DeleteItemComplete(CalenderItem item);
    public static event DeleteItemComplete deleteItemComplete;

    [HideInInspector]
    public List<CalendarPage> PageList = new List<CalendarPage>();
    [HideInInspector]
    public List<string> pathList;//保存的人物的路径列表
    public int PersonNum { get; set; }//人物总数
    public int CurPageIndex { get; set; }//真实页面索引，根据这个索引加载对应的人物列表
    public int PageNum{ get; set; }//总页数
    public float PerPageWidth{get;set; }
    public float PerPageHeight{get; set; }

    private void Awake()
    {
        instance = this;
        GetPersonList();
    }

    public List<string> GetPersonList()
    {
        pathList = PersonManager.instance.GetPersonsList();
        int lastNumber = pathList.Count % 6;
        Debug.Log("num:" + pathList.Count);
        if (lastNumber == 0)
        {
            PageNum = pathList.Count / 6;
        }
        else
        {
            PageNum = pathList.Count / 6 + 1;
        }
        PersonNum = pathList.Count;
        Debug.Log("pageNum:" + PageNum);
        return pathList;
    }

    public void DeleteComplete(CalenderItem item)
    {
        pathList.Remove(item.name);
        PersonNum--;
        if (deleteItemComplete != null)
        {
            deleteItemComplete(item);
        }
    }
}