using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeIn : MonoBehaviour
{
    float alpha;
    CanvasGroup canvasGroup;

    public delegate void FadeInComplete();
    public static FadeInComplete fadeInComplete;

    void Start()
    {
        if (canvasGroup==null)
        {
            GetCanvasGroup();
        }
        alpha = 0;
        StartCoroutine("Cor_FadeIn");
    }

    void GetCanvasGroup()
    {
        if (canvasGroup !=null)
        {
            return;
        }
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            gameObject.AddComponent<CanvasGroup>();
        }
    }

    IEnumerator Cor_FadeIn()
    {
        while(alpha<=1.1f)
        {
            canvasGroup.alpha = alpha;
            alpha += 0.05f;
            yield return new WaitForSeconds(0.01f);//0.2s完成
        }
        fadeInComplete?.Invoke();
    }
}
