using System;
namespace ResMgr
{
    //平台标示
    public enum ResPlatForm
    {
        unknow = 0,
        standalonewindows = 1,
        iOS = 2,
        andorid = 3,
        webplayer = 4,
    }

    public static class ResConf
    {
        //平台
#if UNITY_EDITOR
        public static ResPlatForm resPlatForm = ResPlatForm.unknow;
#elif UNITY_ANDROID
        public static ResPlatForm resPlatForm = ResPlatForm.andorid;
#elif UNITY_IPHONE
        public static ResPlatForm resPlatForm = ResPlatForm.iOS;
#endif

        //bundle后缀名
        public const string ASSET_BUNDLE_SUFFIX = ".ab";//ab只是用于磁盘文件上的标记
        //大bundle的名字
        public const string BUNDLE_NAME = "StreamingAssets";
    }
}
