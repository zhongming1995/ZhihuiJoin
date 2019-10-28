using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BreathAni : MonoBehaviour
{
    private Image image;

    void Start()
    {
        image = transform.GetComponent<Image>();
        Sequence s = DOTween.Sequence();
        s.Append(image.DOFade(0.7f, 1f));
        s.Append(image.DOFade(1, 1f));
        s.AppendInterval(0.5f);
        s.SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
