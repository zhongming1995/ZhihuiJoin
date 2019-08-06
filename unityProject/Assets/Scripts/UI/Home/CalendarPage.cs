using Helper;
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

    public void LoadItems(int _index)
    {
        if (_index < 0 || _index>CalenderController.instance.PageNum-1)
        {
            return;
        }
        StartCoroutine(Cor_LoadItems(_index));
    }

    IEnumerator Cor_LoadItems(int _index)
    {
        PageIndex = _index;
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        int startItemIndex = 6 * _index;
        int endItemIndex = 6 * _index + 6;

        int i = startItemIndex;
        while (i < endItemIndex)
        {
            UIHelper.instance.LoadPrefabAsync("Prefabs/calendar|calendar_item", ItemContent, Vector3.zero, Vector3.one, false, null, (item) => {
                if (i<CalenderController.instance.PersonNum)
                {
                    Debug.Log("loadpersosn:"+i);
                    string path = CalenderController.instance.pathList[i];
                    PartDataWhole whole = PersonManager.instance.DeserializePerson(path);
                    CalenderItem calenderItem = item.GetComponent<CalenderItem>();
                    calenderItem.Init(i, path, whole);
                    personList.Add(calenderItem);
                }
                else
                {
                    Debug.Log("load null:"+i);
                    CalenderItem calenderItem = item.GetComponent<CalenderItem>();
                    calenderItem.Init();
                }
                i++;
            });
            yield return new WaitForSeconds(0.05f);
        }
    }

}