using UnityEngine;
using Helper;
using GameMgr;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using UI.Data;

public class ResDragItem : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler,IPointerDownHandler
{
    private Image image;
    private JoinMainView joinMainView;
    private Vector3 leftTop;
    private Vector3 rightBottom;
    private Vector2 anchorLeftTop;
    private Vector2 anchorRightBottom;
    private RectTransform rt;
    public PartType partType;
    bool isInit = false;//是否获取了需要的控件
    Vector3 offset;

    void Init()
    {
        joinMainView = GetComponentInParent<JoinMainView>();
        leftTop = joinMainView.PosLeftTop.position;
        rightBottom = joinMainView.PosRightBottom.position;
        anchorLeftTop = joinMainView.PosLeftTop.GetComponent<RectTransform>().anchoredPosition;
        anchorRightBottom = joinMainView.PosRightBottom.GetComponent<RectTransform>().anchoredPosition;
        rt = transform.GetComponent<RectTransform>();
        image = transform.GetComponent<Image>();
        isInit = true;
    }

    public void InitItem(int index)
    {
        Init();
        Debug.Log("Init");
        int type = GameManager.instance.curSelectResType;
        partType = (PartType)type;
        string path = GameManager.instance.resPathList[type][index];
        UIHelper.instance.SetImage(path, image, true);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("RedDragItem BeginDrag");
        if (isInit==false)
        {
            Init();
        }
        //选中画笔的情况下，素材不可以拖动
        if (GameManager.instance.curSelectResType==0)
        {
            return;
        }
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y,screenPos.z));
        Debug.Log("offset:" + offset);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //选中画笔的情况下，素材不可以拖动
        if (GameManager.instance.curSelectResType == 0)
        {
            return;
        }
        Vector3 globalMousePos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, eventData.pressEventCamera,out globalMousePos);
        //transform.position = globalMousePos;
        transform.position = globalMousePos + offset;
        Debug.Log(transform.position);
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
        //选中画笔的情况下，素材不可以拖动
        if (GameManager.instance.curSelectResType == 0)
        {
            return;
        }
        joinMainView.ShowBackBtn(false);
        if (InCorrectArea())
        {
            joinMainView.SetSelectResObj(transform);
            float posx = rt.anchoredPosition.x;
            float posy = rt.anchoredPosition.y;
            if (rt.anchoredPosition.x>anchorLeftTop.x&&rt.anchoredPosition.x<(anchorLeftTop.x+rt.sizeDelta.x/2))
            {
                Debug.Log("x左压线");
                posx = anchorLeftTop.x + rt.sizeDelta.x / 2;
            }
            if (rt.anchoredPosition.x<anchorRightBottom.x&&rt.anchoredPosition.x>(anchorRightBottom.x-rt.sizeDelta.x/2))
            {
                Debug.Log("x右压线");
                posx = anchorRightBottom.x - rt.sizeDelta.x / 2;
            }
            if (rt.anchoredPosition.y>anchorRightBottom.y&&rt.anchoredPosition.y<(anchorRightBottom.y+rt.sizeDelta.y/2))
            {
                Debug.Log("下压线");
                posy = anchorRightBottom.y + rt.sizeDelta.y / 2;
            }
            if (rt.anchoredPosition.y < anchorLeftTop.y && rt.anchoredPosition.y > (anchorLeftTop.y - rt.sizeDelta.y / 2)) 
            {
                Debug.Log("上压线");
                posy = anchorLeftTop.y - rt.sizeDelta.y / 2;
            }
            rt.DOAnchorPos(new Vector2(posx, posy), 0.5f);
            return;
        }
        else
        {
            if (partType==PartType.Body)
            {
                SetState(true);
                transform.localPosition = Vector3.zero;
                //涂色的纹理在这里清空！！！
                return;
            }
            joinMainView.SetSelectResObj(null);
            Destroy(gameObject);
        }
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

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isInit == false)
        {
            Init();
        }
        //选中画笔的情况下，素材不可以拖动
        if (GameManager.instance.curSelectResType == 0)
        {
            return;
        }
        joinMainView.SetSelectResObj(transform);
        joinMainView.ShowBackBtn(false);
    }
}
