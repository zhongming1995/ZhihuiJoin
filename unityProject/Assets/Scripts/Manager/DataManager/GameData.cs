using System;
using System.Collections.Generic;
using UnityEngine;
using GameMgr;
using Random = System.Random;

public class GameData:SingletonPersistent<GameData>
{ 
    [HideInInspector]
    public List<string> homePathList = new List<string>();//选择界面的资源路径
    [HideInInspector]
    public List<string> drawBgPathList = new List<string>();//画图背景资源路径
    [HideInInspector]
    public List<string> drawAudioPathList = new List<string>();//绘画模板的音频路径
    [HideInInspector]
    public List<List<string>> resPathList = new List<List<string>>();//全部资源路径
    [HideInInspector]
    public List<string> resPrefabPathList = new List<string>();//素材资源prefab路径
    [HideInInspector]
    public List<string> LetterEyeList = new List<string>();
    [HideInInspector]
    public List<string> LetterMouseList = new List<string>();
    [HideInInspector]
    public List<string> LetterHatList = new List<string>();
    [HideInInspector]
    public List<string> LetterHandList = new List<string>();
    [HideInInspector]
    public List<string> LetterLegList = new List<string>();
    [HideInInspector]
    public List<string> LetterHeadWearList = new List<string>();
    [HideInInspector]
    public List<string> AnimalHeadList = new List<string>();
    [HideInInspector]
    public List<string> AnimalBodyList = new List<string>();
    [HideInInspector]
    public List<string> AnimalEyeList = new List<string>();
    [HideInInspector]
    public List<string> AnimalMouseList = new List<string>();
    [HideInInspector]
    public List<string> AnimalHatList = new List<string>();
    [HideInInspector]
    public List<string> AnimalHandList = new List<string>();
    [HideInInspector]
    public List<string> AnimalLegList = new List<string>();
    [HideInInspector]
    public List<string> AnimalHeadWearList = new List<string>();
    [HideInInspector]
    private string[][] restrictList;

    //画笔颜色
    [HideInInspector]
    public Color[] ColorList;
    [HideInInspector]
    public Color[] MultiColorList;

    [HideInInspector]
    public int resTypeCount = 10;//素材资源种类，目前8种

    private int letterEyeCount = 25;
    private int numberEyeCount = 2;
    private int animalEyeCount = 7;
    private int animalBodyCount = 9;
    private int letterHandCount = 26;
    private int numberHandCount = 4;
    private int animalHandCount = 9;
    private int letterHatCount = 14;
    private int numberHatCount = 1;
    private int animalHatCount = 8;
    private int animalHeadCount = 18;
    private int letterHeadWearCount = 16;
    private int numberHeadWearCount = 2;
    private int letterLegCount = 26;
    private int numberLegCount = 4;
    private int animalLegCount = 9;
    private int letterMouseCount = 23;
    private int numberMouseCount = 2;
    private int animalMouseCount = 17;

    //初始化颜色列表
    public void InitColor()
    {
        ColorList = new Color[]{
            new Color32(0, 0, 0, 255),
            new Color32(0, 0, 0, 255),
            new Color32(40, 186, 255, 255),//天蓝
            new Color32(153, 90, 72, 255),//褐
            new Color32(255, 136, 18, 255),//橘
            new Color32(19, 163, 62, 255),//绿
            new Color32(255, 228, 34, 255),//黄
            new Color32(35, 90, 223, 255),//蓝
            new Color32(133, 224, 44, 255),//草绿
            new Color32(150, 78, 238, 255),//紫
            new Color32(250, 66, 66, 255),//红
            new Color32(48, 41, 44, 255),//黑
            new Color32(255, 127, 190, 255),//玫粉
            new Color32(131, 133, 135, 255),//灰
            new Color32(254, 207, 207, 255),//粉红
            new Color32(255, 255, 255, 255),//白
            };

        MultiColorList = new Color[]
        {
            new Color32(250,66,72,255),//1
            new Color32(251,82,52,255),//2
            new Color32(253,97,39,255),//3
            new Color32(254,113,28,255),//4
            new Color32(255,131,19,255),//5
            new Color32(255,148,18,255),//6
            new Color32(255,171,19,255),//7
            new Color32(255,192,24,255),//8
            new Color32(255,211,29,255),//9
            new Color32(255,226,33,255),//10
            new Color32(242,228,34,255),//11
            new Color32(216,228,34,255),//12
            new Color32(184,228,34,255),//13
            new Color32(152,228,34,255),//14
            new Color32(131,224,46,255),//15
            new Color32(106,219,83,255),//16
            new Color32(79,213,137,255),//17
            new Color32(55,205,193,255),//18
            new Color32(42,195,236,255),//19
            new Color32(42,180,255,255),//20
            new Color32(56,156,255,255),//21
            new Color32(82,127,255,255),//22
            new Color32(112,100,252,255),//23
            new Color32(134,85,243,255),//24
            new Color32(161,78,234,255),//25
            new Color32(185,83,224,255),//26
            new Color32(209,96,213,255),//27
            new Color32(229,109,203,255),//28
            new Color32(248,123,193,255),//29
            new Color32(254,119,176,255),//30
            new Color32(253,103,149,255),//31
            new Color32(252,87,122,255),//32
        };
    }

