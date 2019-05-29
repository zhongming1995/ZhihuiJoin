﻿using System;
using System.Collections;
using System.Collections.Generic;
using DataMgr;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CompleteWindow : MonoBehaviour
{
    public Button BtnHome;
    public Button BtnEdit;
    public Button BtnReplay;
    public Transform WindowPersonParent;

    private DisplayPartItem[] windowlstDisplayItem;

    void Start()
    {
        AddClickEvent();
        LoadPerson();
    }

    void LoadPerson()
    {
        GameObject person = null;
        if (DataManager.instance.partDataList != null)
        {
            person = DataManager.instance.GetPersonObj(DataManager.instance.partDataList);
        }
        person.transform.SetParent(WindowPersonParent);
        person.transform.localScale = new Vector3(0.83f, 0.83f, 0.83f);
        person.transform.localPosition = Vector3.zero;

        windowlstDisplayItem = DataManager.instance.GetListDiaplayItem(person.transform);

        //加上按钮
        Button btn = person.gameObject.AddComponent<Button>();
        btn.onClick.AddListener(Greeting);
        //默认打招呼一次
        Greeting();
    }

    void AddClickEvent()
    {
        BtnHome.onClick.AddListener(delegate
        {
            SceneManager.LoadScene("Home");
            GameOperDelegate.GoToHome();
        });

        BtnEdit.onClick.AddListener(delegate
        {
            JoinMainView joinMainView = transform.parent.GetComponentInChildren<JoinMainView>(true);
            DisplayView displayView = transform.parent.GetComponentInChildren<DisplayView>(true);
            Destroy(displayView.gameObject);
            joinMainView.gameObject.SetActive(true);
            joinMainView.BackToJoinEdit();
            CloseWindow();
            GameOperDelegate.GotoEdit();
        });

        BtnReplay.onClick.AddListener(delegate
        {
            CloseWindow();
            GameOperDelegate.Replay();
        });
    }

    void CloseWindow()
    {
        Destroy(gameObject);
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

    public void Greeting()
    {
        DataManager.instance.PersonGreeting(windowlstDisplayItem);
    }
}
