using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class PianoKey : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler,IPointerUpHandler
{
    private PianoView pianoView;
    public int keyIndex { get; set; }

    public void Init(int index)
    {
        keyIndex = index;
        pianoView = GetComponentInParent<PianoView>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //if (Application.platform==RuntimePlatform.OSXEditor||Application.platform==RuntimePlatform.WindowsEditor)
        //{
        //    DoKeyDown(transform);
        //}
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
        //{
            DoKeyDown(transform);
        //}
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    void DoKeyDown(Transform t)
    {
        Sequence s = DOTween.Sequence();
        s.Append(t.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.1f));
        s.Append(t.DOScale(new Vector3(1, 1, 1), 0.1f));
        pianoView.PlayPiano(keyIndex);
    }
}
