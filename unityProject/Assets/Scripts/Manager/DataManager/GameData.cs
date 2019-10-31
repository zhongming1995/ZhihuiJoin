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

        MultiColorList = new Color[32]
        {
            //new Color32(250, 66, 66, 255),//红
            //new Color32(255, 136, 18, 255),//橙
            //new Color32(255, 228, 34, 255),//黄
            //new Color32(133, 224, 44, 255),//草绿
            //new Color32(40, 186, 255, 255),//天蓝
            //new Color32(150, 78, 238, 255),//紫
            //new Color32(255, 127, 190, 255),//玫粉
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
        /*
        List<string> colorPathList = new List<string>();//颜色资源路径
        //颜色,现在没用到了，但是不能删，因为影响索引
        string colorPath = "sprite/small_fodder/color|color_{0}_icon";
        for (int i = 0; i < 16; i++)
        {
            colorPathList.Add(string.Format(colorPath, i.ToString()));
        }
        resPathList.Add(colorPathList);

        List<string> eyePathList = new List<string>();
        //眼睛
        string letterEyePath = "sprite/fodder/eye|eye_L_{0}";
        string letterEyePath_R = "sprite/fodder/eye|eye_R_{0}";
        for (int i = 0; i < letterEyeCount; i++)
        {
            eyePathList.Add(string.Format(letterEyePath, i.ToString()));
            eyePathList.Add(string.Format(letterEyePath_R, i.ToString()));
        }
        string numEyePath = "sprite/fodder/eye|number_eye_L_{0}";
        string numEyePath_R = "sprite/fodder/eye|number_eye_R_{0}";
        for (int i = 0; i < numberEyeCount; i++)
        {
            eyePathList.Add(string.Format(numEyePath, i.ToString()));
            eyePathList.Add(string.Format(numEyePath_R, i.ToString()));
        }
        string aniEyePath = "sprite/fodder/eye|animal_eye_L_{0}";
        string aniEyePath_R = "sprite/fodder/eye|animal_eye_R_{0}";
        for (int i = 0; i < animalEyeCount; i++)
        {
            eyePathList.Add(string.Format(aniEyePath, i.ToString()));
            eyePathList.Add(string.Format(aniEyePath_R, i.ToString()));
        }
        resPathList.Add(eyePathList);

        //嘴巴
        List<string> mouthPathList = new List<string>();
        string letterMouthPath = "sprite/fodder/mouth|mouse_{0}";
        for (int i = 0; i < letterMouseCount; i++)
        {
            mouthPathList.Add(string.Format(letterMouthPath, i.ToString()));
        }
        string numMouthPath = "sprite/fodder/mouth|number_mouse_{0}";
        for (int i = 0; i < numberMouseCount; i++)
        {
            mouthPathList.Add(string.Format(numMouthPath, i.ToString()));
        }
        string aniMouthPath = "sprite/fodder/mouth|animal_mouse_{0}";
        for (int i = 0; i < animalMouseCount ; i++)
        {
            mouthPathList.Add(string.Format(aniMouthPath, i.ToString()));
        }
        resPathList.Add(mouthPathList);

        //头发
        List<string> hairPathList = new List<string>();
        string letterHairPath = "sprite/fodder/hair|hair_{0}";
        for (int i = 0; i < 10; i++)
        {
            hairPathList.Add(string.Format(letterHairPath, i.ToString()));
        }
        resPathList.Add(hairPathList);

        //帽子
        List<string> hatPathList = new List<string>();
        string letterHatPath = "sprite/fodder/hat|hat_{0}";
        for (int i = 0; i < letterHatCount; i++)
        {
            hatPathList.Add(string.Format(letterHatPath, i.ToString()));
        }
        string numHatPath = "sprite/fodder/hat|number_hat_{0}";
        for (int i = 0; i < numberHatCount; i++)
        {
            hatPathList.Add(string.Format(numHatPath, i.ToString()));
        }
        string aniHatPath = "sprite/fodder/hat|animal_hat_{0}";
        for (int i = 0; i < animalHatCount; i++)
        {
            hatPathList.Add(string.Format(aniHatPath, i.ToString()));
        }
        resPathList.Add(hatPathList);

        //饰品
        List<string> headWearPathList = new List<string>();
        string letterHeadWearPath = "sprite/fodder/headwear|headwear_{0}";
        for (int i = 0; i < letterHeadWearCount; i++)
        {
            headWearPathList.Add(string.Format(letterHeadWearPath, i.ToString()));
        }

        string numHeadWearPath = "sprite/fodder/headwear|number_headwear_{0}";
        for (int i = 0; i < numberHeadWearCount; i++)
        {
            headWearPathList.Add(string.Format(numHeadWearPath, i.ToString()));
        }
        resPathList.Add(headWearPathList);

        //手
        List<string> handPathList = new List<string>();
        string letterHandPath = "sprite/fodder/hand|hand_L_{0}";
        string letterHandPath_R = "sprite/fodder/hand|hand_R_{0}";
        for (int i = 0; i < letterHandCount; i++)
        {
            handPathList.Add(string.Format(letterHandPath, i.ToString()));
            handPathList.Add(string.Format(letterHandPath_R, i.ToString()));
        }
        string numHandPath = "sprite/fodder/hand|number_hand_L_{0}";
        string numHandPath_R = "sprite/fodder/hand|number_hand_R_{0}";
        for (int i = 0; i < numberHandCount; i++)
        {
            handPathList.Add(string.Format(numHandPath, i.ToString()));
            handPathList.Add(string.Format(numHandPath_R, i.ToString()));
        }
        string aniHandPath = "sprite/fodder/hand|animal_hand_L_{0}";
        string aniHandPath_R = "sprite/fodder/hand|animal_hand_R_{0}";
        for (int i = 0; i < animalHandCount; i++)
        {
            handPathList.Add(string.Format(aniHandPath, i.ToString()));
            handPathList.Add(string.Format(aniHandPath_R, i.ToString()));
        }
        resPathList.Add(handPathList);

        //脚
        List<string> legPathList = new List<string>();
        string letterLegPath = "sprite/fodder/leg|leg_L_{0}";
        string letterLegPath_R = "sprite/fodder/leg|leg_R_{0}";
        for (int i = 0; i < letterLegCount; i++)
        {
            legPathList.Add(string.Format(letterLegPath, i.ToString()));
            legPathList.Add(string.Format(letterLegPath_R, i.ToString()));
        }
        string numLegPath = "sprite/fodder/leg|number_leg_L_{0}";
        string numLegPath_R = "sprite/fodder/leg|number_leg_R_{0}";
        for (int i = 0; i < numberLegCount; i++)
        {
            legPathList.Add(string.Format(numLegPath, i.ToString()));
            legPathList.Add(string.Format(numLegPath_R, i.ToString()));
        }
        string aniLegPath = "sprite/fodder/leg|animal_leg_L_{0}";
        string aniLegPath_R = "sprite/fodder/leg|animal_leg_R_{0}";
        for (int i = 0; i < animalLegCount; i++)
        {
            legPathList.Add(string.Format(aniLegPath, i.ToString()));
            legPathList.Add(string.Format(aniLegPath_R, i.ToString()));
        }
        resPathList.Add(legPathList);

        //头
        List<string> headPathList = new List<string>();//动物头
        string animalHeadPath = "sprite/fodder/head|animal_head_{0}";
        for (int i = 0; i < animalHeadCount; i++)
        {
            headPathList.Add(string.Format(animalHeadPath, i.ToString()));
        }
        resPathList.Add(headPathList);

        //身体
        List<string> bodyPathList = new List<string>();//身体
        string animalBodyPath = "sprite/fodder/body|animal_body_{0}";
        for (int i = 0; i < animalBodyCount; i++)
        {
            bodyPathList.Add(string.Format(animalBodyPath, i.ToString()));
        }
        resPathList.Add(bodyPathList);
        */
    }

    public void InitResPrefabList()
    {
        string path = "prefabs/join|res_obj_{0}";
        for (int i = 0; i < resTypeCount; i++)
        {
            resPrefabPathList.Add(string.Format(path, i.ToString()));
        }
    }

    public List<List<string>> ModulePathList = new List<List<string>>()    {     new List<string>(){//A         "eye_L_0",         "eye_R_0",         "mouse_0",         "hand_L_0",         "hand_R_0",         "leg_L_0",         "leg_R_0",         "",         "",         "",         ""     },new List<string>(){//B         "eye_L_1",         "eye_R_1",         "",         "hand_L_1",         "hand_R_1",         "leg_L_1",         "leg_R_1",         "hat_1",         "",         "",         ""     },new List<string>(){//C         "eye_L_2",         "eye_R_2",         "mouse_1",         "hand_L_2",         "hand_R_2",         "leg_L_2",         "leg_R_2",         "hat_2",         "",         "",         ""     },new List<string>(){//D         "eye_L_3",         "eye_R_3",         "mouse_2",         "hand_L_3",         "hand_R_3",         "leg_L_3",         "leg_R_3",         "hat_5",         "headwear_1",         "",         ""     },new List<string>(){//E         "eye_L_4",         "eye_R_4",         "mouse_3",         "hand_L_4",         "hand_R_4",         "leg_L_4",         "leg_R_4",         "",         "headwear_0",         "",         ""     },new List<string>(){//F         "eye_L_5",         "eye_R_5",         "mouse_4",         "hand_L_5",         "hand_R_5",         "leg_L_5",         "leg_R_5",         "hat_3",         "",         "",         ""     },new List<string>(){//G         "eye_L_6",         "eye_R_6",         "mouse_5",         "hand_L_6",         "hand_R_6",         "leg_L_6",         "leg_R_6",         "",         "headwear_2",         "",         ""     },new List<string>(){//H         "eye_L_7",         "eye_R_7",         "mouse_6",         "hand_L_7",         "hand_R_7",         "leg_L_7",         "leg_R_7",         "",         "headwear_3",         "",         ""     },new List<string>(){//I         "eye_L_8",         "eye_R_8",         "mouse_7",         "hand_L_8",         "hand_R_8",         "leg_L_8",         "leg_R_8",         "hat_4",         "",         "",         ""     },new List<string>(){//J         "eye_L_9",         "eye_R_9",         "mouse_8",         "",         "",         "leg_L_9",         "leg_R_9",         "",         "headwear_4",         "",         ""     },new List<string>(){//K         "eye_L_10",         "eye_R_10",         "mouse_10",         "hand_L_10",         "hand_R_10",         "leg_L_10",         "leg_R_10",         "hat_10",         "",         "",         ""     },new List<string>(){//L         "eye_L_11",         "eye_R_11",         "mouse_11",         "",         "",         "leg_L_11",         "leg_R_11",         "hat_11",         "headwear_13",         "",         ""     },new List<string>(){//M         "eye_L_12",         "eye_R_12",         "mouse_12",         "hand_L_12",         "hand_R_12",         "leg_L_12",         "leg_R_12",         "hat_12",         "",         "",         ""     },new List<string>(){//N         "eye_L_13",         "eye_R_13",         "mouse_13",         "hand_L_13",         "hand_R_13",         "leg_L_13",         "leg_R_13",         "",         "headwear_10",         "",         ""     },new List<string>(){//O         "eye_L_14",         "eye_R_14",         "mouse_14",         "hand_L_14",         "hand_R_14",         "leg_L_14",         "leg_R_14",         "hat_0",         "",         "",         ""     },new List<string>(){//P         "eye_L_15",         "eye_R_15",         "mouse_15",         "hand_L_15",         "hand_R_15",         "leg_L_15",         "leg_R_15",         "hat_9",         "",         "",         ""     },new List<string>(){//Q         "eye_L_16",         "eye_R_16",         "mouse_16",         "hand_L_16",         "hand_R_16",         "leg_L_16",         "leg_R_16",         "",         "headwear_11",         "",         ""     },new List<string>(){//R         "eye_L_17",         "eye_R_17",         "mouse_17",         "hand_L_17",         "hand_R_17",         "leg_L_17",         "leg_R_17",         "",         "headwear_7",         "",         ""     },new List<string>(){//S         "eye_L_18",         "eye_R_18",         "",         "hand_L_18",         "hand_R_18",         "leg_L_18",         "leg_R_18",         "hat_8",         "",         "",         ""     },new List<string>(){//T         "eye_L_6",         "eye_R_6",         "mouse_18",         "hand_L_19",         "hand_R_19",         "leg_L_19",         "leg_R_19",         "",         "headwear_12",         "",         ""     },new List<string>(){//U         "eye_L_20",         "eye_R_20",         "mouse_19",         "hand_L_20",         "hand_R_20",         "leg_L_20",         "leg_R_20",         "",         "",         "",         ""     },new List<string>(){//V         "eye_L_21",         "eye_R_21",         "",         "hand_L_21",         "hand_R_21",         "leg_L_21",         "leg_R_21",         "hat_6",         "",         "",         ""     },new List<string>(){//W         "eye_L_22",         "eye_R_22",         "mouse_20",         "hand_L_22",         "hand_R_22",         "leg_L_22",         "leg_R_22",         "hat_7",         "",         "",         ""     },new List<string>(){//X         "eye_L_23",         "eye_R_23",         "mouse_21",         "hand_L_23",         "hand_R_23",         "leg_L_23",         "leg_R_23",         "hat_13",         "",         "",         ""     },new List<string>(){//Y         "eye_L_24",         "eye_R_24",         "mouse_22",         "hand_L_24",         "hand_R_24",         "leg_L_24",         "leg_R_24",         "",         "headwear_14",         "",         ""     },new List<string>(){//Z         "eye_L_19",         "eye_R_19",         "",         "hand_L_25",         "hand_R_25",         "leg_L_25",         "leg_R_25",         "",         "headwear_15",         "",         ""     },new List<string>(){//1         "eye_L_4",         "eye_R_4",         "number_mouse_0",         "number_hand_L_0",         "number_hand_R_0",         "number_leg_L_0",         "number_leg_R_0",         "number_hat_0",         "",         "",         ""     },new List<string>(){//2         "number_eye_L_0",         "number_eye_R_0",         "number_mouse_1",         "number_hand_L_1",         "number_hand_R_1",         "number_leg_L_1",         "number_leg_R_1",         "",         "number_headwear_0",         "",         ""     },new List<string>(){//3         "number_eye_L_1",         "number_eye_R_1",         "",         "number_hand_L_2",         "number_hand_R_2",         "number_leg_L_2",         "number_leg_R_2",         "",         "number_headwear_1",         "",         ""     },new List<string>(){//4         "eye_L_17|eye_L_16",         "eye_R_17|eye_R_16",         "mouse_22",         "hand_L_5",         "hand_R_5",         "leg_L_5",         "leg_R_5",         "",         "headwear_8",         "",         ""     },new List<string>(){//5         "eye_L_6",         "eye_R_6",         "mouse_19",         "hand_L_20",         "hand_R_20",         "leg_L_21",         "leg_R_21",         "",         "headwear_6",         "",         ""     },new List<string>(){//6         "eye_L_18",         "eye_R_18",         "mouse_20",         "hand_L_13",         "hand_R_13",         "leg_L_13",         "leg_R_13",         "",         "",         "",         ""     },new List<string>(){//7         "",         "",         "mouse_4",         "hand_L_24",         "hand_R_24",         "leg_L_24",         "leg_R_24",         "hat_7",         "headwear_5",         "",         ""     },new List<string>(){//8         "eye_L_7",         "eye_R_7",         "mouse_10",         "number_hand_L_3",         "number_hand_R_3",         "number_leg_L_3",         "number_leg_R_3",         "hat_9",         "headwear_9",         "",         ""     },new List<string>(){//9         "number_eye_L_1",         "number_eye_R_1",         "mouse_15",         "hand_L_11",         "hand_R_11",         "leg_L_11",         "leg_R_11",         "hat_11",         "",         "",         ""     },new List<string>(){//0         "eye_L_10",         "eye_R_10",         "mouse_13",         "number_hand_L_4",         "number_hand_R_4",         "number_leg_L_4",         "number_leg_R_4",         "",         "number_headwear_0"     },new List<string>(){//猪         "animal_eye_L_0|number_eye_L_0|eye_L_20",         "animal_eye_R_0|number_eye_R_0|eye_R_20",         "animal_mouse_0|animal_mouse_3|animal_mouse_4|animal_mouse_15|animal_mouse_16",         "animal_hand_L_0|animal_hand_L_3|animal_hand_L_4",         "animal_hand_R_0|animal_hand_R_3|animal_hand_R_4",         "animal_leg_L_0|animal_leg_L_3|animal_leg_L_4",         "animal_leg_R_0|animal_leg_R_3|animal_leg_R_4",         "animal_hat_0|animal_hat_3",         "number_headwear_1",         "animal_head_0|animal_head_3|animal_head_4",         "animal_body_0|animal_body_3"     },new List<string>(){//熊         "animal_eye_L_1|eye_L_1|eye_L_13",         "animal_eye_R_1|eye_R_1|eye_R_13",         "animal_mouse_1|animal_mouse_5|animal_mouse_6",         "animal_hand_L_1|animal_hand_L_5|animal_hand_L_6",         "animal_hand_R_1|animal_hand_R_5|animal_hand_R_6",         "animal_leg_L_1|animal_leg_L_5|animal_leg_L_6",         "animal_leg_R_1|animal_leg_R_5|animal_leg_R_6",         "animal_hat_1|animal_hat_4|animal_hat_5",         "",         "animal_head_1|animal_head_5|animal_head_6",         "animal_body_1|animal_body_5|animal_body_6"     },new List<string>(){//猫         "animal_eye_L_2|animal_eye_L_3|eye_L_3",         "animal_eye_R_2|animal_eye_R_3|eye_R_3",         "animal_mouse_2|animal_mouse_7|animal_mouse_8",         "animal_hand_L_2|animal_hand_L_7|animal_hand_L_8",         "animal_hand_R_2|animal_hand_R_7|animal_hand_R_8",         "animal_leg_L_2|animal_leg_L_7|animal_leg_L_8",         "animal_leg_R_2|animal_leg_R_7|animal_leg_R_8",         "animal_hat_2|animal_hat_6|animal_hat_7",         "",         "animal_head_2|animal_head_7|animal_head_8",         "animal_body_2|animal_body_7|animal_body_8"     },new List<string>(){//兔子         "eye_L_24|animal_eye_L_1|eye_L_13",         "eye_R_24|animal_eye_R_1|eye_R_13",         "animal_mouse_9|animal_mouse_6|animal_mouse_10",         "animal_hand_L_3|animal_hand_L_8|animal_hand_L_7",         "animal_hand_R_3|animal_hand_R_8|animal_hand_R_7",         "animal_leg_L_3|animal_leg_L_8|animal_leg_L_7",         "animal_leg_R_3|animal_leg_R_8|animal_leg_R_7",         "animal_hat_7|animal_hat_6",         "number_headwear_1",         "animal_head_10|animal_head_9|animal_head_11",         "animal_body_3|animal_body_8|animal_body_7"     },new List<string>(){//猴子         "animal_eye_L_4|eye_L_13|animal_eye_L_3",         "animal_eye_R_4|eye_R_13|animal_eye_R_3",         "animal_mouse_11|animal_mouse_9|animal_mouse_12",         "animal_hand_L_6",         "animal_hand_R_6",         "animal_leg_L_6",         "animal_leg_R_6",         "animal_hat_5",         "",         "animal_head_13|animal_head_12|animal_head_14",         "animal_body_6"     },new List<string>(){//狮子         "eye_L_13|eye_L_12|eye_L_7",         "eye_R_13|eye_R_12|eye_R_7",         "animal_mouse_8|animal_mouse_13|animal_mouse_14",         "animal_hand_L_4|animal_hand_L_5",         "animal_hand_R_4|animal_hand_R_5",         "animal_leg_L_4|animal_leg_L_5",         "animal_leg_R_4|animal_leg_R_5",         "animal_hat_3|animal_hat_4",         "",         "animal_head_15|animal_head_16|animal_head_17",         "animal_body_4|animal_body_5"     }      };

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

    /*
    //根据字母或数字，返回包含模板在内的5/6个素材
    public List<string> GetPathListWithModule(int index,TemplateResType type)
    {
        List<string> pathList = new List<string>();
        string path = string.Empty;

        //眼睛
        if (type == TemplateResType.Eye)
        {
            int num = 0;
            string mpath = ModulePathList[index][0];
            if (mpath=="")
            {
                num = Math.Min(6, resPathList[1].Count);
            }
            else
            {
                string[] leftst = ModulePathList[index][0].Split('|');
                string[] rightst = ModulePathList[index][1].Split('|');
                for (int i = 0; i < leftst.Length; i++)
                {
                    pathList.Add("sprite/fodder/eye|" + leftst[i]);
                    pathList.Add("sprite/fodder/eye|" + rightst[i]);
                }
                num = Math.Min(6 - leftst.Length, resPathList[1].Count);
            }
            
            int sIndex = 0;
            int eIndex = 0;
            if (GameManager.instance.curJoinType == JoinType.Animal)
            {
                sIndex = letterEyeCount + numberEyeCount;
                eIndex = sIndex + animalEyeCount - 1;
            }
            else
            {
                sIndex = 0;
                eIndex = letterEyeCount + numberEyeCount - 1;
            }
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
                num = Math.Min(5, resPathList[2].Count);
            }
            else
            {
                string[] tempPathLst = mpath.Split('|');
                for (int i = 0; i < tempPathLst.Length; i++) {
                    pathList.Add("sprite/fodder/mouth|" + tempPathLst[i]);
                }
                num = Math.Min(5-tempPathLst.Length, resPathList[2].Count);

            }
            int sIndex = 0;
            int eIndex = 0;
            if (GameManager.instance.curJoinType == JoinType.Animal)
            {
                sIndex = letterMouseCount + numberMouseCount;
                eIndex = sIndex + animalMouseCount - 1;
            }
            else
            {
                sIndex = 0;
                eIndex = letterMouseCount + numberMouseCount - 1;
            }
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
                num = Math.Min(6, resPathList[6].Count);
            }
            else
            {
                string[] leftst = ModulePathList[index][3].Split('|');
                string[] rightst = ModulePathList[index][4].Split('|');
                for (int i = 0; i < leftst.Length; i++)
                {
                    pathList.Add("sprite/fodder/hand|" + leftst[i]);
                    pathList.Add("sprite/fodder/hand|" + rightst[i]);
                }
                num = Math.Min(6- leftst.Length, resPathList[6].Count);
            }
            int sIndex = 0;
            int eIndex = 0;
            if (GameManager.instance.curJoinType == JoinType.Animal)
            {
                sIndex = letterHandCount + numberHandCount;
                eIndex = sIndex + animalHandCount - 1;
            }
            else
            {
                sIndex = 0;
                eIndex = letterHandCount + numberHandCount - 1;
            }
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
                num = Math.Min(5, resPathList[7].Count);
            }
            else
            {
                string[] leftst = ModulePathList[index][5].Split('|');
                string[] rightst = ModulePathList[index][6].Split('|');
                for (int i = 0; i < leftst.Length; i++)
                {
                    pathList.Add("sprite/fodder/leg|" + leftst[i]);
                    pathList.Add("sprite/fodder/leg|" + rightst[i]);
                }
                num = Math.Min(5- leftst.Length, resPathList[7].Count);
            }
            int sIndex = 0;
            int eIndex = 0;
            if (GameManager.instance.curJoinType == JoinType.Animal)
            {
                sIndex = letterLegCount + numberLegCount;
                eIndex = sIndex + animalLegCount - 1;
            }
            else
            {
                sIndex = 0;
                eIndex = letterLegCount + numberLegCount - 1;
            }
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
                num = Math.Min(5, resPathList[4].Count);
            }
            else
            {
                string[] tempPathLst = mpath.Split('|');
                for (int i = 0; i < tempPathLst.Length; i++)
                {
                    pathList.Add("sprite/fodder/hat|" + tempPathLst[i]);
                }
                num = Math.Min(5- tempPathLst.Length, resPathList[4].Count);
            }
            int sIndex = 0;
            int eIndex = 0;
            if (GameManager.instance.curJoinType == JoinType.Animal)
            {
                sIndex = letterHatCount + numberHatCount;
                eIndex = sIndex + animalHatCount - 1;
            }
            else
            {
                sIndex = 0;
                eIndex = letterHatCount + numberHatCount - 1;
            }
            for (int i = 0; i < num; i++)
            {
                Random rd = new Random();
                int n = rd.Next(sIndex, eIndex);
                while (pathList.Contains(resPathList[4][n]))
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
                num = Math.Min(6, resPathList[5].Count);
            }
            else
            {
                string[] tempPathLst = mpath.Split('|');
                for (int i = 0; i < tempPathLst.Length; i++)
                {
                    pathList.Add("sprite/fodder/headwear|" + tempPathLst[i]);
                }
                num = Math.Min(6-tempPathLst.Length, resPathList[5].Count);
            }
            int sIndex = 0;
            int eIndex = 0;
            if (GameManager.instance.curJoinType == JoinType.Animal)
            {
                sIndex = letterHeadWearCount + numberHeadWearCount;
                eIndex = sIndex - 1;
            }
            else
            {
                sIndex = 0;
                eIndex = letterHandCount + numberHandCount - 1;
            }
            for (int i = 0; i < num; i++)
            {
                Random rd = new Random();
                int n = rd.Next(sIndex, eIndex);
                while (pathList.Contains(resPathList[5][n]))
                {
                    n = rd.Next(sIndex, eIndex);
                }
                pathList.Add(resPathList[5][n]);
            }
        }
        else if (type == TemplateResType.Head)
        {
            string mpath = ModulePathList[index][9];
            int num = 0;
            if (mpath == "")
            {
                num = Math.Min(3, resPathList[8].Count);
            }
            else
            {
                string[] tempPathLst = mpath.Split('|');
                for (int i = 0; i < tempPathLst.Length; i++)
                {
                    pathList.Add("sprite/fodder/head|" + tempPathLst[i]);
                }
                num = Math.Min(3 - tempPathLst.Length, resPathList[8].Count);
            }
            int sIndex = 0;
            int eIndex = resPathList[8].Count;
            for (int i = 0; i < num; i++)
            {
                Random rd = new Random();
                int n = rd.Next(sIndex, eIndex);
                while (pathList.Contains(resPathList[8][n]))
                {
                    n = rd.Next(sIndex, eIndex);
                }
                pathList.Add(resPathList[8][n]);
            }
        }
        else if (type == TemplateResType.TrueBody)
        {
            string mpath = ModulePathList[index][10];
            int num = 0;
            if (mpath == "")
            {
                num = Math.Min(3, resPathList[9].Count);
            }
            else
            {
                string[] tempPathLst = mpath.Split('|');
                for (int i = 0; i < tempPathLst.Length; i++)
                {
                    pathList.Add("sprite/fodder/body|" + tempPathLst[i]);
                }
                num = Math.Min(3 - tempPathLst.Length, resPathList[9].Count);
            }
            int sIndex = 0;
            int eIndex = resPathList[9].Count;
            for (int i = 0; i < num; i++)
            {
                Random rd = new Random();
                int n = rd.Next(sIndex, eIndex);
                while (pathList.Contains(resPathList[9][n]))
                {
                    n = rd.Next(sIndex, eIndex);
                }
                pathList.Add(resPathList[9][n]);
            }
        }

        return pathList;
    }
    */

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
                while (pathList.Contains(tmpList[n]) || n % 2 != 0)
                {
                    n = rd.Next(0, tmpList.Count);
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
                string[] rightst = restrictList[index + 1][5].Split('&');
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

