using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helper;
using GameMgr;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ResDragItem : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler,IPointerClickHandler
{
    private Image image;
    private JoinMainView joinMainView;
    private Vector3 leftTop;
    private Vector3 leftBottom;
    private Vector3 rightTop;
    private Vector3 rightBottom;
    public void InitItem(int index)
    {
        joinMainView = GetComponentInParent<JoinMainView>();
        leftTop = joinMainView.PosLeftTop.position;
        rightBottom = joinMainView.PosRightBottom.position;
        image = transform.GetComponent<Image>();
        int type = GameManager.instance.curSelectResType;
        string path = GameManager.instance.resPathList[type][index];
        UIHelper.instance.SetImage(path, image, true);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 globalMousePos;
        RectTransform rt = transform.GetComponent<RectTransform>();
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, eventData.pressEventCamera,out globalMousePos);
        transform.position = globalMousePos;
        bool r = InCorrectArea();
        if (r)
        {
            SetState(true);
        }
        else
        {
            SetState(false);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        joinMainView.SetSelectResObj(transform);
        if (InCorrectArea())
        {
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        joinMainView.SetSelectResObj(transform);
    }

    public void SetState(bool enable)
    {
        if (enable)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        }
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.5f);
        }
    }

    public bool InCorrectArea()
    {
        if (transform.position.x>leftTop.x
            &&transform.position.x<rightBottom.x
            &&transform.position.y>rightBottom.y
            &&transform.position.y<leftTop.y)
        {
            return true;
        }
        return false;
    }
}
