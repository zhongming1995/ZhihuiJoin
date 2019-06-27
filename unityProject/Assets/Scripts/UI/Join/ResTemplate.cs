using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Helper;
using GameMgr;
using UnityEngine.UI;

public class ResTemplate : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    private ScrollRect scrollRect;//父容器滑动列表
    private Transform genParent;
    private JoinMainView joinMainView;
    private JoinGuide joinGuide;
    bool moveSelf = true;
    private Transform HandLegGroup;
    private Transform EyeMouthHairGroup;
    private Transform HatHeadwearGroup;

    void Start()
    {
        scrollRect = transform.GetComponentInParent<ScrollRect>();
        joinMainView = GetComponentInParent<JoinMainView>();
        joinGuide = GetComponentInParent<JoinGuide>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        joinGuide.OperationStart();
        moveSelf = true;
        if (Mathf.Abs(eventData.delta.x) < Mathf.Abs(eventData.delta.y) )
        {
            moveSelf = false;
            scrollRect.OnBeginDrag(eventData);
            return;
        }
        
        TemplateResType type = GameManager.instance.curSelectResType;
        if (type == TemplateResType.Hand || type == TemplateResType.Leg)//手脚
        {
            genParent = GameObject.Find("img_draw_bg/draw_panel/group_handleg").transform;
        }
        else if (type == TemplateResType.Eye || type ==  TemplateResType.Mouth || type == TemplateResType.Hair)
        {
            genParent = GameObject.Find("img_draw_bg/draw_panel/group_eyemouthhair").transform;
        }
        else if (type == TemplateResType.Hat || type == TemplateResType.HeadWear)
        {
            genParent = GameObject.Find("img_draw_bg/draw_panel/group_hatheadwear").transform;
        }
        GameObject obj = UIHelper.instance.LoadPrefab("Prefabs/join|gen_res", genParent, eventData.position, Vector3.one, false);
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
