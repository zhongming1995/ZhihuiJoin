using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CalendarPageScroll : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public delegate void PageScrollEnd(int index);
    public static event PageScrollEnd pageScrollEnd;

    int curIndx;
    float beginPosX;
    void Start()
    {
       
    }
    

    public void OnBeginDrag(PointerEventData eventData)
    {
        beginPosX = transform.localPosition.x;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition = new Vector3(transform.localPosition.x + eventData.delta.x, transform.localPosition.y, 0);
        /*
        int perItemX = (int)CalenderController.instance.PerPageWidth;
        if (transform.localPosition.x > 0.3f * perItemX - perItemX / 2)
        {
            transform.localPosition = new Vector3(0.3f * perItemX - perItemX / 2, transform.localPosition.y, 0);
        }
        if (transform.localPosition.x < -(2 * perItemX + 0.3f * perItemX) - perItemX / 2)
        {
            transform.localPosition = new Vector3(-(2 * perItemX + 0.3f * perItemX) - perItemX / 2, transform.localPosition.y, 0);
        }
        */
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        int perItemX = (int)CalenderController.instance.PerPageWidth;
        float offset = transform.localPosition.x - beginPosX;

        //右
        if (transform.localPosition.x-beginPosX < -0.25f*perItemX)
        {
            CalenderController.instance.CurPageIndex = Mathf.Min(CalenderController.instance.CurPageIndex + 1,CalenderController.instance.PageNum-1);
        }
        //左
        else if (transform.localPosition.x - beginPosX > 0.25*perItemX)
        {
            CalenderController.instance.CurPageIndex = Mathf.Max(0, CalenderController.instance.CurPageIndex - 1);
        }
        if (pageScrollEnd != null)
        {
            Debug.Log("EndDrag");
            pageScrollEnd(CalenderController.instance.CurPageIndex);
        }
        /*
        int perItemX = (int)CalenderController.instance.PerPageWidth;
        
        int tempIndex = -((int)transform.localPosition.x - perItemX) / perItemX - 1;
        Debug.Log("curIndx:" + curIndx);
        Debug.Log("tempIndeX:" + tempIndex);
        if (tempIndex != curIndx && CalenderController.instance.PageNum > 3)
        {
            float endPosX = -perItemX - perItemX / 2.0f;
            curIndx = tempIndex;
            //页面接续
            if (curIndx == 0 )
            {
                CalenderController.instance.CurPageIndex = Mathf.Max(0, CalenderController.instance.CurPageIndex - 1);
                if (CalenderController.instance.CurPageIndex != 0)
                {
                    Transform t = transform.GetChild(2);
                    t.transform.SetAsFirstSibling();
                    transform.localPosition = new Vector3(transform.localPosition.x - perItemX, transform.localPosition.y, 0);
                    t.GetComponent<CalendarPage>().LoadItems(CalenderController.instance.CurPageIndex - 1);
                }
                else
                {
                    endPosX = - perItemX / 2.0f;
                }
            }
            else if (curIndx == 2)
            {
                CalenderController.instance.CurPageIndex = Mathf.Min(CalenderController.instance.PageNum - 1, CalenderController.instance.CurPageIndex + 1);
                if (CalenderController.instance.CurPageIndex != CalenderController.instance.PageNum - 1)
                {
                    Transform t = transform.GetChild(0);
                    t.SetAsLastSibling();
                    transform.localPosition = new Vector3(transform.localPosition.x + perItemX, transform.localPosition.y, 0);
                    t.GetComponent<CalendarPage>().LoadItems(CalenderController.instance.CurPageIndex + 1);
                }
            }
            else if (curIndx == 1)
            { 
                if (CalenderController.instance.CurPageIndex == 0)
                {
                    CalenderController.instance.CurPageIndex = CalenderController.instance.CurPageIndex + 1;
                    endPosX = -perItemX / 2.0f;
                }
            }
            Debug.Log("页面索引：" + curIndx);
            Debug.Log("真实页面:" + CalenderController.instance.CurPageIndex);
            if (pageScrollEnd != null)
            {
                pageScrollEnd(CalenderController.instance.CurPageIndex);
            }
            transform.DOLocalMoveX(endPosX, 0.5f);
        }
        else
        {
            transform.DOLocalMoveX(-perItemX * CalenderController.instance.CurPageIndex - perItemX / 2.0f, 0.5f);
        }
     */
    }
}
