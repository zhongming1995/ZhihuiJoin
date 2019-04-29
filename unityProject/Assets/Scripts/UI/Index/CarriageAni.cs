using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarriageAni : MonoBehaviour
{
    public float delayTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CarriageMove", delayTime);
    }

    void CarriageMove()
    {
        Sequence s = DOTween.Sequence();
        s.Append(transform.DOLocalMoveY(7, 1));
        s.Append(transform.DOLocalMoveY(-7, 2));
        s.Append(transform.DOLocalMoveY(0, 1f));
        s.SetLoops(-1, LoopType.Yoyo);
    }

}
