using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarriageAni : MonoBehaviour
{
    public float delayTime;
    public float topPosY = 7;
    public float bottomPosY = -7;

    private float oriPosY;
    // Start is called before the first frame update
    void Start()
    {
        oriPosY = transform.localPosition.y;
        Invoke("CarriageMove", delayTime);
    }

    void CarriageMove()
    {
        Sequence s = DOTween.Sequence();
        s.Append(transform.DOLocalMoveY(oriPosY+topPosY, 1));
        s.Append(transform.DOLocalMoveY(oriPosY+bottomPosY, 2));
        s.Append(transform.DOLocalMoveY(oriPosY, 1f));
        s.SetLoops(-1, LoopType.Yoyo);
    }

}
