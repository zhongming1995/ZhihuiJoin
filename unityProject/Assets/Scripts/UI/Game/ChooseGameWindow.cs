﻿using System;
using GameMgr;
using Helper;
using UnityEngine;
using UnityEngine.UI;

public class ChooseGameWindow :WindowParent
{
    public Button BtnPiano;
    public Button BtnCard;
    public Button BtnClose;

    private DisplayView displayView;

    void OnEnable()
    {
        InAni();
    }

    // Start is called before the first frame update
    void Start()
    {
        displayView = GameManager.instance.GetCanvas().transform.GetComponentInChildren<DisplayView>();
        AddClickEvent(); 
    }

    void AddClickEvent()
    {
        BtnClose.onClick.AddListener(delegate {
            CloseWindow();
        });

        BtnPiano.onClick.AddListener(delegate
        {
            DestroyWindow();
            GameOperDelegate.PlayPiano();
        });
        BtnCard.onClick.AddListener(delegate
        {
            DestroyWindow();
            GameOperDelegate.PlayCard();
        });
    }

    void CloseWindow(Action callBack = null)
    {
        OutAni(callBack);
    }

    void DestroyWindow()
    {
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

}
