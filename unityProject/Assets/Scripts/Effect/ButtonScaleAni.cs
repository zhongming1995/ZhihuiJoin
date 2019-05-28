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
        Debug.Log("click");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("down");
        transform.DOScale(endValue, duration);
        //transform.localScale = endValue;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("up");
        transform.DOScale(originValue, duration);
        //transform.localScale = originValue;
    }

}
