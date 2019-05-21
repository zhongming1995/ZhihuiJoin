using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CardView : MonoBehaviour
{
    public Transform card;
    public Button btnFlip;

    // Start is called before the first frame update
    void Start()
    {

    }

    void AddClickEvent()
    {
        btnFlip.onClick.AddListener(delegate
        {
            Sequence s = DOTween.Sequence();
            s.Append(card.DORotate(new Vector3(0, 90, 0), 0.5f).OnComplete()));
        }
   }

    void FlipCard()
    {

    }
}