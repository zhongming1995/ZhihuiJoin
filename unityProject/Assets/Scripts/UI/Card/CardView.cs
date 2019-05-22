using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CardView : MonoBehaviour
{
    public Transform card;
    public Button btnFlip;
    private bool forward;

    // Start is called before the first frame update
    void Start()
    {
        FlipCard();
    }

    void AddClickEvent()
    {
        btnFlip.onClick.AddListener(delegate
        {
            Debug.Log("flip--------");
            forward = !forward;
            Sequence s = DOTween.Sequence();
            Tween rotate1 = card.DORotate(new Vector3(0, 90, 0), 0.5f).OnComplete(FlipCard);
            s.Append(rotate1);
            Tween rotate2 = card.DORotate(new Vector3(0, 180, 0), 0.5f);
            s.Append(rotate2);
        });
    }

    void FlipCard()
    {
        card.GetChild(0).gameObject.SetActive(!forward);
        card.GetChild(1).gameObject.SetActive(forward);
    }

}