using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Helper;
using GameMgr;
using UnityEngine.SceneManagement;
using AudioMgr;
using System;

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
        //GameManager.instance.homeContentPosx = 0;
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

        for (int i = StartIndex; i <= EndIndex; i++)
        {
            int j = i;
            GameObject item = UIHelper.instance.LoadPrefab("Prefabs/home|home_item",ListViewContent,Vector3.zero,Vector3.one);
            item.name = i.ToString();
            itemObjList.Add(item);
            RawImage image = item.transform.Find("img_bg/img_item").GetComponent<RawImage>();
            image.texture = UIHelper.instance.LoadSprite(GameData.homePathList[i]).texture;
            image.SetNativeSize();
            item.GetComponent<Button>().onClick.AddListener(delegate {
                //记录主界面选择的素材下标
                AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
                GameManager.instance.SetJoinShowAll(false);
                GameManager.instance.SetOpenType(OpenType.FirstEdit);
                GameManager.instance.homeSelectIndex = j;
                PersonManager.instance.PersonFileName = j.ToString() + "_" + PersonManager.instance.GetPersonsNum();
                GameManager.instance.homeContentPosx = ListViewContent.localPosition.x;
                JumpToJoin();
            });
        }
    }

    private void JumpToJoin()
    {
        //GameManager.instance.SetNextViewPath(PanelName.JoinMainView);
        //UIHelper.instance.LoadPrefab(PanelName.TransitionView, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
        GameManager.instance.SetNextSceneName(SceneName.Join);
        TransitionView.instance.OpenTransition();
    }

    private void BtnClickEvent()
    {
        btnHome.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            //GameManager.instance.SetNextViewPath(PanelName.IndexView);
            //UIHelper.instance.LoadPrefab(PanelName.TransitionView, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
            GameManager.instance.SetNextSceneName(SceneName.Index);
            TransitionView.instance.OpenTransition();
        });
    }

    private void OnDestroy()
    {
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
