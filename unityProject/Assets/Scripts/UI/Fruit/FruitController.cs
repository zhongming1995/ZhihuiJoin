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

    public delegate void ComeToBasket(FruitItem item);
    public static event ComeToBasket comeToBasket;

    void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// 产生随机种类的水果
    /// </summary>
    /// <returns>The fruit type.</returns>
    public int GenFruitType()
    {
        Random rd = new Random();
        int n = rd.Next(1, 3);//右边的不包括
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
            endIndex = 10;//产生随机数时，右侧不包含
        }
        Random rd = new Random();
        int n = rd.Next(startIndex, endIndex);
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
        return posIndexList;
    }

    public void SetChapter(int c)
    {
        chapter = c;
        getFruitCount = 0;
    }

    public void SetBasketRect(RectTransform rectTransform)
    {
        basketRectTransform = rectTransform;
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

    public void FruitToBasket(FruitItem item)
    {
        getFruitCount += 1;
        if (comeToBasket != null)
        {
            comeToBasket(item);
        }
    }

}
