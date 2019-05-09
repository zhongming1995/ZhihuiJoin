using System.Collections;
using System.Collections.Generic;
using AudioMgr;
using DataMgr;
using Helper;
using UnityEngine;

public class PianoView : MonoBehaviour
{
    public Transform Keys;
    public Transform PersonParent;
    public Transform Audio;

    private int curSpecturmIndex = 0;//当前弹奏正确的音符的下标
    private List<PianoKey> pianoKeys = new List<PianoKey>();
    private AudioSource[] audioSources;
    private List<int> songSpectrums;
    private Dictionary<string, AudioClip> audioDic = new Dictionary<string, AudioClip>();//音符音频库


    void Start()
    {
        Init();
        ReminderKey();
    }

    void Init()
    {
        //加载小人
        LoadPerson();
        //给琴谱赋值
        songSpectrums = PianoSpectrum.FindFriendSpecturms;
        //8个琴键脚本
        for (int i = 0; i < Keys.childCount; i++)
        {
            PianoKey pk = Keys.GetChild(i).GetComponent<PianoKey>();
            pk.Init(i);
            pianoKeys.Add(pk);
        }
        //8个AudioSource
        audioSources = Audio.GetComponentsInChildren<AudioSource>();
    }

    private void LoadPerson()
    {
        GameObject person = null;
        if (DataManager.instance.partDataList != null)
        {
            person = DataManager.instance.GetPersonObj(DataManager.instance.partDataList);
        }
        person.transform.SetParent(PersonParent);
        person.transform.localScale = new Vector3(0.83f, 0.83f, 0.83f);
        person.transform.localPosition = Vector3.zero;
    }

    public void PlayPiano(int index)
    {
        string path = "Audio/piano|" + (index+1).ToString();
        //AudioManager.instance.PlayPiano(path);
        //if (IsCorrectSpectrum(index))
        //{
        //    curSpecturmIndex++;
        //    ReminderKey();
        //}
        

        if (string.IsNullOrEmpty(path))
        {
            return;
        }
        AudioClip clip;
        if (audioDic.ContainsKey(path))
        {
            clip = audioDic[path];
        }
        else
        {
            clip = UIHelper.instance.LoadAudioClip(path);
            audioDic.Add(path, clip);
        }
        if (clip == null)
        {
            Debug.LogWarning("play piano:audio clip is null-----");
            return;
        }
        audioSources[index].clip = clip;
        audioSources[index].Play();
        if (IsCorrectSpectrum(index))
        {
            curSpecturmIndex++;
            ReminderKey();
        }
    }

    private bool IsCorrectSpectrum(int keyIndex)
    {
        int key = keyIndex + 1;
        if (curSpecturmIndex>=songSpectrums.Count)
        {
            return false;
        }
        Debug.Log("当前提示index:" + curSpecturmIndex+"  琴键："+songSpectrums[curSpecturmIndex]);
        Debug.Log("当前弹奏的琴键：" + key);
        if (songSpectrums[curSpecturmIndex] == key)
        {
            Debug.Log("正确========");
            DataManager.instance.PersonDance1();
            return true;
        }
        return false;
    }

    private void ReminderKey()
    {
        if (curSpecturmIndex >= songSpectrums.Count)
        {
            return;
        }
        Debug.Log("提示----------"+songSpectrums[curSpecturmIndex]);
    }


}
