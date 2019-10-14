using System.Runtime.InteropServices;
using UnityEngine;
using AudioMgr;

public class CallManager : SingletonMono<CallManager>
{
    public delegate void SavePhotoCallBack(string result);
    public static event SavePhotoCallBack savePhotoCallBack;

    void Awake()
    {
        instance = this;
    }

    //平台回调unity,保存相册的结果
    public void PlatformToUnity_SavePhotoCallBack(string result)
    {
        if (savePhotoCallBack != null)
        {
            savePhotoCallBack(result);
        }
    }

    //平台回调unity，休息页面打开回调
    public void PlatformToUnity_ShowRestView()
    {
        AudioManager.instance.EffectEnable = false;
    }

    //平台回调unity，休息页面关闭回调
    public void PlatformToUnity_HideRestView()
    {
        AudioManager.instance.EffectEnable = true;
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

    //unity调用平台,暂停计时
    [DllImport("__Internal")]
    private static extern void UnityToIOS_PauseTime();
    public void UnityToPlayform_PauseTime()
    {
#if UNITY_IOS && !UNITY_EDITOR
        UnityToIOS_PauseTime();
#endif
    }

    //unity调用平台，个人中心
    [DllImport("__Internal")]
    private static extern void UnityToIOS_GoToPersonalCenter();
    public void UnityToPlatform_GoToPersonalCenter()
    {
#if UNITY_IOS && !UNITY_EDITOR
        UnityToIOS_GoToPersonalCenter();
#endif
    }
}
