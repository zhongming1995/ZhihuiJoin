using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Helper;
using GameMgr;
using UnityEngine.UI;
using UI.Data;

public class ResTemplate : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    private ScrollRect scrollRect;//父容器滑动列表
    private Transform genParent;
    bool moveSelf = true;
    private Transform HandLegGroup;
    private Transform EyeMouthHairGroup;
    private Transform HatHeadwearGroup;

    void Start()
    {
        scrollRect = transform.GetComponentInParent<ScrollRect>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        moveSelf = true;
        if (Mathf.Abs(eventData.delta.x) < Mathf.Abs(eventData.delta.y) )
        {
            moveSelf = false;
            scrollRect.OnBeginDrag(eventData);
            return;
        }
        
        int type = GameManager.instance.curSelectResType;
        if (type == 6 || type == 7)//手脚
        {
            genParent = GameObject.Find("img_draw_bg/draw_panel/group_handleg").transform;
        }
        else if (type == 1 || type == 2 || type == 3)
        {
            genParent = GameObject.Find("img_draw_bg/draw_panel/group_eyemouthhair").transform;
        }
        else if (type == 4 || type == 5)
        {
            genParent = GameObject.Find("img_draw_bg/draw_panel/group_hatheadwear").transform;
        }
        GameObject obj = UIHelper.instance.LoadPrefab("prefabs/join|gen_res", genParent, eventData.position, Vector3.one, false);
        obj.GetComponent<ResDragItem>().InitItem(transform.GetSiblingIndex());
        eventData.pointerDrag = obj;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (moveSelf == false)
        {
            scrollRect.OnDrag(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (moveSelf == false)
        {
            scrollRect.OnEndDrag(eventData);
        }
    }
}
