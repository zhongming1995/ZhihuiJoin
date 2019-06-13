using System;
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
        BtnClose.onClick.AddListener(CloseWindow);

        BtnPiano.onClick.AddListener(delegate
        {
            CloseWindow();
            GameOperDelegate.PlayPiano();
        });
        BtnCard.onClick.AddListener(delegate
        {
            CloseWindow();
            GameOperDelegate.PlayCard();
        });
    }

    void CloseWindow()
    {
        OutAni();
    }

    void OnDestroy()
    {
        Debug.Log("Destroy");
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

}
