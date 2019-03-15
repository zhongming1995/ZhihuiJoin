using System.Collections.Generic;
using UnityEngine;
namespace GameMgr
{
    public class GameManager : SingletonMono<GameManager>
    {

        public List<string> homePathList = new List<string>();//选择界面的资源路径
        public List<string> drawBgPathList = new List<string>();//画图背景资源路径

        public List<string> letterEyePathList = new List<string>();//字母眼睛资源路径
        public List<string> numEyePathList = new List<string>();//数字眼睛资源路径
        public List<string> aniEyePathList = new List<string>();//动物眼睛资源路径

        public List<string> letterMouthPathList = new List<string>();//字母嘴巴资源路径
        public List<string> numMouthPathList = new List<string>();//数字嘴巴资源路径
        public List<string> aniMouthPathList = new List<string>();//动物嘴巴资源路径

        public List<string> letterHairPathList = new List<string>();//字母头发资源路径

        public List<string> letterHatPathList = new List<string>();//字母帽子资源路径
        public List<string> numHatPathList = new List<string>();//数字帽子资源路径
        public List<string> aniHatPathList = new List<string>();//动物帽子资源路径

        public List<string> letterHeadWarePathList = new List<string>();//字母饰品资源路径
        public List<string> numHeadWarePathList = new List<string>();//数字饰品资源路径

        public List<string> letterHandPathList = new List<string>();//字母饰品资源路径
        public List<string> numHandPathList = new List<string>();//数字饰品资源路径
        public List<string> AniHandPathList = new List<string>();//数字饰品资源路径

        public List<string> letterLegPathList = new List<string>();//数字饰品资源路径
        public List<string> numLegPathList = new List<string>();//数字饰品资源路径
        public List<string> aniLegPathList = new List<string>();//数字饰品资源路径

        public int homeSelectIndex = 0;//选择了那个字母或数字，存放的是下标
        public Transform Root;

        void Awake() 
        {
            instance = this;
            Root = GameObject.Find("root").GetComponent<RectTransform>();
        }

        void Start()
        {
            InitItemList();

        }

        //初始化item列表
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

        void InitResList()
        {
            //眼睛
            string letterEyePath = "sprite/fodder/eye|eye_L_{0}";
            for (int i = 0; i < 25; i++)
            {
                letterEyePathList.Add(string.Format(letterEyePath, i.ToString()));
            }

            string numEyePath = "sprite/fodder/eye|number_eye_L_{0}";
            for (int i = 0; i < 3; i++)
            {
                numEyePathList.Add(string.Format(numEyePath, i.ToString()));
            }

            string aniEyePath = "sprite/fodder/eye|animal_eye_L_{0}";
            for (int i = 0; i < 4; i++)
            {
                aniEyePathList.Add(string.Format(aniEyePath, i.ToString()));
            }

            //嘴巴
            string letterMouthPath = "sprite/fodder/mouth|mouse_{0}";
            for (int i = 0; i < 23; i++)
            {
                letterMouthPathList.Add(string.Format(letterMouthPath, i.ToString()));
            }

            string numMouthPath = "sprite/fodder/mouth|number_mouse_{0}";
            for (int i = 0; i < 3; i++)
            {
                numMouthPathList.Add(string.Format(numMouthPath, i.ToString()));
            }

            string aniMouthPath = "sprite/fodder/mouth|animal_mouse_{0}";
            for (int i = 0; i < 4; i++)
            {
                aniMouthPathList.Add(string.Format(aniMouthPath, i.ToString()));
            }

            //头发
            string letterHairPath = "sprite/fodder/hair|hair_{0}";
            for (int i = 0; i < 10; i++)
            {
                letterHatPathList.Add(string.Format(letterHairPath, i.ToString()));
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

            string numHeadWearPath = "sprite/fodder/headwear|number_headwear_0{0}";
            for (int i = 0; i < 3; i++)
            {
                numHeadWarePathList.Add(string.Format(numHeadWearPath, i.ToString()));
            }

            //手
            string letterHandPath = "sprite/fodder/hand|hand_L_{0}";
            for (int i = 0; i < 26; i++)
            {
                letterHandPathList.Add(string.Format(letterHandPath, i.ToString()));
            }

            string numHandPath = "sprite/fodder/hand|number_hand_L_{0}";
            for (int i = 0; i < 4; i++)
            {
                numHandPathList.Add(string.Format(numHandPath, i.ToString()));
            }

            string aniHandPath = "sprite/fodder/hand|animal_hand_L_{0}";
            for (int i = 0; i < 4; i++)
            {
                AniHandPathList.Add(string.Format(aniHandPath, i.ToString()));
            }

            //脚
            string letterLegPath = "sprite/fodder/leg/hat|leg_L_{0}";
            for (int i = 0; i < 26; i++)
            {
                letterLegPathList.Add(string.Format(letterLegPath, i.ToString()));
            }

            string numLegPath = "sprite/fodder/leg|number_leg_L_{0}";
            for (int i = 0; i < 4; i++)
            {
                numLegPathList.Add(string.Format(numLegPath, i.ToString()));
            }

            string aniLegPath = "sprite/fodder/leg|animal_leg_L_{0}";
            for (int i = 0; i < 4; i++)
            {
                aniLegPathList.Add(string.Format(aniLegPath, i.ToString()));
            }
        }
    }
    
}
