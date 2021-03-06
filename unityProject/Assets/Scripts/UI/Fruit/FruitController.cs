﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class FruitController : SingletonMono<FruitController>
{
    [HideInInspector]
    public int chapter = 1;//第几关，123关对应果树上4,6,10个水果
    public int getFruitCount = 0;//已经取得的水果

    private int startIndex;
    private int endIndex;
    private RectTransform basketRectTransform;
    private int needFruitCount; //需要的水果数
    private int lastFruitType = -1;//上一次的水果类型
    private int tempGetFruitCount = 0;
    private Vector3 oriBaksetPos;

    public delegate void ComeToBasketBegin(bool chapterEnd,int num);
    public static event ComeToBasketBegin comeToBasketBegin;//入蓝开始
    public delegate void ComeToBasketEnd(FruitItem item,bool chapterEnd, int num);
    public static event ComeToBasketEnd comeToBasketEnd;//入篮结束

    public delegate void Operation();
    public static event Operation operationStart;
    public static event Operation operationEnd;

    public delegate void DepthChange(FruitItem item);
    public static event DepthChange depthChangeStart;
    public static event DepthChange depthChangeEnd;

    void Awake()
    {
        instance = this;
    }
  

    public void OperationEnd()
    {
        if (operationEnd!=null)
        {
            operationEnd();
        }
    }

    public void OperationStart()
    {
        if (operationStart!= null)
        {
            operationStart();
        }
    }

    public void DepthChangeStart(FruitItem item)
    {
        if (depthChangeStart!=null)
        {
            depthChangeStart(item);
        }
    }

    public void DepthChangeEnd(FruitItem item)
    {
        if (depthChangeEnd != null)
        {
            depthChangeEnd(item);
        }
    }

    /// <summary>
    /// 产生随机种类的水果
    /// </summary>
    /// <returns>The fruit type.</returns>
    public int GenFruitType()
    {
        Random rd = new Random();
        int n = rd.Next(1, 4);//右边的不包括
        while (lastFruitType == n)
        {
            n = rd.Next(1, 4);
        }
        lastFruitType = n;
        return n;
    }

    /// <summary>
    /// 根据关卡产生随机目标数量
    /// </summary>
    /// <returns>The target number.</returns>
    /// <param name="c">C.</param>
    public int GenFruitNumber(int c)
    {
        if (c==1)
        {
            startIndex = 1;
            endIndex = 3;//产生随机数时，右侧不包含
        }else if (c==2)
        {
            startIndex = 4;
            endIndex = 6;//产生随机数时，右侧不包含
        }
        else
        {
            startIndex = 7;
            endIndex = 9;//产生随机数时，右侧不包含
        }
        Random rd = new Random();
        int n = rd.Next(startIndex, endIndex+1);
        needFruitCount = n;
        return n;
    }

    /// <summary>
    /// 根据关卡产生水果出现的位置坐标
    /// </summary>
    /// <returns>The fruit index.</returns>
    /// <param name="c">C.</param>
    public List<int> GenFruitIndex(int count)
    {
        List<int> posIndexList = new List<int>();
        for (int i = 0; i < count; i++)
        {
            Random rd = new Random();
            int n = rd.Next(0,9);
            while (posIndexList.Contains(n))
            {
                n = rd.Next(0,9);
            }
            posIndexList.Add(n);
        }
        posIndexList.Sort();
        return posIndexList;
    }

    public void SetChapter(int c)
    {
        chapter = c;
        getFruitCount = 0;
        needFruitCount = 0;
        tempGetFruitCount = 0;
    }

    public void SetBasketRect(RectTransform rectTransform)
    {
        basketRectTransform = rectTransform;
        oriBaksetPos = basketRectTransform.transform.position;
    }

    public bool isFruitInBasketRect(RectTransform rect2)
    {
        Vector3[] corners1 = new Vector3[4];
        basketRectTransform.GetWorldCorners(corners1);
        corners1[2].x = Mathf.Abs(corners1[2].x - corners1[0].x);
        corners1[2].y = Mathf.Abs(corners1[2].y - corners1[0].y);
        Rect b1 = new Rect(corners1[0].x, corners1[0].y, corners1[2].x, corners1[2].y);

        rect2.GetWorldCorners(corners1);
        corners1[2].x = Mathf.Abs(corners1[2].x - corners1[0].x);
        corners1[2].y = Mathf.Abs(corners1[2].y - corners1[0].y);
        Rect b2 = new Rect(corners1[0].x, corners1[0].y, corners1[2].x, corners1[2].y);
        return b1.Overlaps(b2);
    }

    public void FruitToBasketBegin(FruitItem item)
    {
        tempGetFruitCount = tempGetFruitCount + 1;
        bool chapterEnd = false;
        if (tempGetFruitCount >= needFruitCount)
        {
            chapterEnd = true;
        }
        if (comeToBasketBegin != null)
        {
            comeToBasketBegin(chapterEnd, tempGetFruitCount);
        }
    }

    public void FruitToBasketEnd(FruitItem item)
    {
        bool chapterEnd = false;
        getFruitCount += 1;
        if (getFruitCount >= needFruitCount)
        {
            chapterEnd = true;
        }
        if (comeToBasketEnd != null)
        {
            comeToBasketEnd(item,chapterEnd,getFruitCount);
        }
    }

    public Vector3 GetFruitDesPos()
    {
        Random rd = new Random();
        float offsetX = UnityEngine.Random.Range(-0.8f, 0.8f);
        float offsetY = UnityEngine.Random.Range(-0.3f, -0.2f);
        Vector3 desPos = new Vector3(oriBaksetPos.x+offsetX, oriBaksetPos.y+offsetY,0);
        return desPos;
    }

}
