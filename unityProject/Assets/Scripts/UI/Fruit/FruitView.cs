using System;
using System.Collections;
using System.Collections.Generic;
using AudioMgr;
using GameMgr;
using Helper;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using DataMgr;

public class FruitView :MonoBehaviour
{
    public Button BtnBack;
    public Button BtnBackCheck;
    public List<Transform> FruitTrans;
    public CanvasGroup BubbleCanvaGroup;
    public Transform PersonParent;
    public Transform PersonCorrect;
    public RectTransform Basket;
    public GameObject Mask;
    public Image ImgNumber;
    public Image ImgNeedNum;
    public Image ImgNeedFruit;
    public ParticleSystem ps_Ribbon;
    public Transform ImgBasket;

    private GameObject completeWindow;
    private int fruitType;
    private DisplayPartItem[] lstDisplayItem;
    private  List<FruitItem> fruitList = new List<FruitItem>();
    private Rect basketRect;
    private bool haveGreeting = false;
    private Vector3 oriBasketPos;
    private Vector3 oriImgBasketPos;

    // Start is called before the first frame update
    void Start()
    {
        ShowBackBtn(false);
        AddClickEvent();
        AddListener();
        fruitType = FruitController.instance.GenFruitType();
        FruitController.instance.SetBasketRect(Basket);
        InitGame(1);
        Invoke("LoadPerson",0f);
        oriBasketPos = Basket.transform.localPosition;
        oriImgBasketPos = ImgBasket.localPosition;
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
            FruitController.instance.OperationEnd();
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            //暂停游戏
            string path = "Prefabs/game/window|window_pause";
            UIHelper.instance.LoadPrefab(path, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
        });
    }

    private void AddListener()
    {
        GameOperDelegate.backToEdit += BackToEditFunc;
        GameOperDelegate.pianoBegin += JumpCB;
        GameOperDelegate.cardBegin += JumpCB;
        GameOperDelegate.fruitBegin += JumpCB;
        GameOperDelegate.gameReplay += RePlay;
        FruitController.comeToBasketBegin += ComeToBasketBegin;
        FruitController.comeToBasketEnd += ComeToBasketEnd;
        FruitController.depthChangeStart += DepthChangeStart;
        FruitController.depthChangeEnd += DepthChangeEnd;
    }

    private void RemoveListener()
    {
        GameOperDelegate.backToEdit -= BackToEditFunc;
        GameOperDelegate.pianoBegin -= JumpCB;
        GameOperDelegate.cardBegin -= JumpCB;
        GameOperDelegate.fruitBegin -= JumpCB;
        GameOperDelegate.gameReplay -= RePlay;
        FruitController.comeToBasketBegin -= ComeToBasketBegin;
        FruitController.comeToBasketEnd -= ComeToBasketEnd;
    }

    private void RePlay()
    {
        fruitType = FruitController.instance.GenFruitType();
        for (int i = 0; i < fruitList.Count; i++)
        {
            DestroyImmediate(fruitList[i].gameObject);
        }
        fruitList.Clear();
        gameObject.SetActive(false);
        gameObject.SetActive(true);
        Destroy(completeWindow);
        InitGame(1);
    }

    private void InitGamePre()
    {
        int c = FruitController.instance.chapter + 1;
        InitGame(c);
    }

    private void InitGame(int c)
    {
        Debug.Log("InitGame========");
        FruitController.instance.SetChapter(c);

        int fruitNum = FruitController.instance.GenFruitNumber(c);
        SetNeedFruitNumber(fruitType, fruitNum);

        SetFruitNumber(0);

        List<int> indexList = FruitController.instance.GenFruitIndex(fruitNum);

        for (int i = 0; i < indexList.Count; i++)
        {
            GameObject item = UIHelper.instance.LoadPrefab("Prefabs/game/fruit|fruit_item", FruitTrans[indexList[i]], Vector3.zero, Vector3.zero, false);
            FruitItem fruitItem = item.GetComponent<FruitItem>();
            fruitItem.InitItem(fruitType,indexList[i]);
            fruitList.Add(fruitItem);
        }
        //篮子动画
        if (c!=1)
        {
            Sequence basketSequence = DOTween.Sequence();
            basketSequence.Append(Basket.transform.DOLocalMoveY(oriBasketPos.y - 500, 0.7f).OnComplete(() => {
                //清空篮子
                foreach (Transform child in Basket.transform)
                {
                    if (child.GetSiblingIndex()!=0)
                    {
                        Destroy(child.gameObject);
                    }
                }
            }));
            basketSequence.Join(ImgBasket.DOLocalMoveY(oriImgBasketPos.y - 500, 0.7f));
            basketSequence.Append(Basket.transform.DOLocalMoveY(oriBasketPos.y, 0.7f));
            basketSequence.Join(ImgBasket.DOLocalMoveY(oriImgBasketPos.y, 0.7f));
        }
       
        //出场动画
        Sequence s = DOTween.Sequence();
        for (int i = 0; i < fruitList.Count; i++)
        {
            s.Append(fruitList[i].transform.DOScale(Vector3.one, 0.25f));
        }
        s.AppendCallback(() =>
        {
            if (PersonParent.childCount != 0 && haveGreeting == false)
            {
                haveGreeting = true;
                Greeting();
            }
        });
        s.Append(BubbleCanvaGroup.DOFade(1, 0.5f));
    }

    private void LoadPerson()
    {
        GameObject person = null;
        float minPosY = 0;
        if (DataManager.instance.partDataList != null)
        {
            person = DataManager.instance.GetPersonObjWithFlag(DataManager.instance.partDataList,out minPosY);
        }
        person.transform.SetParent(PersonParent);
        person.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        person.transform.localPosition = Vector3.zero;

        Transform flagbottom = person.transform.Find("flag_bottom").transform;
        flagbottom.SetParent(PersonParent, true);
        float offsety = flagbottom.localPosition.y - PersonCorrect.localPosition.y;
        Debug.Log("offsety:" + offsety);
        person.transform.localPosition = new Vector3(0, -offsety, 0);

        lstDisplayItem = DataManager.instance.GetListDiaplayItem(person.transform);
        if (haveGreeting == false)
        {
            haveGreeting = true;
            Greeting();
        }
    }

    private void ComeToBasketBegin(bool chapterEnd,int number)
    {
        ShowMask();
        SetFruitNumber(number);
        string audioPath = "Audio/num_template|template_num_cn_" + (number);
        AudioManager.instance.PlayOneShotAudio(audioPath);
        ImgNumber.transform.DOScale(Vector3.one,0.5f).OnComplete(() => {
            if (!chapterEnd)
            {
                HideMask();
            }
        });
    }

    private void ComeToBasketEnd(FruitItem item,bool chapterEnd,int number)
    {
        //复制一个水果到篮子里
        GameObject cloneFruit = Instantiate(item.gameObject);
        cloneFruit.transform.SetParent(Basket.transform, false);
        cloneFruit.transform.position = item.transform.position;
        item.gameObject.SetActive(false);
        cloneFruit.GetComponent<FruitItem>().PlayParticle(number);

        //冒星星的动画
        //item.PlayParticle(number);
        if (chapterEnd)
        {
            //切换关卡
            StartCoroutine(NextChapter(number));
        }
    }

    private void DepthChangeStart(FruitItem item)
    {
        Debug.Log(item.depthIndex);
    }

    private void DepthChangeEnd(FruitItem item)
    {
        Debug.Log(item.depthIndex);
    }

    private IEnumerator NextChapter(int number)
    {
        yield return new WaitForSeconds(0);
        if (FruitController.instance.chapter < 3)
        {
            ChapterEndFunc(false);
        }
        else
        {
            ChapterEndFunc(true);
        }
    }
    private void ChapterEndFunc(bool complete)
    {
        FruitController.instance.OperationStart();
       
        BubbleCanvaGroup.DOFade(0, 0.5f).OnComplete(() => {
            //delete old
            for (int i = 0; i < fruitList.Count; i++)
            {
                DestroyImmediate(fruitList[i].gameObject);
            }
            fruitList.Clear();
            JumpAndWaveHand();
            ps_Ribbon.Play();
            //彩带掉落
            if (complete)
            {
                Invoke("ShowCompleteWindow", 2);
            }
            else
            {
                Invoke("InitGamePre", 2);//1s后，播放完小人动画以及彩带飘落的动画以后，再进入下一关或者弹窗
            }
        });
    }

    void ShowCompleteWindow()
    {
        string path = "Prefabs/game/window|window_complete";
        completeWindow = UIHelper.instance.LoadPrefab(path, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
    }

    void SetFruitNumber(int number)
    {
        if (number==0)
        { 
            Sequence s = DOTween.Sequence();
            s.Append(ImgNumber.DOFade(0, 0.5f).OnComplete(() => {
                string path = "Sprite/ui_sp/fruit_sp|fruit_number_" + number;
                UIHelper.instance.SetImage(path, ImgNumber, true);
            }));
            s.Append(ImgNumber.DOFade(1, 0.5f));
            ImgNumber.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            string path = "Sprite/ui_sp/fruit_sp|fruit_number_" + number;
            UIHelper.instance.SetImage(path, ImgNumber, true);
            ImgNumber.transform.localScale = new Vector3(3, 3, 3);
        }
    }

    void SetNeedFruitNumber(int type,int number)
    {
        string path = "Sprite/ui_sp/fruit_sp|fruit_" + type.ToString();
        UIHelper.instance.SetImage(path, ImgNeedFruit, true);

        string numPath = "Sprite/ui_sp/fruit_sp|fruit_number_" + number;
        UIHelper.instance.SetImage(numPath, ImgNeedNum, true);
    }

    void BackToEditFunc()
    {
        Destroy(gameObject);
    }

    void JumpCB()
    {
        Destroy(completeWindow);
        DestroyImmediate(gameObject);
    }

    void ShowMask()
    {
        Mask.gameObject.SetActive(true);
    }

    void HideMask()
    {
        Mask.gameObject.SetActive(false);
        haveGreeting = false;
        FruitController.instance.OperationEnd();
    }

    public float Greeting(bool reminder=false)
    {
        float aniTime = DataManager.instance.PersonGreeting(lstDisplayItem);
        if (reminder == false)
        {
            Invoke("HideMask", aniTime);
        }
        Invoke("PlayBreathe", aniTime);
        return aniTime;
    }

    public void JumpAndWaveHand()
    {
        DataManager.instance.PersonJumpAndWave(lstDisplayItem);
    }

    public void PlayBreathe()
    {
        DataManager.instance.PersonBreathe(lstDisplayItem);
    }

    void OnDestroy()
    {
        RemoveListener();
        AppEntry.instance.SetMultiTouchEnable(false);
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

}
