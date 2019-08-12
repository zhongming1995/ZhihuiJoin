using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Collections;

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
        new List<string>(){ "eye_L_0_icon","eye_R_0_icon", "mouse_0_icon", "hand_L_0_icon", "hand_R_0_icon", "leg_L_0_icon", "leg_R_0_icon" ,"", "" },
        new List<string>(){ "eye_L_1_icon","eye_R_1_icon", "", "hand_L_1_icon", "hand_R_1_icon", "leg_L_1_icon", "leg_R_1_icon" , "hat_1_icon", "" },
        new List<string>(){ "eye_L_2_icon","eye_R_2_icon", "mouse_1_icon", "hand_L_2_icon", "hand_R_2_icon", "leg_L_2_icon", "leg_R_2_icon" , "hat_2_icon", "" },
        new List<string>(){ "eye_L_3_icon","eye_R_3_icon", "mouse_2_icon", "hand_L_3_icon", "hand_R_3_icon", "leg_L_3_icon", "leg_R_3_icon" , "hat_5_icon", "headwear_1_icon" },
        new List<string>(){ "eye_L_4_icon","eye_R_4_icon", "mouse_3_icon", "hand_L_4_icon", "hand_R_4_icon", "leg_L_4_icon", "leg_R_4_icon" ,"", "headwear_0_icon" },
        new List<string>(){ "eye_L_5_icon","eye_R_5_icon", "mouse_4_icon", "hand_L_5_icon", "hand_R_5_icon", "leg_L_5_icon", "leg_R_5_icon" , "hat_3_icon", "" },
        new List<string>(){ "eye_L_6_icon","eye_R_6_icon", "mouse_5_icon", "hand_L_6_icon", "hand_R_6_icon", "leg_L_6_icon", "leg_R_6_icon" ,"", "headwear_2_icon" },
        new List<string>(){ "eye_L_7_icon","eye_R_7_icon","mouse_6_icon", "hand_L_7_icon", "hand_R_7_icon", "leg_L_7_icon", "leg_R_7_icon" ,"", "headwear_3_icon" },
        new List<string>(){ "eye_L_8_icon","eye_R_8_icon", "mouse_7_icon", "hand_L_8_icon", "hand_R_8_icon", "leg_L_8_icon", "leg_R_8_icon" , "hat_4_icon", "" },
        new List<string>(){ "eye_L_9_icon","eye_R_9_icon","mouse_8_icon", "", "", "leg_L_9_icon", "leg_R_9_icon" ,"", "headwear_4_icon" },
        new List<string>(){ "eye_L_10_icon","eye_R_10_icon","mouse_10_icon", "hand_L_10_icon", "hand_R_10_icon", "leg_L_10_icon", "leg_R_10_icon" , "hat_10_icon", "" },
        new List<string>(){ "eye_L_11_icon","eye_R_11_icon","mouse_11_icon", "", "", "leg_L_11_icon", "leg_R_11_icon" , "hat_11_icon", "headwear_13_icon" },
        new List<string>(){ "eye_L_12_icon","eye_R_12_icon","mouse_12_icon", "hand_L_12_icon", "hand_R_12_icon", "leg_L_12_icon", "leg_R_12_icon" , "hat_12_icon", "" },
        new List<string>(){ "eye_L_13_icon","eye_R_13_icon","mouse_13_icon", "hand_L_13_icon", "hand_R_13_icon", "leg_L_13_icon", "leg_R_13_icon" ,"", "headwear_10_icon" },
        new List<string>(){ "eye_L_14_icon","eye_R_14_icon","mouse_14_icon", "hand_L_14_icon", "hand_R_14_icon", "leg_L_14_icon", "leg_R_14_icon" , "hat_0_icon", "" },
        new List<string>(){ "eye_L_15_icon","eye_R_15_icon","mouse_15_icon", "hand_L_15_icon", "hand_R_15_icon", "leg_L_15_icon", "leg_R_15_icon" , "hat_9_icon", "" },
        new List<string>(){ "eye_L_16_icon","eye_R_16_icon","mouse_16_icon", "hand_L_16_icon", "hand_R_16_icon", "leg_L_16_icon", "leg_R_16_icon" ,"", "headwear_11_icon" },
        new List<string>(){ "eye_L_17_icon","eye_R_17_icon","mouse_17_icon", "hand_L_17_icon", "hand_R_17_icon", "leg_L_17_icon", "leg_R_17_icon" ,"", "headwear_7_icon" },
        new List<string>(){ "eye_L_18_icon","eye_R_18_icon","", "hand_L_18_icon", "hand_R_18_icon", "leg_L_18_icon", "leg_R_18_icon" , "hat_8_icon", "" },
        new List<string>(){ "eye_L_6_icon","eye_R_6_icon", "mouse_18_icon", "hand_L_19_icon", "hand_R_19_icon", "leg_L_19_icon", "leg_R_19_icon" ,"", "headwear_12_icon" },
        new List<string>(){ "eye_L_20_icon","eye_R_20_icon","mouse_19_icon", "hand_L_20_icon", "hand_R_20_icon", "leg_L_20_icon", "leg_R_20_icon" ,"", "" },
        new List<string>(){ "eye_L_21_icon", "eye_R_21_icon","", "hand_L_21_icon", "hand_R_21_icon", "leg_L_21_icon", "leg_R_21_icon" , "hat_6_icon", "" },
        new List<string>(){ "eye_L_22_icon","eye_R_22_icon", "mouse_20_icon", "hand_L_22_icon", "hand_R_22_icon", "leg_L_22_icon", "leg_R_22_icon" , "hat_7_icon", "" },
        new List<string>(){ "eye_L_23_icon","eye_R_23_icon", "mouse_21_icon", "hand_L_23_icon", "hand_R_23_icon", "leg_L_23_icon", "leg_R_23_icon" , "hat_13_icon", "" },
        new List<string>(){ "eye_L_24_icon","eye_R_24_icon","mouse_22_icon", "hand_L_24_icon", "hand_R_24_icon", "leg_L_24_icon", "leg_R_24_icon" ,"", "headwear_14_icon" },
        new List<string>(){ "eye_L_19_icon","eye_R_19_icon","", "", "", "leg_L_25_icon", "leg_R_25_icon" ,"", "headwear_15_icon" },
        new List<string>(){ "eye_L_4_icon","eye_R_4_icon","", "number_hand_L_0_icon", "number_hand_R_0_icon", "number_leg_L_0_icon", "number_leg_R_0_icon", "number_hat_0_icon", "number_headwear_0_icon" },
        new List<string>(){ "number_eye_L_0_icon", "number_eye_R_0_icon", "number_mouse_0_icon", "number_hand_L_1_icon", "number_hand_R_1_icon", "number_leg_L_1_icon", "number_leg_R_1_icon", "", "" },
        new List<string>(){ "number_eye_L_1_icon", "number_eye_R_1_icon", "", "number_hand_L_2_icon", "number_hand_R_2_icon", "number_leg_L_2_icon", "number_leg_R_2_icon", "", "number_headwear_1_icon" },
        new List<string>(){ "eye_L_17_icon|eye_L_16_icon", "eye_R_17_icon|eye_R_16_icon", "mouse_22_icon", "hand_L_5_icon", "hand_R_5_icon", "number_leg_L_5_icon", "number_leg_R_5_icon", "", "headwear_8_icon" },
        new List<string>(){ "eye_L_6_icon", "eye_R_6_icon", "mouse_19_icon", "hand_L_20_icon", "hand_R_20_icon", "leg_L_21_icon", "leg_R_21_icon" ,"", "headwear_6_icon" },
        new List<string>(){ "eye_L_18_icon", "eye_R_18_icon", "mouse_20_icon", "hand_L_13_icon", "hand_R_13_icon", "leg_L_13_icon", "leg_R_13_icon" ,"", "" },
        new List<string>(){ "", "", "mouse_4_icon", "hand_L_24_icon", "hand_R_24_icon", "leg_L_24_icon", "leg_R_24_icon" , "hat_7_icon", "headwear_5_icon" },
        new List<string>(){ "eye_L_7_icon", "eye_R_7_icon", "mouse_10_icon", "number_hand_L_3_icon", "number_hand_R_3_icon", "number_leg_L_3_icon", "number_leg_R_2_icon", "hat_9_icon", "headwear_9_icon" },
        new List<string>(){ "number_eye_L_1_icon", "number_eye_R_1_icon", "mouse_15_icon", "hand_L_11_icon", "hand_R_11_icon", "leg_L_11_icon", "leg_R_11_icon" , "hat_11_icon", "" },
        new List<string>(){ "eye_L_10_icon", "eye_R_10_icon", "mouse_13_icon", "number_hand_L_4_icon", "number_hand_R_4_icon", "number_leg_L_4_icon", "number_leg_R_4_icon", "", "" },
       
    };
}

