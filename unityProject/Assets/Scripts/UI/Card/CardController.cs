﻿using System.Collections;
using System.Collections.Generic;
using GameMgr;
using UnityEngine;
using Random = System.Random;

public class CardController : SingletonMono<CardController>
{
    [HideInInspector]
    public int chapter = 1;//第几关，1234关对应2，3，4，6对牌

    public delegate void ShieldOper(bool shield);
    public static event ShieldOper shieldOper;

    public delegate void CardDismiss(CardItem item1, CardItem item2);
    public static event CardDismiss cardDismiss;

    public delegate void CardFlipBack(CardItem item1, CardItem item2);
    public static event CardFlipBack cardFlipBack;

    public delegate void ChapterEnd();
    public static event ChapterEnd chapterEnd;

    private int startIndex;
    private int endIndex;
    private List<CardItem> compareList = new List<CardItem>();//用来比较两张牌是否一致的数组
    private List<CardItem> cardAllList = new List<CardItem>();//存在于界面上的牌

    void Awake()
    {
        instance = this;
    }

    //产生牌
    public List<int> GenCard(int c)
    {
        chapter = c;
        Debug.Log("joinType:" + GameManager.instance.curJoinType);
        //根据选择的类型确定可选排面的范围
        if (GameManager.instance.curJoinType==JoinType.Letter)
        {
            startIndex = 0;
            endIndex = 25;
        }else if (GameManager.instance.curJoinType == JoinType.Num)
        {
            startIndex = 26;
            endIndex = 36;
        }
        else
        {
            startIndex = 37;
            endIndex = 42;
        }
        int cardSingleNum = 0;
        if (chapter==1)
        {
            cardSingleNum = 2;
        }else if (chapter==2)
        {
            cardSingleNum = 3;
        }else if (chapter==3)
        {
            cardSingleNum = 4;
        }else if (chapter==4)
        {
            cardSingleNum = 6;
        }
        List<int> cardIndexList = new List<int>();
        cardIndexList.Add(GameManager.instance.homeSelectIndex);//当前选择拼接的牌一定会出现
        cardIndexList.Add(GameManager.instance.homeSelectIndex);//当前选择拼接的牌一定会出现
        for (int i = 0; i < cardSingleNum-1; i++)
        {
            Random rd = new Random();
            int n = GameManager.instance.homeSelectIndex;
            while (cardIndexList.Contains(n))
            {
                n = rd.Next(startIndex,endIndex);
            }
            cardIndexList.Add(n);
            cardIndexList.Add(n);
        }

        return cardIndexList;
    }

    public bool AddCompareList(CardItem card)
    {
        if (compareList.Count==0)//翻一张
        {
            compareList.Add(card);
            return false;
        }

        if (compareList.Count>0)
        {
            shieldOper?.Invoke(true);
            compareList.Add(card);
            if (compareList[0].ID==card.ID)
            {
                cardDismiss?.Invoke(compareList[0],compareList[1]);
                ClearCompareList();
            }
            else
            {
                cardFlipBack?.Invoke(compareList[0],compareList[1]);
                ClearCompareList();
            }
        }
        return true;
    }

    public void ClearCompareList()
    {
        compareList.Clear();
    }

    public void CleadCardAllList()
    {
        cardAllList.Clear();
    }

    public void SetChapter(int c)
    {
        chapter = c;
    }

    public void SetCardAllList(List<CardItem> list)
    {
        cardAllList = list;
    }

    public void DeletePair(int id)
    {
        for (int i = 0; i < cardAllList.Count; i++)
        {
            Debug.Log(cardAllList[i].ID);
        }

        for (int j = 0; j < 2; j++)
        {
            for (int i = 0; i < cardAllList.Count; i++)
            {
                if (cardAllList[i].ID == id)
                {
                    cardAllList.RemoveAt(i);
                }
            }
        }

        for (int i = 0; i < cardAllList.Count; i++)
        {
            Debug.Log(cardAllList[i].ID);
        }

        //判断数组是否空了
        if (cardAllList.Count == 0)
        {
            chapterEnd?.Invoke();
        }
    }
}
