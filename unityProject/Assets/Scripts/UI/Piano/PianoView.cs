using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoView : MonoBehaviour
{
    public Transform Keys;

    private int curSpecturmIndex = 0;
    private List<PianoKey> pianoKeys = new List<PianoKey>();
    private List<int> songSpectrums;

    void Start()
    {
        Init();
        ReminderKey();
    }

    void Init()
    {
        //给琴谱赋值
        songSpectrums = PianoSpectrum.LittleStarSpecturms;
        //8个琴键脚本
        for (int i = 0; i < Keys.childCount; i++)
        {
            PianoKey pk = Keys.GetChild(i).GetComponent<PianoKey>();
            pk.Init(i+1);
            pianoKeys.Add(pk);
        }
    }

    public void PlayPiano(int index)
    {
        if (IsCorrectSpectrum(index))
        {
            curSpecturmIndex++;
            ReminderKey();
        }
    }

    private bool IsCorrectSpectrum(int keyIndex)
    {
        Debug.Log("当前提示index:" + curSpecturmIndex+"  琴键："+songSpectrums[curSpecturmIndex]);
        Debug.Log("当前弹奏的琴键：" + keyIndex);
        if (songSpectrums[curSpecturmIndex] == keyIndex)
        {
            Debug.Log("正确========");
            return true;
        }
        return false;
    }

    private void ReminderKey()
    {
        Debug.Log("提示----------"+songSpectrums[curSpecturmIndex]);
    }
}
