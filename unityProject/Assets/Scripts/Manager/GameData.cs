﻿using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Collections;
using System;
using Random = System.Random;

public class GameData 
{
    [HideInInspector]
    public static List<string> homePathList = new List<string>();//选择界面的资源路径
    [HideInInspector]
    public static List<string> drawBgPathList = new List<string>();//画图背景资源路径
    [HideInInspector]
    public static List<string> drawAudioPathList = new List<string>();//绘画模板的音频路径

    private static List<string> colorPathList = new List<string>();//颜色资源路径

    private static List<string> letterEyePathList = new List<string>();//字母眼睛资源路径
    private static List<string> numEyePathList = new List<string>();//数字眼睛资源路径
    private static List<string> aniEyePathList = new List<string>();//动物眼睛资源路径

    private static List<string> letterMouthPathList = new List<string>();//字母嘴巴资源路径
    private static List<string> numMouthPathList = new List<string>();//数字嘴巴资源路径
    private static List<string> aniMouthPathList = new List<string>();//动物嘴巴资源路径

    private static List<string> letterHairPathList = new List<string>();//字母头发资源路径

    private static List<string> letterHatPathList = new List<string>();//字母帽子资源路径
    private static List<string> numHatPathList = new List<string>();//数字帽子资源路径
    private static List<string> aniHatPathList = new List<string>();//动物帽子资源路径

    private static List<string> letterHeadWarePathList = new List<string>();//字母饰品资源路径
    private static List<string> numHeadWarePathList = new List<string>();//数字饰品资源路径

    private static List<string> letterHandPathList = new List<string>();//字母手资源路径
    private static List<string> numHandPathList = new List<string>();//数字手资源路径
    private static List<string> AniHandPathList = new List<string>();//数字手资源路径

    private static List<string> letterLegPathList = new List<string>();//数字脚资源路径
    private static List<string> numLegPathList = new List<string>();//数字脚资源路径
    private static List<string> aniLegPathList = new List<string>();//数字脚资源路径

    [HideInInspector]
    public static List<List<string>> resPathList = new List<List<string>>();//全部资源路径
    [HideInInspector]
    public static List<string> resPrefabPathList = new List<string>();//素材资源prefab路径

    //画笔颜色
    [HideInInspector]
    public static Color[] ColorList;
    [HideInInspector]
    public static Color[] MultiColorList;

    [HideInInspector]
    public static int resTypeCount = 8;//素材资源种类，目前8种

