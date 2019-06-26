using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using GameMgr;
using AudioMgr;

public class ColorToggleCtrl : MonoBehaviour
{
    private bool isFirstValueChange = true;
    public List<Toggle> toggleLst = new List<Toggle>();
    ToggleGroup tg;
    JoinMainView joinMainView;
    JoinGuide joinGuide;
    // Use this for initialization
    void Start()
    {
        joinMainView = transform.GetComponentInParent<JoinMainView>();
        joinGuide = transform.GetComponentInParent<JoinGuide>();
        tg = transform.GetComponent<ToggleGroup>();
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
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
            //播放音效
            if (isFirstValueChange == false)
            {
                joinGuide.DoOperation();
                AudioManager.instance.PlayAudio(EffectAudioType.Option, "Audio/option_audio/color_option_audio|color_" + index);
            }
            if (isFirstValueChange)
            {
                isFirstValueChange = false;
            }
            //index：0为七彩笔 1为橡皮擦 2以后为颜色
            joinMainView.SelectColor(index,GameManager.instance.ColorList[index]);
            joinMainView.ShowBackBtn(false);
        }
    }

}
