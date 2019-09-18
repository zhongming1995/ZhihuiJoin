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
        //string path = GameManager.instance.homePathList[ID];
        string path = GameData.homePathList[ID];
        UIHelper.instance.SetImage(path, ImgCard, true);

        if (ID==GameManager.instance.homeSelectIndex)
        {
            ImgCard.gameObject.SetActive(false);
            if (GameManager.instance.curWhole != null)
            {
                Debug.Log(GameManager.instance.curWhole.JoinType);
                Debug.Log(GameManager.instance.curWhole.ModelIndex);
                GameObject person = DataManager.instance.GetPersonObj(GameManager.instance.curWhole);
                person.transform.SetParent(ImgCardMask.transform);
                person.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                person.transform.localPosition = Vector3.zero;
                person.transform.localRotation = new Quaternion(0, 0, 0, 0);
            }
        }

        BtnBack.onClick.AddListener(delegate
        {
            BtnBack.interactable = false;
            FlipToForward(CompareCard);
            //AudioManager.instance.PlayOneShotAudio(GameManager.instance.drawAudioPathList[ID]);
            AudioManager.instance.PlayOneShotAudio(GameData.drawAudioPathList[ID]);
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
        BtnBack.interactable = true;
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

    public void Dismiss(Action action = null)
    {
        Tweener t1 = CardObj.transform.DORotate(new Vector3(0, 0, -360), 0.5f,RotateMode.LocalAxisAdd).OnComplete(()=> {
            ps.Play();
        });
        Tweener t2 =CardObj.transform.DOScale(Vector3.zero, 0.5f);
        if (action!=null)
        {
            t2.OnComplete(() =>
            {
                action(); 
            });
        }
       
    }
}
