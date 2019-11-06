using AudioMgr;
using GameMgr;
using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CalenderItem : MonoBehaviour
{
    public Transform PersonParent;
    public Button BtnDelete;
    public Button BtnDetail;
    public GameObject MaskDelete;
    public RawImage rawImage;
    public int Index;
    public int PageIndex;
    public string FileName;

    private bool IsItem;//真实的item，不是null
    private Texture2D texture;


    //初始化
    public void ItemInit()
    {
        //默认隐藏删除按钮
        MaskDelete.SetActive(false);
        //按钮点击
        BtnDetail.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            CalenderController.instance.ItemChoosed(this);
        });

        BtnDelete.onClick.AddListener(delegate {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            CalenderController.instance.DeleteComplete(this);
        });

        if (CalenderController.instance.IsDelete)
        {
            ShowDelete(true);
        }
    }

    //空物体
    public void SetEmpty()
    {
        FileName = string.Empty;
        IsItem = false;
        rawImage.gameObject.SetActive(false);
        BtnDetail.interactable = false;
        BtnDelete.interactable = false;
        ShowDelete(false);
    }
    //设置图片
    public void SetImage(int _pageIndex,int _index,string _fileName)
    {
        //Debug.Log(FileName + "  ==  "+_fileName);
        if (FileName==_fileName)
        {
            return;
        }
        Debug.Log("pageIndex:" + _pageIndex + " ,_index:" + _index + " _fileName:" + _fileName);
        IsItem = true;
        PageIndex = _pageIndex;
        Index = _index;
        FileName = _fileName;
        transform.name = FileName;
        string path = PersonManager.instance.PersonImgPath + "/" + FileName + PersonManager.instance.PicPrefix; //".png";
        LoadByIO(path);
        rawImage.gameObject.SetActive(true);
        //rawImage.texture = Resources.Load<Texture2D>("Sprite/fodder/body/animal_body_0");
        //StartCoroutine(Cor_LoadImage("file:///"+path));
        BtnDetail.interactable = true;
        BtnDelete.interactable = true;

        if (CalenderController.instance.IsDelete)
        {
            ShowDelete(true);
        }
        //Debug.Log("time:" + (Time.realtimeSinceStartup - time));
    }

    void LoadByIO(string path)
    {
        //float time = Time.realtimeSinceStartup;
        //Resources.UnloadAsset(texture);
        //byte[] bytes = FileHelper.FileToByte(path);
        byte[] bytes = File.ReadAllBytes(path);
        texture = new Texture2D(450, 450);
        texture.LoadImage(bytes);
        texture.Compress(false);
        texture.Apply();
        bytes = null;
        rawImage.texture = texture;

        //Debug.Log("time:" + (Time.realtimeSinceStartup - time));
    }

    IEnumerator Cor_LoadImage(string path)
    {
        WWW www = new WWW(path);
        while (!www.isDone)
        {
            yield return null;
        }
        yield return www;
        if (www.bytes == null)
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

    public void ShowDelete(bool show)
    {
        //if (IsItem)
        //{
        //    MaskDelete.SetActive(show);
        //}
        Debug.Log("isItem:" + IsItem);
        if (show)
        {
            if (IsItem)
            {
                MaskDelete.SetActive(show);
            }
        }
        else
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
