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

    private GameObject completeWindow;
    private int fruitType;
    private DisplayPartItem[] lstDisplayItem;
    private  List<FruitItem> fruitList = new List<FruitItem>();
    private Rect basketRect;

    // Start is called before the first frame update
    void Start()
    {
        AddClickEvent();
        AddListener();
        fruitType = FruitController.instance.GenFruitType();
        basketRect = new Rect(basketRect.x, basketRect.y, basketRect.width, basketRect.height);
        InitGame(1);
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
        GameOperDelegate.fruitBegin += PlayFruit;
        GameOperDelegate.gameReplay += PlayFruit;
    }

    private void RemoveListener()
    {
        GameOperDelegate.backToEdit -= BackToEditFunc;
        GameOperDelegate.pianoBegin -= JumpCB;
        GameOperDelegate.cardBegin -= JumpCB;
        GameOperDelegate.fruitBegin -= PlayFruit;
        GameOperDelegate.gameReplay -= PlayFruit;
    }

    private void PlayFruit()
    {
        gameObject.SetActive(false);
        gameObject.SetActive(true);
        Destroy(completeWindow);
        InitGame(1);
    }

    private void InitGame(int c)
    {
        Debug.Log("========fruitType:" + fruitType);
        BubbleCanvaGroup.alpha = 0;
        FruitController.instance.SetChapter(c);

        //delete old
        for (int i = 0; i < fruitList.Count; i++)
        {
            Destroy(fruitList[i].gameObject);
        }
        fruitList.Clear();

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
        //s.AppendInterval(0.5f);
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

    void OnDestroy()
    {
        RemoveListener();
        AppEntry.instance.SetMultiTouchEnable(false);
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

}
