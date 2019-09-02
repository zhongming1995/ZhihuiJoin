﻿using UnityEngine;
using Helper;
using GameMgr;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using AudioMgr;

public class ResDragItem : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler,IPointerDownHandler
{
    [HideInInspector]
    public PartType partType;
    public Material selectMaterial;//选中状态，描边
    private Vector3 partScale = new Vector3(1,1,1);

    private Image image;
    private JoinMainView joinMainView;
    private JoinGuide joinGuide;
    private Vector3 leftTop;
    private Vector3 rightBottom;
    private Vector2 anchorLeftTop;
    private Vector2 anchorRightBottom;
    private RectTransform rt;
    bool isInit = false;//是否获取了需要的控件
    bool isSelected = false;//是否被选中高亮
    Vector3 offset;

    private string resPath;

    void Init()
    {
        joinMainView = GetComponentInParent<JoinMainView>();
        joinGuide = GetComponentInParent<JoinGuide>();
        leftTop = joinMainView.PosLeftTop.position;
        rightBottom = joinMainView.PosRightBottom.position;
        anchorLeftTop = joinMainView.PosLeftTop.GetComponent<RectTransform>().anchoredPosition;
        anchorRightBottom = joinMainView.PosRightBottom.GetComponent<RectTransform>().anchoredPosition;
        rt = transform.GetComponent<RectTransform>();
        image = transform.GetComponent<Image>();
        isInit = true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index">siblingIndex</param>
    /// <param name="index">图片路径</param>
    public void InitItem(int index,string paramPath = null)
    {
        Init();
        TemplateResType type = GameManager.instance.curSelectResType;
        partType = GetPartTypeByResType(type, index);
        string path = string.Empty;
        if (paramPath==null)
        {
            path = GameData.resPathList[(int)type][index];
        }
        else
        {
            path = paramPath;
        }
        UIHelper.instance.SetImage(path, image, true);
    }

    public void LoadInitItem(PartType type,Sprite s)
    {
        Init();
        partType = type;
        image.sprite = s;
    }

    public void SetScale(Vector3 scale)
    {
        partScale = scale;
    }

    /// <summary>
    /// Gets the type of the part type by res.//素材类型 0颜色(身体) 1眼睛 2嘴巴 3头发 4帽子 5饰品 6手 7脚
    /// </summary>
    /// <param name="resType">素材类型</param>
    /// <param name="index">素材下标</param>
    PartType GetPartTypeByResType(TemplateResType resType,int index)
    {
        if (resType == TemplateResType.Body)
        {
            return PartType.Body;
        }
        if (resType == TemplateResType.Eye)
        {
            if (index%2!=0)//右眼
            {
                return PartType.RightEye;
            }
            return PartType.LeftEye;
        }
        if (resType == TemplateResType.Mouth)
        {
            return PartType.Mouth;
        }
        if (resType == TemplateResType.Hair)
        {
            return PartType.Hair;
        }
        if (resType == TemplateResType.Hat)
        {
            return PartType.Hat;
        }
        if (resType == TemplateResType.HeadWear)
        {
            return PartType.HeadWear;
        }
        if (resType == TemplateResType.Hand)
        {
            if (index % 2 != 0)//右手
            {
                return PartType.RightHand;
            }
            return PartType.LeftHand;
        }
        if (resType == TemplateResType.Leg)
        {
            if (index % 2 != 0)//右脚
            {
                return PartType.RightLeg;
            }
            return PartType.LeftLeg;
        }
        return PartType.Body;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        joinGuide.OperationStart();
        if (isInit==false)
        {
            Init();
        }
        //选中画笔的情况下，素材不可以拖动
        if (GameManager.instance.curSelectResType==0)
        {
            return;
        }
        if (isSelected)
        {
            //ShowOutLine(false);
        }
        //AudioManager.instance.PlayOneShotAudio("Audio/option_audio/common_option_audio|dragbegin");
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y,screenPos.z));
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
        transform.position = globalMousePos + offset;
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
        joinGuide.OperationEnd();
        //选中画笔的情况下，素材不可以拖动
        if (GameManager.instance.curSelectResType == 0)
        {
            return;
        }
        if (isSelected)
        {
            //ShowOutLine(true);
        }
        joinMainView.ShowBackBtn(false);
        if (InCorrectArea())
        {
            AudioManager.instance.PlayOneShotAudio("Audio/option_audio/common_option_audio|dragend");
            joinMainView.SetSelectResObj(transform);
            joinMainView.hasDraged = true;
            float posx = rt.anchoredPosition.x;
            float posy = rt.anchoredPosition.y;
            if (rt.anchoredPosition.x > anchorLeftTop.x && rt.anchoredPosition.x < (anchorLeftTop.x + rt.sizeDelta.x*partScale.x / 2))
            {
                Debug.Log("x左压线");
                posx = anchorLeftTop.x + rt.sizeDelta.x * partScale.x / 2;
            }
            if (rt.anchoredPosition.x < anchorRightBottom.x && rt.anchoredPosition.x > (anchorRightBottom.x - rt.sizeDelta.x* partScale.x / 2))
            {
                Debug.Log("x右压线");
                posx = anchorRightBottom.x - rt.sizeDelta.x * partScale.x / 2;
            }
            if (rt.anchoredPosition.y > anchorRightBottom.y && rt.anchoredPosition.y < (anchorRightBottom.y + rt.sizeDelta.y * partScale.y / 2))
            {
                Debug.Log("下压线");
                posy = anchorRightBottom.y + rt.sizeDelta.y * partScale.y / 2;
            }
            if (rt.anchoredPosition.y < anchorLeftTop.y && rt.anchoredPosition.y > (anchorLeftTop.y - rt.sizeDelta.y * partScale.y / 2))
            {
                Debug.Log("上压线");
                posy = anchorLeftTop.y - rt.sizeDelta.y * partScale.y / 2;
            }
            rt.DOAnchorPos(new Vector2(posx, posy), 0.5f);
            return;
        }
        else
        {
            Debug.Log("delete:"+partType);
            if (partType==PartType.Body)
            {
                SetState(true);
                transform.localPosition = Vector3.zero;
                return;
            }
            joinMainView.SetSelectResObj(null);
            Destroy(gameObject);
        }
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
        AudioManager.instance.PlayOneShotAudio("Audio/option_audio/common_option_audio|dragend");
        joinMainView.SetSelectResObj(transform);
        joinMainView.ShowBackBtn(false);
    }

    public void SetState(bool enable)
    {
        if (enable)
        {
            if (isSelected)
            {
                ShowOutLine(true);
            }
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1);//使用描边shader之后就没用了
        }
        else
        {
            ShowOutLine(false);
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

    public void SetOutline(bool isSelect)
    {
        isSelected = isSelect;
        ShowOutLine(isSelect);
    }

    private void ShowOutLine(bool isSelect)
    {
        if (isSelect)
        {
            image.material = selectMaterial;
        }
        else
        {
            image.material = null;
        }
    }
}
