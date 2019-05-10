using System.Collections;
using System.Collections.Generic;
using AudioMgr;
using DataMgr;
using Helper;
using UnityEngine;
using UnityEngine.UI;

public class PianoView : MonoBehaviour
{
    public Transform Keys;
    public Transform PersonParent;
    public Transform Audio;
    public Button BtnBack;
    public Button BtnBackCheck;

    private int curSpecturmIndex = 0;//当前弹奏正确的音符的下标
    private List<PianoKey> pianoKeys = new List<PianoKey>();
    private List<Animation> pianoKeyAnimations = new List<Animation>();
    private List<GameObject> reminders = new List<GameObject>();
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
        songSpectrums = PianoSpectrum.LittleStarSpecturms;
        //8个琴键脚本,8个琴键提示动画
        for (int i = 0; i < Keys.childCount; i++)
        {
            Transform key = Keys.GetChild(i);
            PianoKey pk = key.GetComponentInChildren<PianoKey>();
            pk.Init(i);
            pianoKeys.Add(pk);

            Animation ani = key.GetComponentInChildren<Animation>();
            pianoKeyAnimations.Add(ani);

            GameObject reminder = ani.transform.Find("reminder").gameObject;
            reminder.SetActive(false);
            reminders.Add(reminder);
        }

        //8个AudioSource
        audioSources = Audio.GetComponentsInChildren<AudioSource>();
        //隐藏返回按钮
        ShowBackBtn(false);
        //按钮点击
        AddClickEvent();
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

    //显示返回按钮，否则是半透明状态
    public void ShowBackBtn(bool show)
    {
        BtnBack.gameObject.SetActive(show);
        BtnBackCheck.gameObject.SetActive(!show);
    }

    //按钮点击事件
    private void AddClickEvent()
    {
        BtnBackCheck.onClick.AddListener(delegate
        {
            ShowBackBtn(true);
        });

        BtnBack.onClick.AddListener(delegate
        {
            DisplayView view = transform.parent.GetComponentInChildren<DisplayView>(true);
            view.gameObject.SetActive(true);
            Destroy(gameObject);
            Resources.UnloadUnusedAssets();
            System.GC.Collect();
        });
    }

    public void PlayPiano(int index)
    {
        string path = "Audio/piano|" + (index+1).ToString();
        ShowBackBtn(false);
        reminders[index].SetActive(false);
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
        int keyIndex = songSpectrums[curSpecturmIndex];
        Debug.Log("提示----------" + keyIndex);
        reminders[keyIndex-1].SetActive(true);
        pianoKeyAnimations[keyIndex-1].Play();
    }

}
