using System;
using GameMgr;
using Helper;
using UnityEngine;
using UnityEngine.UI;

public class ChooseGameWindow : MonoBehaviour
{
    public Button BtnPiano;
    public Button BtnCard;
    public Button BtnClose;

    private DisplayView displayView;

    //public delegate void PianoBegin();
    //public static event PianoBegin pianoBegin;

    //public delegate void CardBegin();
    //public static event CardBegin cardBegin;

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
        Destroy(gameObject);

    }

    void OnDestroy()
    {
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

}
