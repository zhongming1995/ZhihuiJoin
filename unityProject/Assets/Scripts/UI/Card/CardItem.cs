using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Helper;
using DG.Tweening;

public class CardItem : MonoBehaviour
{
    public int ID { get; set; }

    private Image ImgCard;
    private Image ImgBack;
    private Button BtnCard;
    private Button BtnBack;

    private void Start()
    {
        InitCard(0);
    }

    public void InitCard(int id)
    {
        ID = id;
        ImgCard = transform.GetChild(0).GetComponent<Image>();
        ImgBack = transform.GetChild(1).GetComponent<Image>();
        BtnCard = ImgCard.GetComponent<Button>();
        BtnBack = ImgBack.GetComponent<Button>();

        //设置图片
        string path = "";
        //UIHelper.instance.SetImage(path, ImgBack, true);

        //设置正反
        ImgBack.transform.rotation = new Quaternion(0, 0, 0, 0);
        ImgCard.transform.DORotate(new Vector3(0, 90, 0), 0.01f);

        BtnCard.onClick.AddListener(delegate
        {
            Debug.Log("播放音频");
            FlipToBackward();
        });

        BtnBack.onClick.AddListener(delegate
        {
            Debug.Log("翻牌");
            FlipToForward();
        });
    }

    private void FlipToForward()
    {
        Debug.Log("翻到正面");
        Sequence s = DOTween.Sequence();
        s.Append(ImgBack.transform.DORotate(new Vector3(0, 90, 0), 0.5f));
        s.Append(ImgCard.transform.DORotate(new Vector3(0, 0, 0), 0.5f));
    }

    private void FlipToBackward()
    {
        Debug.Log("翻到反面");
        Sequence s = DOTween.Sequence();
        s.Append(ImgCard.transform.DORotate(new Vector3(0, 90, 0), 0.5f));
        s.Append(ImgBack.transform.DORotate(new Vector3(0, 0, 0), 0.5f));
    }

}
