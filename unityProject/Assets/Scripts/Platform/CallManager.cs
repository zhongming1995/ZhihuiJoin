using System.Runtime.InteropServices;
using UnityEngine;

public class CallManager : SingletonMono<CallManager>
{
    public delegate void SavePhotoCallBack(string result);
    public static event SavePhotoCallBack savePhotoCallBack;

    void Awake()
    {
        Debug.Log("CallManager Awake" + Time.realtimeSinceStartup);
        instance = this;
    }

    //平台回调unity 
    public void PlatformToUnity_SavePhotoCallBack(string result)
    {
        Debug.Log("Recv==================:" + result);
        if (savePhotoCallBack != null)
        {
            savePhotoCallBack(result);
        }
    }

    //unity调用平台，保存到相册
    [DllImport("__Internal")]
    private static extern void UnityToIOS_SavePhotoToAlbum(string path);
    public void UnityToPlatform_SavePhotoToAlbum(string path)
    {
#if UNITY_IOS && !UNITY_EDITOR
        UnityToIOS_SavePhotoToAlbum(path);
#endif
    }

    //unity调用平台,开始计时
    [DllImport("__Internal")]
    private static extern void UnityToIOS_ResumeTime();
    public void UnityToPlatform_ResumeTime()
    {
#if UNITY_IOS && !UNITY_EDITOR
        UnityToIOS_ResumeTime();
#endif
    }

    //unity调用平,暂停计时
    [DllImport("__Internal")]
    private static extern void UnityToIOS_PauseTime();
    public void UnityToPlayform_PauseTime()
    {
#if UNITY_IOS && !UNITY_EDITOR
        UnityToIOS_PauseTime();
#endif
    }
}
