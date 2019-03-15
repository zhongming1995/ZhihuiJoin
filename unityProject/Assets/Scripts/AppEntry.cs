using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helper;
using ResMgr;
using GameMgr;

public class AppEntry : SingletonMono<AppEntry>
{
    void Awake()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        //第一步资源加载
        if (ResManager.instance.LoadMainAssetBundle())
        {
            //加载第一个页面
            UIHelper.instance.LoadPrefab("prefabs/home|select_item_view", GameManager.instance.Root , Vector3.zero, Vector3.one,true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
