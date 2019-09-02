using DataMgr;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class CalendarDetailItem : MonoBehaviour
{
    public Transform PersonParent;
    public Transform TransDetail;
    public RawImage rawImage;

    private CanvasGroup CGDetail;

    //定义一些变量
    Vector3 SelectScale = Vector3.one;
    Vector3 UnSelectScale = new Vector3(0.55f, 0.55f, 0.55f);
    float SelectAlpha = 1;
    float UnSelectAlpha = 1f;

    public void Init(string fileName,bool isCurIndex)
    {
        CGDetail = TransDetail.GetComponent<CanvasGroup>();
        if (isCurIndex)
        {
            SetSelectAlpha();
            Sequence s = DOTween.Sequence();
            s.Append(transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.3f));
            s.Append(transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.1f));
            s.AppendCallback(() => {
                SetSelectScale();
            });
        }
        else
        {
            SetUnSelectScale();
            SetUnSelectAlpha();
        }
         
        Texture2D t = new Texture2D(500, 500, TextureFormat.RGBA32, false);
        t.filterMode = FilterMode.Point;
        byte[] b = FileHelper.FileToByte(PersonManager.instance.PersonImgPath + "/" + fileName+".png");
        t.LoadImage(b);
        t.Apply(false);
        rawImage.texture = t;

    }
    /*
    public void Init(PartDataWhole whole, bool isCurIndex)
    {
        CGDetail = TransDetail.GetComponent<CanvasGroup>();
        if (isCurIndex)
        {
            SetSelectAlpha();
            Sequence s = DOTween.Sequence();
            s.Append(transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.3f));
            s.Append(transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.1f));
            s.AppendCallback(() => {
                SetSelectScale();
            });
        }
        else
        {
            SetUnSelectScale();
            SetUnSelectAlpha();
        }
        //初始化显示
        if (PersonParent == null)
        {
            PersonParent = transform.Find("detail/mask/parent").transform;
        }
        GameObject person = DataManager.instance.GetPersonObj(whole.partDataList);
        person.transform.SetParent(PersonParent);
        person.transform.localPosition = Vector3.zero;
        person.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
    */

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

    //直接设置透明度
    public void SetSelectAlpha()
    {
        CGDetail.alpha = SelectAlpha;
    }

    //直接设置透明度
    public void SetUnSelectAlpha()
    {
        CGDetail.alpha = UnSelectAlpha;
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

    //动画方式设置透明度变化
    public void AniAlpha(float endValue)
    {
        float number = 0;
        Tween t = DOTween.To(() => number, x => number = x, endValue, 0.3f);
        t.OnUpdate(() => {
            CGDetail.alpha = number;
        });
    }

    //动画方式设置透明度变化
    public void AniSelectAlpha()
    {
        float number = 0;
        Tween t = DOTween.To(() => number, x => number = x, SelectAlpha, 0.3f);
        t.OnUpdate(() => {
            CGDetail.alpha = number;
        });
    }

    //动画方式设置透明度变化
    public void AniUnSelectAlpha()
    {
        float number = 0;
        Tween t = DOTween.To(() => number, x => number = x, UnSelectAlpha, 0.3f);
        t.OnUpdate(() => {
            CGDetail.alpha = number;
        });
    }

    private void OnDestroy()
    {
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
