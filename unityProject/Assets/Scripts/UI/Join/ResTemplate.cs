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
        HandLegGroup = GameObject.Find("DrawItemGroup/HandLegGroup").transform;
        EyeMouthHairGroup = GameObject.Find("DrawItemGroup/EyeMouthHairGroup").transform;
        HatHeadwearGroup = GameObject.Find("DrawItemGroup/HatHeadwearGroup").transform;
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

        /*
        //Debug.Log("=======traPos:"+transform.position);
        //GameObject obj1 = UIHelper.instance.LoadPrefab("prefabs/draw|draw_item", null, new Vector3(transform.position.x, transform.position.y, 0), Vector3.one);
        
        PartType type = (PartType)GameManager.instance.curSelectResType;
        if (type == PartType.Hand || type == PartType.Leg)//手脚
        {
            genParent = HandLegGroup;
        }
        else if (type == PartType.Eye || type == PartType.Mouth || type == PartType.Hair)
        {
            genParent = EyeMouthHairGroup;
        }
        else if (type == PartType.Hat || type == PartType.HeadWear)
        {
            genParent = HatHeadwearGroup;
        }
        Debug.Log(transform.position);

        //Vector3 screenPos = eventData.pointerCurrentRaycast.screenPosition;
        // Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        //Debug.Log(worldPos);
        //Vector3 pos = transform.GetComponent<RectTransform>().anchoredPosition3D;
        //Debug.Log("w:------------" + pos);
        //Vector3 worldPos = Camera.main.ScreenToWorldPoint(transform.position);
        GameObject obj = UIHelper.instance.LoadPrefab("prefabs/draw|draw_item", genParent, new Vector3(transform.position.x,transform.position.y,0), Vector3.one);
        obj.GetComponent<MobileDrag>().InitItem(transform.GetSiblingIndex(), genParent, new Vector3(transform.position.x, transform.position.y, 0));
        //eventData.pointerDrag = obj;
       */
        
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
