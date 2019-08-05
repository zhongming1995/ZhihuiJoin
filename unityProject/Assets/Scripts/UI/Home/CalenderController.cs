using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class CalenderController : SingletonMono<CalenderController>
{
    public delegate void DeleteItemComplete(CalenderItem item);
    public static event DeleteItemComplete deleteItemComplete;

    public List<CalendarPage> PageList = new List<CalendarPage>();
    public List<string> pathList;//保存的人物的路径列表
    public float PerPageWidth
    {
        get;
        set;
    }

    private void Awake()
    {
        instance = this;
    }

    public List<string> GetPersonList()
    {
        pathList = PersonManager.instance.GetPersonsList();
        return pathList;
    }

    public void DeleteComplete(CalenderItem item)
    {
        pathList.Remove(item.name);
        if (deleteItemComplete != null)
        {
            deleteItemComplete(item);
        }
    }
}