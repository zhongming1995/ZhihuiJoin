using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Helper;
using GameMgr;
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
        Debug.Log(GameManager.instance.homeContentPosx);
        //开始计时
        CallManager.instance.UnityToPlatform_ResumeTime();
        //按钮点击事件
        BtnClickEvent();
        ListViewContent = transform.Find("list_items/Scroll View/Viewport/Content");
        //ListViewContent.localPosition = new Vector3(GameManager.instance.homeContentPosx, ListViewContent.localPosition.y, ListViewContent.localPosition.z);
        ListViewContent.gameObject.SetActive(false);
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
        else if (GameManager.instance.curJoinType == JoinType.Animal)
        {
            StartIndex = 36;
            EndIndex = 41;
        }

        for (int i = StartIndex; i <= EndIndex; i++)
        {
            int j = i;
            GameObject item = UIHelper.instance.LoadPrefab("Prefabs/home|home_item",ListViewContent,Vector3.zero,Vector3.one);
            item.name = i.ToString();
            itemObjList.Add(item);
            RawImage image = item.transform.Find("img_bg/img_item").GetComponent<RawImage>();
            image.texture = UIHelper.instance.LoadSprite(GameData.instance.homePathList[i]).texture;
            image.SetNativeSize();
            item.GetComponent<Button>().onClick.AddListener(delegate {
                //记录主界面选择的素材下标
                GameManager.instance.SetJoinShowAll(false);
                GameManager.instance.SetOpenType(OpenType.FirstEdit);
                GameManager.instance.homeSelectIndex = j;
                PersonManager.instance.PersonFileName = Utils.GetTimeStamp();
                GameManager.instance.homeContentPosx = ListViewContent.localPosition.x;
                JumpToJoin();
            });
        }
        float offset = Math.Abs(GameManager.instance.homeContentPosx - GameManager.instance.defaultHomeContentPos);
        if (offset<1)
        {
            Invoke("SetContentPos", 0.5f);
        }
        else
        {
            ListViewContent.gameObject.SetActive(true);
            ListViewContent.localPosition = new Vector3(GameManager.instance.homeContentPosx, ListViewContent.localPosition.y, ListViewContent.localPosition.z);
        }
    }

    private void SetContentPos()
    {
        ListViewContent.gameObject.SetActive(true);
        ListViewContent.localPosition = new Vector3(GameManager.instance.homeContentPosx, ListViewContent.localPosition.y, ListViewContent.localPosition.z);
        Debug.Log(ListViewContent.localPosition.x);
    }

    private void JumpToJoin()
    {
        GameManager.instance.SetNextSceneName(SceneName.Join);
        TransitionView.instance.OpenTransition();
    }

    private void BtnClickEvent()
    {
        btnHome.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
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
