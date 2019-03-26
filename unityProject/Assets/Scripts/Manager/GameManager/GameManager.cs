using System.Collections.Generic;
using UnityEngine;
namespace GameMgr
{
    public class GameManager : SingletonMono<GameManager>
    {

        public List<string> homePathList = new List<string>();//选择界面的资源路径
        public List<string> drawBgPathList = new List<string>();//画图背景资源路径

        private List<string> colorPathList = new List<string>();//颜色资源路径

        private List<string> letterEyePathList = new List<string>();//字母眼睛资源路径
        private List<string> numEyePathList = new List<string>();//数字眼睛资源路径
        private List<string> aniEyePathList = new List<string>();//动物眼睛资源路径

        private List<string> letterMouthPathList = new List<string>();//字母嘴巴资源路径
        private List<string> numMouthPathList = new List<string>();//数字嘴巴资源路径
        private List<string> aniMouthPathList = new List<string>();//动物嘴巴资源路径

        private List<string> letterHairPathList = new List<string>();//字母头发资源路径

        private List<string> letterHatPathList = new List<string>();//字母帽子资源路径
        private List<string> numHatPathList = new List<string>();//数字帽子资源路径
        private List<string> aniHatPathList = new List<string>();//动物帽子资源路径

        private List<string> letterHeadWarePathList = new List<string>();//字母饰品资源路径
        private List<string> numHeadWarePathList = new List<string>();//数字饰品资源路径

        private List<string> letterHandPathList = new List<string>();//字母饰品资源路径
        private List<string> numHandPathList = new List<string>();//数字饰品资源路径
        private List<string> AniHandPathList = new List<string>();//数字饰品资源路径

        private List<string> letterLegPathList = new List<string>();//数字饰品资源路径
        private List<string> numLegPathList = new List<string>();//数字饰品资源路径
        private List<string> aniLegPathList = new List<string>();//数字饰品资源路径

        public List<List<string>> resPathList = new List<List<string>>();//全部资源路径

        public List<string> resPrefabPathList = new List<string>();//素材资源prefab路径

        //画笔颜色
        public Color[] ColorList;
        

        public int homeSelectIndex = 0;//选择了那个字母或数字，存放的是下标
        public int resTypeCount = 8;//素材资源种类，目前8种
        public int curSelectResType = 0;//当前选择的素材类型 0颜色 1眼睛 2嘴巴 3头发 4帽子 5饰品 6手7脚
        public Transform Root;

        void Awake()
        {
            instance = this;
            Root = GameObject.Find("root").GetComponent<RectTransform>();
        }

        void Start()
        {
            InitItemList();//首页选字母，数字
            InitResPrefabList();//素材中的预制体路径
            InitResList();//素材资源
        }

        //初始化颜色列表
        void InitColor()
        {
            ColorList = new Color[16]{
            new Color32(0, 0, 0, 255),
            new Color32(0, 0, 0, 255),
            new Color32(228, 82, 75, 255),
            new Color32(143, 93, 76, 255),
            new Color32(237, 141, 57, 255),
            new Color32(80, 160, 75, 255),
            new Color32(250, 228, 84, 255),
            new Color32(151, 92, 215, 255),
            new Color32(157, 221, 80, 255),
            new Color32(139, 85, 230, 255),
            new Color32(95, 184, 249, 255),
            new Color32(47, 41, 44, 255),
            new Color32(236, 135, 188, 255),
            new Color32(131, 133, 135, 255),
            new Color32(145, 209, 208, 255),
            new Color32(255, 255, 255, 255),
            };
        }

        //初始化item列表,首页选字母的
        void InitItemList()
        {
            //26个字母
            string homeLetterPath = "sprite/homeitems|splice_home_{0}_pic";
            string drawBgLetterPath = "sprite/draw|draw_letter_{0}_pic";
            //3个数字
            string homeNumPath = "sprite/homeitems|splice_home_number_{0}_pic";
            string drawBgNumPath = "sprite/draw|draw_num_{0}_pic";

            for (int i = 0; i < 26; i++)
            {
                homePathList.Add(string.Format(homeLetterPath, i.ToString()));
                drawBgPathList.Add(string.Format(drawBgLetterPath, i.ToString()));
            }

            for (int i = 0; i < 3; i++)
            {
                homePathList.Add(string.Format(homeNumPath, i.ToString()));
                drawBgPathList.Add(string.Format(drawBgNumPath, i.ToString()));
            }
        }

