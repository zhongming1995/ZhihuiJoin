using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Helper;
using GameMgr;
using System;
using Random = System.Random;

public class CardView : MonoBehaviour
{
    public Button BtnBack;
    public Button BtnBackCheck;
    public GridLayoutGroup cardContent;

    private int chapter = 4;

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

    void Start()
    {
        AddClickEvent();
        //隐藏返回按钮
        ShowBackBtn(false);
        InitGame();
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
    }

    public void BackToEditFunc()
    {
        Destroy(gameObject);
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

    void InitGame()
    {
        cardContent.constraint = GridLayoutGroup.Constraint.FixedRowCount;
        if (chapter==1)
        {
            cardContent.constraintCount = 2;
        }else if (chapter==2)
        {
            cardContent.constraintCount = 2;
        }else if (chapter == 3)
        {
            cardContent.constraintCount = 2;
        }
        else
        {
            cardContent.constraintCount = 3;
        }
        //牌下标
        List<int> cardIndexList = CardController.instance.GenCard(chapter);
        //打印
        Debug.Log("-----------index-----------");
        for (int i = 0; i < cardIndexList.Count; i++)
        {
            Debug.Log(cardIndexList[i]);
        }

        //打乱顺序
        Debug.Log("-----------牌------------");
        List<int> randomList = new List<int>();
        while (cardIndexList.Count>0)
        {
            //取随机数
            Random random = new Random();
            int listIndex = random.Next(0, cardIndexList.Count);
            int cardIndex = cardIndexList[listIndex];
            randomList.Add(cardIndex);
            cardIndexList.RemoveAt(listIndex);
            Debug.Log(cardIndex);
        }

        //产生牌
        for (int i = 0; i < randomList.Count; i++)
        {
            GameObject card = UIHelper.instance.LoadPrefab("Prefabs/game/card|card_item", cardContent.transform, Vector3.zero, Vector3.one, false);
            CardItem cardItem = card.GetComponent<CardItem>();
            string path = GameManager.instance.homePathList[randomList[i]];
            cardItem.InitCard(randomList[i], path);
        }
    }

    void PlayPiano()
    {

    }

    void PlayCard()
    {
        //Destroy(gameObject);
        //GameManager.instance.SetNextViewPath("prefabs/game/card|card_view");
        //UIHelper.instance.LoadPrefab("prefabs/common|transition_prefab_view", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
    }

    void OnDestroy()
    {
        AppEntry.instance.SetMultiTouchEnable(false);
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

}