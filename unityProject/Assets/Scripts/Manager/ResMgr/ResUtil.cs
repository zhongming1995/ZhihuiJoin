using UnityEngine;

namespace ResMgr
{
    public static class ResUtil
    {
       
        public static string GetStreamingAssetPath(string subPath)
        {
            string path = string.Format(@"{0}/{1}", Application.streamingAssetsPath, subPath);
#if UNITY_EDITOR
            path = "file://" + path;
#elif UNITY_ANDROID
#elif Unity_IOS
            path = "file://"+path
#endif
            return path;
        }

        //用LoadFromFile方法加载的时候不能加“file://”
        public static string GetStreamingAssetPathWithoutFile(string subPath)
        {
            return string.Format(@"{0}/{1}", Application.streamingAssetsPath, subPath); 
        }

        public static string GetPersistentDataPath(string subPath)
        {
            string path = Application.persistentDataPath;
            return path;
        }

        /// <summary>
        /// 加载AB使用的是xx/xx|a 这样的路径，用Resources加载要转换成xx/xx/a
        /// </summary>
        /// <param name="path"></param>
        public static string PathToResourcePath(string path)
        {
            string[] strLst = path.Split('|');
            //Debug.Log(path);
            return strLst[0] + "/" + strLst[1];
        }
    }
}


