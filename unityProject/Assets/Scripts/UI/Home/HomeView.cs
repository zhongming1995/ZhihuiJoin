using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Helper;
using GameMgr;
using UnityEngine.SceneManagement;

public class HomeView : MonoBehaviour
{
    private List<GameObject> itemObjList = new List<GameObject>();
    private Transform ListViewContent;
    private Transform Root;
    private Transform SelectItemView;
    // Start is called before the first frame update

    void Awake()
    {
       
    }

    void Start()
    {
        ListViewContent = transform.Find("list_items/Scroll View/Viewport/Content");
        for (int i = 0; i < GameManager.instance.homePathList.Count; i++)
        {
            int j = i;
            GameObject item = UIHelper.instance.LoadPrefab("prefabs/home|home_item",ListViewContent,Vector3.zero,Vector3.one);
            item.name = i.ToString();
            itemObjList.Add(item);
            UIHelper.instance.SetImage(GameManager.instance.homePathList[i], item.transform.Find("img_bg/img_item").GetComponent<Image>());
            item.GetComponent<Button>().onClick.AddListener(delegate {
                //记录主界面选择的素材下标
                GameManager.instance.homeSelectIndex = j;
                //GameObject obj = UIHelper.instance.LoadPrefab("prefabs/join|join_main_view", GameManager.instance.Root, Vector3.zero, Vector3.one,true);
                //Destroy(gameObject);
                SceneManager.LoadScene("join");
            });
        }
    }
}
