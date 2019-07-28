using System.Collections.Generic;
using DG.Tweening;
using Draw_MobilePaint;
using GameMgr;
using Helper;
using UnityEngine;
using UnityEngine.UI;
using DataMgr;
using UnityEngine.SceneManagement;
using AudioMgr;
using System.Collections;
using System;

public class JoinMainView : MonoBehaviour
{
    private JoinGuide joinGuide;
    public Button BtnBack;
    public Button BtnBackCheck;
    public Button BtnPre;
    public Button BtnNext;
    public Button BtnOk;
    public Image ImgReference;
    public Image ImgDraw;
    public Image ImgDrawBg;
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

    public MobilePaint mobilePaint;
    private Transform BodyGroup;
    [HideInInspector]
    public bool hasPainted;//涂色过，即涂色面积>0过
    [HideInInspector]
    public bool hasDraged;//是否拖入过素材（附着过）

    //定义数据变量
    private Transform curSelectResObj;
    private ResDragItem curResDragItem;//选中部位身上挂的脚本
    private int typeCount = 8;//资源类型数量
    [HideInInspector]
    public int step = 1;//步骤1-4
    public List<Transform> typeTransList = new List<Transform>();//类型列表
    private bool[] loadResult = new bool[8] { false, false, false, false, false, false, false, false };//用来标示素材列表里的元素是否已被加载
    private bool[] guideResult = {false,false,false,false };//用来标示每一步的引导语音是否已经播放

    private int penSize = -1;
    private int eraseSize = 35;
    private bool MultiColorMode = false;
    private int penIndex = 2;//0七彩 1橡皮 2以后单色（修改初始颜色需要到mobilepaint里修改）
    private float oriPos_ResContentList = 500;
    private float desPos_ResContentList = 69;

    private JoinPlus joinPlus;

    private void OnEnable()
    {
        AppEntry.instance.SetMultiTouchEnable(false);
    }

    void Start()
    {
        Init();
    }
    

    void Update()
    {
        if (mobilePaint != null)
        {
            if (mobilePaint.havePainted)
            {
                //只要有大于0过就ok
                hasPainted = true;
            }
            if (step==1)
            {
                if (hasPainted == true && guideResult[0] == true)
                {
                    BtnNext.interactable = true;
                }
                else
                {
                    BtnNext.interactable = false;
                }
            }
            if (step==4)
            {
                if (guideResult[3]==true)
                {
                    BtnOk.interactable = true;
                }
                else
                {
                    BtnOk.interactable = false;
                }
            }
            if (GameManager.instance.curSelectResType == 0)
            {
                mobilePaint.MousePaint();
            }
        }
    }

    private void Init()
    {
        //补充脚本
        joinPlus = GetComponent<JoinPlus>();

        mobilePaint.gameObject.SetActive(false);
        //引导脚本
        joinGuide = GetComponent<JoinGuide>();
        if (joinGuide==null)
        {
            joinGuide = gameObject.AddComponent<JoinGuide>();
        }
        //按钮点击
        AddClickEvent();
        //左下角参考缩略图
        UIHelper.instance.SetImage(GameManager.instance.homePathList[GameManager.instance.homeSelectIndex], ImgReference, true);
        //涂色背景（只做淡入展示）
        UIHelper.instance.SetImage(GameManager.instance.drawBgPathList[GameManager.instance.homeSelectIndex], ImgDrawBg, true);
        //未选择素材时，滑块不出现
        if (curSelectResObj==null)
        {
            ImageScaleSlider.gameObject.SetActive(false);
        }
        //返回按钮显示半透明
        ShowBackBtn(false);

        //右边素材切换按钮
        for (int i = 0; i < GameManager.instance.resTypeCount; i++)
        {
            int clickType = i;
            typeTransList[i].GetComponent<Button>().onClick.AddListener(delegate
            {
                SetSelectResObj(null);
                joinGuide.DoOperation();
                AudioManager.instance.PlayAudio(EffectAudioType.Option, "Audio/option_audio/material_option_audio|material_" + clickType);
                TypeButtonClick((TemplateResType)clickType, true);
            });
        }
        step = 1;//初始是第一步
        ShowTypeByStep(step,true);
        SetDrawMessage();
        ContentColor.gameObject.AddComponent<ColorToggleCtrl>();
        LoadResListByType((int)PartType.Body);//初始加载颜色列表,Body是0

        //test
        if (GameManager.instance.openType==OpenType.ReEdit && GameManager.instance.curWhole!=null)
        {
            joinPlus.LoadFile(GameManager.instance.curWhole);
        }
    }

    void ShowDrawPanel()
    {
        mobilePaint.gameObject.SetActive(true);
    }

