using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScale : MonoBehaviour
{
    public Vector3 FromScale = new Vector3(0f, 0f, 0f);
    public Vector3 MiddleScale = new Vector3(1.2f, 1.2f, 1.2f);
    public Vector3 ToScale = new Vector3(1, 1, 1);
    public float DelayTime;
    public float AniTime1 = 0.2f;
    public float AniTime2 = 0.1f;
    private int enableCount = 0;
    public bool isEnterPlay = true;

    void OnEnable()
    {
        if (isEnterPlay == true)
        {
            ScaleShow();
        }
        else
        {
            if (enableCount == 0)
            {
                ScaleShow();
            }
        }

        enableCount += 1;
    }

    public void ScaleShow(Action cb = null)
    {
        if (gameObject.activeSelf==false)
        {
            gameObject.SetActive(true);
        }
        transform.localScale = Vector3.zero;
        Sequence mySequence = DOTween.Sequence();
        mySequence.AppendInterval(DelayTime);
        mySequence.Append(transform.DOScale(MiddleScale, AniTime1));
        mySequence.Append(transform.DOScale(ToScale, AniTime2));
        if (cb != null)
        {
            mySequence.AppendCallback(() => { cb(); });
        }
    }
    public void ScaleHide()
    {
        transform.localScale = Vector3.one;
        Sequence mySequence = DOTween.Sequence();
        mySequence.AppendInterval(DelayTime);
        mySequence.Append(transform.DOScale(FromScale, AniTime1));
    }


}
