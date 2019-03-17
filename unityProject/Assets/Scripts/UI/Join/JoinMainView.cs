using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Helper;
using GameMgr;

public class JoinMainView : MonoBehaviour
{
    public Button BtnBack;
    public Button BtnPre;
    public Button BtnNext;
    public Button BtnOk;
    public Image ImgReference;
    public Image ImgBody;
    public List<GameObject> ResScrollViewList;//各类素材列表
    public List<Transform> ResContentList;//各类素材容器-父节点
    public Transform PosLeftTop;
    public Transform PosRightBottom;
    public Transform conResType;//类型列表的父节点
    public Slider imageScaleSlider;//控制图片大小的slider

    private List<Transform> typeTransList = new List<Transform>();//类型列表


    //定义数据变量
    [HideInInspector]
    private Transform curSelectResObj ;
    private int typeCount = 8;//资源类型数量
    private int step = 1;//步骤1-4

    void Start()
    {
        Init();
        GameManager.instance.curSelectResType = 0;//默认选择颜色
        TypeButtonClick(0);//初始选中第一个类型
        ShowTypeByStep(step);
        LoadAllResList();
    }


    private void Init()
    {
        //按钮点击
        AddClickEvent();

        //绘画素材
        UIHelper.instance.SetImage(GameManager.instance.drawBgPathList[GameManager.instance.homeSelectIndex], ImgBody, true);

        //左下角参考缩略图
        UIHelper.instance.SetImage(GameManager.instance.homePathList[GameManager.instance.homeSelectIndex], ImgReference, true);

        //加载所有类型
        string typeUnSelectPath = "sprite/ui|splice_type_{0}";
        string typeSelectPath = "sprite/ui|splice_type_{0}_select";
        for (int i = 0; i < GameManager.instance.resTypeCount; i++)
        {
            int clickType = i;
            Transform t = UIHelper.instance.LoadPrefab("prefabs/join|res_type_item", conResType,Vector3.zero,Vector3.one,false).transform;
            UIHelper.instance.SetImage(string.Format(typeSelectPath, i.ToString()), t.GetChild(0).GetComponent<Image>(), true);
            UIHelper.instance.SetImage(string.Format(typeUnSelectPath, i.ToString()), t.GetChild(1).GetComponent<Image>(), true);
            t.GetComponent<Button>().onClick.AddListener(delegate
            {
                TypeButtonClick(clickType);
            });
            typeTransList.Add(t);
        }
    }

    private void AddClickEvent()
    {
        BtnBack.onClick.AddListener(delegate
        {
            UIHelper.instance.LoadPrefab("prefabs/home|select_item_view", GameManager.instance.Root, Vector3.zero, Vector3.one,true);
            Destroy(gameObject);
        });

        BtnPre.onClick.AddListener(delegate
        {
            step = Mathf.Max(1, step - 1);
            ShowTypeByStep(step);
        });

        BtnNext.onClick.AddListener(delegate
        {
            step = Mathf.Min(4, step + 1);
            ShowTypeByStep(step);
        });

        imageScaleSlider.onValueChanged.AddListener(delegate
        {
            Debug.Log(imageScaleSlider.value);
            curSelectResObj.transform.localScale = new Vector3(0.5f + imageScaleSlider.value, 0.5f + imageScaleSlider.value, 0);
        });

    }

    public void SetSelectResObj(Transform t)
    {
        if (t == null)
        {
            return;
        }
        curSelectResObj = t;
        float scale = t.localScale.x;
        imageScaleSlider.value = scale - 0.5f; ;
        t.SetAsLastSibling();
    }

    private void TypeButtonClick(int n)
    {
        GameManager.instance.curSelectResType = n;
        for (int i = 0; i < GameManager.instance.resTypeCount; i++)
        {
            if (i==n)
            {
                typeTransList[i].GetChild(0).gameObject.SetActive(true);
                typeTransList[i].GetChild(1).gameObject.SetActive(false);
                ResScrollViewList[i].gameObject.SetActive(true);
            }
            else
            {
                typeTransList[i].GetChild(0).gameObject.SetActive(false);
                typeTransList[i].GetChild(1).gameObject.SetActive(true);
                ResScrollViewList[i].gameObject.SetActive(false);
            }
        }
    }

    private void ShowTypeByStep(int step)
    {
        if (step==1)
        {
            GameManager.instance.curSelectResType = 0;
            BtnPre.gameObject.SetActive(false);
            BtnNext.gameObject.SetActive(true);
            BtnOk.gameObject.SetActive(false);
            typeTransList[0].gameObject.SetActive(true);
            for (int i = 1; i < GameManager.instance.resTypeCount; i++)
            {
                typeTransList[i].gameObject.SetActive(false);
            }
        }else if (step==2)
        {
            GameManager.instance.curSelectResType = 1;
            BtnPre.gameObject.SetActive(true);
            BtnNext.gameObject.SetActive(true);
            BtnOk.gameObject.SetActive(false);
            for (int i = 0; i < 4; i++)
            {
                typeTransList[i].gameObject.SetActive(true);
            }
            for (int i = 4; i < GameManager.instance.resTypeCount; i++)
            {
                typeTransList[i].gameObject.SetActive(false);
            }
        }else if (step == 3)
        {
            GameManager.instance.curSelectResType = 4;
            BtnPre.gameObject.SetActive(true);
            BtnNext.gameObject.SetActive(true);
            BtnOk.gameObject.SetActive(false);
            typeTransList[0].gameObject.SetActive(true);
            for (int i = 1; i < 4; i++)
            {
                typeTransList[i].gameObject.SetActive(false);
            }
            for (int i = 4; i < 6; i++)
            {
                typeTransList[i].gameObject.SetActive(true);
            }
            for (int i = 6; i < 8; i++)
            {
                typeTransList[i].gameObject.SetActive(false);
            }
        }
        else if (step == 4)
        {
            GameManager.instance.curSelectResType = 6;
            BtnPre.gameObject.SetActive(true);
            BtnNext.gameObject.SetActive(false);
            BtnOk.gameObject.SetActive(true);
            typeTransList[0].gameObject.SetActive(true);
            for (int i = 1; i < 6; i++)
            {
                typeTransList[i].gameObject.SetActive(false);
            }
            for (int i = 6; i < GameManager.instance.resTypeCount; i++)
            {
                typeTransList[i].gameObject.SetActive(true);
            }
        }
        TypeButtonClick(GameManager.instance.curSelectResType);
    }

    private void LoadAllResList()
    {
        for (int i = 0; i < GameManager.instance.resTypeCount; i++)
        {
            string resPrefabPath = GameManager.instance.resPrefabPathList[i];
            List<string> resPath = GameManager.instance.resPathList[i];
            if (resPath.Count <= 0)
            {
                continue;
            }
            for (int j = 0; j < resPath.Count; j++)
            {
                GameObject resObj = UIHelper.instance.LoadPrefab(resPrefabPath, ResContentList[i], Vector3.zero, Vector3.one, false);
                if (i == 0 || i == 1 || i == 6 || i== 7)
                {
                    string imgPath = resPath[j];
                    if (i != 0)
                    {
                        imgPath = GameManager.instance.FodderToSamllFodderPath(resPath[j]);
                    }
                    UIHelper.instance.SetImage(imgPath, resObj.transform.Find("img_res").GetComponent<Image>(), true);
                }
                else
                {
                    string imgPath  = GameManager.instance.FodderToSamllFodderPath(resPath[j]);
                    UIHelper.instance.SetImage(imgPath, resObj.transform.GetComponent<Image>(), true);
                }
            }
        }
    }
}
