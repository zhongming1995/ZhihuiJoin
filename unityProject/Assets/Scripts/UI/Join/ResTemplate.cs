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
    bool moveSelf = true;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin");
        moveSelf = true;
        if (Mathf.Abs(eventData.delta.x) < Mathf.Abs(eventData.delta.y) )
        {
            moveSelf = false;
            scrollRect.OnBeginDrag(eventData);
            return;
        }
        GameObject obj = UIHelper.instance.LoadPrefab("prefabs/join|gen_res", genParent, eventData.position, Vector3.one, false);
        obj.GetComponent<ResDragItem>().InitItem(transform.GetSiblingIndex());
        //int i = GameManager.instance.curSelectResType;
        //int j = transform.GetSiblingIndex();
       // string path = GameManager.instance.resPathList[i][j];
        //UIHelper.instance.SetImage(path, obj.GetComponent<Image>(), true);
        eventData.pointerDrag = obj;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("drag");
        if (moveSelf == false)
        {
            scrollRect.OnDrag(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end");
        if (moveSelf == false)
        {
            scrollRect.OnEndDrag(eventData);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scrollRect = transform.GetComponentInParent<ScrollRect>();
        genParent = GameObject.Find("img_draw_bg/draw_panel").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
