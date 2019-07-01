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
        //window.gameObject.SetActive(true);
        //mask.gameObject.SetActive(true);
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
        GameObject person = null;
        if (DataManager.instance.partDataList != null)
        {
            person = DataManager.instance.GetPersonObj(DataManager.instance.partDataList);
        }
        person.transform.SetParent(WindowPersonParent);
        person.transform.localScale = new Vector3(0.83f, 0.83f, 0.83f);
        person.transform.localPosition = Vector3.zero;

        windowlstDisplayItem = DataManager.instance.GetListDiaplayItem(person.transform);

        //加上按钮
        Button btn = person.gameObject.AddComponent<Button>();
        btn.onClick.AddListener(Greeting);
        //默认打招呼一次
        Greeting();
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
    }

    void CloseWindow()
    {
        Destroy(gameObject);
    }

    public void Greeting()
    {
        Debug.Log("Greeting==============");
        DataManager.instance.PersonGreeting(windowlstDisplayItem);
    }

    void OnDestroy()
    {
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
