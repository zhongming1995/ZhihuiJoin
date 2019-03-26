using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Helper;
using GameMgr;
using DG.Tweening;
using Draw_MobilePaint;

public class JoinMainView : MonoBehaviour
{
    public Button BtnBack;
    public Button BtnBackCheck;
    public Button BtnPre;
    public Button BtnNext;
    public Button BtnOk;
    public Image ImgReference;
    public Image ImgBody;
    public Image ImgLetterRef;
    public Transform DrawPanel;//画布
    public List<GameObject> ResScrollViewList;//各类素材列表
    public List<Transform> ResContentList;//各类素材容器-父节点
    public Transform PosLeftTop;
    public Transform PosRightBottom;
    public Transform ConResType;//类型列表的父节点
    public Slider ImageScaleSlider;//控制图片大小的slider
    public Slider PenScaleSlider;//控制画笔大小的slider
    public Transform ResListTrans;//抽屉动画的节点
	public Transform DrawingPanelCanvas;

    public GraphicRaycaster GraRay_HandLeg;
    public GraphicRaycaster GraRay_Body;
    public GraphicRaycaster GraRay_EyeMouthHair;
    public GraphicRaycaster GraRay_HatHeadwear;

    private List<Transform> typeTransList = new List<Transform>();//类型列表
    private MobilePaint mobilePaint;


    //定义数据变量
    [HideInInspector]
    private Transform curSelectResObj ;
    private int typeCount = 8;//资源类型数量
    private int step = 1;//步骤1-4

    void Start()
    {
        Init();
        //SetCurSelectType(0);
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
        UIHelper.instance.SetImage(GameManager.instance.drawBgPathList[GameManager.instance.homeSelectIndex], ImgLetterRef, true);
        mobilePaint = DrawingPanelCanvas.GetComponent<MobilePaint>();
        if (mobilePaint==null)
        {
            Debug.Log("mobile is null");
        }
        mobilePaint.SetDrawTexture(ImgBody.sprite.texture);
        mobilePaint.SetBrushSize(20);

        //左下角参考缩略图
        UIHelper.instance.SetImage(GameManager.instance.homePathList[GameManager.instance.homeSelectIndex], ImgReference, true);

        //未选择素材时，滑块不出现
        if (curSelectResObj==null)
        {
            ImageScaleSlider.gameObject.SetActive(false);
        }

        //返回按钮显示半透明
        ShowBackBtn(false);

        //加载所有类型素材
        string typeUnSelectPath = "sprite/ui|splice_type_{0}";
        string typeSelectPath = "sprite/ui|splice_type_{0}_select";
        for (int i = 0; i < GameManager.instance.resTypeCount; i++)
        {
            int clickType = i;
            Transform t = UIHelper.instance.LoadPrefab("prefabs/join|res_type_item", ConResType,Vector3.zero,Vector3.one,false).transform;
            UIHelper.instance.SetImage(string.Format(typeSelectPath, i.ToString()), t.GetChild(0).GetComponent<Image>(), true);
            UIHelper.instance.SetImage(string.Format(typeUnSelectPath, i.ToString()), t.GetChild(1).GetComponent<Image>(), true);
            t.GetComponent<Button>().onClick.AddListener(delegate
            {
                TypeButtonClick(clickType);
            });
            typeTransList.Add(t);
        }
    }

    public void ShowBackBtn(bool show)
    {
        BtnBack.gameObject.SetActive(show);
        BtnBackCheck.gameObject.SetActive(!show);
    }

    private void AddClickEvent()
    {
        BtnBackCheck.onClick.AddListener(delegate
        {
            ShowBackBtn(true);
        });

        BtnBack.onClick.AddListener(delegate
        {
            UIHelper.instance.LoadPrefab("prefabs/home|select_item_view", GameManager.instance.Root, Vector3.zero, Vector3.one,true);
            Destroy(gameObject);
        });

        BtnPre.onClick.AddListener(delegate
        {
            step = Mathf.Max(1, step - 1);
            ShowTypeByStep(step);
            ShowBackBtn(false);
        });

        BtnNext.onClick.AddListener(delegate
        {
            step = Mathf.Min(4, step + 1);
            ShowTypeByStep(step);
            ShowBackBtn(false);
        });

        BtnOk.onClick.AddListener(delegate
        {
            gameObject.SetActive(false);
            UIHelper.instance.LoadPrefab("prefabs/display|display_view", GameManager.instance.Root, Vector3.zero, Vector3.one, true);

            //DataManager.instance.TransformToPartsList(DrawPanel);
        });

        ImageScaleSlider.onValueChanged.AddListener(delegate
        {
            ShowBackBtn(false);
           
            curSelectResObj.transform.localScale = new Vector3(0.5f + ImageScaleSlider.value, 0.5f + ImageScaleSlider.value, 0);
        });

    }

    public void SelectColor(Color32 color)
    {
        mobilePaint.SetPaintColor(color);
    }

    public void SetCurSelectType(int type)
    {
        GameManager.instance.SetJoinCurSelectType(type);
        if (type == 0)
        {
            //画笔，要禁用其他部位的事件
            GraRay_HandLeg.enabled = false;
            GraRay_Body.enabled = false;
            GraRay_EyeMouthHair.enabled = false;
            GraRay_HatHeadwear.enabled = false;
        }
        else
        {
            //不是画笔，要禁用画笔
            GraRay_HandLeg.enabled = true;
            GraRay_Body.enabled = true;
            GraRay_EyeMouthHair.enabled = true;
            GraRay_HatHeadwear.enabled = true;
        }
    }

    public void SetSelectResObj(Transform t)
    {
        curSelectResObj = t;
        if (t == null)
        {
            ImageScaleSlider.gameObject.SetActive(false);
            return;
        }
        if (ImageScaleSlider.gameObject.activeSelf == false)
        {
            ImageScaleSlider.gameObject.SetActive(true);
        }
        float scale = t.localScale.x;
        ImageScaleSlider.value = scale - 0.5f; ;
        t.SetAsLastSibling();
    }

    private void TypeButtonClick(int n)
    {
        ShowBackBtn(false);

        Sequence seq = DOTween.Sequence();
        seq.Append(ResListTrans.DOLocalMoveX(454, 0.2f));
        seq.InsertCallback(0.2f, () =>
        {
            SetCurSelectType(n);
            for (int i = 0; i < GameManager.instance.resTypeCount; i++)
            {
                if (i == n)
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
        });
        seq.Append(ResListTrans.DOLocalMoveX(69, 0.2f));
        if (n==0)//选择画笔
        {
            PenScaleSlider.gameObject.SetActive(true);
            ImageScaleSlider.gameObject.SetActive(false);
        }
        else
        {
            PenScaleSlider.gameObject.SetActive(false);
            SetSelectResObj(curSelectResObj);
        }
    }

    private void ShowTypeByStep(int step)
    {
        if (step==1)
        {
            SetCurSelectType(0);
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
            SetCurSelectType(1);
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
            SetCurSelectType(4);
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
            SetCurSelectType(6);
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
                    if (i==0)
                    {
                        string selectPath = imgPath + "_select";
                        UIHelper.instance.SetImage(selectPath, resObj.transform.Find("img_res/img_res_select").GetComponent<Image>(), true);
                    }
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
