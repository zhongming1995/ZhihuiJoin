using System;
using System.Collections;
using System.Collections.Generic;
using GameMgr;
using Helper;
using UnityEngine;
using UnityEngine.UI;

public class TransitionPrefabView : MonoBehaviour
{
  
    public Text TxtProgress;
    // Start is called before the first frame update
    void Start()
    {
        UIHelper.instance.LoadPrefabAsync(GameManager.instance.nextViewPath, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true, SetProgress, LoadComplete);
    }

    void SetProgress(float progress)
    {
        TxtProgress.text = (progress * 100).ToString() + "%";
    }

    void LoadComplete(GameObject obj)
    {
        Destroy(gameObject);
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
    /*
    IEnumerator LoadPrefabAsync()
    {
        yield return new WaitForEndOfFrame();
        ResourceRequest request = Resources.LoadAsync(GameManager.instance.nextViewPath);
        while (!request.isDone)
        {
            if (request.progress < 0.9f)
            {
                progress = request.progress;
            }
            else
            {
                progress = 1.0f;
            }
            TxtProgress.text = (progress * 100).ToString() + "%";

            yield return null;
        }
        GameObject go = Instantiate(request.asset) as GameObject;
        go.transform.SetParent(GameManager.instance.GetCanvas().transform);
        go.transform.localPosition = Vector3.zero;
        go.transform.localScale = Vector3.one;

        go.transform.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        go.transform.GetComponent<RectTransform>().offsetMax = Vector2.zero;
    }
    */
}
