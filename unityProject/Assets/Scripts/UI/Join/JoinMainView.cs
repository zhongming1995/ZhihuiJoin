﻿using System.Collections.Generic;
using DG.Tweening;
using Draw_MobilePaint;
using GameMgr;
using Helper;
using UnityEngine;
using UnityEngine.UI;
using DataMgr;
using UnityEngine.SceneManagement;

public class JoinMainView : MonoBehaviour
{
    public Button BtnBack;
    public Button BtnBackCheck;
    public Button BtnPre;
    public Button BtnNext;
    public Button BtnOk;
    public Image ImgReference;
    public Image ImgDraw;
    public Transform DrawPanel;//画布
    public List<GameObject> ResScrollViewList;//各类素材列表
    public List<Transform> ResContentList;//各类素材容器-父节点
    public Transform PosLeftTop;
    public Transform PosRightBottom;
    public Transform ConResType;//类型列表的父节点
    public Slider ImageScaleSlider;//控制图片大小的slider
    public Slider PenScaleSlider;//控制画笔大小的slider
    public Transform ResListTrans;//抽屉动画的节点
    public Transform ContentColor;

    private MobilePaint mobilePaint;
    private Transform BodyGroup;
    private Transform CanvasTrans;


    //定义数据变量
    private Transform curSelectResObj ;
    private int typeCount = 8;//资源类型数量
    private int step = 1;//步骤1-4
    private List<Transform> typeTransList = new List<Transform>();//类型列表
    private bool[] loadResult = new bool[8] { false, false, false, false, false, false, false, false };//用来标示素材列表里的元素是否已被加载

    private int penSize = -1;
    private int eraseSize = 35;
    private bool MultiColorMode = false;
    private int penIndex = 2;//0七彩 1橡皮 2以后单色（修改初始颜色需要到mobilepaint里修改）

    void Start()
    {
        Init();
    }

    void Update()
    {
        if (GameManager.instance.curSelectResType == 0)
        {
            if (mobilePaint!=null)
            {
                mobilePaint.MousePaint();
            }
        }


    }

    void OnEnable()
    {

    }

