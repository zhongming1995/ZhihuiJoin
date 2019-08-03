using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CalendarListDrag : MonoBehaviour
{
    public int perItemX = 650;
    [HideInInspector]
    public int curIndex;
    
    public void ResetPosition(int curIndex)
    {
        transform.localPosition = new Vector3(-curIndex * perItemX, 0, 0);
    }

    public void AniResetScaleAndAlpha(int curIndex)
    {
        if (curIndex-1>=0)
        {
            CalendarDetailController.instance.detailList[curIndex - 1].AniUnSelectScale();
            CalendarDetailController.instance.detailList[curIndex - 1].AniUnSelectAlpha();
        }
        CalendarDetailController.instance.detailList[curIndex].AniSelectScale();
        CalendarDetailController.instance.detailList[curIndex].AniSelectAlpha();
        if (curIndex+1 < CalendarDetailController.instance.detailList.Count)
        {
            CalendarDetailController.instance.detailList[curIndex + 1].AniUnSelectAlpha();
            CalendarDetailController.instance.detailList[curIndex + 1].AniUnSelectScale();
        }
    }
    
    public void AniResetPosition(int curIndex)
    {
        transform.DOLocalMoveX(-curIndex * perItemX, 0.3f);
    }

}
