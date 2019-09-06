using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CalendarListDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Transform content;
    public int perItemX = 650;
    [HideInInspector]
    public int curIndex;

    public delegate void DetailSwitchIndex(int _curIndex);
    public DetailSwitchIndex detailSwitchIndex;

    public void ResetPosition(int curIndex)
    {
        content.localPosition = new Vector3(-curIndex * perItemX, 0, 0);
    }

    public void AniResetScaleAndAlpha(int curIndex)
    {
        if (curIndex-1>=0)
        {
            CalendarDetailController.instance.detailList[curIndex - 1].AniUnSelectScale();
            //CalendarDetailController.instance.detailList[curIndex - 1].AniUnSelectAlpha();
        }
        CalendarDetailController.instance.detailList[curIndex].AniSelectScale();
        //CalendarDetailController.instance.detailList[curIndex].AniSelectAlpha();
        if (curIndex+1 < CalendarDetailController.instance.detailList.Count)
        {
            //CalendarDetailController.instance.detailList[curIndex + 1].AniUnSelectAlpha();
            CalendarDetailController.instance.detailList[curIndex + 1].AniUnSelectScale();
        }
    }

    public void AniResetScale(int curIndex)
    {
        if (curIndex - 1 >= 0)
        {
            CalendarDetailController.instance.detailList[curIndex - 1].AniUnSelectScale();
        }
        CalendarDetailController.instance.detailList[curIndex].AniSelectScale();
        if (curIndex + 1 < CalendarDetailController.instance.detailList.Count)
        {
            CalendarDetailController.instance.detailList[curIndex + 1].AniUnSelectScale();
        }
    }

    public void AniResetPosition(int curIndex)
    {
        content.DOLocalMoveX(-curIndex * perItemX, 0.3f);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x)<1)
        {
            return;
        }
        content.localPosition += new Vector3(eventData.delta.x,0,0);
        curIndex = -((int)content.transform.localPosition.x - perItemX / 2) / perItemX;
        curIndex = Mathf.Max(0, curIndex);
        curIndex = Mathf.Min(curIndex, CalendarDetailController.instance.detailList.Count - 1);
        Debug.Log("curIndex:" + curIndex);
        AniResetScale(curIndex);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        AniResetPosition(curIndex);
        if (detailSwitchIndex!=null)
        {
            detailSwitchIndex(curIndex);
        }
    }
}
