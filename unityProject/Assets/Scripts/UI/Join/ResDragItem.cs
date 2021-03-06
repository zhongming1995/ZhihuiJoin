﻿using UnityEngine;
using Helper;
using GameMgr;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using AudioMgr;

public class ResDragItem : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler
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
    private bool isInit;//是否获取了需要的控件
    private bool isSelected;//是否被选中高亮
    private Vector3 offset;
    private string resPath;
    private bool canDrag;
    private int dragCount = 0;
    private bool HasDrag;//本次触摸是否触发了拖拽

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
    /// <param name="paramPath">图片路径</param>
    public void InitItem(int index,string paramPath = null)
    {
        Init();
        TemplateResType type = GameManager.instance.curSelectResType;
        partType = GetPartTypeByResType(type, index);
        string path = string.Empty;
        if (paramPath == null)
        {
            path = GameData.instance.resPathList[(int)type][index];
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
        dragCount = 1;
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
        if (resType==TemplateResType.Head)
        {
            return PartType.Head;
        }
        if (resType == TemplateResType.TrueBody)
        {
            return PartType.TrueBody;
        }
        return PartType.Body;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //选中画笔的情况下，素材不可以拖动
        if (GameManager.instance.curJoinType == JoinType.Animal)
        {
            //动物拼接的第一步,第二步时，头不可以动
            if (joinMainView.step == 1 || joinMainView.step == 2)
            {
                if (partType == PartType.Head && dragCount != 0)
                {
                    return;
                }
            }

            //动物拼接的第三步第四步，眼睛鼻子不可以动
            if (joinMainView.step == 3 || joinMainView.step == 4)
            {
                if (partType == PartType.LeftEye || partType == PartType.RightEye || partType == PartType.Mouth)
                {
                    return;
                }
            }
        }
        else
        {
            if (joinMainView.step == 1)
            {
                return;
            }
        }
        HasDrag = true;
        Vector3 globalMousePos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, eventData.pressEventCamera,out globalMousePos);
        transform.position = globalMousePos + offset;
        //头不进行边界判断，只在拖拽结束的时候判断
        if (partType == PartType.Head)
        {
            return;
        }
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

    public void OnPointerDown(PointerEventData eventData)
    {
        joinGuide.OperationStart();
        if (isInit == false)
        {
            Init();
        }
        //选中画笔的情况下，素材不可以拖动
        if (GameManager.instance.curJoinType == JoinType.Animal)
        {
            //动物拼接的第一步,第二步时，头不可以动
            if (joinMainView.step == 1 || joinMainView.step == 2)
            {
                if (partType == PartType.Head && dragCount != 0)
                {
                    return;
                }
            }

            //动物拼接的第三步第四步，眼睛鼻子不可以动
            if (joinMainView.step == 3 || joinMainView.step == 4)
            {
                if (partType == PartType.LeftEye || partType == PartType.RightEye || partType == PartType.Mouth)
                {
                    return;
                }
            }
        }
        else
        {
            if (joinMainView.step == 1)
            {
                return;
            }
        }
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, screenPos.z));
        AudioManager.instance.PlayOneShotAudio("Audio/option_audio/common_option_audio|dragend");
        joinMainView.SetSelectResObj(transform);
        joinMainView.ShowBackBtn(false);
    }

    public void OnPointerUp(PointerEventData data)
    {
        joinGuide.OperationEnd();
        joinMainView.hasDraged = true;
        //选中画笔的情况下，素材不可以拖动
        if (GameManager.instance.curJoinType == JoinType.Animal)
        {
            //动物拼接的第一步,第二步时，头不可以动
            if (joinMainView.step == 1 || joinMainView.step == 2)
            {
                if (partType == PartType.Head && dragCount != 0)
                {
                    return;
                }
            }

            //动物拼接的第三步第四步，眼睛鼻子不可以动
            if (joinMainView.step == 3 || joinMainView.step == 4)
            {
                if (partType == PartType.LeftEye || partType == PartType.RightEye || partType == PartType.Mouth)
                {
                    return;
                }
                if (partType == PartType.Head)
                {
                    joinMainView.targetHeadPos = transform.localPosition;
                }
            }
            //拖头上来的时候，把眼睛嘴巴作为头的子节点
            if (partType == PartType.Head && dragCount == 0)
            {
                joinMainView.EyeMouthHairCG.transform.SetParent(transform);
                joinMainView.EyeMouthHairCG.transform.localPosition = Vector3.zero;
                if (transform.parent.childCount > 1)
                {
                    for (int i = 0; i < transform.parent.childCount - 1; i++)
                    {
                        Destroy(transform.parent.GetChild(i).gameObject);
                    }
                }
            }
        }
        else
        {
            if (joinMainView.step == 1)
            {
                return;
            }
        }
        joinMainView.ShowBackBtn(false);
        dragCount++;
        if (GameManager.instance.curJoinType == JoinType.Animal && joinMainView.step == 1)
        {
            if (partType == PartType.Head)
            {
                //头定位
                transform.DOLocalMove(Vector3.zero, 0.5f);
                //将眼鼻的父物体挂在头下面
                return;
            }
        }

        if (InCorrectArea())
        {
            if (data!=null)
            {
                AudioManager.instance.PlayOneShotAudio("Audio/option_audio/common_option_audio|dragend");
            }
            joinMainView.SetSelectResObj(transform);
            joinMainView.SetScaleSlider(transform);
            float posx = rt.anchoredPosition.x;
            float posy = rt.anchoredPosition.y;
            if (rt.anchoredPosition.x > anchorLeftTop.x && rt.anchoredPosition.x < (anchorLeftTop.x + rt.sizeDelta.x * partScale.x / 2))
            {
                posx = anchorLeftTop.x + rt.sizeDelta.x * partScale.x / 2;
            }
            if (rt.anchoredPosition.x < anchorRightBottom.x && rt.anchoredPosition.x > (anchorRightBottom.x - rt.sizeDelta.x * partScale.x / 2))
            {
                posx = anchorRightBottom.x - rt.sizeDelta.x * partScale.x / 2;
            }
            if (rt.anchoredPosition.y > anchorRightBottom.y && rt.anchoredPosition.y < (anchorRightBottom.y + rt.sizeDelta.y * partScale.y / 2))
            {
                posy = anchorRightBottom.y + rt.sizeDelta.y * partScale.y / 2;
            }
            if (rt.anchoredPosition.y < anchorLeftTop.y && rt.anchoredPosition.y > (anchorLeftTop.y - rt.sizeDelta.y * partScale.y / 2))
            {
                posy = anchorLeftTop.y - rt.sizeDelta.y * partScale.y / 2;
            }
            rt.DOAnchorPos(new Vector2(posx, posy), 0.5f);
        }
        else
        {
            if (partType == PartType.Body || partType == PartType.Head)
            {
                joinMainView.SetSelectResObj(null);
                transform.DOLocalMove(joinMainView.defaultTargetPos, 0.5f);
                joinMainView.targetHeadPos = joinMainView.defaultTargetPos;
                joinMainView.HeadCG.transform.GetChild(0).DOScale(joinMainView.targetScale, 0.5f);
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
            if (isSelected)
            {
                ShowOutLine(true);
            }
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        }
        else
        {
            ShowOutLine(false);
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.5f);
        }
    }

    public bool InCorrectArea()
    {
        if (GameManager.instance.curJoinType == JoinType.Animal && (partType == PartType.LeftEye || partType == PartType.RightEye || partType == PartType.Mouth))
        {
            return Utils.IsRectTransformInside(transform.GetComponent<RectTransform>(), transform.parent.parent.GetComponent<RectTransform>());
        }
        if (transform.position.x > leftTop.x
            && transform.position.x < rightBottom.x
            && transform.position.y > rightBottom.y
            && transform.position.y < leftTop.y)
        {
            return true;
        }
        return false;
    }

    public void SetOutline(bool _isSelect)
    {
        isSelected = _isSelect;
        ShowOutLine(isSelected);
    }

    private void ShowOutLine(bool _isSelect)
    {
        if(_isSelect)
        {
            image.material = selectMaterial;
        }
        else
        {
            image.material = null;
        }
    }
}
