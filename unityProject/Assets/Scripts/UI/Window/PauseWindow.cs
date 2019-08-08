using System;
using System.Collections;
using System.Collections.Generic;
using AudioMgr;
using GameMgr;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseWindow : WindowParent
{
    public Button BtnHome;
    public Button BtnEdit;
    public Button BtnReplay;//在用
    public Button BtnDisplay;//在用
    public Button BtnContinue;//在用
    public Button BtnClose;

    private void OnEnable()
    {
        InAni(()=> { Time.timeScale = 0; });
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

        BtnDisplay.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            CloseWindow();
            if (GameManager.instance.openType == OpenType.FirstEdit)
            {
                DisplayView displayView = transform.parent.GetComponentInChildren<DisplayView>(true);
                displayView.gameObject.SetActive(true);
            }            
            GameOperDelegate.GotoDisplay();
        });

        BtnContinue.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            CloseWindow();
        });

        BtnClose.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            CloseWindow();
        });
    }

    void CloseWindow()
    {
        Time.timeScale = 1;
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
