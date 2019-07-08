﻿using System;
using AudioMgr;
using GameMgr;
using Helper;
using UnityEngine;
using UnityEngine.UI;

public class ChooseGameWindow :WindowParent
{
    public Button BtnPiano;
    public Button BtnCard;
    public Button BtnClose;
    public Button BtnFruit;

    void OnEnable()
    {
        InAni();
    }

    // Start is called before the first frame update
    void Start()
    {
        AddClickEvent(); 
    }

    void AddClickEvent()
    {
        BtnClose.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            CloseWindow();
        });

        BtnPiano.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            DestroyWindow();
            GameOperDelegate.PlayPiano();
            UIHelper.instance.LoadPrefab("Prefabs/game/piano|piano_view", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
        });

        BtnCard.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            DestroyWindow();
            GameOperDelegate.PlayCard();
            UIHelper.instance.LoadPrefab("Prefabs/game/card|card_view", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
        });

        BtnFruit.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            DestroyWindow();
            GameOperDelegate.PlayFruit();
            UIHelper.instance.LoadPrefab("Prefabs/game/fruit|fruit_view", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
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