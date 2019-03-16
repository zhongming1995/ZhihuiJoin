using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Helper;
using UnityEngine.UI;
using GameMgr;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    /*
    private Transform genParent;
    private bool isTemplat = true;//是否是模板
    private ScrollRect scrollRect;//父容器滑动列表
    private JoinMainView joinMainView;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin drag");
        if (Mathf.Abs(eventData.delta.x) < Mathf.Abs(eventData.delta.y)&& isTemplat)
        {
            scrollRect.OnBeginDrag(eventData);
            return;
        }
        if (isTemplat)
        {
            GameObject obj = UIHelper.instance.LoadPrefab("prefabs/join|gen_res", genParent, eventData.position, Vector3.one, false);
            int i= GameManager.instance.curSelectResType;
            int j = transform.GetSiblingIndex();
            string path = GameManager.instance.resPathList[i][j];
            UIHelper.instance.SetImage(path, obj.GetComponent<Image>(), true);
            eventData.pointerDrag = obj;
        }
        else
        {

        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("drag:"+eventData.position);
        transform.position = new Vector3(eventData.position.x, eventData.position.y, 0);
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end drag");
    }

    // Start is called before the first frame update
    void Start()
    {
        if (isTemplat)
        {
            scrollRect = transform.GetComponentInParent<ScrollRect>();
            genParent = GameObject.Find("img_draw_bg/draw_panel").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
    public delegate void DragEventDelegate(PointerEventData data);
    public DragEventDelegate onBeginDragDelegate;
    public DragEventDelegate onDragDelagate;
    public DragEventDelegate onEndDragDelegate;

    public void OnBeginDrag(PointerEventData eventData)
    {
        onBeginDragDelegate?.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        onDragDelagate?.Invoke(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        onEndDragDelegate?.Invoke(eventData);
    }
}
