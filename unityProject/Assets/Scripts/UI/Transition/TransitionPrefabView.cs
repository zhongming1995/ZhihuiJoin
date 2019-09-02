using System;
using GameMgr;
using Helper;
using ResMgr;
using UnityEngine;

//这个暂时没用到，现在有过度页的只有列表页到拼接页，是用的跳转场景
public class TransitionPrefabView : MonoBehaviour
{

    //public Text TxtProgress;
    private float time;
    void Start()
    {
        Debug.Log("start transition");
        FadeIn.fadeInComplete += FadeComplete;
        //UIHelper.instance.LoadPrefab(GameManager.instance.nextViewPath, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
        //Invoke("PreLoad", 0.1f);
        time = Time.realtimeSinceStartup;
    }

    private void FadeComplete(PanelEnum panelEnum)
    {
        Debug.Log(panelEnum.ToString());
        if (panelEnum==PanelEnum.TransitionView)
        {
            PreLoad();
            PanelManager.instance.CloseTopPanel();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void SetProgress(float progress)
    {
        //TxtProgress.text = (progress * 100).ToString() + "%";
    }

    public void PreLoad()
    {
        Debug.Log("LoadComplete");
        if (AppEntry.instance.IsDebugging)
        {
            Debug.Log("==========测试模式，不预加载");
            Invoke("PreloadComplete", 0.5f);
        }
        else
        {
            string[] preloaList = PanelPreload.PreloadDic[GameManager.instance.nextViewPath];
            int resultCount = 0;
            if (preloaList != null && preloaList.Length != 0)
            {
                Debug.Log("list count:" + preloaList.Length);
                for (int i = 0; i < preloaList.Length; i++)
                {
                    //ResManager.instance.LoadAssetBundle(preloaList[i]);
                    Debug.Log("育加载：" + i);
                    ResManager.instance.LoadAssetBundleAsync(preloaList[i], (bundle) =>
                    {
                        resultCount++;
                        if (resultCount == preloaList.Length)
                        {
                            Debug.Log("育加载最后一个了----");
                            if (Time.realtimeSinceStartup - time > 0.2f)
                            {
                                PreloadComplete();
                            }
                            else
                            {
                                Debug.Log("offset:" + (Time.realtimeSinceStartup - time));
                                float offsetTime = 0.2f - (Time.realtimeSinceStartup - time);
                                Invoke("PreloadComplete", offsetTime);
                            }
                        }

                    });
                }
            }
            else
            {
                Debug.Log("no list");
                Invoke("PreloadComplete", 0.5f);
            }

            Debug.Log("preload complete:" + Time.realtimeSinceStartup);

            //if (Time.realtimeSinceStartup - time > 0.2f)
            //{
            //    PreloadComplete();
            //}
            //else
            //{
            //    Debug.Log("offset:" + (Time.realtimeSinceStartup - time));
            //    float offsetTime = 0.2f - (Time.realtimeSinceStartup - time);
            //    Invoke("PreloadComplete", offsetTime);
            //}
        }
    }

    void PreloadComplete()
    {
        //预加载完成
        //GameObject panel = UIHelper.instance.LoadPrefab(GameManager.instance.nextViewPath, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
        //PanelManager.instance.PushPanel(GameManager.instance.nextViewPath, panel);
        //Destroy(gameObject);
        Debug.Log("preload complete func");
        UIHelper.instance.LoadPrefabAsync(GameManager.instance.nextViewPath, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true,null,(panel)=> {
            PanelManager.instance.PushPanel(GameManager.instance.nextViewPath, panel);
        });
    }

    void OnDestroy()
    {
        FadeIn.fadeInComplete -= FadeComplete;
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
