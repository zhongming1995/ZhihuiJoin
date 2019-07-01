using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class FruitController : SingletonMono<FruitController>
{
    [HideInInspector]
    public int chapter = 1;//第几关，123关对应果树上4,6,10个水果

    private int startIndex;
    private int endIndex;

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
    }

    public void FruitToBasket(FruitItem item)
    {
        if (comeToBasket != null)
        {
            comeToBasket(item);
        }
    }

}
