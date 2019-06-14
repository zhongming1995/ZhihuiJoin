using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Helper;
using DG.Tweening;
using System;

public class CardItem : MonoBehaviour
{
    public int ID { get; set; }
    public int Index { get; set; }

    private Transform CardObj;
    private Image ImgCardBg;
    private Image ImgCard;
    private Image ImgBack;
    private Button BtnCard;
    private Button BtnBack;

    private void Start()
    {

    }

    public void InitCard(int id,string path)
    {
        ID = id;
        CardObj = transform.Find("card");
        ImgCardBg = CardObj.Find("img_card_bg").GetComponent<Image>();
        ImgCard = CardObj.Find("img_card_bg/img_card").GetComponent<Image>();
        ImgBack = CardObj.Find("img_back").GetComponent<Image>();
        //BtnCard = ImgCardBg.GetComponent<Button>();
        BtnBack = ImgBack.GetComponent<Button>();

        //设置图片
        UIHelper.instance.SetImage(path, ImgCard, false);

        //设置正反
        //ImgBack.transform.rotation = new Quaternion(0, 90, 0, 0);
        //ImgCardBg.transform.rotation = new Quaternion(0, 0, 0, 0);

        //BtnCard.onClick.AddListener(delegate
        //{
        //    //FlipToBackward();
        //});

        BtnBack.onClick.AddListener(delegate
        {
            Debug.Log("click");
            FlipToForward(CompareCard);
        });
    }

    void CompareCard()
    {
        CardController.instance.AddCompareList(this);
    }

    public void FlipToForward(Action action=null)
    {
        action?.Invoke();

        Debug.Log("翻到正面");
        Sequence s = DOTween.Sequence();
        s.Append(ImgBack.transform.DORotate(new Vector3(0, 90,0), 0.25f));
        s.Append(ImgCardBg.transform.DORotate(new Vector3(0, 0, 0), 0.25f));

    }

    public void FlipToBackward(Action action=null)
    {
        Debug.Log("翻到反面");
        Sequence s = DOTween.Sequence();
        s.Append(ImgCardBg.transform.DORotate(new Vector3(0, 90, 0), 0.25f));
        s.Append(ImgBack.transform.DORotate(new Vector3(0, 0, 0), 0.25f));
        if (action != null)
        {
            s.AppendCallback(() =>
            {
                action();
            });
        }
    }

    public void Dismiss()
    {
        CardObj.gameObject.SetActive(false);
    }

}
