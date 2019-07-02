using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Helper;
using DG.Tweening;

public class FruitItem : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler,IPointerClickHandler
{
    Vector3 offset;
    private Vector3 oriPos;
    private RectTransform rt;
    private Image img_fruit;
    private bool canDrag = true;
    private bool isDragging = false;

    //初始化一个水果对象
    public void InitItem(int type)
    {
        oriPos = transform.position;
        rt = transform.GetComponent<RectTransform>();
        img_fruit = transform.GetComponent<Image>();
        string path = "Sprite/ui_sp/fruit_sp|fruit_icon_" + type.ToString();
        UIHelper.instance.SetImage(path, img_fruit, true);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            isDragging = true;
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, screenPos.z));
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            Vector3 globalMousePos;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, eventData.pressEventCamera, out globalMousePos);
            transform.position = globalMousePos + offset;

            if (FruitController.instance.isFruitInBasketRect(rt))
            {
                Debug.Log("======接触到热区");
                canDrag = false;
                isDragging = false;
                FruitController.instance.FruitToBasketBegin(this);
                Vector3 desPos = FruitController.instance.GetFruitDesPos();
                transform.DOMove(desPos, 0.3f).OnComplete(()=> {
                    FruitController.instance.FruitToBasketEnd(this);
                });
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            Debug.Log("======endDrag");
            isDragging = false;
            transform.DOMove(oriPos, 0.3f);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isDragging==false)
        {
            Debug.Log("----------click");
            FruitController.instance.FruitToBasketBegin(this);
            DoLinerPathMove();
        }
    }

    private void DoLinerPathMove()
    {
        Vector3 desPos = FruitController.instance.GetFruitDesPos();
        transform.DOPath(new Vector3 []{transform.position,new Vector3(transform.position.x-1f,transform.position.y+0.1f,0),desPos},1f,PathType.CatmullRom).OnComplete(()=> {
            FruitController.instance.FruitToBasketEnd(this);
        });
    }
}
