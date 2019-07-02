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
    public RectTransform Basket;
    public GameObject Mask;
    public Image ImgNumber;

    private GameObject completeWindow;
    private int fruitType;
    private DisplayPartItem[] lstDisplayItem;
    private  List<FruitItem> fruitList = new List<FruitItem>();
    private Rect basketRect;

    // Start is called before the first frame update
    void Start()
    {
        ShowMask(false);
        AddClickEvent();
        AddListener();
        fruitType = FruitController.instance.GenFruitType();
        FruitController.instance.SetBasketRect(Basket);
        ImgNumber.gameObject.SetActive(false);
        InitGame(1,false);
        Invoke("LoadPerson",0.5f);
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

    private void AddListener()
    {
        GameOperDelegate.backToEdit += BackToEditFunc;
        GameOperDelegate.pianoBegin += JumpCB;
        GameOperDelegate.cardBegin += JumpCB;
        GameOperDelegate.fruitBegin += JumpCB;
        GameOperDelegate.gameReplay += PlayFruit;
        FruitController.comeToBasketBegin += ComeToBasketBegin;
        FruitController.comeToBasketEnd += ComeToBasketEnd;
    }

    private void RemoveListener()
    {
        GameOperDelegate.backToEdit -= BackToEditFunc;
        GameOperDelegate.pianoBegin -= JumpCB;
        GameOperDelegate.cardBegin -= JumpCB;
        GameOperDelegate.fruitBegin -= JumpCB;
        GameOperDelegate.gameReplay -= PlayFruit;
        FruitController.comeToBasketBegin -= ComeToBasketBegin;
        FruitController.comeToBasketEnd -= ComeToBasketEnd;
    }

    private void PlayFruit()
    {
        gameObject.SetActive(false);
        gameObject.SetActive(true);
        Destroy(completeWindow);
        InitGame(1,false);
    }

    private void InitGame(int c,bool delay)
    {
        Debug.Log("========fruitType:" + fruitType);
        FruitController.instance.SetChapter(c);

        //delete old
        for (int i = 0; i < fruitList.Count; i++)
        {
            Destroy(fruitList[i].gameObject);
        }
        fruitList.Clear();

        BubbleCanvaGroup.DOFade(0, 0.5f).OnComplete(()=> { ImgNumber.gameObject.SetActive(false); });

        int fruitNum = FruitController.instance.GenFruitNumber(c);
        List<int> indexList = FruitController.instance.GenFruitIndex(fruitNum);

        for (int i = 0; i < indexList.Count; i++)
        {
            Debug.Log(indexList[i]);
            GameObject item = UIHelper.instance.LoadPrefab("Prefabs/game/fruit|fruit_item", FruitTrans[indexList[i]], Vector3.zero, Vector3.zero, false);
            FruitItem fruitItem = item.GetComponent<FruitItem>();
            fruitItem.InitItem(fruitType);
            fruitList.Add(fruitItem);
        }
        //出场动画
        Sequence s = DOTween.Sequence();
        if (delay)
        {
            s.AppendInterval(0.5f);
        }
        for (int i = 0; i < fruitList.Count; i++)
        {
            s.Append(fruitList[i].transform.DOScale(Vector3.one, 0.25f));
        }
        s.AppendCallback(() =>
        {
            if (PersonParent.childCount != 0)
            {
                Greeting();
            }
        });
        s.Append(BubbleCanvaGroup.DOFade(1, 0.5f));
    }

    private void LoadPerson()
    {
        GameObject person = null;
        if (DataManager.instance.partDataList != null)
        {
            person = DataManager.instance.GetPersonObj(DataManager.instance.partDataList);
        }
        person.transform.SetParent(PersonParent);
        person.transform.localScale = new Vector3(0.83f, 0.83f, 0.83f);
        person.transform.localPosition = Vector3.zero;

        lstDisplayItem = DataManager.instance.GetListDiaplayItem(person.transform);
        Greeting();
    }

    public void Greeting()
    {
        DataManager.instance.PersonGreeting(lstDisplayItem);
    }

    private void ComeToBasketBegin(bool chapterEnd)
    {
        ShowMask(true);
    }

    private void ComeToBasketEnd(bool chapterEnd)
    {
        SetFruitNumber();
        ImgNumber.transform.DOScale(Vector3.one, 0.3f).OnComplete(()=> { 
            ShowMask(false);
            if (chapterEnd)
            {
                if (FruitController.instance.chapter<3)
                {
                    InitGame(FruitController.instance.chapter + 1,true);
                }
                else
                {
                    ShowCompleteWindow();
                }
            }
        });
    }

    void ShowCompleteWindow()
    {
        string path = "Prefabs/game/window|window_complete";
        completeWindow = UIHelper.instance.LoadPrefab(path, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
    }

    void SetFruitNumber()
    {
        ImgNumber.gameObject.SetActive(true);
        string path = "Sprite/ui_sp/fruit_sp|fruit_number_" + FruitController.instance.getFruitCount;
        UIHelper.instance.SetImage(path, ImgNumber, true);
        ImgNumber.transform.localScale = new Vector3(3, 3, 3);
    }

    void BackToEditFunc()
    {
        Destroy(gameObject);
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

    void JumpCB()
    {
        Destroy(completeWindow);
        Destroy(gameObject);
    }

    void ShowMask(bool show)
    {
        Mask.gameObject.SetActive(show);
    }

    void OnDestroy()
    {
        Debug.Log("destroy");
        RemoveListener();
        AppEntry.instance.SetMultiTouchEnable(false);
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

}
