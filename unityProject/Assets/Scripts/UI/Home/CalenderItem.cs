﻿using DataMgr;
using GameMgr;
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

    private PartDataWhole curWhole;

    public void Init(PartDataWhole whole)
    {
        if (whole==null)
        {
            Debug.Log("null===");
        }
        curWhole = whole;

        //初始化显示
        GameObject person = DataManager.instance.GetPersonObj(whole.partDataList);
        Transform personParent = transform.Find("item_mask/person_parent").transform;
        person.transform.SetParent(personParent);
        person.transform.localPosition = Vector3.zero;
        person.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

        //默认隐藏删除按钮
        MaskDelete.SetActive(false);

        //按钮点击
        BtnDetail.onClick.AddListener(delegate {
            Debug.Log("Detail");
            GameManager.instance.homeSelectIndex = whole.ModelIndex;
            GameManager.instance.SetOpenType(OpenType.ReEdit);
            GameManager.instance.SetCurPartDataWhole(whole);
            GameManager.instance.JumpToJoin();
        });

        BtnDelete.onClick.AddListener(delegate {
            Debug.Log("Delete");
            
        });
    }

    public void ShowDelete(bool show)
    {
        MaskDelete.SetActive(show);
    }
    
}
