using UnityEngine;
using System.Collections.Generic;
using GameMgr;

public static class PanelName
{
    public static string IndexView = "prefabs/index|index_view";
    public static string HomeView = "prefabs/home|home_view";
    public static string JoinMainView = "prefabs/join|join_main_view";
    public static string DisplayView = "prefabs/display|display_view";
    public static string PianoView = "prefabs/game/piano|piano_view";
    public static string CardView = "prefabs/game/card|card_view";
    public static string FruitView = "prefabs/game/fruit|fruit_view";
    public static string CalendarView = "prefabs/calendar|calendar_view";
    public static string CalendarDetailView = "prefabs/calendar|calendar_detail_view";
    public static string TransitionView = "Prefabs/common|transition_prefab_view";
}

public enum PanelEnum
{
    IndexView,
    HomeView,
    JoinMainView,
    DisplayView,
    PianoView,
    CardView,
    FruitView,
    CalendarView,
    CalendarDetailView,
    TransitionView
}

public static class PanelPreload
{
    public static Dictionary<string, string[]> PreloadDic = new Dictionary<string, string[]>() 
    {
        { PanelName.IndexView,null },
        { PanelName.HomeView,new string[]{
            "prefabs/home",
            //"sprite/homeitems"
            }},
        { PanelName.JoinMainView,new string[]{
            "prefabs/join",
            //"prefabs/guide",
            //"sprite/fodder/eye",
            //"sprite/fodder/hair",
            //"sprite/fodder/hair",
            //"sprite/fodder/hat",
            //"sprite/fodder/headwear",
            //"sprite/fodder/leg",
            //"sprite/fodder/mouth",
            //"sprite/small_fodder/eye",
            //"sprite/small_fodder/hair",
            //"sprite/small_fodder/hair",
            //"sprite/small_fodder/hat",
            //"sprite/small_fodder/headwear",
            //"sprite/small_fodder/leg",
            //"sprite/small_fodder/mouth",
            //"sprite/ui_sp/join_sp",
            } },
        { PanelName.DisplayView,new string[]{
            "prefabs/display",
            } },
        { PanelName.PianoView,new string[]{
            "prefabs/game/piano",
            //"prefabs/game/window",
            //"sprite/ui_sp/piano_sp/piano_symbols",
            //"sprite/ui_sp/piano_sp/song_name",
        } },
        { PanelName.FruitView,new string[]{
            "prefabs/game/fruit",
            //"prefabs/game/window",
            //"sprite/ui_sp/fruit",
        } },
        { PanelName.CardView,new string[]{
            "prefabs/game/card",
            //"prefabs/game/window",
        } },
        { PanelName.CalendarView,new string[]{
            "prefabs/calendar",
        } },
        { PanelName.CalendarDetailView,new string[]{} },
    };
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
    private List<string> PanelNameList = new List<string>();
    private string LastPanel = string.Empty;

    public bool isEmpty()
    {
        if (PanelList.Count==0)
        {
            return true;
        }
        return false;
    }

    public void PushPanelName(string name)
    {
        PanelNameList.Add(name);
    }

    public string PopPanelName()
    {
        string panel = PanelNameList[PanelList.Count - 1];
        PanelNameList.RemoveAt(PanelNameList.Count - 1);
        return panel;
    }


    public void PushPanel(string name,GameObject obj)
    {
        Debug.Log("pushPanel:"+name);
        PushPanelName(name);
        Panel lastPanel = GetTopPanel();
        if (lastPanel != null)
        {
            lastPanel.panelObject.SetActive(false);
        }
        Panel panel = new Panel(name, obj);
        PanelList.Add(panel);
    }

    public Panel GetTopPanel()
    {
        Panel panel = null;
        if (PanelList.Count>0)
        {
            panel = PanelList[PanelList.Count - 1];
        }
        if (panel!=null)
        {
            return panel;
        }
        return null;
    }

    //关掉最上层panel
    public void CloseTopPanel()
    {
        //关闭顶层
        Panel p = GetTopPanel();
        if (p!=null)
        {
            GameObject g = p.panelObject;
            PanelList.RemoveAt(PanelList.Count - 1);
            Destroy(g);
            g = null;
        }

        //显示倒数第二层
        Panel top = GetTopPanel();
        if (top!=null)
        {
            top.panelObject.SetActive(true);
        }
    }

    public void ClearPanelList()
    {
        for (int i = 0; i < PanelList.Count; i++)
        {
            if (PanelList[i]!=null)
            {
                GameObject g = PanelList[i].panelObject;
                Destroy(g);
                g = null;
            }
        }
        PanelList.Clear();
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