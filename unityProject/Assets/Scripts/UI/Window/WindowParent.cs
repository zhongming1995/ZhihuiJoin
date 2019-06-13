using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class WindowParent : MonoBehaviour
{
    public Image mask;
    public Transform window;

    public float oriMaskAlpha = 0f;
    public float desMaskAlpha = 0.4f;
    public float maskDuration = 0.2f;

    public Vector3 oriWindowScale = new Vector3(0, 0, 0);
    public Vector3 desWindowScale = new Vector3(1, 1, 1);
    public float windowDuration = 0.2f;

    public void InAni()
    {
        if (mask == null)
        {
            mask = transform.Find("window_mask").GetComponent<Image>();
        }
        if (window==null)
        {
            window = transform.Find("window_bg");
        }

        //mask
        Color c = mask.color;
        mask.color = new Color(c.r, c.g, c.b, oriMaskAlpha);
        mask.DOFade(desMaskAlpha, maskDuration);

        //window
        window.localScale = oriWindowScale;
        window.DOScale(desWindowScale, windowDuration);
    }

    public void OutAni(Action callBack = null)
    {
        //mask
        mask.DOFade(oriMaskAlpha, maskDuration);

        //window
        window.DOScale(oriWindowScale, windowDuration).OnComplete(()=> {
            callBack?.Invoke();
            OutComplete();
        });
    }

    void OutComplete()
    {
        Destroy(gameObject);
    }
}
