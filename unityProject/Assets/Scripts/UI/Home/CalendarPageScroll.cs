using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CalendarPageScroll : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public delegate void PageScrollEnd(int index,int x,bool isFirst = false);
    public static event PageScrollEnd pageScrollEnd;
    private RectTransform rectTransform;
    private int beginAnchorPosx;

    void Start()
    {
        rectTransform = transform.GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (CalenderController.instance.IsScrolling)
        {
            return;
        }
        beginAnchorPosx = (int)rectTransform.anchoredPosition.x; //CalenderController.instance.ContentPosX;//
        Debug.Log("dragstart");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (CalenderController.instance.IsScrolling)
        {
            return;
        }
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x + eventData.delta.x, rectTransform.anchoredPosition.y);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (CalenderController.instance.IsScrolling)
        {
            return;
        }
        int perItemX = (int)CalenderController.instance.PerPageWidth;
        float offset = rectTransform.anchoredPosition.x - beginAnchorPosx;
        int tempIndex = 0;
        if (offset<0)
        {
            //左滑
            if (offset < -0.25 * perItemX)
            {
                tempIndex = Mathf.Min(PersonManager.instance.CurPersonPageIndex + 1, PersonManager.instance.PageCount - 1);
            }
            else
            {
                tempIndex = PersonManager.instance.CurPersonPageIndex;
            }
        }
        else if (offset>0)
        {
            if (offset > 0.25 * perItemX)
            {
                tempIndex = Mathf.Max(0, PersonManager.instance.CurPersonPageIndex - 1);
            }
            else
            {
                tempIndex = PersonManager.instance.CurPersonPageIndex;
            }
        }
        else
        {
            tempIndex = PersonManager.instance.CurPersonPageIndex;
        }
        if (tempIndex!=PersonManager.instance.CurPersonPageIndex)
        {
            PersonManager.instance.CurPersonPageIndex = tempIndex;
            if (pageScrollEnd != null)
            {
                pageScrollEnd(PersonManager.instance.CurPersonPageIndex, beginAnchorPosx);
            }
        }
        else
        {
            CalenderController.instance.IsScrolling = true;
            rectTransform.DOAnchorPos(new Vector2(beginAnchorPosx,rectTransform.anchoredPosition.y), 0.5f).OnComplete(()=> {
                CalenderController.instance.IsScrolling = false;
            });
        }
        Debug.Log("dragend");
    }
}
