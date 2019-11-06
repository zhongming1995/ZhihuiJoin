using AudioMgr;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonCommonAni : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    public Transform targetTrans;
    public Vector3 originValue = new Vector3(1.0f, 1.0f, 1.0f);
    public Vector3 endValue = new Vector3(0.98f, 0.98f, 0.98f);
    public Vector3 middleValue = new Vector3(1.1f, 1.1f, 1.1f);
    public float duration = 0.1f;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (targetTrans == null)
        {
            targetTrans = transform;
        }
        targetTrans.DOScale(endValue, duration);
        AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
    }
     
    public void OnPointerUp(PointerEventData eventData)
    {
        Sequence s = DOTween.Sequence();
        s.Append(targetTrans.DOScale(middleValue, duration));
        s.Append(targetTrans.DOScale(originValue, duration));
    }

}