    //初始化颜色列表
    public static void InitColor()
    {
        ColorList = new Color[16]{
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

        MultiColorList = new Color[7]
        {
            new Color32(250, 66, 66, 255),//红
            new Color32(255, 136, 18, 255),//橙
            new Color32(255, 228, 34, 255),//黄
            new Color32(133, 224, 44, 255),//草绿
            new Color32(40, 186, 255, 255),//天蓝
            new Color32(150, 78, 238, 255),//紫
            new Color32(255, 127, 190, 255),//玫粉
        };
    }

    //初始化item列表,首页选字母的
    public static void InitItemList()
    {
        //26个字母
        string homeLetterPath = "sprite/homeitems|splice_home_{0}_pic";
        string drawBgLetterPath = "sprite/draw|draw_letter_{0}_pic";
        string drawLetterAudioPath = "Audio/letter_tmplate|template_letter_{0}";
        //10个数字
        string homeNumPath = "sprite/homeitems|splice_home_number_{0}_pic";
        string drawBgNumPath = "sprite/draw|draw_num_{0}_pic";
        string drawNumAudioPath = "Audio/num_template|template_num_{0}";

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
    }

    //初始化素材列表
    public static void InitResList()
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
        for (int i = 0; i < 5; i++)
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
        for (int i = 0; i < 5; i++)
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

        //-------------组装-------------

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

    public static void InitResPrefabList()
    {
        string path = "prefabs/join|res_obj_{0}";
        for (int i = 0; i < resTypeCount; i++)
        {
            resPrefabPathList.Add(string.Format(path, i.ToString()));
        }
    }

    public static List<List<string>> ModulePathList = new List<List<string>>()
    {
        new List<string>(){ "eye_L_0","eye_R_0", "mouse_0", "hand_L_0", "hand_R_0", "leg_L_0", "leg_R_0" ,"", "" },
        new List<string>(){ "eye_L_1","eye_R_1", "", "hand_L_1", "hand_R_1", "leg_L_1", "leg_R_1" , "hat_1", "" },
        new List<string>(){ "eye_L_2","eye_R_2", "mouse_1", "hand_L_2", "hand_R_2", "leg_L_2", "leg_R_2" , "hat_2", "" },
        new List<string>(){ "eye_L_3","eye_R_3", "mouse_2", "hand_L_3", "hand_R_3", "leg_L_3", "leg_R_3" , "hat_5", "headwear_1" },
        new List<string>(){ "eye_L_4","eye_R_4", "mouse_3", "hand_L_4", "hand_R_4", "leg_L_4", "leg_R_4" ,"", "headwear_0" },
        new List<string>(){ "eye_L_5","eye_R_5", "mouse_4", "hand_L_5", "hand_R_5", "leg_L_5", "leg_R_5" , "hat_3", "" },
        new List<string>(){ "eye_L_6","eye_R_6", "mouse_5", "hand_L_6", "hand_R_6", "leg_L_6", "leg_R_6" ,"", "headwear_2" },
        new List<string>(){ "eye_L_7","eye_R_7","mouse_6", "hand_L_7", "hand_R_7", "leg_L_7", "leg_R_7" ,"", "headwear_3" },
        new List<string>(){ "eye_L_8","eye_R_8", "mouse_7", "hand_L_8", "hand_R_8", "leg_L_8", "leg_R_8" , "hat_4", "" },
        new List<string>(){ "eye_L_9","eye_R_9","mouse_8", "", "", "leg_L_9", "leg_R_9" ,"", "headwear_4" },
        new List<string>(){ "eye_L_10","eye_R_10","mouse_10", "hand_L_10", "hand_R_10", "leg_L_10", "leg_R_10" , "hat_10", "" },
        new List<string>(){ "eye_L_11","eye_R_11","mouse_11", "", "", "leg_L_11", "leg_R_11" , "hat_11", "headwear_13" },
        new List<string>(){ "eye_L_12","eye_R_12","mouse_12", "hand_L_12", "hand_R_12", "leg_L_12", "leg_R_12" , "hat_12", "" },
        new List<string>(){ "eye_L_13","eye_R_13","mouse_13", "hand_L_13", "hand_R_13", "leg_L_13", "leg_R_13" ,"", "headwear_10" },
        new List<string>(){ "eye_L_14","eye_R_14","mouse_14", "hand_L_14", "hand_R_14", "leg_L_14", "leg_R_14" , "hat_0", "" },
        new List<string>(){ "eye_L_15","eye_R_15","mouse_15", "hand_L_15", "hand_R_15", "leg_L_15", "leg_R_15" , "hat_9", "" },
        new List<string>(){ "eye_L_16","eye_R_16","mouse_16", "hand_L_16", "hand_R_16", "leg_L_16", "leg_R_16" ,"", "headwear_11" },
        new List<string>(){ "eye_L_17","eye_R_17","mouse_17", "hand_L_17", "hand_R_17", "leg_L_17", "leg_R_17" ,"", "headwear_7" },
        new List<string>(){ "eye_L_18","eye_R_18","", "hand_L_18", "hand_R_18", "leg_L_18", "leg_R_18" , "hat_8", "" },
        new List<string>(){ "eye_L_6","eye_R_6", "mouse_18", "hand_L_19", "hand_R_19", "leg_L_19", "leg_R_19" ,"", "headwear_12" },
        new List<string>(){ "eye_L_20","eye_R_20","mouse_19", "hand_L_20", "hand_R_20", "leg_L_20", "leg_R_20" ,"", "" },
        new List<string>(){ "eye_L_21", "eye_R_21","", "hand_L_21", "hand_R_21", "leg_L_21", "leg_R_21" , "hat_6", "" },
        new List<string>(){ "eye_L_22","eye_R_22", "mouse_20", "hand_L_22", "hand_R_22", "leg_L_22", "leg_R_22" , "hat_7", "" },
        new List<string>(){ "eye_L_23","eye_R_23", "mouse_21", "hand_L_23", "hand_R_23", "leg_L_23", "leg_R_23" , "hat_13", "" },
        new List<string>(){ "eye_L_24","eye_R_24","mouse_22", "hand_L_24", "hand_R_24", "leg_L_24", "leg_R_24" ,"", "headwear_14" },
        new List<string>(){ "eye_L_19","eye_R_19","", "hand_L_25", "hand_R_25", "leg_L_25", "leg_R_25" ,"", "headwear_15" },
        new List<string>(){ "eye_L_4","eye_R_4","number_mouse_0", "number_hand_L_0", "number_hand_R_0", "number_leg_L_0", "number_leg_R_0", "number_hat_0", "number_headwear_0" },
        new List<string>(){ "number_eye_L_0", "number_eye_R_0", "number_mouse_1", "number_hand_L_1", "number_hand_R_1", "number_leg_L_1", "number_leg_R_1", "", "" },
        new List<string>(){ "number_eye_L_1", "number_eye_R_1", "", "number_hand_L_2", "number_hand_R_2", "number_leg_L_2", "number_leg_R_2", "", "number_headwear_1" },
        new List<string>(){ "eye_L_17|eye_L_16", "eye_R_17|eye_R_16", "mouse_22", "hand_L_5", "hand_R_5", "leg_L_5", "leg_R_5", "", "headwear_8" },
        new List<string>(){ "eye_L_6", "eye_R_6", "mouse_19", "hand_L_20", "hand_R_20", "leg_L_21", "leg_R_21" ,"", "headwear_6" },
        new List<string>(){ "eye_L_18", "eye_R_18", "mouse_20", "hand_L_13", "hand_R_13", "leg_L_13", "leg_R_13" ,"", "" },
        new List<string>(){ "", "", "mouse_4", "hand_L_24", "hand_R_24", "leg_L_24", "leg_R_24" , "hat_7", "headwear_5" },
        new List<string>(){ "eye_L_7", "eye_R_7", "mouse_10", "number_hand_L_3", "number_hand_R_3", "number_leg_L_3", "number_leg_R_3", "hat_9", "headwear_9" },
        new List<string>(){ "number_eye_L_1", "number_eye_R_1", "mouse_15", "hand_L_11", "hand_R_11", "leg_L_11", "leg_R_11" , "hat_11", "" },
        new List<string>(){ "eye_L_10", "eye_R_10", "mouse_13", "number_hand_L_4", "number_hand_R_4", "number_leg_L_4", "number_leg_R_4", "", "number_headwear_0" },
    };

    //根据字母或数字，返回包含模板在内的5/6个素材
    public static List<string> GetPathList(int index,TemplateResType type)
    {
        List<string> pathList = new List<string>();
        string path = string.Empty;

        //眼睛
        if (type == TemplateResType.Eye)
        {
            int num = 0;
            string mpath = ModulePathList[index][0];
            if (mpath.Contains("|"))
            {
                string[] leftst = ModulePathList[index][0].Split('|');
                string[] rightst = ModulePathList[index][1].Split('|');
                for (int i = 0; i < leftst.Length; i++)
                {
                    pathList.Add("sprite/fodder/eye|" + leftst[i]);
                    pathList.Add("sprite/fodder/eye|" + rightst[i]);
                }
                num = 4;
            }
            else if(mpath != "")
            {
                pathList.Add("sprite/fodder/eye|" + ModulePathList[index][0]);
                pathList.Add("sprite/fodder/eye|" + ModulePathList[index][1]);
                num = 5;
            }
            else
            {
                num = 6;
            }
            int sIndex = 0;
            int eIndex = resPathList[1].Count;
            for (int i = 0; i < num; i++)
            {
                Random rd = new Random();
                int n = rd.Next(sIndex,eIndex);
                while (pathList.Contains(resPathList[1][n]) || n%2!=0)
                {
                    n = rd.Next(sIndex, eIndex);
                }
                pathList.Add(resPathList[1][n]);
                pathList.Add(resPathList[1][n + 1]);
            }
        }
        else if (type == TemplateResType.Mouth)
        {
            string mpath = ModulePathList[index][2];
            int num = 0;
            if (mpath=="")
            {
                num = 6;
            }
            else
            {
                num = 5;
                pathList.Add("sprite/fodder/mouth|" + mpath);
            }
            int sIndex = 0;
            int eIndex = resPathList[2].Count;
            for (int i = 0; i < num; i++)
            {
                Random rd = new Random();
                int n = rd.Next(sIndex, eIndex);
                while (pathList.Contains(resPathList[2][n]))
                {
                    n = rd.Next(sIndex, eIndex);
                }
                pathList.Add(resPathList[2][n]);
            }
        }
        else if (type == TemplateResType.Hand)
        {
            string mpath = ModulePathList[index][3];
            int num = 0;
            if (mpath == "")
            {
                num = 6;
            }
            else
            {
                num = 5;
                pathList.Add("sprite/fodder/hand|" + mpath);
                pathList.Add("sprite/fodder/hand|" + ModulePathList[index][4]);
            }
            int sIndex = 0;
            int eIndex = resPathList[6].Count;
            for (int i = 0; i < num; i++)
            {
                Random rd = new Random();
                int n = rd.Next(sIndex, eIndex);
                while (pathList.Contains(resPathList[6][n])||n%2!=0)
                {
                    n = rd.Next(sIndex, eIndex);
                }
                pathList.Add(resPathList[6][n]);
                pathList.Add(resPathList[6][n + 1]);
            }
        }
        else if (type == TemplateResType.Leg)
        {
            string mpath = ModulePathList[index][5];
            int num = 0;
            if (mpath == "")
            {
                num = 5;
            }
            else
            {
                num = 4;
                pathList.Add("sprite/fodder/leg|" + mpath);
                pathList.Add("sprite/fodder/leg|" + ModulePathList[index][6]);
            }
            int sIndex = 0;
            int eIndex = resPathList[7].Count;
            for (int i = 0; i < num; i++)
            {
                Random rd = new Random();
                int n = rd.Next(sIndex, eIndex);
                while (pathList.Contains(resPathList[7][n]) || n % 2 != 0)
                {
                    n = rd.Next(sIndex, eIndex);
                }
                pathList.Add(resPathList[7][n]);
                pathList.Add(resPathList[7][n + 1]);
            }
        }
        else if (type == TemplateResType.Hat)
        {
            string mpath = ModulePathList[index][7];
            int num = 0;
            if (mpath == "")
            {
                num = 5;
            }
            else
            {
                num = 4;
                pathList.Add("sprite/fodder/hat|" + mpath);
            }
            int sIndex = 0;
            int eIndex = resPathList[4].Count;
            for (int i = 0; i < num; i++)
            {
                Random rd = new Random();
                int n = rd.Next(sIndex, eIndex);
                while (pathList.Contains(resPathList[4][n]) || n % 2 != 0)
                {
                    n = rd.Next(sIndex, eIndex);
                }
                pathList.Add(resPathList[4][n]);
            }
        }
        else if (type == TemplateResType.HeadWear)
        {
            string mpath = ModulePathList[index][8];
            int num = 0;
            if (mpath == "")
            {
                num = 6;
            }
            else
            {
                num = 5;
                pathList.Add("sprite/fodder/headwear|" + mpath);
            }
            int sIndex = 0;
            int eIndex = resPathList[5].Count;
            for (int i = 0; i < num; i++)
            {
                Random rd = new Random();
                int n = rd.Next(sIndex, eIndex);
                while (pathList.Contains(resPathList[5][n]) || n % 2 != 0)
                {
                    n = rd.Next(sIndex, eIndex);
                }
                pathList.Add(resPathList[5][n]);
            }
        }

        return pathList;
    }
}
