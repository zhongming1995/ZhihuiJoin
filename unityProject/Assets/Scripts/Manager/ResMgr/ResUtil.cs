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

    }
}


