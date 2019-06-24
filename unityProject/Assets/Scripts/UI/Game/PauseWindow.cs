using System;
using System.Collections;
using System.Collections.Generic;
using AudioMgr;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseWindow : WindowParent
{
    public Button BtnHome;
    public Button BtnEdit;
    public Button BtnReplay;
    public Button BtnClose;

    private void OnEnable()
    {
        Debug.Log("111111");
        InAni();
    }

    // Start is called before the first frame update
    void Start()
    {
        AddClickEvent();
    }

    void AddClickEvent()
    {
        BtnHome.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            SceneManager.LoadScene("Home");
            GameOperDelegate.GoToHome();
        });

        BtnEdit.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            JoinMainView joinMainView = transform.parent.GetComponentInChildren<JoinMainView>(true);
            DisplayView displayView = transform.parent.GetComponentInChildren<DisplayView>(true);
            DestroyWindow();
            Destroy(displayView.gameObject);
            joinMainView.gameObject.SetActive(true);
            joinMainView.BackToJoinEdit();
            GameOperDelegate.GotoEdit();
        });

        BtnReplay.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            CloseWindow();
            GameOperDelegate.Replay();
        });

        BtnClose.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            CloseWindow();
        });
    }

    void CloseWindow()
    {
        OutAni();
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
