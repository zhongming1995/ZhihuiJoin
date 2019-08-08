﻿using GameMgr;
using Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AudioMgr;
using DataMgr;

public class CalendarDetailView : MonoBehaviour
{
    public Transform ListContent;
    public Button BtnPre;
    public Button BtnNext;
    public Button BtnDownload;
    public Button BtnEdit;
    public Button BtnGame;
    public Button BtnBack;

    private CalendarListDrag calendarListDrag;

    private List<CalendarDetailItem> detailList = new List<CalendarDetailItem>();

    private void OnEnable()
    {
        GameOperDelegate.pianoBegin += JumpToGameCB;
        GameOperDelegate.cardBegin += JumpToGameCB;
        GameOperDelegate.fruitBegin += JumpToGameCB;
        CallManager.savePhotoCallBack += SavePhotoCallBack;
    }
    
    private void OnDisable()
    {
        GameOperDelegate.pianoBegin -= JumpToGameCB;
        GameOperDelegate.cardBegin -= JumpToGameCB;
        GameOperDelegate.fruitBegin -= JumpToGameCB;
        CallManager.savePhotoCallBack -= SavePhotoCallBack;
    }

    // Start is called before the first frame update
    void Start()
    {
        calendarListDrag = ListContent.GetComponent<CalendarListDrag>();
        StartCoroutine(LoadPersonList(PersonManager.instance.pathList, PersonManager.instance.CurPersonIndex));
        AddBtnEvent();
    }

    void AddBtnEvent()
    {
        BtnBack.onClick.AddListener(delegate {
            Destroy(gameObject);
        });

        BtnPre.onClick.AddListener(delegate {
            int curIndex = CalendarDetailController.instance.PreDetail();
            calendarListDrag.AniResetPosition(curIndex);
            calendarListDrag.AniResetScaleAndAlpha(curIndex);
            SetBtnActive(curIndex);
        });

        BtnNext.onClick.AddListener(delegate {
            int curIndex = CalendarDetailController.instance.NextDetail();
            calendarListDrag.AniResetPosition(curIndex);
            calendarListDrag.AniResetScaleAndAlpha(curIndex);
            SetBtnActive(curIndex);
        });

        BtnDownload.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
        });

        BtnEdit.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            string fileName = PersonManager.instance.pathList[CalendarDetailController.instance.curDetailIndex];
            PartDataWhole whole = PersonManager.instance.DeserializePerson(fileName);
            GameManager.instance.homeSelectIndex = whole.ModelIndex;
            GameManager.instance.SetOpenType(OpenType.ReEdit);
            GameManager.instance.SetCurPartDataWhole(whole);
            PersonManager.instance.PersonFileName = fileName;
            GameManager.instance.JumpToJoin();
        });

        BtnGame.onClick.AddListener(delegate {
            string fileName = PersonManager.instance.pathList[CalendarDetailController.instance.curDetailIndex];
            PartDataWhole whole = PersonManager.instance.DeserializePerson(fileName);
            DataManager.instance.partDataList = whole.partDataList;
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            UIHelper.instance.LoadPrefab("Prefabs/game/window|window_choosegame", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
        });
    }

    private void SetBtnActive(int _curIndex)
    {
        if (_curIndex == 0)
        {
            BtnPre.gameObject.SetActive(false);
        }
        else if (_curIndex == detailList.Count - 1)
        {
            BtnNext.gameObject.SetActive(false);
        }
        else
        {
            BtnPre.gameObject.SetActive(true);
            BtnNext.gameObject.SetActive(true);
        }
    }

    private void EnableBtn(bool enable)
    {
        BtnPre.interactable = enable;
        BtnNext.interactable = enable;
    }

    IEnumerator LoadPersonList(List<string> pathList,int curIndex)
    {
        int index = 0;
        SetBtnActive(curIndex);
        EnableBtn(false);
        calendarListDrag.ResetPosition(curIndex);

        while (index < pathList.Count)
        {
            UIHelper.instance.LoadPrefabAsync("Prefabs/calendar|calendar_detail_item", ListContent, Vector3.zero, Vector3.one, false, null, (item) => {
                PartDataWhole whole = PersonManager.instance.DeserializePerson(pathList[index]);
                item.name = pathList[index];
                item.transform.localPosition = new Vector3(index * 650, 0, 0);
                CalendarDetailItem detailItem = item.GetComponent<CalendarDetailItem>();
                if (curIndex == index)
                {
                    detailItem.Init(whole, true);
                }
                else
                {
                    detailItem.Init(whole, false);
                }
                detailList.Add(detailItem);
                index += 1;
                if (index == pathList.Count-1)
                {
                    CalendarDetailController.instance.SetDetailList(detailList);
                    CalendarDetailController.instance.curDetailIndex = curIndex;
                }
            });
            yield return new WaitForSeconds(0.01f);
        }
        EnableBtn(true);
        SetBtnActive(curIndex);
    }

    private void SavePhotoCallBack(string result)
    {
        
    }

    private void JumpToGameCB()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
