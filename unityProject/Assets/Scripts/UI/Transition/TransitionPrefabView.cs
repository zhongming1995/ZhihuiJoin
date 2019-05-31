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
        FadeIn.fadeInComplete += LoadComplete;
        UIHelper.instance.LoadPrefabAsync(GameManager.instance.nextViewPath, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true, SetProgress, null);
    }

    void OnDestroy()
    {
        FadeIn.fadeInComplete -= LoadComplete;
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

    void SetProgress(float progress)
    {
        TxtProgress.text = (progress * 100).ToString() + "%";
    }

    public void LoadComplete()
    {
        Destroy(gameObject);
    }
}
