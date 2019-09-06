using UnityEngine;
using ResMgr;
using Helper;
using UnityEngine.SceneManagement;
using GameMgr;

public class AppEntry : SingletonMono<AppEntry>
{
    public bool IsDebugging;
    private void Awake()
    {
        Debug.Log("AppEntry Awake" + Time.realtimeSinceStartup);
        instance = this;
    }

    void Start()
    {
        //屏蔽多点触摸
        Input.multiTouchEnabled = false;

        //帧率
        Application.targetFrameRate = 60;

        //打印开关
        Debug.unityLogger.logEnabled = false;

        //不销毁的物体，挂了很多管理脚本
        DontDestroyOnLoad(gameObject);

        IsDebugging = true;

        /*同步加载方式*/
        if (ResManager.instance.LoadMainAssetBundle())
        {
            GameManager.instance.SetNextSceneName(SceneName.Index);
            StartCoroutine(TransitionView.instance.LoadSceneAsync());
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
