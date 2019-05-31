using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonScaleAni : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IPointerClickHandler
{
    public float duration = 0.1f;
    public Vector3 originValue = new Vector3(1.0f, 1.0f, 1.0f);
    public Vector3 endValue = new Vector3(0.85f, 0.85f, 0.85f);

    public void OnPointerClick(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(endValue, duration);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale(originValue, duration);
    }

}
