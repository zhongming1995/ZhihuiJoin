using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class PanelManager :SingletonMono<PanelManager>
{
    private void Awake()
    {
        instance = this;
    }

    private List<Transform> PanelList = new List<Transform>();

    public void PushPanel(Transform panel)
    {
        PanelList.Add(panel);
    }

    public Transform PopPanel()
    {
        Transform panel = null;
        if (PanelList.Count>0)
        {
            panel = PanelList[PanelList.Count - 1];
        }
        return panel;
    }
}