using System;
using System.Collections.Generic;
using DataMgr;
using UnityEngine;
using UnityEngine.UI;

public class PianoView : MonoBehaviour
{
    public Transform Keys;
    public Transform PersonParent;
    public Transform Audio;
    public Button BtnBack;
    public Button BtnBackCheck;
    public Transform ResultWindow;
    public Button RBtnHome;
    public Button RBtnEdit;
    public Button RBtnReplay;

    private int curSpecturmIndex = 0;//当前弹奏正确的音符的下标
    private List<PianoKey> pianoKeys = new List<PianoKey>();
    private List<Animation> pianoKeyAnimations = new List<Animation>();
    private List<GameObject> reminders = new List<GameObject>();
    private List<AudioSource> audioSources = new List<AudioSource>();
    private List<int> songSpectrums;
    private DisplayPartItem[] lstDisplayItem;
    private DisplayPartItem[] windowlstDisplayItem;

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
            //琴键
            Transform key = Keys.GetChild(i);
            PianoKey pk = key.GetComponentInChildren<PianoKey>();
            pk.Init(i);
            pianoKeys.Add(pk);
            //Audio
            if (key==null)
            {
                Debug.Log("null1");
            }
            if (audioSources==null)
            {
                Debug.Log("null2");
            }
            audioSources.Add(key.GetComponentInChildren<AudioSource>());
            //提示动画
            Animation ani = key.GetComponentInChildren<Animation>();
            pianoKeyAnimations.Add(ani);
            //提示物体
            GameObject reminder = ani.transform.Find("reminder").gameObject;
            reminder.SetActive(false);
            reminders.Add(reminder);
        }
        //隐藏返回按钮
        ShowBackBtn(false);
        //按钮点击
        AddClickEvent();
        //隐藏结果弹窗
        ResultWindow.gameObject.SetActive(false);
        //结果弹窗上添加小人
        LoadWindowPerson();
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

        lstDisplayItem = DataManager.instance.GetListDiaplayItem(person.transform);
    }

    private void LoadWindowPerson()
    {
        GameObject person = null;
        if (DataManager.instance.partDataList != null)
        {
            person = DataManager.instance.GetPersonObj(DataManager.instance.partDataList);
        }
        person.transform.SetParent(ResultWindow);
        person.transform.localScale = new Vector3(0.83f, 0.83f, 0.83f);
        person.transform.localPosition = Vector3.zero;

        windowlstDisplayItem = DataManager.instance.GetListDiaplayItem(person.transform);
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
            gameObject.SetActive(false);
            Destroy(gameObject);
            Resources.UnloadUnusedAssets();
            GC.Collect();
        });

        RBtnHome.onClick.AddListener(delegate
        {
            Debug.Log("Home");
        });

        RBtnEdit.onClick.AddListener(delegate
        {
            Debug.Log("edit");
        });

        RBtnReplay.onClick.AddListener(delegate
        {
            Debug.Log("replay");
            ResultWindow.gameObject.SetActive(false);
            Replay();
        });
    }

    void Replay()
    {
        curSpecturmIndex = 0;
        ReminderKey();
    }

    public void PlayPiano(int index)
    {
        ShowBackBtn(false);
        reminders[index].SetActive(false);
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
            DataManager.instance.PersonDance1(lstDisplayItem);
            return true;
        }
        return false;
    }

    private void ReminderKey()
    {
        if (curSpecturmIndex >= songSpectrums.Count)
        {
            Debug.Log("弹奏完成---------");
            ResultWindow.gameObject.SetActive(true);
            return;
        }
        int keyIndex = songSpectrums[curSpecturmIndex];
        Debug.Log("提示----------" + keyIndex);
        reminders[keyIndex-1].SetActive(true);
        pianoKeyAnimations[keyIndex-1].Play();
    }

}
