using System;
using System.Collections;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public delegate void FadeInComplete(PanelEnum panelEnum);
    public static FadeInComplete fadeInComplete;

    public delegate void FadeOutComplete(PanelEnum panelEnum);
    public static FadeOutComplete fadeOutComplete;

    public PanelEnum panelEnum;

    private int enableCount = 0;
    private bool isCallBack = false;
    CanvasGroup[] groups;
    bool groupGets = false;

    private void OnEnable()
    {
        if (groupGets==false)
        {
            groups = transform.GetComponentsInChildren<CanvasGroup>();
        }
        enableCount += 1; 
        if (panelEnum == PanelEnum.TransitionView && enableCount == 1)
        {
            if (fadeInComplete!=null)
            {
                fadeInComplete(panelEnum);
            }
            return;
        }
        FadeInFunc();
    }

    void FadeInFunc()
    {
        //Debug.Log("-------------fadein");
        isCallBack = false;
        if (groups.Length == 0)
        {
            if (fadeInComplete != null)
            {
                fadeInComplete(panelEnum);
            }
        }

        for (int i = 0; i < groups.Length; i++)
        {
            if (!groups[i].ignoreParentGroups)
            {
                StartCoroutine(Cor_FadeIn(groups[i], () => {
                    if (isCallBack == false)
                    {
                        isCallBack = true;
                        fadeInComplete?.Invoke(panelEnum);
                    }
                }));
            }
        }
    }
  
    IEnumerator Cor_FadeIn(CanvasGroup canvasGroup,Action cb = null)
    {
        //Debug.Log("-------------corfadein");
        float alpha = 0f;
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

    public void FadeOutFunc()
    {
        //Debug.Log("-------------fadeout");
        isCallBack = false;
        if (groups.Length == 0)
        {
            if (fadeOutComplete != null)
            {
                fadeOutComplete(panelEnum);
            }
        }

        for (int i = 0; i < groups.Length; i++)
        {
            if (!groups[i].ignoreParentGroups)
            {
                StartCoroutine(Cor_FadeOut(groups[i], () => {
                    if (isCallBack == false)
                    {
                        isCallBack = true;
                        fadeOutComplete?.Invoke(panelEnum);
                    }
                }));
            }
        }
    }


    IEnumerator Cor_FadeOut(CanvasGroup canvasGroup, Action cb = null)
    {
        //Debug.Log("-------------corfadeout");
        float alpha = 1f;
        WaitForSeconds delay = new WaitForSeconds(0.01f);
        while (alpha >= 0f)
        {
            canvasGroup.alpha = alpha;
            alpha -= 0.05f;
            yield return delay;//0.2s完成
        }
        if (cb != null)
        {
            cb();
        }
    }
}
