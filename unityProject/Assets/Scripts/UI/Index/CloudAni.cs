using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CloudAni : MonoBehaviour
{
    private IndexView indexView;
    private DOTweenPath tweener;
    // Start is called before the first frame update
    void Start()
    {
        indexView = GetComponentInParent<IndexView>();
        tweener = transform.GetComponent<DOTweenPath>();
    }

    private void OnEnable()
    {
        Invoke("DoScaleAni", 0.5f);
        Invoke("DoRotateAni", 1.3f);
        Invoke("DoFadeAni", 2f);
        //if (tweener!=null)
        //{
        //    tweener.DORestart();
        //}
    }

    void DoScaleAni()
    {
        Sequence s = DOTween.Sequence();
        s.Append(transform.DOScale(1, 1.5f));
        s.Append(transform.DOScale(0.5f, 1f));
    }

    void DoRotateAni()
    {
        transform.DORotate(new Vector3(0, 0, 40), 1.5f);
    }

    void DoFadeAni()
    {
        transform.GetComponent<Image>().DOFade(0f, 0.5f).OnComplete(HandleTweenCallback);;
    }

    void HandleTweenCallback()
    {
        //gameObject.SetActive(false);
        //indexView.CloudEnterPool(gameObject);
    }

}
