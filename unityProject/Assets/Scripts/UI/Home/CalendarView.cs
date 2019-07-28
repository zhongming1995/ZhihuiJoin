﻿using DataMgr;
using Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarView : MonoBehaviour
{
    public Button BtnBack;
    public Transform ListContent;

    private List<CalenderItem> personList = new List<CalenderItem>();

    void Start()
    {
        AddBtnListener();
        List<string> pathList = PersonManager.instance.GetPersonsList();

        StartCoroutine(LoadPersonList(pathList));
    }

    private void AddBtnListener()
    {
        BtnBack.onClick.AddListener(delegate {
            Destroy(gameObject);
        });
    }
    
    IEnumerator LoadPersonList(List<string> pathList)
    {
        int index = 0;
        while (index < pathList.Count)
        {
            UIHelper.instance.LoadPrefabAsync("Prefabs/calendar|calendar_item", ListContent, Vector3.zero, Vector3.one, false, null, (item) => {
                Debug.Log(pathList[index]);
                PartDataWhole whole = PersonManager.instance.DeserializePerson(pathList[index]);
                item.name = pathList[index];
                CalenderItem calenderItem = item.GetComponent<CalenderItem>();
                calenderItem.Init(whole);
                personList.Add(calenderItem);
                index += 1;
            });
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void ShowDeleteBtn(bool show)
    {
        for (int i = 0; i < personList.Count; i++)
        {
            personList[i].ShowDelete(show);
        }
    }
}