using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Helper;
using DataMgr;
using GameMgr;

public class DisplayView : MonoBehaviour
{
    public Button BtnHome;
    public Button BtnBack;
    public Button BtnSave;
    public Transform ImgDisplay;

    private JoinMainView joinMainView;
    private Vector2 rectImgDisplay;

    void Start()
    {
        rectImgDisplay = ImgDisplay.GetComponent<RectTransform>().sizeDelta;
        joinMainView = GameManager.instance.Root.GetComponentInChildren<JoinMainView>(true);
        AddEvent();
        Display();
    }

    private void AddEvent()
    {
        BtnHome.onClick.AddListener(delegate
        {
            UIHelper.instance.LoadPrefab("prefabs/home|select_item_view", GameManager.instance.Root, Vector3.zero, Vector3.one, true);
            Destroy(gameObject);
            Destroy(joinMainView.gameObject);
        });

        BtnBack.onClick.AddListener(delegate
        {
            Destroy(gameObject);
            joinMainView.gameObject.SetActive(true);
        });
        BtnSave.onClick.AddListener(delegate
        {
            DataManager.instance.TransformToPartsList(joinMainView.DrawPanel);
            DataManager.instance.SerializePersonData();
        });
    }

    public void Display()
    {
        Transform displayItem = (Transform)Instantiate(joinMainView.DrawPanel, ImgDisplay);
        Vector2 vDisplayItem = displayItem.GetComponent<RectTransform>().sizeDelta;
        float rate = rectImgDisplay.x / vDisplayItem.x;
        displayItem.localScale = new Vector3(rate, rate, rate);
    }

}
