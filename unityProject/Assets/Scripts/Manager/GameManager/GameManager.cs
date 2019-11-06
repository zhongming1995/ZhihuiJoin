using AudioMgr;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameMgr
{
    public enum JoinType
    {
        Letter,
        Num,
        Animal,
    }

    //打开拼接页面的方式
    public enum OpenType
    {
        FirstEdit,//从字母列表页点击
        ReEdit,//从画册重新编辑
        BackEdit,//从展示页返回
    }

    //打开展示页面的方式
    public enum DisplayType
    {
        FirstDisplay,//首次打开，需要播放音效，彩带，人物动作
        BackDisplay,
        NoDisplay,//没有展示，从画册进入游戏
    }

    public class GameManager : SingletonMono<GameManager>
    {
        //创建出来的画布
        [HideInInspector]
        public int homeSelectIndex = -1;//选择了那个字母或数字，存放的是下标
        [HideInInspector]
        public float homeContentPosx = 0;//记录列表页的位置
        [HideInInspector]
        public int resTypeCount = 10;//素材资源种类，目前8种
        [HideInInspector]
        public TemplateResType curSelectResType = TemplateResType.Body;//当前选择的素材类型 0颜色 1眼睛 2嘴巴 3头发 4帽子 5饰品 6手 7脚
        [HideInInspector]
        public JoinType curJoinType;//当前拼接的类型是字母，数字还是别的
        [HideInInspector]
        public Canvas gameCanvas;//项目只用了一个场景的时候，用这个Canvas
        [HideInInspector]
        public string nextSceneName;//接下来要跳转的场景名
        [HideInInspector]
        public string nextViewPath;//接下来要打开的view的路径
        [HideInInspector]
        public OpenType openType;//拼接页面的打开方式
        [HideInInspector]
        public DisplayType displayType;//展示页面的打开方式
        [HideInInspector]
        public PartDataWhole curWhole;//当前打开的本地人物数据
        [HideInInspector]
        public bool CalendarDetailShow;//进入画册是否显示详情

        [HideInInspector]
        public float ScreenWidth;
        [HideInInspector]
        public float ScreenHeight;

        [HideInInspector]
        public bool joinShowAll = false;

        [HideInInspector]
        public Texture2D[] personTextureList;

        void Awake()
        {
            Debug.Log("GameManager Awake" + Time.realtimeSinceStartup);
            instance = this;
            ScreenWidth = Screen.width;
            ScreenHeight = Screen.height;
        }

        void Start()
        {
            GameData.instance.InitItemList();
            GameData.instance.InitResPrefabList();
            //GameData.instance.InitResList();
            GameData.instance.InitColor();
        }

        public Canvas GetCanvas()
        {
            if (gameCanvas!=null)
            {
                return gameCanvas;
            }
            return GameObject.Find("Canvas").GetComponent<Canvas>();
        }
      
        public string FodderToSamllFodderPath(string path)
        {
            string tmpPath = path.Replace("fodder", "fodder_icon");
            return tmpPath + "_icon";
        }

        public void SetJoinCurSelectType(TemplateResType type)
        {
            curSelectResType = type;
        }

        public void SetNextSceneName(string name)
        {
            nextSceneName = name;
        }

        public void SetNextViewPath(string path)
        {
            nextViewPath = path;
        }

        public void SetOpenType(OpenType _openType)
        {
            openType = _openType;
        }

        public void SetCurPartDataWhole(PartDataWhole whole)
        {
            curWhole = whole;
        }

        public void SetJoinShowAll(bool show)
        {
            joinShowAll = show;
        }

        public void SetPersonTexture(int index,Texture2D t)
        {
            personTextureList[index] = t;
        }

        public void ClearPersonTextureList()
        {
            if (personTextureList!=null)
            {
                Array.Clear(personTextureList, 0, personTextureList.Length);
                personTextureList = null;
            }
        }

        public void CreatePersonTextureList(int count)
        {
            ClearPersonTextureList();
            personTextureList = new Texture2D[count];
        }
    }
   
}
