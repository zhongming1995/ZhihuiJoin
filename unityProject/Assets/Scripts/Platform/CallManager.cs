using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallManager : SingletonMono<CallManager>
{
    public delegate void SavePhotoCallBack(string result);
    public static event SavePhotoCallBack savePhotoCallBack;

    void Awake()
    {
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
