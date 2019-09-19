using DataMgr;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;
using System.Collections;
using GameMgr;

public class CalendarDetailItem : MonoBehaviour
{
    public Transform PersonParent;
    public Transform TransDetail;
    public RawImage rawImage;
    [HideInInspector]
    public int DetailIndex;
    private CanvasGroup CGDetail;
    //定义一些变量
    Vector3 SelectScale = Vector3.one;
    Vector3 UnSelectScale = new Vector3(0.55f, 0.55f, 0.55f);

    public void Init(string fileName,bool isCurIndex,int index)
    {
        DetailIndex = index;
        if (isCurIndex)
        {
            Sequence s = DOTween.Sequence();
            s.Append(transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.3f));
            s.Append(transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.1f));
            s.AppendCallback(() => {
                SetSelectScale();
                s = null;
            });
        }
        else
        {
            SetUnSelectScale();
        }
        string path = PersonManager.instance.PersonImgPath + "/" + fileName + ".png";
        StartCoroutine(Cor_LoadImage("file:///" + PersonManager.instance.PersonImgPath + "/" + fileName + ".png"));
    }

    void LoadByIO(string path)
    {
        byte[] bytes = FileHelper.FileToByte(path);

        Texture2D t = new Texture2D(450, 450);
        t.LoadImage(bytes);
        bytes = null;
        rawImage.texture = t;
        t = null;
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

    //直接设置缩放
    public void SetSelectScale()
    {
        TransDetail.localScale = SelectScale;
    }

    //直接设置缩放
    public void SetUnSelectScale()
    {
        TransDetail.localScale = UnSelectScale;
    }
    //动画方式设置缩放
    public void AniSelectScale()
    {
        TransDetail.DOScale(SelectScale, 0.3f);
    }

    //动画方式设置缩放
    public void AniUnSelectScale()
    {
        TransDetail.DOScale(UnSelectScale, 0.3f);
    }

    private void OnDestroy()
    {
        rawImage = null;
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
