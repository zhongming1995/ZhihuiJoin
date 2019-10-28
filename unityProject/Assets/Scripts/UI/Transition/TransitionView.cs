using System;
using System.Collections;
using GameMgr;
using Helper;
using ResMgr;
using UnityEngine;
using UnityEngine.SceneManagement;

//用的跳转场景
public class TransitionView : SingletonMono<TransitionView>
{
    private float MinTime = 0.3f;
    private float time;
    private FadeIn fadeIn;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        fadeIn = GetComponent<FadeIn>();
        FadeIn.fadeInComplete += FadeInComplete; 
        FadeIn.fadeOutComplete += FadeOutComplete;
        DontDestroyOnLoad(this);
        gameObject.SetActive(false);
    }

    public void OpenTransition()
    {
        gameObject.SetActive(true);
    }

    private void FadeInComplete(PanelEnum panelEnum)
    {
        if (panelEnum == PanelEnum.TransitionView)
        {
            StartCoroutine(LoadSceneAsync());
        }
    }

    private void FadeOutComplete(PanelEnum panelEnum)
    {
        gameObject.SetActive(false);
    }

    public IEnumerator LoadSceneAsync(Action cb = null)
    {
        time = Time.realtimeSinceStartup;
        bool LoadComplete = false;
        yield return new WaitForEndOfFrame();
        AsyncOperation async = SceneManager.LoadSceneAsync(GameManager.instance.nextSceneName);
        async.allowSceneActivation = true;
        while (!async.isDone)
        {
            if (async.progress < 0.9f)
            {

            }
            else
            {
                async.allowSceneActivation = true;
                if (LoadComplete==false)
                {
                    LoadComplete = true;
                    float offsetTime = MinTime - (Time.realtimeSinceStartup - time);
                    if (offsetTime > 0)
                    {
                        Invoke("LoadSceneComplete", offsetTime);
                    }
                    else
                    {
                        LoadSceneComplete();
                    }
                }
              
            }
            yield return null;
        }
    }

    void LoadSceneComplete()
    {
        fadeIn.FadeOutFunc();
    }

    void OnDestroy()
    {
        FadeIn.fadeInComplete -= FadeInComplete;
        FadeIn.fadeOutComplete -= FadeOutComplete;
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
