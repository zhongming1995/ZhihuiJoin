using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMove : MonoBehaviour
{
    public Vector3 FromPos;
    public Vector3 ToPos;
    public float AniTime = 0.2f;
    public float DelayTime;
    public bool isEnterPlay = true;
    public bool isRecycle = false;//是否需要循环使用的
    private int enableCount = 0;

    void OnEnable()
    {
        if (isEnterPlay == true)
        {
            DoAction();
        }
        else
        {
            if (enableCount == 0)
            {
                DoAction();
            }
        }
        enableCount += 1;
    }

    void OnDisable()
    {
        if (isRecycle == true)
        {
            //			transform.localPosition = FormPos;
            transform.GetComponent<RectTransform>().anchoredPosition3D = FromPos;
        }
    }

    void DoAction()
    {
        transform.GetComponent<RectTransform>().anchoredPosition3D = FromPos;
        Sequence mySequence = DOTween.Sequence();
        mySequence.AppendInterval(DelayTime);
        mySequence.Append((transform as RectTransform).DOAnchorPos3D(ToPos, AniTime));
    }

    public void MoveShow()
    {
        if (gameObject.activeSelf==false)
        {
            gameObject.SetActive(true);
        }
        Sequence mySequence = DOTween.Sequence();
        mySequence.AppendInterval(DelayTime);
        mySequence.Append((transform as RectTransform).DOAnchorPos3D(ToPos, AniTime));
    }

    public void MoveHide()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.AppendInterval(DelayTime);
        mySequence.Append((transform as RectTransform).DOAnchorPos3D(FromPos, AniTime));
    }
}