    //初始化item列表,首页选字母的
    public void InitItemList()
    {
        //26个字母
        string homeLetterPath = "sprite/homeitems|splice_home_{0}_pic";
        string drawBgLetterPath = "sprite/draw|draw_letter_{0}_pic";
        string drawLetterAudioPath = "Audio/letter_tmplate|template_letter_{0}";
        //10个数字
        string homeNumPath = "sprite/homeitems|splice_home_number_{0}_pic";
        string drawBgNumPath = "sprite/draw|draw_num_{0}_pic";
        string drawNumAudioPath = "Audio/num_template|template_num_{0}";
        //6个动物
        string homeAnimalPath = "sprite/homeitems|splice_home_animal_{0}_pic";
        string drawAnimalAudioPath = "Audio/animal_template|template_animal_{0}";

        for (int i = 0; i < 26; i++)
        {
            homePathList.Add(string.Format(homeLetterPath, i.ToString()));
            drawBgPathList.Add(string.Format(drawBgLetterPath, i.ToString()));
            drawAudioPathList.Add(string.Format(drawLetterAudioPath, i.ToString()));
        }

        for (int i = 0; i < 10; i++)
        {
            homePathList.Add(string.Format(homeNumPath, i.ToString()));
            drawBgPathList.Add(string.Format(drawBgNumPath, i.ToString()));
            drawAudioPathList.Add(string.Format(drawNumAudioPath, i.ToString()));
        }

        for (int i = 0; i < 6; i++)
        {
            homePathList.Add(string.Format(homeAnimalPath, i.ToString()));
            drawAudioPathList.Add(string.Format(drawAnimalAudioPath, i.ToString()));
        }
    }

    //初始化素材列表
    public void InitResList()
    {
        LetterEyeList = CSVUtil.GetListFromPath("Config|letter_eye");
        LetterMouseList = CSVUtil.GetListFromPath("Config|letter_mouth");
        LetterHatList = CSVUtil.GetListFromPath("Config|letter_hat");
        LetterHandList = CSVUtil.GetListFromPath("Config|letter_hand");
        LetterLegList = CSVUtil.GetListFromPath("Config|letter_leg");
        LetterHeadWearList = CSVUtil.GetListFromPath("Config|letter_headwear");
        AnimalEyeList = CSVUtil.GetListFromPath("Config|animal_eye");
        AnimalMouseList = CSVUtil.GetListFromPath("Config|animal_mouth");
        AnimalHatList = CSVUtil.GetListFromPath("Config|animal_hat");
        AnimalHandList = CSVUtil.GetListFromPath("Config|animal_hand");
        AnimalLegList = CSVUtil.GetListFromPath("Config|animal_leg");
        AnimalHeadWearList = CSVUtil.GetListFromPath("Config|animal_headwear");
        AnimalBodyList = CSVUtil.GetListFromPath("Config|animal_body");
        AnimalHeadList = CSVUtil.GetListFromPath("Config|animal_head");
        restrictList = CSVUtil.GetListFromRestrict("Config|restrict");
    }

    public void InitResPrefabList()
    {
        string path = "prefabs/join|res_obj_{0}";
        for (int i = 0; i < resTypeCount; i++)
        {
            resPrefabPathList.Add(string.Format(path, i.ToString()));
        }
    }
 
