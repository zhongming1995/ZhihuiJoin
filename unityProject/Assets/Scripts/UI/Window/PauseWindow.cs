using System;
using System.Collections;
using System.Collections.Generic;
using AudioMgr;
using GameMgr;
using Helper;
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
        //暂时无用
        BtnHome.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            SceneManager.LoadScene("Home");
            GameOperDelegate.GoToHome();
        });

        //暂时无用
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
            if (GameManager.instance.displayType == DisplayType.NoDisplay)
            {
                GameManager.instance.SetNextViewPath(PanelName.CalendarDetailView);
                UIHelper.instance.LoadPrefab(PanelName.TransitionView, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
            }
            else
            {
                GameManager.instance.displayType = DisplayType.BackDisplay;
                GameManager.instance.SetNextViewPath(PanelName.DisplayView);
                UIHelper.instance.LoadPrefab(PanelName.TransitionView, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
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
