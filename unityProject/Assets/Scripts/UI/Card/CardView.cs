using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Helper;
using GameMgr;
using System;
using DG.Tweening;
using Random = System.Random;
using AudioMgr;

public class CardView : MonoBehaviour
{
    public Button BtnBack;
    public Button BtnBackCheck;
    public GridLayoutGroup cardContent;
    public Image ImgMask;
    public Image ImgProgress;
    public Transform ChapterObj;

    private float oriProgressPosx;//初始时间进度条的位置
    private float countMaxTime = 5;
    private float countTime = 0;//用于计时
    private List<CardItem> randomCardList = new List<CardItem>(); 

    private GameObject completeWindow;


    private void AddListener()
    {
        GameOperDelegate.backToEdit += BackToEditFunc;
        GameOperDelegate.pianoBegin += PlayPiano;
        GameOperDelegate.cardBegin += PlayPiano;
        GameOperDelegate.fruitBegin += PlayPiano;
        GameOperDelegate.gameReplay += PlayCard;
        CardController.shieldOper += ShowMask;//屏蔽翻牌
        CardController.cardDismiss += CardDismiss;
        CardController.cardFlipBack += CardFlipBack;
        CardController.chapterEnd += ChapterEndFunc;
    }

    private void RemoveListener()
    {
        GameOperDelegate.backToEdit -= BackToEditFunc;
        GameOperDelegate.pianoBegin -= PlayPiano;
        GameOperDelegate.cardBegin -= PlayPiano;
        GameOperDelegate.fruitBegin -= PlayPiano;
        GameOperDelegate.gameReplay -= PlayCard;
        CardController.shieldOper -= ShowMask;
        CardController.cardDismiss -= CardDismiss;
        CardController.cardFlipBack -= CardFlipBack;
        CardController.chapterEnd -= ChapterEndFunc;
    }

    void Start()
    {
        oriProgressPosx = ImgProgress.transform.localPosition.x;
        //ShowMask(true);
        AddClickEvent();
        AddListener();
        //隐藏返回按钮
        ShowBackBtn(false);
        InitGame(1);
    }

    //显示返回按钮，否则是半透明状态
    public void ShowBackBtn(bool show)
    {
        BtnBack.gameObject.SetActive(show);
        BtnBackCheck.gameObject.SetActive(!show);
    }

