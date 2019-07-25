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
    public Button btnCalendar;
    private List<GameObject> itemObjList = new List<GameObject>();
    private Transform ListViewContent;
    private Transform Root;
    private Transform SelectItemView;
    // Start is called before the first frame update

    void Start()
    {
        //按钮点击事件
        BtnClickEvent();
       
        ListViewContent = transform.Find("list_items/Scroll View/Viewport/Content");
        //列表定位
        ListViewContent.localPosition = new Vector3(GameManager.instance.homeContentPosx, ListViewContent.localPosition.y, ListViewContent.localPosition.z);

        for (int i = 0; i < GameManager.instance.homePathList.Count; i++)
        {
            int j = i;
            GameObject item = UIHelper.instance.LoadPrefab("Prefabs/home|home_item",ListViewContent,Vector3.zero,Vector3.one);
            item.name = i.ToString();
            itemObjList.Add(item);
            UIHelper.instance.SetImage(GameManager.instance.homePathList[i], item.transform.Find("img_bg/img_item").GetComponent<Image>());
            item.GetComponent<Button>().onClick.AddListener(delegate {
                //记录主界面选择的素材下标
                GameManager.instance.homeSelectIndex = j;
                PersonManager.instance.PersonFileName = j.ToString() + "_" + PersonManager.instance.GetPersonsNum();
                //GameObject obj = UIHelper.instance.LoadPrefab("Prefabs/join|join_main_view", GameManager.instance.Root, Vector3.zero, Vector3.one,true);
                //Destroy(gameObject);
                GameManager.instance.homeContentPosx = ListViewContent.localPosition.x;
                //记录列表的位置
                //设置类型
                if (j < 26)
                {
                    GameManager.instance.curJoinType = JoinType.Letter;
                }
                else
                {
                    GameManager.instance.curJoinType = JoinType.Num;
                }
                //跳转后再播放素材模版音效
                AudioManager.instance.PlayAudio(EffectAudioType.Option,GameManager.instance.drawAudioPathList[GameManager.instance.homeSelectIndex]);
                JumpToJoin();
            });
        }
    }

    private void JumpToJoin()
    {
        GameManager.instance.SetNextSceneName("join");
        SceneManager.LoadScene("transition");
    }

    private void BtnClickEvent()
    {
        btnHome.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            SceneManager.LoadScene("index");
        });

        btnCalendar.onClick.AddListener(delegate {
            UIHelper.instance.LoadPrefab("Prefabs/calendar|calendar_view",GameManager.instance.GetCanvas().transform,Vector3.zero,Vector3.one,true);
        });
    }
}