        //初始化素材列表
        void InitResList()
        {
            //颜色
            string colorPath = "sprite/small_fodder/color|color_{0}_icon";
            for (int i = 0; i < 16; i++)
            {
                colorPathList.Add(string.Format(colorPath, i.ToString()));
            }
            //眼睛
            string letterEyePath = "sprite/fodder/eye|eye_L_{0}";
            string letterEyePath_R = "sprite/fodder/eye|eye_R_{0}";
            for (int i = 0; i < 25; i++)
            {
                letterEyePathList.Add(string.Format(letterEyePath, i.ToString()));
                letterEyePathList.Add(string.Format(letterEyePath_R, i.ToString()));
            }

            string numEyePath = "sprite/fodder/eye|number_eye_L_{0}";
            string numEyePath_R = "sprite/fodder/eye|number_eye_R_{0}";
            for (int i = 0; i < 2; i++)
            {
                numEyePathList.Add(string.Format(numEyePath, i.ToString()));
                numEyePathList.Add(string.Format(numEyePath_R, i.ToString()));
            }

            string aniEyePath = "sprite/fodder/eye|animal_eye_L_{0}";
            string aniEyePath_R = "sprite/fodder/eye|animal_eye_R_{0}";
            for (int i = 0; i < 3; i++)
            {
                aniEyePathList.Add(string.Format(aniEyePath, i.ToString()));
                aniEyePathList.Add(string.Format(aniEyePath_R, i.ToString()));
            }

            //嘴巴
            string letterMouthPath = "sprite/fodder/mouth|mouse_{0}";
            for (int i = 0; i < 23; i++)
            {
                letterMouthPathList.Add(string.Format(letterMouthPath, i.ToString()));
            }

            string numMouthPath = "sprite/fodder/mouth|number_mouse_{0}";
            for (int i = 0; i < 2; i++)
            {
                numMouthPathList.Add(string.Format(numMouthPath, i.ToString()));
            }

            string aniMouthPath = "sprite/fodder/mouth|animal_mouse_{0}";
            for (int i = 0; i < 3; i++)
            {
                aniMouthPathList.Add(string.Format(aniMouthPath, i.ToString()));
            }

            //头发
            string letterHairPath = "sprite/fodder/hair|hair_{0}";
            for (int i = 0; i < 10; i++)
            {
                letterHairPathList.Add(string.Format(letterHairPath, i.ToString()));
            }

            //帽子
            string letterHatPath = "sprite/fodder/hat|hat_{0}";
            for (int i = 0; i < 14; i++)
            {
                letterHatPathList.Add(string.Format(letterHatPath, i.ToString()));
            }

            string numHatPath = "sprite/fodder/hat|number_hat_{0}";
            for (int i = 0; i < 1; i++)
            {
                numHatPathList.Add(string.Format(numHatPath, i.ToString()));
            }

            string aniHatPath = "sprite/fodder/hat|animal_hat_{0}";
            for (int i = 0; i < 3; i++)
            {
                aniHatPathList.Add(string.Format(aniHatPath, i.ToString()));
            }

            //饰品
            string letterHeadWearPath = "sprite/fodder/headwear|headwear_{0}";
            for (int i = 0; i < 16; i++)
            {
                letterHeadWarePathList.Add(string.Format(letterHeadWearPath, i.ToString()));
            }

            string numHeadWearPath = "sprite/fodder/headwear|number_headwear_{0}";
            for (int i = 0; i < 2; i++)
            {
                numHeadWarePathList.Add(string.Format(numHeadWearPath, i.ToString()));
            }

            //手
            string letterHandPath = "sprite/fodder/hand|hand_L_{0}";
            string letterHandPath_R = "sprite/fodder/hand|hand_R_{0}";
            for (int i = 0; i < 26; i++)
            {
                letterHandPathList.Add(string.Format(letterHandPath, i.ToString()));
                letterHandPathList.Add(string.Format(letterHandPath_R, i.ToString()));

            }

            string numHandPath = "sprite/fodder/hand|number_hand_L_{0}";
            string numHandPath_R = "sprite/fodder/hand|number_hand_R_{0}";
            for (int i = 0; i < 3; i++)
            {
                numHandPathList.Add(string.Format(numHandPath, i.ToString()));
                numHandPathList.Add(string.Format(numHandPath_R, i.ToString()));
            }

            string aniHandPath = "sprite/fodder/hand|animal_hand_L_{0}";
            string aniHandPath_R = "sprite/fodder/hand|animal_hand_R_{0}";
            for (int i = 0; i < 3; i++)
            {
                AniHandPathList.Add(string.Format(aniHandPath, i.ToString()));
                AniHandPathList.Add(string.Format(aniHandPath_R, i.ToString()));
            }

            //脚
            string letterLegPath = "sprite/fodder/leg|leg_L_{0}";
            string letterLegPath_R = "sprite/fodder/leg|leg_R_{0}";
            for (int i = 0; i < 26; i++)
            {
                letterLegPathList.Add(string.Format(letterLegPath, i.ToString()));
                letterLegPathList.Add(string.Format(letterLegPath_R, i.ToString()));
            }

            string numLegPath = "sprite/fodder/leg|number_leg_L_{0}";
            string numLegPath_R = "sprite/fodder/leg|number_leg_R_{0}";
            for (int i = 0; i < 3; i++)
            {
                numLegPathList.Add(string.Format(numLegPath, i.ToString()));
                numLegPathList.Add(string.Format(numLegPath_R, i.ToString()));
            }

            string aniLegPath = "sprite/fodder/leg|animal_leg_L_{0}";
            string aniLegPath_R = "sprite/fodder/leg|animal_leg_R_{0}";
            for (int i = 0; i < 3; i++)
            {
                aniLegPathList.Add(string.Format(aniLegPath, i.ToString()));
                aniLegPathList.Add(string.Format(aniLegPath_R, i.ToString()));
            }

            //组装

            //颜色
            resPathList.Add(colorPathList);
            //眼睛
            List<string> eyePathList = new List<string>();
            for (int i = 0; i < letterEyePathList.Count; i++)
            {
                eyePathList.Add(letterEyePathList[i]);
            }
            for (int i = 0; i < numEyePathList.Count; i++)
            {
                eyePathList.Add(numEyePathList[i]);
            }
            for (int i = 0; i < aniEyePathList.Count; i++)
            {
                eyePathList.Add(aniEyePathList[i]);
            }
            resPathList.Add(eyePathList);
            //嘴巴
            List<string> mouthPathList = new List<string>();
            for (int i = 0; i < letterMouthPathList.Count; i++)
            {
                mouthPathList.Add(letterMouthPathList[i]);
            }
            for (int i = 0; i < numMouthPathList.Count; i++)
            {
                mouthPathList.Add(numMouthPathList[i]);
            }
            for (int i = 0; i < aniMouthPathList.Count; i++)
            {
                mouthPathList.Add(aniMouthPathList[i]);
            }
            resPathList.Add(mouthPathList);
            //头发
            List<string> hairPathList = new List<string>();
            for (int i = 0; i < letterHairPathList.Count; i++)
            {
                hairPathList.Add(letterHairPathList[i]);
            }
            resPathList.Add(hairPathList);
            //帽子
            List<string> hatPathList = new List<string>();
            for (int i = 0; i < letterHatPathList.Count; i++)
            {
                hatPathList.Add(letterHatPathList[i]);
            }
            for (int i = 0; i < numHatPathList.Count; i++)
            {
                hatPathList.Add(numHatPathList[i]);
            }
            for (int i = 0; i < aniHatPathList.Count; i++)
            {
                hatPathList.Add(aniHatPathList[i]);
            }
            resPathList.Add(hatPathList);
            //饰品
            List<string> headWearPathList = new List<string>();
            for (int i = 0; i < letterHeadWarePathList.Count; i++)
            {
                headWearPathList.Add(letterHeadWarePathList[i]);
            }
            for (int i = 0; i < numHeadWarePathList.Count; i++)
            {
                headWearPathList.Add(numHeadWarePathList[i]);
            }
            resPathList.Add(headWearPathList);
            //手
            List<string> handPathList = new List<string>();
            for (int i = 0; i < letterHandPathList.Count; i++)
            {
                handPathList.Add(letterHandPathList[i]);
            }
            for (int i = 0; i < numHandPathList.Count; i++)
            {
                handPathList.Add(numHandPathList[i]);
            }
            for (int i = 0; i < AniHandPathList.Count; i++)
            {
                handPathList.Add(AniHandPathList[i]);
            }
            resPathList.Add(handPathList);
            //脚
            List<string> legPathList = new List<string>();
            for (int i = 0; i < letterLegPathList.Count; i++)
            {
                legPathList.Add(letterLegPathList[i]);
            }
            for (int i = 0; i < numLegPathList.Count; i++)
            {
                legPathList.Add(numLegPathList[i]);
            }
            for (int i = 0; i < aniLegPathList.Count; i++)
            {
                legPathList.Add(aniLegPathList[i]);
            }
            resPathList.Add(legPathList);
        }

        void InitResPrefabList()
        {
            string path = "prefabs/join|res_obj_{0}";
            for (int i = 0; i < resTypeCount; i++)
            {
                resPrefabPathList.Add(string.Format(path, i.ToString()));
            }
        }

        public string FodderToSamllFodderPath(string path)
        {
            string tmpPath = path.Replace("fodder", "small_fodder");
            return tmpPath + "_icon";
        }

        public void SetJoinCurSelectType(int type)
        {
            curSelectResType = type;
        }
    }

   
}