    void AddClickEvent()
    {
        BtnBackCheck.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            ShowBackBtn(true);
        });

        BtnBack.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            //暂停游戏
            string path = "Prefabs/game/window|window_pause";
            UIHelper.instance.LoadPrefab(path, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
        });
    }

    public void BackToEditFunc()
    {
        Destroy(gameObject);
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

    void InitGame(int chapter)
    {
        ShowMask(true);
        //delete old
        for (int i = 0; i < cardContent.transform.childCount; i++)
        {
            Destroy(cardContent.transform.GetChild(i).gameObject);
        }

        CardController.instance.CleadCardAllList();
        CardController.instance.ClearCompareList();
        CardController.instance.SetChapter(chapter);
        randomCardList.Clear();
        countTime = 0;
        cardContent.constraint = GridLayoutGroup.Constraint.FixedRowCount;
        if (chapter==1)
        {
            cardContent.constraintCount = 2;
        }else if (chapter==2)
        {
            cardContent.constraintCount = 2;
        }else if (chapter == 3)
        {
            cardContent.constraintCount = 2;
        }
        else
        {
            cardContent.constraintCount = 3;
        }
        //牌下标
        List<int> cardIndexList = CardController.instance.GenCard(chapter);
        //打印
        Debug.Log("-----------index-----------");
        for (int i = 0; i < cardIndexList.Count; i++)
        {
            Debug.Log(cardIndexList[i]);
        }

        //打乱顺序
        Debug.Log("-----------牌------------");
        List<int> randomIdList = new List<int>();
        while (cardIndexList.Count>0)
        {
            //取随机数
            Random random = new Random();
            int listIndex = random.Next(0, cardIndexList.Count);
            int cardIndex = cardIndexList[listIndex];
            randomIdList.Add(cardIndex);
            cardIndexList.RemoveAt(listIndex);
            Debug.Log(cardIndex);
        }

        //产生牌
        for (int i = 0; i < randomIdList.Count; i++)
        {
            GameObject card = UIHelper.instance.LoadPrefab("Prefabs/game/card|card_item", cardContent.transform, Vector3.zero, Vector3.one, false);
            card.transform.localScale = Vector3.zero;
            CardItem cardItem = card.GetComponent<CardItem>();

            cardItem.InitCard(randomIdList[i]);
            randomCardList.Add(cardItem);
        }
        CardController.instance.SetCardAllList(randomCardList);

        //出现关卡
        SetChapterNum();

        //出现牌
        ChapterObj.GetChild(chapter - 1).GetChild(1).transform.localScale = Vector3.zero;
        Sequence s = DOTween.Sequence();
        s.AppendInterval(0.5f);
        s.Append(ChapterObj.GetChild(chapter - 1).GetChild(1).transform.DOScale(new Vector3(1.7f, 1.7f, 1.7f), 0.2f));
        s.Append(ChapterObj.GetChild(chapter - 1).GetChild(1).transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.15f));

        for (int i = 0; i < randomCardList.Count; i++)
        {
            s.Append(randomCardList[i].transform.DOScale(Vector3.one, 0.1f));
        }
        s.AppendInterval(0.2f);
        s.AppendCallback(() =>
        {
            for (int i = 0; i < randomCardList.Count; i++)
            {
                randomCardList[i].FlipToForward();
            }
            StartCoroutine("Cor_CountTimeFilp");
        });
    }

    //计时翻牌
    IEnumerator Cor_CountTimeFilp()
    {
        ImgProgress.transform.parent.parent.transform.localScale = Vector3.one;
        ImgProgress.transform.localPosition = new Vector3(oriProgressPosx, ImgProgress.transform.localPosition.y, ImgProgress.transform.localPosition.z);

        //倒计时
        float perX = ImgProgress.GetComponent<RectTransform>().sizeDelta.x / (countMaxTime / 0.1f);
        while (countTime<countMaxTime)
        {
            countTime += 0.1f;
            ImgProgress.transform.localPosition = new Vector3(ImgProgress.transform.localPosition.x + perX, ImgProgress.transform.localPosition.y, ImgProgress.transform.localPosition.z);
            yield return new WaitForSeconds(0.1f);
        }

        //时间消失
        ImgProgress.transform.parent.parent.transform.DOScale(Vector3.zero, 0.2f);

        for (int i = 0; i < randomCardList.Count; i++)
        {
            randomCardList[i].FlipToBackward(()=> {
                ShowMask(false);
            });
        }
    }

    void ChapterEndFunc()
    {
        Invoke("ChapterEndFuncReal", 1.3f);
    }

    void ChapterEndFuncReal()
    {
        if (CardController.instance.chapter < 4)
        {
            //generate new
            InitGame(CardController.instance.chapter + 1);
        }
        else
        {
            ShowCompleteWindow();
        }
    }

    void ShowCompleteWindow()
    {
        string path = "Prefabs/game/window|window_complete";
        completeWindow = UIHelper.instance.LoadPrefab(path, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
    }

    void SetChapterNum()
    {
        for (int i = 0; i < CardController.instance.chapter; i++)
        {
            ChapterObj.GetChild(i).GetChild(1).gameObject.SetActive(true);
        }
        for (int i = CardController.instance.chapter; i < 4; i++)
        {
            ChapterObj.GetChild(i).GetChild(1).gameObject.SetActive(false);
        }
    }

    void PlayPiano()
    {
        Destroy(completeWindow);
        Destroy(gameObject);
        //GameManager.instance.SetNextViewPath("Prefabs/game/piano|piano_view");
        //UIHelper.instance.LoadPrefab("Prefabs/common|transition_prefab_view", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
        //UIHelper.instance.LoadPrefab("Prefabs/game/piano|piano_view", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
    }

    void PlayCard()
    {
        gameObject.SetActive(false);
        gameObject.SetActive(true);
        Destroy(completeWindow);
        InitGame(1);
    }

    //void Replay()
    //{
    //    gameObject.SetActive(false);
    //    gameObject.SetActive(true);
    //    InitGame(1);
    //}

    void ShowMask(bool shield)
    {
        ImgMask.gameObject.SetActive(shield);
    }

    void CardDismiss(CardItem item1,CardItem item2)
    {
        StartCoroutine(Cor_CardDismissReal(item1,item2));
    }

    IEnumerator Cor_CardDismissReal(CardItem item1, CardItem item2)
    {
        yield return new WaitForSeconds(1.0f);
        item1.Dismiss();
        item2.Dismiss(()=> {
            ShowMask(false);
         });

        CardController.instance.DeletePair(item1.ID);
    }


    void CardFlipBack(CardItem item1,CardItem item2)
    {
        StartCoroutine(Cor_CardFlipBack(item1,item2));
    }

    IEnumerator Cor_CardFlipBack(CardItem item1,CardItem item2)
    {
        yield return new WaitForSeconds(1.0f);
        item1.FlipToBackward();
        item2.FlipToBackward(() =>
        {
            ShowMask(false);
        });
    }

    void OnDestroy()
    {
        RemoveListener();
        AppEntry.instance.SetMultiTouchEnable(false);
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

}