    //根据类型，返回对应的素材列表
    public List<string> GetPathList(TemplateResType type)
    {
        if (GameManager.instance.curJoinType==JoinType.Animal)
        {
            if (type == TemplateResType.Eye)
            {
                return AnimalEyeList;
            }
            if (type == TemplateResType.Mouth)
            {
                return AnimalMouseList;
            }
            if (type == TemplateResType.Hat)
            {
                return AnimalHatList;
            }
            if (type == TemplateResType.Hand)
            {
                return AnimalHandList;
            }
            if (type == TemplateResType.Leg)
            {
                return AnimalLegList;
            }
            if (type == TemplateResType.Head)
            {
                return AnimalHeadList;
            }
            if (type == TemplateResType.TrueBody)
            {
                return AnimalBodyList;
            }
            if (type == TemplateResType.HeadWear)
            {
                return AnimalHeadWearList;
            }
        }
        else
        {
            if (type == TemplateResType.Eye)
            {
                return LetterEyeList;
            }
            if (type == TemplateResType.Mouth)
            {
                return LetterMouseList;
            }
            if (type == TemplateResType.Hat)
            {
                return LetterHatList;
            }
            if (type == TemplateResType.Hand)
            {
                return LetterHandList;
            }
            if (type == TemplateResType.Leg)
            {
                return LetterLegList;
            }
            if (type == TemplateResType.HeadWear)
            {
                return LetterHeadWearList;
            }
        }
        return null;
    }

