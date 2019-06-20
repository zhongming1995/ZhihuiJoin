using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Helper;
using DG.Tweening;
using System;
using GameMgr;
using DataMgr;
using AudioMgr;

public class CardItem : MonoBehaviour
{
    public int ID { get; set; }
    public int Index { get; set; }

    private Transform CardObj;
    private Transform ImgCardBg;
    private Transform ImgCardMask;
    private Image ImgCard;
    private Transform ImgBack;
    private Button BtnCard;
    private Button BtnBack;
    private ParticleSystem ps;

    private void Start()
    {

    }

    public void InitCard(int id)
    {
        ID = id;
        CardObj = transform.Find("card");
        ImgCardBg = CardObj.Find("img_card_bg");
        ImgCardMask = ImgCardBg.Find("img_card_mask");
        ImgCard = CardObj.Find("img_card_bg/img_card_mask/img_card").GetComponent<Image>();
        ImgBack = CardObj.Find("img_back");
        BtnBack = ImgBack.GetComponent<Button>();
        ps = transform.Find("particle_dismiss").GetComponent<ParticleSystem>();

        //设置图片
        string path = GameManager.instance.homePathList[ID];
        UIHelper.instance.SetImage(path, ImgCard, true);

        if (ID==GameManager.instance.homeSelectIndex)
        {
            ImgCard.gameObject.SetActive(false);
            GameObject person = null;
            if (DataManager.instance.partDataList != null)
            {
                person = DataManager.instance.GetPersonObj(DataManager.instance.partDataList);
            }
            person.transform.SetParent(ImgCardMask.transform);
            person.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            person.transform.localPosition = Vector3.zero;
            person.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }

        BtnBack.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayPiano(GameManager.instance.drawAudioPathList[ID]);
            FlipToForward(CompareCard);
        });
    }

    void CompareCard()
    {
        CardController.instance.AddCompareList(this);
    }

    public void FlipToForward(Action action = null)
    {
        //播放音效
        action?.Invoke();
        Sequence s = DOTween.Sequence();
        s.Append(ImgBack.transform.DORotate(new Vector3(0, 90, 0), 0.2f));
        s.Append(ImgCardBg.transform.DORotate(new Vector3(0, 0, 0), 0.25f));
    }

    public void FlipToBackward(Action action=null)
    {
        Sequence s = DOTween.Sequence();
        s.Append(ImgCardBg.transform.DORotate(new Vector3(0, 90, 0), 0.2f));
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
        ps.Play();
    }

}
