using System;
using System.Collections;
using System.Collections.Generic;
using AudioMgr;
using DataMgr;
using GameMgr;
using Helper;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CompleteWindow : WindowParent
{
    public Button BtnHome;
    public Button BtnEdit;
    public Button BtnGame;
    public Button BtnDisplay;
    public Button BtnReplay;
    public Transform WindowPersonParent;

    private DisplayPartItem[] windowlstDisplayItem;

    private void OnEnable()
    {
        //window.gameObject.SetActive(false);
        //mask.gameObject.SetActive(false);

        window.localScale = Vector3.zero;
        mask.transform.localScale = Vector3.zero;
        Invoke("Show", 1.0f);
    }

    void Show()
    {
        window.localScale = Vector3.zero;
        mask.transform.localScale = Vector3.one;
        InAni(Greeting);
    }


    void Start()
    {
        AddClickEvent();
        Invoke("LoadPerson", 0f);
    }

    void LoadPerson()
    {
        /*同步
        GameObject person = null;
        if (DataManager.instance.partDataList != null)
        {
            person = DataManager.instance.GetPersonObj(DataManager.instance.partDataList);
        }
        person.transform.SetParent(WindowPersonParent);
        person.transform.localScale = new Vector3(0.83f, 0.83f, 0.83f);
        person.transform.localPosition = Vector3.zero;
        windowlstDisplayItem = DataManager.instance.GetListDiaplayItem(person.transform);
        */
        if (DataManager.instance.partDataList != null)
        {
            GameObject person = DataManager.instance.GetPersonObj(DataManager.instance.partDataList);
            person.transform.SetParent(WindowPersonParent);
            person.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            person.transform.localPosition = Vector3.zero;

            windowlstDisplayItem = DataManager.instance.GetListDiaplayItem(person.transform);

            //加上按钮
            Button btn = person.gameObject.AddComponent<Button>();
            btn.onClick.AddListener(Greeting);
            
        }
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
            Destroy(displayView.gameObject);
            joinMainView.gameObject.SetActive(true);
            joinMainView.BackToJoinEdit();
            CloseWindow();
            GameOperDelegate.GotoEdit();
        });

        BtnGame.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            UIHelper.instance.LoadPrefab("Prefabs/game/window|window_choosegame", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
        });

        BtnDisplay.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            CloseWindow();
            /*
            GameManager.instance.displayType = DisplayType.BackDisplay;
            if (GameManager.instance.openType==OpenType.FirstEdit||GameManager.instance.openType==OpenType.BackEdit)
            {
                GameManager.instance.SetNextViewPath(PanelName.DisplayView);
                UIHelper.instance.LoadPrefab(PanelName.TransitionView, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
            }
            else
            {
                GameManager.instance.SetNextViewPath(PanelName.CalendarDetailView);
                UIHelper.instance.LoadPrefab(PanelName.TransitionView, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
            }
            */
            if (GameManager.instance.displayType==DisplayType.NoDisplay)
            {
                //GameManager.instance.SetNextViewPath(PanelName.CalendarDetailView);
                //UIHelper.instance.LoadPrefab(PanelName.TransitionView, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
                GameManager.instance.SetNextSceneName(SceneName.CalendarDetail);
                TransitionView.instance.OpenTransition();
            }
            else
            {
                GameManager.instance.displayType = DisplayType.BackDisplay;
                //GameManager.instance.SetNextViewPath(PanelName.DisplayView);
                //UIHelper.instance.LoadPrefab(PanelName.TransitionView, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
                GameManager.instance.SetNextSceneName(SceneName.Display);
                TransitionView.instance.OpenTransition();
            }

            GameOperDelegate.GotoDisplay();
        });

        BtnReplay.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            CloseWindow();
            GameOperDelegate.Replay();
        });
    }

    void CloseWindow()
    {
        Destroy(gameObject);
    }

    public void Greeting()
    {
        DoubleGreeting();
        Invoke("DoubleGreeting", 1.5f);
    }

    private void DoubleGreeting()
    {
        DataManager.instance.PersonJumpAndWave(windowlstDisplayItem);
    }

    void OnDestroy()
    {
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
