using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helper;
using ResMgr;
using GameMgr;
using UnityEngine.SceneManagement;

public class AppEntry : SingletonMono<AppEntry>
{
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //第一步资源加载
       // if (ResManager.instance.LoadMainAssetBundle())
        //{
            //加载第一个页面
            //UIHelper.instance.LoadPrefab("prefabs/home|select_item_view", GameManager.instance.Root , Vector3.zero, Vector3.one,true);
       // }

        //屏蔽多点触摸
        Input.multiTouchEnabled = false;

        //帧率
        Application.targetFrameRate = 60;

        //打印
        Debug.unityLogger.logEnabled = false;

        //不销毁的物体，挂了很多管理脚本
        DontDestroyOnLoad(gameObject);

        //跳转到首页
        SceneManager.LoadScene("index");
    }

    public void SetMultiTouchEnable(bool enable)
    {
        Input.multiTouchEnabled = enable;
    }
}
