using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Helper;
using GameMgr;
using UnityEngine.SceneManagement;
using AudioMgr;

public class HomeView : MonoBehaviour
{
    public Button btnHome;
    private List<GameObject> itemObjList = new List<GameObject>();
    private Transform ListViewContent;
    private Transform Root;
    private Transform SelectItemView;

    private int StartIndex;
    private int EndIndex;

    void Start()
    {
        //初始化位置
        GameManager.instance.homeContentPosx = 0;
        //按钮点击事件
        BtnClickEvent();
       
        ListViewContent = transform.Find("list_items/Scroll View/Viewport/Content");
        //列表定位
        ListViewContent.localPosition = new Vector3(GameManager.instance.homeContentPosx, ListViewContent.localPosition.y, ListViewContent.localPosition.z);

        //赋值初始位置
        if (GameManager.instance.curJoinType==JoinType.Letter)
        {
            StartIndex = 0;
            EndIndex = 25;
        }
        else if (GameManager.instance.curJoinType == JoinType.Num)
        {
            StartIndex = 26;
            EndIndex = 35;
        }

        //for (int i = 0; i < GameManager.instance.homePathList.Count; i++)
        for (int i = StartIndex; i <= EndIndex; i++)
        {
            int j = i;
            GameObject item = UIHelper.instance.LoadPrefab("Prefabs/home|home_item",ListViewContent,Vector3.zero,Vector3.one);
            item.name = i.ToString();
            itemObjList.Add(item);
            //UIHelper.instance.SetImage(GameManager.instance.homePathList[i], item.transform.Find("img_bg/img_item").GetComponent<Image>());
            UIHelper.instance.SetImage(GameData.homePathList[i], item.transform.Find("img_bg/img_item").GetComponent<Image>());
            item.GetComponent<Button>().onClick.AddListener(delegate {
                //记录主界面选择的素材下标
                GameManager.instance.SetJoinShowAll(false);
                GameManager.instance.SetOpenType(OpenType.FirstEdit);
                GameManager.instance.homeSelectIndex = j;
                PersonManager.instance.PersonFileName = j.ToString() + "_" + PersonManager.instance.GetPersonsNum();
                GameManager.instance.homeContentPosx = ListViewContent.localPosition.x;
                //记录列表的位置
                //跳转后再播放素材模版音效
                //AudioManager.instance.PlayAudio(EffectAudioType.Option,GameManager.instance.drawAudioPathList[GameManager.instance.homeSelectIndex]);
                AudioManager.instance.PlayAudio(EffectAudioType.Option, GameData.drawAudioPathList[GameManager.instance.homeSelectIndex]);
                JumpToJoin();

            });
        }
    }

    private void JumpToJoin()
    {
        UIHelper.instance.LoadPrefabAsync("Prefabs/join|join_main_view", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true, null, (panel) => {
            PanelManager.instance.PushPanel(PanelName.JoiMainView,panel);
        });
    }

    private void BtnClickEvent()
    {
        btnHome.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            PanelManager.instance.CloseTopPanel();
        });
    }
}
