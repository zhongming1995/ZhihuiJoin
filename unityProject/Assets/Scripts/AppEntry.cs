﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ResMgr;
using UnityEngine.SceneManagement;

public class AppEntry : SingletonMono<AppEntry>
{
    //用来控制资源加载方式，isEditorDebug=true时用编辑器下的方法，isEditorDebug=false 正式时用AssetBundle
    public bool isEditorDebug;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //屏蔽多点触摸
        Input.multiTouchEnabled = false;

        //帧率
        Application.targetFrameRate = 60;

        //打印开关
        Debug.unityLogger.logEnabled = true;

        //不销毁的物体，挂了很多管理脚本
        DontDestroyOnLoad(gameObject);

        /*同步加载方式*/
        if (ResManager.instance.LoadMainAssetBundle())
        {
            SceneManager.LoadScene("index");
        }
        
        //异步加载方式
        //ResManager.instance.LoadMainAssetBundleAsync(() => { SceneManager.LoadScene("index"); });
    }

    //供外部调用，弹钢琴页面允许多指，其他时候不允许
    public void SetMultiTouchEnable(bool enable)
    {
        Input.multiTouchEnabled = enable;
    }
}
