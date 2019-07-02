using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Helper;

public class FruitItem : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler,IPointerClickHandler
{
    Vector3 offset;
    private RectTransform rt;
    private Image img_fruit;
    private bool canDrag = true;

    //初始化一个水果对象
    public void InitItem(int type)
    {
        rt = transform.GetComponent<RectTransform>();
        img_fruit = transform.GetComponent<Image>();
        string path = "Sprite/ui_sp/fruit_sp|fruit_icon_" + type.ToString();
        UIHelper.instance.SetImage(path, img_fruit, true);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
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
                FruitController.instance.FruitToBasket(this);
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            Debug.Log("======endDrag");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("----------click");
    }
}
