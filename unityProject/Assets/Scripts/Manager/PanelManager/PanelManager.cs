using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public static class PanelName
{
    public static string IndexView = "index_view";
    public static string HomeView = "home_view";
    public static string JoiMainView = "join_main_view";
    public static string DisplayView = "display_view";
    public static string PianoView = "piano_view";
    public static string CardView = "card_view";
    public static string FruitView = "fruit_view";
    public static string CalendarView = "calendar_view";
    public static string CalendarDetailView = "calendar_detail_view";
}

public class Panel
{
    public string panelName;
    public GameObject panelObject;

    public Panel(string _panelName,GameObject _panelObject)
    {
        panelName = _panelName;
        panelObject = _panelObject;
    }
}

public class PanelManager :SingletonMono<PanelManager>
{
    private void Awake()
    {
        instance = this;
    }

    private List<Panel> PanelList = new List<Panel>();

    public void PushPanel(string name,GameObject obj)
    {
        GameObject lastPanel = PopPanel();
        if (lastPanel != null)
        {
            lastPanel.gameObject.SetActive(false);
        }
        Panel panel = new Panel(name, obj);
        PanelList.Add(panel);
    }

    public GameObject PopPanel()
    {
        Panel panel = null;
        if (PanelList.Count>0)
        {
            panel = PanelList[PanelList.Count - 1];
        }
        if (panel!=null)
        {
            return panel.panelObject;
        }
        return null;
    }

    //关掉最上层panel
    public void CloseTopPanel()
    {
        //关闭顶层
        GameObject g = PopPanel();
        PanelList.RemoveAt(PanelList.Count - 1);
        Destroy(g);
        //显示倒数第二层
        GameObject top = PopPanel();
        if (top!=null)
        {
            top.gameObject.SetActive(true);
        }
    }

    public void BackToView(string name)
    {
        int findIndex = -1;
        for (int i = 0; i < PanelList.Count; i++)
        {
            if(PanelList[i].panelName == name)
            {
                findIndex = i;
            }
        }
        if (findIndex!=-1)
        {
            PanelList[findIndex].panelObject.SetActive(true);
        }
        for (int j = PanelList.Count-1; j >findIndex; j--)
        {
            GameObject g = PanelList[j].panelObject;
            PanelList.RemoveAt(j);
            Destroy(g);
        }
    }
}