    void SetDrawMessage()
    {
        //绘画素材
        //BodyGroup = transform.Find("img_draw_bg/draw_panel/group_body").transform;
        //GameObject draw = UIHelper.instance.LoadPrefab("Prefabs/draw|draw_item", BodyGroup, new Vector3(71, -38, 0), new Vector3(150,150,150));
        Sprite s = UIHelper.instance.LoadSprite(GameManager.instance.drawBgPathList[GameManager.instance.homeSelectIndex]);
        mobilePaint.InitializeEverything(s.texture);
        mobilePaint.SetBrushSize(1);
        PenScaleSlider.value = 0.5f;
        ImageScaleSlider.value = 0.5f;
        AdjustBurshSize(PenScaleSlider.value);
        joinGuide.AddMobileDrawDelagate();

        //mobilePaint.gameObject.SetActive(false);
        Invoke("ShowDrawPanel",0.4f);
    }

    /// <summary>
    /// 返回编辑时，回到第二步
    /// </summary>
    /// <param name="show">If set to <c>true</c> show.</param>
    public void BackToJoinEdit()
    {
        ShowTypeByStep(2);
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
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            ShowBackBtn(true);
        });

        BtnBack.onClick.AddListener(delegate
        {
            AudioManager.instance.StopEffect();
            joinGuide.DoOperation();
            SceneManager.LoadScene("home");
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
        });

        BtnPre.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            joinGuide.DoOperation();
            step = Mathf.Max(1, step - 1);
            ShowTypeByStep(step);
            ShowBackBtn(false);
            BtnNext.interactable = true;
        });

        BtnNext.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            joinGuide.DoOperation();
            step = Mathf.Min(4, step + 1);
            ShowTypeByStep(step);
            ShowBackBtn(false);
        });

        BtnOk.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            joinGuide.DoOperation();
            gameObject.SetActive(false);
            //Texture2D t = GetDrawTexture();
            //Sprite s = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0.5f, 0.5f));
            //ImgDraw.sprite = s;
            //ImgDraw.SetNativeSize();
            //ImgDraw.transform.localScale = Vector3.one;
            DataManager.instance.TransformToPartsList(DrawPanel, GameManager.instance.homeSelectIndex, mobilePaint.GetAllPixels(),mobilePaint.GetDrawByte());
            UIHelper.instance.LoadPrefab("Prefabs/display|display_view",GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
            //GameManager.instance.SetNextViewPath("Prefabs/display|display_view");
            //UIHelper.instance.LoadPrefab("Prefabs/common|transition_prefab_view", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
        });

        ImageScaleSlider.onValueChanged.AddListener(delegate
        {
            joinGuide.DoOperation();
            ShowBackBtn(false);
            curSelectResObj.transform.localScale = new Vector3(0.5f + ImageScaleSlider.value, 0.5f + ImageScaleSlider.value, 0);
            curSelectResObj.GetComponent<ResDragItem>().SetScale(curSelectResObj.transform.localScale);
        });

        PenScaleSlider.onValueChanged.AddListener(delegate
        {
            joinGuide.DoOperation();
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
                //mobilePaint.ChangeBrush(brushSize);
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
            MultiColorMode = true;
            mobilePaint.SetDrawModeBrush();
            //mobilePaint.ChangeBrush(penSize);
            mobilePaint.SetBrushSize(1);
            //mobilePaint.SetPaintColor(color);
            mobilePaint.SetMultiColor(true);
        }
        else if (index == 1)
        {
            mobilePaint.SetMultiColor(false);
            mobilePaint.SetDrawModeEraser();
            mobilePaint.SetBrushSize(eraseSize);
        }
        else
        {
            mobilePaint.SetMultiColor(false);
            mobilePaint.SetDrawModeBrush();
            //mobilePaint.ChangeBrush(penSize);
            mobilePaint.ChangeBrush(0);
            mobilePaint.SetBrushSize(1);
            mobilePaint.SetPaintColor(color);
        }
    }

    //右侧素材类型切换
    public void SetCurSelectType(TemplateResType type)
    {
        if (GameManager.instance.curSelectResType==type)
        {
            return;
        }
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
        ResDragItem oldDragItem = curResDragItem;
        Transform oldObj = curSelectResObj;
        curSelectResObj = t;

        if (oldObj==null)
        {
            if (t==null)
            {
                ImageScaleSlider.gameObject.SetActive(false);
                return;
            }
            curResDragItem = curSelectResObj.GetComponent<ResDragItem>();
            curResDragItem.SetOutline(true);
        }
        else
        {
            if (t==null)
            {
                oldDragItem.SetOutline(false);
                ImageScaleSlider.gameObject.SetActive(false);
                return;
            }
            if (oldObj.GetInstanceID()!=t.GetInstanceID())
            {
                oldDragItem.SetOutline(false);
                curResDragItem = curSelectResObj.GetComponent<ResDragItem>();
                curResDragItem.SetOutline(true);
            }
            else
            {
                return;
            }
        }
        //以下是t不为空,且与old不是同一个物体才会执行的
        if (ImageScaleSlider.gameObject.activeSelf == false)
        {
            ImageScaleSlider.gameObject.SetActive(true);
        }
        float scale = t.localScale.x;
        ImageScaleSlider.value = scale - 0.5f; ;
        t.SetAsLastSibling();
    }

    //右侧类型图标点击事件
    private void TypeButtonClick(TemplateResType type,bool isClick = false)
    {
        if (isClick && type == GameManager.instance.curSelectResType)
        {
            return;
        }
        ShowBackBtn(false);
        if (type==TemplateResType.Body)
        {
            ImgDrawBg.DOFade(1, 0.5f).OnComplete(()=> {
                ImgDraw.gameObject.SetActive(false);
                mobilePaint.gameObject.SetActive(true);
            });
        }
        else
        {
            Debug.Log("TypeButtonClick=========");
            Texture2D t = GetDrawTexture();
            ImgDraw.gameObject.SetActive(true);
            Sprite s = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0.5f, 0.5f));
            ImgDraw.sprite = s;
            ImgDraw.SetNativeSize();
            ImgDraw.transform.localScale = Vector3.one;
            mobilePaint.gameObject.SetActive(false);
            ImgDrawBg.DOFade(0, 0.5f);
        }
        Sequence seq = DOTween.Sequence();
        seq.Append(ResListTrans.DOLocalMoveX(oriPos_ResContentList, 0.2f));
        seq.InsertCallback(0.2f, () =>
        {
            ShowResListByType(type);
        });
        seq.Append(ResListTrans.DOLocalMoveX(desPos_ResContentList, 0.2f));
    }

    private void ShowResListByType(TemplateResType type)
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
    }

    //根据步骤决定显示哪个类型的素材
    private void ShowTypeByStep(int step,bool isDefault = false)
    {
        this.step = step;
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
            BtnPre.gameObject.SetActive(false);
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
        if (isDefault == false)
        {
            TypeButtonClick(GameManager.instance.curSelectResType);
        }
        else
        {
            ShowResListByType(GameManager.instance.curSelectResType);
        }

        if (guideResult[step - 1] == false)
        {
            //播放引导语音
            string audioPath = "Audio/guide_effect|guide_" + GameManager.instance.curJoinType.ToString().ToLower() + "_" + step.ToString();
            if (step == 1)
            {
                StartCoroutine(CorPlayGuideStep1(audioPath, step));
            }
            else
            {
                PlayGuideAudio(audioPath, step);
            }
        }
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
        float width = ResContentList[type].GetComponent<RectTransform>().rect.size.x;
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
                Image resImg = resObj.transform.Find("img_res").GetComponent<Image>();
                UIHelper.instance.SetImage(imgPath, resImg, true);
                float y = resImg.GetComponent<RectTransform>().sizeDelta.y;
                resObj.GetComponent<RectTransform>().sizeDelta = new Vector2(width + 30, y + 40);
                //UIHelper.instance.SetImage(imgPath, resObj.transform.Find("img_res").GetComponent<Image>(), true);
                if (type == 0)
                {
                    string selectPath = imgPath + "_select";
                    UIHelper.instance.SetImage(selectPath, resObj.transform.Find("img_res/img_res_select").GetComponent<Image>(), true);
                }
            }
            else
            {
                string imgPath = GameManager.instance.FodderToSamllFodderPath(resPath[j]);
                //UIHelper.instance.SetImage(imgPath, resObj.transform.GetComponent<Image>(), true);
                Image resImg = resObj.transform.Find("img_res").GetComponent<Image>();
                UIHelper.instance.SetImage(imgPath, resImg, true);
                float y = resImg.GetComponent<RectTransform>().sizeDelta.y;
                resObj.GetComponent<RectTransform>().sizeDelta = new Vector2(width+20, y+45);
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

    public void PlayGuideAudio(string path,int step)
    {
        BtnNext.interactable = false;
        AudioManager.instance.PlayAudio(EffectAudioType.Guide, path,()=>
        {
            guideResult[step - 1] = true;
            BtnNext.interactable = true;
            if (joinGuide.isOperating == false)
            {
                joinGuide.DoOperation();
            }
        });
    }

    IEnumerator CorPlayGuideStep1(string path,int step)
    {
        yield return new WaitForSeconds(1.4f);
        PlayGuideAudio(path,step);
    }

    private void OnDestroy()
    {
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
