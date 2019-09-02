using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonScaleAni : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IPointerClickHandler
{
    public float duration = 0.1f;
    public Vector3 originValue = new Vector3(1.0f, 1.0f, 1.0f);
    public Vector3 endValue = new Vector3(0.95f, 0.95f, 0.95f);
    public Transform targetTrans;

    public void OnPointerClick(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (targetTrans != null)
        {
            targetTrans.DOScale(endValue, duration);
        }
        else
        {
            transform.DOScale(endValue, duration);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (targetTrans != null)
        {
            targetTrans.DOScale(originValue, duration);
        }
        else
        {
            transform.DOScale(originValue, duration);
        }
    }

}
