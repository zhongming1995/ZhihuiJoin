using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameMgr;
using UI.Data;
using Draw_MobilePaint;
using ResMgr;
using UnityEngine.EventSystems;

public class MobileDrag : MonoBehaviour
{
    //外部可用
    public PartType partType;
    public LayerMask layerMask;//拖拽的射线检测层

    [HideInInspector]
    public Transform parentTrans;
    public MobilePaint mobilePaint;//绘画脚本

    //内部变量
    private RaycastHit hit;
    //drag
    private Vector3 offset = new Vector3(0, 0, 0);//拖拽开始时，手指与拖拽物体中心点的偏移
    bool isDragging = false;//是否正在拖拽

    private JoinMainView joinMainView;
    private Vector3 leftTop;
    private Vector3 rightBottom;
    private Vector2 anchorLeftTop;
    private Vector2 anchorRightBottom;
    private RectTransform rt;
    
    bool isInit = false;//是否获取了需要的控件


    void Init()
    {
        leftTop = GameManager.instance.LeftTopPoint.position;
        rightBottom = GameManager.instance.RightBottomPoint.position;
        anchorLeftTop = GameManager.instance.LeftTopPoint.GetComponent<RectTransform>().anchoredPosition;
        anchorRightBottom = GameManager.instance.RightBottomPoint.GetComponent<RectTransform>().anchoredPosition;
        rt = transform.GetComponent<RectTransform>();
        isInit = true;
    }

    //参数是该部件在该类别下对应的下标
    public void InitItem(int index,Transform parent,Vector3 pos)
    {
        Init();
        Debug.Log("Init");
        parentTrans = parent;
        int type = GameManager.instance.curSelectResType;
        partType = (PartType)type;
        string path;
        if (partType==PartType.Body)
        {
            path = GameManager.instance.drawBgPathList[GameManager.instance.homeSelectIndex];
        }
        else
        {
            path = GameManager.instance.resPathList[type][index];
        } 
        //设置绘画背景，初始化绘画组件中的内容
        mobilePaint = transform.GetComponent<MobilePaint>();
        Sprite sprite = ResManager.instance.LoadSprite(path);
        mobilePaint.InitializeEverything(sprite.texture);
        transform.position = pos;
        //mobilePaint.SetBrushSize(20);
    }
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.curSelectResType==0)
        {
            return;
        }
        if (GameObject.Find("EventSystem").GetComponent<EventSystem>().IsPointerOverGameObject())
        {
            return;
        }
        DragEvent();
    }

    void DragEvent()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (Input.GetMouseButtonDown(0))
        {
            if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask)) return;
            Transform t = hit.collider.transform;
            isDragging = true;
            Debug.Log(hit.collider.name);
            //鼠标位置和物体的距离
            offset = t.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPos.z));

            Debug.Log("screenPos：" + screenPos);
            Debug.Log("mousePos:" + Input.mousePosition);
            Debug.Log("offset:" + offset);
        }
        if (Input.GetMouseButton(0))
        {
            //if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask)) return;
            if (isDragging)
            {
                Vector3 curMouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPos.z));
                hit.collider.transform.position = curMouseWorldPos + offset;
                //Debug.Log("offset:" + offset);
                //Debug.Log("cur:" + curMouseWorldPos);
                //Debug.Log("tra:" + transform.position);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            //if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask)) return;
            Debug.Log("mouse up");
        }
    }
}
