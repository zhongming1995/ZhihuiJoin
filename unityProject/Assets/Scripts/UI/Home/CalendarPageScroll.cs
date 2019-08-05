using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CalendarPageScroll : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public delegate void PageScrollEnd(int index);
    public static event PageScrollEnd pageScrollEnd;

    private int curIndex;

    void Start()
    {
       
    }

    private void GetPageList()
    {
        CalenderController.instance.PageList.Clear();
        foreach (Transform item in transform)
        {
            CalendarPage page = item.GetComponent<CalendarPage>();
            CalenderController.instance.PageList.Add(page);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition = new Vector3(transform.localPosition.x + eventData.delta.x, transform.localPosition.y, 0);
        Debug.Log("pos:" + transform.localPosition);
        int perItemX = (int)CalenderController.instance.PerPageWidth;
        if (transform.localPosition.x > 0.3f* perItemX - perItemX/2)
        {
            transform.localPosition = new Vector3(0.3f * perItemX - perItemX / 2, transform.localPosition.y, 0);
        }
        if (transform.localPosition.x<-(2*perItemX+0.3f*perItemX) - perItemX / 2)
        {
            transform.localPosition = new Vector3(-(2 * perItemX + 0.3f * perItemX) - perItemX / 2, transform.localPosition.y, 0);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        int perItemX = (int)CalenderController.instance.PerPageWidth;
        curIndex = -((int)transform.localPosition.x - perItemX) / perItemX - 1;
        Debug.Log("curIndx:" + curIndex);
        //页面接续
        if (curIndex==0)
        {
            transform.GetChild(2).transform.SetAsFirstSibling();
            transform.localPosition = new Vector3(transform.localPosition.x - perItemX, transform.localPosition.y, 0);
        }
        if (curIndex == 2)
        {
            transform.GetChild(0).transform.SetAsLastSibling();
            transform.localPosition = new Vector3(transform.localPosition.x + perItemX, transform.localPosition.y, 0);
        }
        transform.DOLocalMoveX(-perItemX - perItemX / 2.0f,0.5f);
    }
  
}
