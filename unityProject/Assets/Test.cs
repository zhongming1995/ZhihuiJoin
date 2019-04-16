using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ButtonRotate(transform);
    }

    private void ButtonRotate(Transform t)
    {
        // Tweener tw = t.DOLocalRotate(new Vector3(0, 0, 15f), 0.5f).OnComplete(delegate
        //{
        //    t.DOLocalRotate(new Vector3(0, 0, -15f), 1f).OnComplete(delegate
        //         {
        //           t.DOLocalRotate(new Vector3(0, 0, 0), 0.5f);
        //       });
        //});
        //tw.SetLoops(100,LoopType.Yoyo);
        Sequence s = DOTween.Sequence();
        s.Append(t.DOLocalRotate(new Vector3(0, 0, 15f), 0.5f));
        s.Append(t.DOLocalRotate(new Vector3(0, 0, -15f), 1f));
        s.Append(t.DOLocalRotate(new Vector3(0, 0, 0), 0.5f));
        s.SetEase(Ease.Flash);
        s.SetLoops(-1,LoopType.Restart);
    }


}
