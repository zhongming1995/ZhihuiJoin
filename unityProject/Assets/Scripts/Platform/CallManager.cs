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

    public void PlatformToUnity_SavePhotoCallBack(string result)
    {
        Debug.Log("Recv==================:" + result);
        if (savePhotoCallBack != null)
        {
            savePhotoCallBack(result);
        }
    }
}
