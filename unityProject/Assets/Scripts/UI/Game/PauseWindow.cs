using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseWindow : MonoBehaviour
{
    public Button BtnHome;
    public Button BtnEdit;
    public Button BtnReplay;
    public Button BtnClose;


    // Start is called before the first frame update
    void Start()
    {
        AddClickEvent();
    }

    void AddClickEvent()
    {
        BtnHome.onClick.AddListener(delegate
        {
            SceneManager.LoadScene("Home");
            GameOperDelegate.GoToHome();
        });

        BtnEdit.onClick.AddListener(delegate
        {
            JoinMainView joinMainView = transform.parent.GetComponentInChildren<JoinMainView>(true);
            DisplayView displayView = transform.parent.GetComponentInChildren<DisplayView>(true);
            Destroy(gameObject);
            Destroy(displayView.gameObject);
            joinMainView.gameObject.SetActive(true);
            joinMainView.BackToJoinEdit();
            Resources.UnloadUnusedAssets();
            GC.Collect();
            GameOperDelegate.GotoEdit();
        });

        BtnReplay.onClick.AddListener(delegate
        {
            CloseWindow();
            GameOperDelegate.Replay();
        });

        BtnClose.onClick.AddListener(CloseWindow);
    }

    void CloseWindow()
    {
        Destroy(gameObject);
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
