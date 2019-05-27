using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CardView : MonoBehaviour
{
    //public Transform card;
    //public Button btnFlip;
    //private bool forward;

    // Start is called before the first frame update
    void Start()
    {
        //AddClickEvent();
        //SetOrigin(card);
    }

    void AddClickEvent()
    {
        //btnFlip.onClick.AddListener(delegate
        //{
        //    Debug.Log("flip--------");
        //    if (forward)
        //    {
        //        ToBackward(card);
        //    }else
        //    {
        //        ToForward(card);
        //    }
        //    forward = !forward;
        //});
    }

    //翻到背面
    void ToBackward(Transform t)
    {
        //Sequence s = DOTween.Sequence();
        //s.Append(t.GetChild(1).DORotate(new Vector3(0, 90, 0), 0.5f));
        //s.Append(t.GetChild(0).DORotate(new Vector3(0, 0, 0), 0.5f));
    }

    //翻到正面
    void ToForward(Transform t)
    {
        //Sequence s = DOTween.Sequence();
        //s.Append(t.GetChild(0).DORotate(new Vector3(0, 90, 0), 0.5f));
        //s.Append(t.GetChild(1).DORotate(new Vector3(0, 0, 0), 0.5f));
    }

    void SetOrigin(Transform t)
    {
        //forward = true;
        //t.GetChild(1).rotation = new Quaternion(0, 0, 0,0);
        //t.GetChild(0).rotation = new Quaternion(0, 90, 0, 0);
    }

}