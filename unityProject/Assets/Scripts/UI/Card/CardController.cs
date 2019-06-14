using System.Collections;
using System.Collections.Generic;
using GameMgr;
using UnityEngine;
using Random = System.Random;

public class CardController : SingletonMono<CardController>
{
    [HideInInspector]
    public int chapter = 1;//第几关，1234关对应2，3，4，6对牌

    private int startIndex;
    private int endIndex;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    //产生牌
    public List<int> GenCard(int c)
    {
        chapter = c;
        //根据选择的类型确定可选排面的范围
        if (GameManager.instance.curJoinType==JoinType.Letter)
        {
            startIndex = 0;
            endIndex = 25;
        }else
        {
            startIndex = 26;
            endIndex = 36;
        }
        int cardSingleNum = 0;
        Debug.Log("chapter:" + chapter);
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
        Debug.Log("num" + cardSingleNum);
        List<int> cardIndexList = new List<int>();
        cardIndexList.Add(GameManager.instance.homeSelectIndex);//当前选择拼接的牌一定会出现
        cardIndexList.Add(GameManager.instance.homeSelectIndex);//当前选择拼接的牌一定会出现
        for (int i = 0; i < cardSingleNum-1; i++)
        {
            Random rd = new Random();
            int n = GameManager.instance.homeSelectIndex;
            Debug.Log("contains:" + cardIndexList.Contains(n));
            while (cardIndexList.Contains(n))
            {
                n = rd.Next(startIndex,endIndex+1);
                Debug.Log("n:" + n);
            }
            cardIndexList.Add(n);
            cardIndexList.Add(n);
        }

        return cardIndexList;
    }
}
