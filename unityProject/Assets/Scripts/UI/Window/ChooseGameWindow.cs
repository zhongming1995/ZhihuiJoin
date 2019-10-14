using System;
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
            GameManager.instance.SetNextSceneName(SceneName.Piano);
            TransitionView.instance.OpenTransition();

        });

        BtnCard.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            DestroyWindow();
            GameOperDelegate.PlayCard();
            GameManager.instance.SetNextSceneName(SceneName.Card);
            TransitionView.instance.OpenTransition();
        });

        BtnFruit.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            DestroyWindow();
            GameOperDelegate.PlayFruit();
            GameManager.instance.SetNextSceneName(SceneName.Fruit);
            TransitionView.instance.OpenTransition();
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
