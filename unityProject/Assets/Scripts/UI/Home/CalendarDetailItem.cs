using DataMgr;
using UnityEngine;
using DG.Tweening;

public class CalendarDetailItem : MonoBehaviour
{
    public Transform PersonParent;
    public Transform TransDetail;

    private CanvasGroup CGDetail;

    //定义一些变量
    Vector3 SelectScale = Vector3.one;
    Vector3 UnSelectScale = new Vector3(0.55f, 0.55f, 0.55f);
    float SelectAlpha = 1;
    float UnSelectAlpha = 0.5f;

    public void Init( PartDataWhole whole,bool isCurIndex)
    {
        CGDetail = TransDetail.GetComponent<CanvasGroup>();
        //初始化显示
        if (PersonParent == null)
        {
            PersonParent = transform.Find("detail/mask/parent").transform;
        }
        DataManager.instance.GetPersonObjAsync(whole.partDataList,(person)=> {
            person.transform.SetParent(PersonParent);
            person.transform.localPosition = Vector3.zero;
            person.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            if (isCurIndex)
            {
                SetSelectScale();
                SetSelectAlpha();
            }
            else
            {
                SetUnSelectScale();
                SetUnSelectAlpha();
            }
        });
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
}