    public List<string> GetPathListWithModule(int index, TemplateResType type)
    {
        List<string> pathList = new List<string>();
        string path = string.Empty;
        List<string> tmpList;
        //眼睛
        if (type == TemplateResType.Eye)
        {
            int num = 0;
            if (GameManager.instance.curJoinType==JoinType.Animal)
            {
                tmpList = AnimalEyeList;
            }
            else
            {
                tmpList = LetterEyeList;
            }
            string mpath = restrictList[index+1][1];//因为restrict表有表头，行列都有一项多余的，有效下标从1开始
            if (mpath == "")
            {
                num = Math.Min(6, tmpList.Count);
            }
            else
            {
                string[] leftst = restrictList[index+1][1].Split('&');
                string[] rightst = restrictList[index+1][2].Split('&');
                for (int i = 0; i < leftst.Length; i++)
                {
                    pathList.Add(leftst[i]);
                    pathList.Add(rightst[i]);
                }
                num = Math.Min(6 - leftst.Length, tmpList.Count);
            }
            for (int i = 0; i < num; i++)
            {
                Random rd = new Random();
                int n = rd.Next(0, tmpList.Count);
                while (pathList.Contains(tmpList[n])|| n % 2 != 0)
                {
                    n = rd.Next(0, tmpList.Count);
                    Debug.Log(tmpList[n]);
                }
                pathList.Add(tmpList[n]);
                pathList.Add(tmpList[n + 1]);
            }
        }
        else if (type == TemplateResType.Mouth)
        {
            string mpath = restrictList[index+1][3];
            int num = 0;
            if (GameManager.instance.curJoinType == JoinType.Animal)
            {
                tmpList = AnimalMouseList;
            }
            else
            {
                tmpList = LetterMouseList;
            }
            if (mpath == "")
            {
                num = Math.Min(5, tmpList.Count);
            }
            else
            {
                string[] tempPathLst = mpath.Split('&');
                for (int i = 0; i < tempPathLst.Length; i++)
                {
                    pathList.Add(tempPathLst[i]);
                }
                num = Math.Min(5 - tempPathLst.Length, tmpList.Count);

            }

            for (int i = 0; i < num; i++)
            {
                Random rd = new Random();
                int n = rd.Next(0, tmpList.Count);
                while (pathList.Contains(tmpList[n]))
                {
                    n = rd.Next(0, tmpList.Count);
                }
                pathList.Add(tmpList[n]);
            }
        }
        else if (type == TemplateResType.Hand)
        {
            string mpath = restrictList[index+1][4];
            int num = 0;
            if (GameManager.instance.curJoinType == JoinType.Animal)
            {
                tmpList = AnimalHandList;
            }
            else
            {
                tmpList = LetterHandList;
            }
            if (mpath == "")
            {
                num = Math.Min(6, tmpList.Count);
            }
            else
            {
                string[] leftst = restrictList[index+1][4].Split('&');
                string[] rightst = restrictList[index+1][5].Split('&');
                for (int i = 0; i < leftst.Length; i++)
                {
                    pathList.Add(leftst[i]);
                    pathList.Add(rightst[i]);
                }
                num = Math.Min(6 - leftst.Length, tmpList.Count);
            }
            for (int i = 0; i < num; i++)
            {
                Random rd = new Random();
                int n = rd.Next(0, tmpList.Count);
                while (pathList.Contains(tmpList[n]) || n % 2 != 0)
                {
                    n = rd.Next(0, tmpList.Count);
                }
                pathList.Add(tmpList[n]);
                pathList.Add(tmpList[n + 1]);
            }
        }
        else if (type == TemplateResType.Leg)
        {
            string mpath = restrictList[index+1][6];
            int num = 0;
            if (GameManager.instance.curJoinType == JoinType.Animal)
            {
                tmpList = AnimalLegList;
            }
            else
            {
                tmpList = LetterLegList;
            }
            if (mpath == "")
            {
                num = Math.Min(5, tmpList.Count);
            }
            else
            {
                string[] leftst = restrictList[index+1][6].Split('&');
                string[] rightst = restrictList[index+1][7].Split('&');
                for (int i = 0; i < leftst.Length; i++)
                {
                    pathList.Add(leftst[i]);
                    pathList.Add(rightst[i]);
                }
                num = Math.Min(5 - leftst.Length, tmpList.Count);
            }
          
            for (int i = 0; i < num; i++)
            {
                Random rd = new Random();
                int n = rd.Next(0, tmpList.Count);
                while (pathList.Contains(tmpList[n]) || n % 2 != 0)
                {
                    n = rd.Next(0, tmpList.Count);
                }
                pathList.Add(tmpList[n]);
                pathList.Add(tmpList[n + 1]);
            }
        }
        else if (type == TemplateResType.Hat)
        {
            string mpath = restrictList[index+1][8];
            int num = 0;
            if (GameManager.instance.curJoinType == JoinType.Animal)
            {
                tmpList = AnimalHatList;
            }
            else
            {
                tmpList = LetterHatList;
            }
            if (mpath == "")
            {
                num = Math.Min(5, tmpList.Count);
            }
            else
            {
                string[] tempPathLst = mpath.Split('&');
                for (int i = 0; i < tempPathLst.Length; i++)
                {
                    pathList.Add(tempPathLst[i]);
                }
                num = Math.Min(5 - tempPathLst.Length, tmpList.Count);
            }
           
            for (int i = 0; i < num; i++)
            {
                Random rd = new Random();
                int n = rd.Next(0, tmpList.Count);
                while (pathList.Contains(tmpList[n]))
                {
                    n = rd.Next(0, tmpList.Count);
                }
                pathList.Add(tmpList[n]);
            }
        }
        else if (type == TemplateResType.HeadWear)
        {
            string mpath = restrictList[index+1][9];
            int num = 0;
            if (GameManager.instance.curJoinType == JoinType.Animal)
            {
                tmpList = AnimalHeadWearList;
            }
            else
            {
                tmpList = LetterHeadWearList;
            }
            if (mpath == "")
            {
                num = Math.Min(6, tmpList.Count);
            }
            else
            {
                string[] tempPathLst = mpath.Split('&');
                for (int i = 0; i < tempPathLst.Length; i++)
                {
                    pathList.Add(tempPathLst[i]);
                }
                num = Math.Min(6 - tempPathLst.Length, tmpList.Count);
            }
           
            for (int i = 0; i < num; i++)
            {
                Random rd = new Random();
                int n = rd.Next(0, tmpList.Count);
                while (pathList.Contains(tmpList[n]))
                {
                    n = rd.Next(0, tmpList.Count);
                }
                pathList.Add(tmpList[n]);
            }
        }
        else if (type == TemplateResType.Head)
        {
            string mpath = restrictList[index+1][10];
            int num = 0;
            tmpList = AnimalHeadList;
            if (mpath == "")
            {
                num = Math.Min(3, tmpList.Count);
            }
            else
            {
                string[] tempPathLst = mpath.Split('&');
                for (int i = 0; i < tempPathLst.Length; i++)
                {
                    pathList.Add(tempPathLst[i]);
                }
                num = Math.Min(3 - tempPathLst.Length, tmpList.Count);
            }
            for (int i = 0; i < num; i++)
            {
                Random rd = new Random();
                int n = rd.Next(0, tmpList.Count);
                while (pathList.Contains(tmpList[n]))
                {
                    n = rd.Next(0, tmpList.Count);
                }
                pathList.Add(tmpList[n]);
            }
        }
        else if (type == TemplateResType.TrueBody)
        {
            string mpath = restrictList[index+1][11];
            int num = 0;
            tmpList = AnimalBodyList;
            if (mpath == "")
            {
                num = Math.Min(3, tmpList.Count);
            }
            else
            {
                string[] tempPathLst = mpath.Split('&');
                for (int i = 0; i < tempPathLst.Length; i++)
                {
                    pathList.Add(tempPathLst[i]);
                }
                num = Math.Min(3 - tempPathLst.Length, tmpList.Count);
            }
            for (int i = 0; i < num; i++)
            {
                Random rd = new Random();
                int n = rd.Next(0, tmpList.Count);
                while (pathList.Contains(tmpList[n]))
                {
                    n = rd.Next(0, tmpList.Count);
                }
                pathList.Add(tmpList[n]);
            }
        }
        return pathList;
    }
}

