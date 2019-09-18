using AudioMgr;
using GameMgr;
using System;
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
        string path = PersonManager.instance.PersonImgPath + "/" + fileName + ".png";
        //StartCoroutine(Cor_LoadImage("file:///" + PersonManager.instance.PersonImgPath + "/" + fileName+".png"));
        LoadByIO(path);
        //默认隐藏删除按钮
        MaskDelete.SetActive(false);

        //按钮点击
        BtnDetail.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            PersonManager.instance.CurPersonIndex = Index;
            CalenderController.instance.ItemChoosed(this);
            //GameManager.instance.SetNextSceneName(SceneName.CalendarDetail);
            //TransitionView.instance.OpenTransition();
        });

        BtnDelete.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            CalenderController.instance.DeleteComplete(this);
        });
    }

    void LoadByIO(string path)
    {
        byte[] bytes = FileHelper.FileToByte(path);

        Texture2D t = new Texture2D(450, 450);
        t.LoadImage(bytes);
        bytes = null;
        //GameManager.instance.SetPersonTexture(Index, t);
        rawImage.texture = t;
        t = null;
    }

    /*
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
            rawImage.texture = www.texture;
        }
        www.Dispose();
        www = null;
    }
    */
  
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
