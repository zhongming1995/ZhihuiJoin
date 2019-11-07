using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using AudioMgr;

public class ButtonScaleAni : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IPointerClickHandler
{
    public float duration = 0.1f;
    public Vector3 originValue = new Vector3(1.0f, 1.0f, 1.0f);
    public Vector3 endValue = new Vector3(0.98f, 0.98f, 0.98f);
    public Vector3 middleValue = new Vector3(1.1f, 1.1f, 1.1f);
    public Transform targetTrans;

    public delegate void ButtonClickEvent();
    public ButtonClickEvent buttonClickEvent;

    void Awake()
    {
        if (targetTrans==null)
        {
            targetTrans = transform;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(targetTrans.DOScale(middleValue, 2*duration));
        sequence.Append(targetTrans.DOScale(endValue, 2*duration));
        sequence.AppendCallback(() =>
        {
            if (buttonClickEvent != null)
            {
                buttonClickEvent();
            }
        });
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        targetTrans.DOScale(endValue, duration);
        AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        targetTrans.DOScale(originValue, duration);
    }

}
