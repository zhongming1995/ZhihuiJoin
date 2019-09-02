using System;
using System.Collections;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public delegate void FadeInComplete(PanelEnum panelEnum);
    public static FadeInComplete fadeInComplete;

    public bool isEnable = true;//是否每次
    public PanelEnum panelEnum;

    private int enableCount = 0;
    private bool isCallBack = false;

    private void OnEnable()
    {
        CanvasGroup[] groups = transform.GetComponentsInChildren<CanvasGroup>();
        if (groups.Length==0)
        {
            if (fadeInComplete!=null)
            {
                fadeInComplete(panelEnum);
            }
        }
        if (isEnable)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                if (!groups[i].ignoreParentGroups)
                {
                    StartCoroutine(Cor_FadeIn(groups[i], () => {
                        if (isCallBack==false)
                        {
                            isCallBack = true;
                            fadeInComplete?.Invoke(panelEnum);
                        }
                    }));
                }
            }
        }
        else
        {
            if (enableCount==0)
            {
                for (int i = 0; i < groups.Length; i++)
                {
                    if (!groups[i].ignoreParentGroups)
                    {
                        StartCoroutine(Cor_FadeIn(groups[i], () =>
                        {
                            if (isCallBack == false)
                            {
                                isCallBack = true;
                                fadeInComplete?.Invoke(panelEnum);
                            }
                        }));
                    }
                }
            }
            enableCount++;
        }
    }

    IEnumerator Cor_FadeIn(CanvasGroup canvasGroup,Action cb = null)
    {
        float alpha = 0;
        canvasGroup.interactable = false;
        WaitForSeconds delay = new WaitForSeconds(0.01f);
        while(alpha <= 1.1f)
        {
            canvasGroup.alpha = alpha;
            alpha += 0.05f;
            yield return delay;//0.2s完成
        }
        canvasGroup.interactable = true;
        if (cb!=null)
        {
            cb();
        }
    }
}
