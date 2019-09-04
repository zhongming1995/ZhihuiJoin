using AudioMgr;
using DataMgr;
using GameMgr;
using Helper;
using System;
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
    public RawImage rawImage;

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
        rawImage.gameObject.SetActive(false);
    }

    public void Init(int _pageIndex, int _index, string _fileName)
    {
        Debug.Log("Init fileName:" + _fileName);
        PageIndex = _pageIndex;
        IsItem = true;
        Index = _index;
        fileName = _fileName;

        StartCoroutine(Cor_LoadImage("file:///" + PersonManager.instance.PersonImgPath + "/" + fileName+".png"));

        //默认隐藏删除按钮
        MaskDelete.SetActive(false);

        //按钮点击
        BtnDetail.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            PersonManager.instance.CurPersonIndex = Index;
            //GameManager.instance.SetNextViewPath(PanelName.CalendarDetailView);
            //UIHelper.instance.LoadPrefab(PanelName.TransitionView, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
            GameManager.instance.SetNextSceneName(SceneName.CalendarDetail);
            TransitionView.instance.OpenTransition();
        });

        BtnDelete.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            CalenderController.instance.DeleteComplete(this);
        });
    }

    IEnumerator Cor_LoadImage(string path)
    {
        WWW www = new WWW(path);
        while (!www.isDone)
        {
            yield return null;
        }
        yield return www;
        if (www.bytes==null)
        {
            Debug.Log("读图片失败");
        }
        if (string.IsNullOrEmpty(www.error))
        {
            Texture2D t = new Texture2D(500, 500, TextureFormat.RGBA32, false);
            t.filterMode = FilterMode.Point;
            byte[] b = www.bytes;
            t.LoadImage(b);
            t.Apply(false);
            rawImage.texture = t;
        }
        www.Dispose();
    }

    /*
    public void Init(int _pageIndex,int _index,string _fileName, PartDataWhole whole)
    {
        PageIndex = _pageIndex;
        IsItem = true;
        Index = _index;
        fileName = _fileName;
        if (whole==null)
        {
            Debug.Log("null whole===");
        }
        curWhole = whole;

        //异步加载人物
        GameObject person = DataManager.instance.GetPersonObj(whole.partDataList);
        
        person.transform.SetParent(PersonParent);
        person.transform.localPosition = Vector3.zero;
        person.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);


        //默认隐藏删除按钮
        MaskDelete.SetActive(false);

        //按钮点击
        BtnDetail.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            PersonManager.instance.CurPersonIndex = Index;
            GameObject panel = UIHelper.instance.LoadPrefab("Prefabs/calendar|calendar_detail_view", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
            PanelManager.instance.PushPanel(PanelName.CalendarDetailView,panel);
        });

        BtnDelete.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            CalenderController.instance.DeleteComplete(this);
        });
    }*/

    public void Refresh(int _pageIndex, int _index, string _fileName)
    {
        DestroyImmediate(PersonParent.GetChild(0).gameObject);
        //加载新的人物
        Init(_pageIndex, _index, _fileName);
    }

    public void ShowDelete(bool show)
    {
        if (IsItem)
        {
            MaskDelete.SetActive(show);
        }
    }

    private void OnDestroy()
    {
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

}
