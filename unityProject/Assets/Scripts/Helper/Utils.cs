using UnityEngine;
using System.Collections;

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

    public static float GetPicHeightRate(Texture2D t)
    {
        int texWidth = t.width;
        int texHeight = t.height;
        Debug.Log(texWidth + "," + texHeight);
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
        for (float i = 0f; i <= 1f; i = i + 0.03f)
        {
            for (float j = 0f; j <= 1f; j = j + 0.03f)
            {
                Debug.Log("i,j:================" + i + "," + j);
                int x = (int)(i * texWidth);
                int y = (int)(j * texHeight);
                byte hitColorR = maskPixels[(texWidth * y + x) * 4 + 0];
                byte hitColorG = maskPixels[(texWidth * y + x) * 4 + 1];
                byte hitColorB = maskPixels[(texWidth * y + x) * 4 + 2];
                byte hitColorA = maskPixels[(texWidth * y + x) * 4 + 3];
                Debug.Log("hitA=============" + hitColorA);

                if (hitColorA != 0)//透明部分不可绘画
                {
                    resultJ = j;
                    return resultJ;
                }
            }
        }
        return resultJ;
    }
}
