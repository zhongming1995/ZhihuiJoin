using System.Collections;
using System.Collections.Generic;
using GameMgr;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionView : MonoBehaviour
{
    public Text TxtProgress;

    private float progress;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoadScene");
    }

    IEnumerator LoadScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(GameManager.instance.nextSceneName);
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            if (async.progress < 0.9f)
            {
                progress = async.progress;
            }
            else
            {
                progress = 1.0f;
            }
            TxtProgress.text = (progress*100).ToString()+"%";

            if (progress >= 0.9f)
            {
                TxtProgress.text = "按任意键跳转场景";
                if (Input.anyKey)
                {
                    async.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
}
