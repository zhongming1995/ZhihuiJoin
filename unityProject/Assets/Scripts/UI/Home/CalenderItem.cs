using DataMgr;
using GameMgr;
using Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalenderItem : MonoBehaviour
{
    public Transform PersonParent;
    public Button BtnDelete;
    public Button BtnDetail;
    public GameObject MaskDelete;

    private bool IsItem;//真实的item，不是null
    public int Index;
    public int PageIndex;

    private PartDataWhole curWhole;
    public string fileName;

    public void Init()
    {
        //默认隐藏删除按钮
        MaskDelete.SetActive(false);
        IsItem = false;
    }

    public void Init(int _pageIndex,int _index,string _fileName, PartDataWhole whole)
    {
        PageIndex = _pageIndex;
        IsItem = true;
        Index = _index;
        fileName = _fileName;
        if (whole==null)
        {
            Debug.Log("null===");
        }
        curWhole = whole;

        //异步加载人物
        DataManager.instance.GetPersonObjAsync(whole.partDataList, (person) =>
        {
            Transform personParent = transform.Find("item_mask/person_parent").transform;
            person.transform.SetParent(personParent);
            person.transform.localPosition = Vector3.zero;
            person.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        });

        //默认隐藏删除按钮
        MaskDelete.SetActive(false);

        //按钮点击
        BtnDetail.onClick.AddListener(delegate {
            PersonManager.instance.CurPersonIndex = Index;
            UIHelper.instance.LoadPrefabAsync("Prefabs/calendar|calendar_detail_view", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true,null,(panel)=> {
                PanelManager.instance.PushPanel(PanelName.CalendarDetailView,panel);
            });
        });

        BtnDelete.onClick.AddListener(delegate {
             CalenderController.instance.DeleteComplete(this);
        });
    }

    public void ShowDelete(bool show)
    {
        if (IsItem)
        {
            MaskDelete.SetActive(show);
        }
    }
    
}
