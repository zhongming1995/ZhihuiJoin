using System.Collections.Generic;
using UnityEngine;

public class CalendarDetailController : SingletonMono<CalendarDetailController>
{
    [HideInInspector]
    public List<CalendarDetailItem> detailList = new List<CalendarDetailItem>();
    [HideInInspector]
    public int curDetailIndex;

    private void Awake()
    {
        instance = this;
    }

    public void SetDetailList(List<CalendarDetailItem> _list)
    {
        detailList.Clear();
        detailList = _list;
    }

    public int NextDetail()
    {
        curDetailIndex = Mathf.Min(detailList.Count-1, curDetailIndex + 1);
        return curDetailIndex;
    }

    public int PreDetail()
    {
        curDetailIndex = Mathf.Max(0, curDetailIndex - 1);
        return curDetailIndex;
    }
}