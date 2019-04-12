using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using GameMgr;

public class ColorToggleCtrl : MonoBehaviour
{
    public List<Toggle> toggleLst = new List<Toggle>();
    ToggleGroup tg;
    JoinMainView joinMainView;
    // Use this for initialization
    void Start()
    {
        Debug.Log("Color Start");
        joinMainView = transform.GetComponentInParent<JoinMainView>();
        tg = transform.GetComponent<ToggleGroup>();
        int count = transform.childCount;
        Debug.Log(count);
        for (int i = 0; i < count; i++)
        {
            Debug.Log("i:" + i);
            int index = i;
            Toggle t = transform.GetChild(i).GetComponent<Toggle>();
            t.group = tg;
            t.onValueChanged.AddListener(delegate
            {
                SelectOneColor(t.isOn,index);
            });
            toggleLst.Add(t);
        }
        toggleLst[2].isOn = true;

        //初始选中红色单色蜡笔
        joinMainView.SelectColor(2, GameManager.instance.ColorList[2]);
    }

    private void SelectOneColor(bool isOn,int index) {
        if (isOn)
        {
            //index：0为七彩笔 1为橡皮擦 2以后为颜色
            joinMainView.SelectColor(index,GameManager.instance.ColorList[index]);
            joinMainView.ShowBackBtn(false);
        }
    }

}
