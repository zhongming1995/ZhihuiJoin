using AudioMgr;
using GameMgr;
using Helper;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResTemplate : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    private ScrollRect scrollRect;//父容器滑动列表
    private Transform genParent;
    private JoinMainView joinMainView;
    private JoinGuide joinGuide;
    bool moveSelf = true;
    private string resPath;

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
        //if (Mathf.Abs(eventData.delta.x) < Mathf.Abs(eventData.delta.y) )
        Debug.Log(Mathf.Abs(eventData.delta.x) + "   " + Mathf.Abs(eventData.delta.y));
        if (Mathf.Abs(eventData.delta.x) < 0.5f*Mathf.Abs(eventData.delta.y))
        {
            moveSelf = false;
            scrollRect.OnBeginDrag(eventData);
            return;
        }
        AudioManager.instance.PlayOneShotAudio("Audio/option_audio/common_option_audio|dragend");
        TemplateResType type = GameManager.instance.curSelectResType;
        if (type == TemplateResType.Hand || type == TemplateResType.Leg)//手脚
        {
            genParent = GameObject.Find("group_handleg").transform;
        }
        else if (type == TemplateResType.Eye || type ==  TemplateResType.Mouth || type == TemplateResType.Hair)
        {
            genParent = GameObject.Find("group_eyemouthhair").transform;
        }
        else if (type == TemplateResType.Hat || type == TemplateResType.HeadWear)
        {
            genParent = GameObject.Find("group_hatheadwear").transform;
        }
        else if (type==TemplateResType.Head)
        {
            genParent = GameObject.Find("group_head").transform;
        }
        else if (type == TemplateResType.TrueBody)
        {
            genParent = GameObject.Find("group_truebody").transform;
        }
        GameObject obj = UIHelper.instance.LoadPrefab("Prefabs/join|gen_res", genParent, eventData.position, Vector3.one, false);
        obj.GetComponent<ResDragItem>().InitItem(transform.GetSiblingIndex(),resPath);
        obj.transform.name = type.ToString();
        eventData.pointerPress = obj;
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

    public void SetPath(string paramPath)
    {
        resPath = paramPath;
    }
}