    private void Init()
    {
        //按钮点击
        AddClickEvent();

        //赋值给GameManager，因为外部要调用
        GameManager.instance.LeftTopPoint = PosLeftTop;
        GameManager.instance.RightBottomPoint = PosRightBottom;

        //绘画素材
        BodyGroup = transform.Find("img_draw_bg/draw_panel/group_body").transform;
        GameObject draw = UIHelper.instance.LoadPrefab("prefabs/draw|draw_item", BodyGroup, new Vector3(0f, 0f, 0), new Vector3(135,135,135));

        Sprite s = UIHelper.instance.LoadSprite(GameManager.instance.drawBgPathList[GameManager.instance.homeSelectIndex]);
        mobilePaint = draw.GetComponent<MobilePaint>();
        mobilePaint.InitializeEverything(s.texture);
        mobilePaint.SetBrushSize(1);
        draw.transform.localPosition = new Vector3(-1757, -68, 0);

        //Canvas结点
        CanvasTrans = transform.GetComponentInParent<Canvas>().transform;

        //左下角参考缩略图
        UIHelper.instance.SetImage(GameManager.instance.homePathList[GameManager.instance.homeSelectIndex], ImgReference, true);

        //未选择素材时，滑块不出现
        if (curSelectResObj==null)
        {
            ImageScaleSlider.gameObject.SetActive(false);
        }

        //返回按钮显示半透明
        ShowBackBtn(false);

        //加载颜色列表
        //LoadResList((int)PartType.Body);

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
                TypeButtonClick((TemplateResType)clickType);
            });
            typeTransList.Add(t);
        }

        ContentColor.gameObject.AddComponent<ColorToggleCtrl>();

        TypeButtonClick(TemplateResType.Body);//初始选中第一个类型
        step = 1;//初始是第一步
        ShowTypeByStep(step);
        LoadResListByType((int)PartType.Body);//初始加载颜色列表,Body是0
        PenScaleSlider.value = 0.5f;
        ImageScaleSlider.value = 0.5f;
        AdjustBurshSize(PenScaleSlider.value);
    }

    //类型按钮
    void LoadResList(int resType)
    {
        string typeUnSelectPath = "sprite/ui|splice_type_{0}";
        string typeSelectPath = "sprite/ui|splice_type_{0}_select";
        Transform t = UIHelper.instance.LoadPrefab("prefabs/join|res_type_item", ConResType, Vector3.zero, Vector3.one, false).transform;
        UIHelper.instance.SetImage(string.Format(typeSelectPath, resType.ToString()), t.GetChild(0).GetComponent<Image>(), true);
        UIHelper.instance.SetImage(string.Format(typeUnSelectPath, resType.ToString()), t.GetChild(1).GetComponent<Image>(), true);
        t.GetComponent<Button>().onClick.AddListener(delegate
        {
            TypeButtonClick((TemplateResType)resType);
        });
        typeTransList.Add(t);
    }

    //显示返回按钮，否则是半透明状态
    public void ShowBackBtn(bool show)
    {
        BtnBack.gameObject.SetActive(show);
        BtnBackCheck.gameObject.SetActive(!show);
    }

    //按钮点击事件
    private void AddClickEvent()
    {
        BtnBackCheck.onClick.AddListener(delegate
        {
            ShowBackBtn(true);
        });

        BtnBack.onClick.AddListener(delegate
        {
            SceneManager.LoadScene("home");
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
            /*测试贴图加载
            byte[] b = GetDrawTexture().EncodeToPNG();
            Texture2D t = new Texture2D(GetDrawTexture().width, GetDrawTexture().height,TextureFormat.RGBA32,false);
            t.filterMode = FilterMode.Point;
            //t.wrapMode = TextureWrapMode.Clamp;
            //t.LoadRawTextureData(b);
            //t.Apply();
            t.LoadImage(b);
            Sprite s = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0.5f, 0.5f));
            testImage.sprite = s;
            testImage.SetNativeSize();
            testImage.transform.localScale = Vector3.one;
            */

            gameObject.SetActive(false);
            Texture2D t = GetDrawTexture();
            Sprite s = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0.5f, 0.5f));
            ImgDraw.sprite = s;
            ImgDraw.SetNativeSize();
            ImgDraw.transform.localScale = Vector3.one;
            DataManager.instance.partDataList = DataManager.instance.TransformToPartsList(DrawPanel);
            UIHelper.instance.LoadPrefab("prefabs/display|display_view",CanvasTrans, Vector3.zero, Vector3.one, true);

        });

        ImageScaleSlider.onValueChanged.AddListener(delegate
        {
            ShowBackBtn(false);
           
            curSelectResObj.transform.localScale = new Vector3(0.5f + ImageScaleSlider.value, 0.5f + ImageScaleSlider.value, 0);
        });

        PenScaleSlider.onValueChanged.AddListener(delegate
        {
            ShowBackBtn(false);
            AdjustBurshSize(PenScaleSlider.value);
        });
    }

    private void AdjustBurshSize(float sliderValue)
    {
        int brushSize = (int)(sliderValue * 10);//临时变量
        eraseSize = (int)(sliderValue * 25 + 25);//橡皮擦的尺寸控制在25 ～ 50
        //橡皮擦的笔触大小
        if (penIndex == 1)
        {
            Debug.Log(eraseSize);
            mobilePaint.SetBrushSize(eraseSize);
        }
        else
        {
            //因为蜡笔笔刷调整是通过不同尺寸的笔刷图来实现的，所以统一尺寸的图不重新设置
            if (penSize != brushSize)
            {
                mobilePaint.ChangeBrush(brushSize);
            }
        }
        penSize = brushSize;
    }

    //右侧选择颜色
    public void SelectColor(int index, Color32 color)
    {
        penIndex = index;
        if (index == 0)
        {
            Debug.Log("彩虹笔");
            MultiColorMode = true;
            mobilePaint.SetDrawModeBrush();
            mobilePaint.ChangeBrush(penSize);
            mobilePaint.SetBrushSize(1);
            //mobilePaint.SetPaintColor(color);
            mobilePaint.SetMultiColor(true);
        }
        else if (index == 1)
        {
            Debug.Log("橡皮擦");
            mobilePaint.SetMultiColor(false);
            mobilePaint.SetDrawModeEraser();
            mobilePaint.SetBrushSize(eraseSize);
        }
        else
        {
            Debug.Log("单色蜡笔");
            mobilePaint.SetMultiColor(false);
            mobilePaint.SetDrawModeBrush();
            mobilePaint.ChangeBrush(penSize);
            mobilePaint.SetBrushSize(1);
            mobilePaint.SetPaintColor(color);
        }
    }

    //右侧素材类型切换
    public void SetCurSelectType(TemplateResType type)
    {
        GameManager.instance.SetJoinCurSelectType(type);
      
        if (type == 0)
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

    //选中某个部件
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

    //右侧类型图标点击事件
    private void TypeButtonClick(TemplateResType type)
    {
        ShowBackBtn(false);

        Sequence seq = DOTween.Sequence();
        seq.Append(ResListTrans.DOLocalMoveX(454, 0.2f));
        seq.InsertCallback(0.2f, () =>
        {

            SetCurSelectType(type);
            for (int i = 0; i < GameManager.instance.resTypeCount; i++)
            {
                if (i == (int)type)
                {
                    typeTransList[i].GetChild(0).gameObject.SetActive(true);
                    typeTransList[i].GetChild(1).gameObject.SetActive(false);
                    if (loadResult[(int)type] == false)
                    {
                        LoadResListByType((int)type);
                    }
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

    }

    //根据步骤决定显示哪个类型的素材
    private void ShowTypeByStep(int step)
    {
        if (step==1)
        {
            SetCurSelectType(TemplateResType.Body);
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
            SetCurSelectType(TemplateResType.Eye);
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
            SetCurSelectType(TemplateResType.Hat);
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
            SetCurSelectType(TemplateResType.Hand);
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

    //加载所有类型素材
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

    //加载某种类型的素材
    private void LoadResListByType(int type)
    {
        string resPrefabPath = GameManager.instance.resPrefabPathList[type];
        List<string> resPath = GameManager.instance.resPathList[type];
        if (resPath.Count <= 0)
        {
            return;
        }
        for (int j = 0; j < resPath.Count; j++)
        {
            GameObject resObj = UIHelper.instance.LoadPrefab(resPrefabPath, ResContentList[type], Vector3.zero, Vector3.one, false);
            if (type == 0 || type == 1 || type == 6 || type == 7)
            {
                string imgPath = resPath[j];
                if (type != 0)
                {
                    imgPath = GameManager.instance.FodderToSamllFodderPath(resPath[j]);
                }
                UIHelper.instance.SetImage(imgPath, resObj.transform.Find("img_res").GetComponent<Image>(), true);
                if (type == 0)
                {
                    string selectPath = imgPath + "_select";
                    UIHelper.instance.SetImage(selectPath, resObj.transform.Find("img_res/img_res_select").GetComponent<Image>(), true);
                }
            }
            else
            {
                string imgPath = GameManager.instance.FodderToSamllFodderPath(resPath[j]);
                UIHelper.instance.SetImage(imgPath, resObj.transform.GetComponent<Image>(), true);
            }
        }

        loadResult[type] = true;
    }

    public Texture2D GetDrawTexture()
    {
        if (mobilePaint)
        {
            return mobilePaint.GetDrawTexture();
        }
        return null;
    }

}
