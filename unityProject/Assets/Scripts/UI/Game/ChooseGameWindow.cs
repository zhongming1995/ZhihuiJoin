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

    public delegate void PianoBegin();
    public static event PianoBegin pianoBegin;

    public delegate void CardBegin();
    public static event CardBegin cardBegin;

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
            //displayView.gameObject.SetActive(false);
            pianoBegin?.Invoke();
            GameManager.instance.SetNextViewPath("prefabs/game/piano|piano_view");
            UIHelper.instance.LoadPrefab("prefabs/common|transition_prefab_view", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
            CloseWindow();
        });
        BtnCard.onClick.AddListener(delegate
        {
            //displayView.gameObject.SetActive(false);
            cardBegin?.Invoke();
            GameManager.instance.SetNextViewPath("prefabs/game/card|card_view");
            UIHelper.instance.LoadPrefab("prefabs/common|transition_prefab_view", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
            CloseWindow();
        });
    }

    void CloseWindow()
    {
        Destroy(gameObject);
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

}
