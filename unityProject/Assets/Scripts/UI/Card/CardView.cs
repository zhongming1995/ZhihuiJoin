using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Helper;
using GameMgr;
using System;

public class CardView : MonoBehaviour
{
    public Button BtnBack;
    public Button BtnBackCheck;
    //public Transform card;
    //public Button btnFlip;
    //private bool forward;

    private void OnEnable()
    {
        GameOperDelegate.backToEdit += BackToEditFunc;
        GameOperDelegate.pianoBegin += PlayPiano;
        GameOperDelegate.cardBegin += PlayCard;
    }

    private void OnDisable()
    {
        GameOperDelegate.backToEdit -= BackToEditFunc;
        GameOperDelegate.pianoBegin -= PlayPiano;
        GameOperDelegate.cardBegin -= PlayCard;
    }

    // Start is called before the first frame update
    void Start()
    {
        AddClickEvent();
        //SetOrigin(card);
        //隐藏返回按钮
        ShowBackBtn(false);
    }

    //显示返回按钮，否则是半透明状态
    public void ShowBackBtn(bool show)
    {
        BtnBack.gameObject.SetActive(show);
        BtnBackCheck.gameObject.SetActive(!show);
    }

    void AddClickEvent()
    {
        BtnBackCheck.onClick.AddListener(delegate
        {
            ShowBackBtn(true);
        });

        BtnBack.onClick.AddListener(delegate
        {
            //暂停游戏
            string path = "Prefabs/game|window_pause";
            UIHelper.instance.LoadPrefab(path, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
        });
        //btnFlip.onClick.AddListener(delegate
        //{
        //    Debug.Log("flip--------");
        //    if (forward)
        //    {
        //        ToBackward(card);
        //    }else
        //    {
        //        ToForward(card);
        //    }
        //    forward = !forward;
        //});
    }

    //翻到背面
    void ToBackward(Transform t)
    {
        //Sequence s = DOTween.Sequence();
        //s.Append(t.GetChild(1).DORotate(new Vector3(0, 90, 0), 0.5f));
        //s.Append(t.GetChild(0).DORotate(new Vector3(0, 0, 0), 0.5f));
    }

    //翻到正面
    void ToForward(Transform t)
    {
        //Sequence s = DOTween.Sequence();
        //s.Append(t.GetChild(0).DORotate(new Vector3(0, 90, 0), 0.5f));
        //s.Append(t.GetChild(1).DORotate(new Vector3(0, 0, 0), 0.5f));
    }

    void SetOrigin(Transform t)
    {
        //forward = true;
        //t.GetChild(1).rotation = new Quaternion(0, 0, 0,0);
        //t.GetChild(0).rotation = new Quaternion(0, 90, 0, 0);
    }

    public void BackToEditFunc()
    {
        Destroy(gameObject);
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

    void PlayPiano()
    {

    }

    void PlayCard()
    {
        //Destroy(completeWindow);
        Destroy(gameObject);
        GameManager.instance.SetNextViewPath("prefabs/game/card|card_view");
        UIHelper.instance.LoadPrefab("prefabs/common|transition_prefab_view", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
    }

    void OnDestroy()
    {
        AppEntry.instance.SetMultiTouchEnable(false);
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

}