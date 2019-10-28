using UnityEngine;
using System.Collections;
using System;

//一个公共的帮助类
public class Utils 
{
    public static float ParticleSystemLength(Transform transform)
    {
        ParticleSystem[] particleSystems = transform.GetComponentsInChildren<ParticleSystem>();
        float maxDuration = 0;
        foreach (ParticleSystem ps in particleSystems)
        {
            if (ps.enableEmission)
            {
                if (ps.loop)
                {
                    return -1f;
                }
                float dunration = 0f;
                if (ps.emissionRate <= 0)
                {
                    dunration = ps.startDelay + ps.startLifetime;
                }
                else
                {
                    dunration = ps.startDelay + Mathf.Max(ps.duration, ps.startLifetime);
                }
                if (dunration > maxDuration)
                {
                    maxDuration = dunration;
                }
            }
        }
        return maxDuration;
    }

    //从下到上0-1
    public static float GetPicHeightRate(Texture2D t)
    {
        int texWidth = t.width;
        int texHeight = t.height;
        byte[] maskPixels = new byte[texWidth * texHeight * 4];
        int pixel = 0;
        Color32[] tempPixels = t.GetPixels32();//获取mask纹理
        int tempCount = tempPixels.Length;

        for (int i = 0; i < tempCount; i++)
        {
            maskPixels[pixel] = tempPixels[i].r;
            maskPixels[pixel + 1] = tempPixels[i].g;
            maskPixels[pixel + 2] = tempPixels[i].b;
            maskPixels[pixel + 3] = tempPixels[i].a;
            pixel += 4;
        }

        float resultJ = 1;
        for (float j = 0f; j <= 1f; j = j + 0.03f)
        {
            for (float i = 0f; i <= 1f; i = i + 0.03f)
            {
                //Debug.Log("i,j:================" + i + "," + j);
                int x = (int)(i * texWidth);
                int y = (int)(j * texHeight); 
                byte hitColorR = maskPixels[(texWidth * y + x) * 4 + 0];
                byte hitColorG = maskPixels[(texWidth * y + x) * 4 + 1];
                byte hitColorB = maskPixels[(texWidth * y + x) * 4 + 2];
                byte hitColorA = maskPixels[(texWidth * y + x) * 4 + 3];
                //Debug.Log("hitA=============" + hitColorA);

                if (hitColorA != 0)//透明部分不可绘画
                {
                    resultJ = j;
                    return resultJ;
                }
            }
        }
        return resultJ;
    }

    //判断两个矩形是否包含
    public static bool IsRectTransformInside(RectTransform rect1, RectTransform rect2)
    {
        Debug.Log(rect1.anchoredPosition);
        Debug.Log(rect2.anchoredPosition);
        float rect1MinX = rect1.anchoredPosition.x - rect1.rect.width / 2;//矩形1的左x
        float rect1MaxX = rect1.anchoredPosition.x + rect1.rect.width / 2;//矩形1的右x
        float rect1MinY = rect1.anchoredPosition.y - rect1.rect.height / 2;//矩形1的下y
        float rect1MaxY = rect1.anchoredPosition.y + rect1.rect.height / 2;//矩形1的上y

        float rect2MinX = rect2.anchoredPosition.x - rect2.rect.width / 2;//矩形1的左x
        float rect2MaxX = rect2.anchoredPosition.x + rect2.rect.width / 2;//矩形1的右x
        float rect2MinY = rect2.anchoredPosition.y - rect2.rect.height / 2;//矩形1的下y
        float rect2MaxY = rect2.anchoredPosition.y + rect2.rect.height / 2;//矩形1的上y

        //rect2包含rect1
        bool IsInside1 = rect1MinX >= rect2MinX && rect1MaxX <= rect2MaxX && rect1MinY >= rect2MinY && rect1MaxY <= rect2MaxY;
        //rect1包含rect2
        bool IsInside2 = rect2MinX >= rect1MinX && rect2MaxX <= rect1MaxX && rect2MinY >= rect1MinY && rect2MaxY <= rect1MaxY;
        bool notOverlap = IsInside1 || IsInside2;
        return notOverlap;
    }

    //判断两个矩形是否相交
    public static bool IsRectTransformOverlap(RectTransform rect1, RectTransform rect2)
    {
        float rect1MinX = rect1.position.x - rect1.rect.width / 2;
        float rect1MaxX = rect1.position.x + rect1.rect.width / 2;
        float rect1MinY = rect1.position.y - rect1.rect.height / 2;
        float rect1MaxY = rect1.position.y + rect1.rect.height / 2;

        float rect2MinX = rect2.position.x - rect2.rect.width / 2;
        float rect2MaxX = rect2.position.x + rect2.rect.width / 2;
        float rect2MinY = rect2.position.y - rect2.rect.height / 2;
        float rect2MaxY = rect2.position.y + rect2.rect.height / 2;

        bool xNotOverlap = rect1MaxX <= rect2MinX || rect2MaxX <= rect1MinX;
        bool yNotOverlap = rect1MaxY <= rect2MinY || rect2MaxY <= rect1MinY;

        bool notOverlap = xNotOverlap || yNotOverlap;
        return !notOverlap;
    }

    //获取当前时间戳
    public static string GetTimeStamp()
    {
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(ts.TotalMilliseconds).ToString();
    }
}
