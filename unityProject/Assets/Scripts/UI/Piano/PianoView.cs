using System;
using System.Collections.Generic;
using AudioMgr;
using DataMgr;
using GameMgr;
using Helper;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class PianoView : MonoBehaviour
{
    public Transform Keys;
    public Transform PersonParent;
    public Button BtnBack;
    public Button BtnBackCheck;
    public Transform SongAniLeft;
    public Transform SongAniRight;
    public Image ImgSongName;

    private int curSpecturmIndex = 0;//当前弹奏正确的音符的下标
    private List<PianoKey> pianoKeys = new List<PianoKey>();
    private List<Animation> pianoKeyAnimations = new List<Animation>();
    private List<Image> reminders = new List<Image>();
    private List<AudioSource> audioSources = new List<AudioSource>();
    private List<ParticleSystem> particles = new List<ParticleSystem>();
    private List<int> songSpectrums;
    private DisplayPartItem[] lstDisplayItem;
    //private DisplayPartItem[] windowlstDisplayItem;
    private int lastSymbolNum;
    private int lastDanceNum;
    private int songIndex;
    public Animator AniLeft;
    public Animator AniRight;
    private GameObject completeWindow;

    void Start()
    {
        Init();
        ReminderKey();
        AppEntry.instance.SetMultiTouchEnable(true);
    }

    private void OnEnable()
    {
        AudioManager.instance.BgmPause();

        GameOperDelegate.backToEdit += BackToEditFunc;
        GameOperDelegate.pianoBegin += Replay;
        GameOperDelegate.cardBegin += PlayCard;
        GameOperDelegate.fruitBegin += PlayCard;
        GameOperDelegate.gameReplay += Replay;
    }

    private void OnDisable()
    {
        AudioManager.instance.BgmUnPause();

        GameOperDelegate.backToEdit -= BackToEditFunc;
        GameOperDelegate.pianoBegin -= Replay;
        GameOperDelegate.fruitBegin -= PlayCard;
        GameOperDelegate.cardBegin -= PlayCard;
        GameOperDelegate.gameReplay -= Replay;
    }

    void Init()
    {
        //加载小人
        LoadPerson();
        SelectSong();
        //8个琴键脚本,8个琴键提示动画
        for (int i = 0; i < Keys.childCount; i++)
        {
            //琴键
            Transform key = Keys.GetChild(i);
            PianoKey pk = key.GetComponentInChildren<PianoKey>();
            pk.Init(i);
            pianoKeys.Add(pk);
            //Audio
            audioSources.Add(key.GetComponentInChildren<AudioSource>());
            //提示动画
            Animation ani = key.GetComponentInChildren<Animation>(true);
            pianoKeyAnimations.Add(ani);
            //提示物体
            GameObject reminder = key.Find("reminder").gameObject;
            reminder.SetActive(false);
            Image img_reminder = reminder.GetComponent<Image>();
            reminders.Add(img_reminder);
            //粒子特效
            ParticleSystem ps = key.GetComponentInChildren<ParticleSystem>();
            particles.Add(ps);
        }
        //隐藏返回按钮
        ShowBackBtn(false);
        //按钮点击
        AddClickEvent();
    }

    void SelectSong()
    {
        //给琴谱赋值
        songIndex = RandomSongNum();
        songSpectrums = PianoSpectrum.SongsList[songIndex];
        //根据歌曲不同加载不同的动画
        LoadSongAni(songIndex);
        //显示歌曲名称
        SetSongName(songIndex);
    }

    int RandomSongNum()
    { 
        Random rd = new Random();
        int n = songIndex;
        while (n == songIndex)
        {
            n = rd.Next(0, 3);
        }
        return n;
    }

    void LoadSongAni(int index)
    {
        string path = string.Format("Animator/Piano_Ani/Ani_{0}|song_ani_{1}", index, index);
        RuntimeAnimatorController runAni = UIHelper.instance.LoadAnimationController(path);
        AniLeft.runtimeAnimatorController = runAni;
        AniRight.runtimeAnimatorController = runAni;
    }

    void SetSongName(int index)
    {
        string path = "Sprite/ui_sp/piano_sp/song_name|game_music_" + index.ToString();
        UIHelper.instance.SetImage(path, ImgSongName, true);
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

    private int RandowSymbol()
    {
        Random rd = new Random();
        int n = lastSymbolNum;
        while (n == lastSymbolNum)
        {
            n = rd.Next(1,7);
        }
        lastSymbolNum = n;
        return n;
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
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            ShowBackBtn(true);
        });

        BtnBack.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            //暂停游戏
            string path = "Prefabs/game/window|window_pause";
            UIHelper.instance.LoadPrefab(path, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
        });
    }

    void Replay()
    {
        Destroy(completeWindow);
        gameObject.SetActive(false);
        gameObject.SetActive(true);
        SelectSong();
        curSpecturmIndex = 0;
        HideAllReminder();
        ReminderKey();
    }

    void HideAllReminder()
    {
        for (int i = 0; i < reminders.Count; i++)
        {
            reminders[i].gameObject.SetActive(false);
        }
    }

    public void PlayPiano(int index)
    {
        ShowBackBtn(false);
        reminders[index].gameObject.SetActive(false);
        audioSources[index].Play();
        particles[index].Play();
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
        if (songSpectrums[curSpecturmIndex] == key)
        {
            Dance();
            return true;
        }
        return false;
    }

    private void ReminderKey()
    {
        if (curSpecturmIndex >= songSpectrums.Count)
        {
            Invoke("ShowWindow", 0f);
            return;
        }
        int keyIndex = songSpectrums[curSpecturmIndex];
        int n = RandowSymbol();
        string path = string.Format("Sprite/ui_sp/piano_symbols|game_music_symbol{0}_pic@3x", n);
        UIHelper.instance.SetImage(path, reminders[keyIndex - 1], true);
        reminders[keyIndex-1].gameObject.SetActive(true);
        pianoKeyAnimations[keyIndex-1].Play();
    }

    void ShowWindow()
    {
        string path = "Prefabs/game/window|window_complete";
        completeWindow = UIHelper.instance.LoadPrefab(path, GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
    }

    public void Dance()
    {
        Random r = new Random();
        int n = r.Next(1, 5);
        while(n==lastDanceNum)
        {
            n = r.Next(1, 5);
        }
        lastDanceNum = n;
        DataManager.instance.PersonDance(lstDisplayItem, n);
        //星星跳跃
        AniLeft.SetBool("isJump", true);
        AniRight.SetBool("isJump", true);
        //0.5f后让星星回归默认状态（从jump到default动作不打断，从default到jump是打断的）
        Invoke("StarToDefault", 0.5f);
    }

    void StarToDefault()
    {
        AniLeft.SetBool("isJump", false);
        AniRight.SetBool("isJump", false);
    }

    public void BackToEditFunc()
    {
        Destroy(gameObject);
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }

    void PlayCard()
    {
        Destroy(completeWindow);
        Destroy(gameObject);
        //GameManager.instance.SetNextViewPath("Prefabs/game/card|card_view");
        //UIHelper.instance.LoadPrefab("Prefabs/common|transition_prefab_view", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
        //UIHelper.instance.LoadPrefab("Prefabs/game/card|card_view", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
    }

    void OnDestroy()
    {
        AppEntry.instance.SetMultiTouchEnable(false);
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
