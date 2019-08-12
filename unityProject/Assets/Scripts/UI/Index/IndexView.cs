using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Common.ObjectPool;
using GameMgr;
using AudioMgr;
using Helper;

public class IndexView : MonoBehaviour
{
    public Button BtnLetter;
    public Button BtnNumber;
    public Button BtnAnimal;
    public Button BtnPlay;
    public Button BtnCalendar;
    public GameObjectPool gamePool;
    public Transform TrainHead;
    public Transform Cloud;
    // Start is called before the first frame update
    void Start()
    {
        PanelManager.instance.PushPanel(PanelName.IndexView,gameObject);
        //PlayButtonAni();
        AddBtnListener();
        int personNum = PersonManager.instance.GetPersonsNum();
        if (personNum > 0)
        {
            BtnCalendar.gameObject.SetActive(true);
        }
        else
        {
            BtnCalendar.gameObject.SetActive(false);
        }

        
       // StartCoroutine(CorGenerateCloud());
    }

    private void AddBtnListener()
    {
        BtnCalendar.onClick.AddListener(delegate {
            UIHelper.instance.LoadPrefabAsync("Prefabs/calendar|calendar_view", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true, null, (panel) => {
                PanelManager.instance.PushPanel(PanelName.CalendarView, panel);
            });
        });

        BtnLetter.onClick.AddListener(delegate {
            GameManager.instance.curJoinType = JoinType.Letter;
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            UIHelper.instance.LoadPrefabAsync("Prefabs/home|home_view", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true, null, (panel) =>
            {
                PanelManager.instance.PushPanel(PanelName.HomeView, panel);
            });
        });

        BtnNumber.onClick.AddListener(delegate {
            GameManager.instance.curJoinType = JoinType.Num;
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            UIHelper.instance.LoadPrefabAsync("Prefabs/home|home_view", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true, null, (panel) =>
            {
                PanelManager.instance.PushPanel(PanelName.HomeView, panel);
            });
        });

        BtnAnimal.onClick.AddListener(delegate {
            GameManager.instance.curJoinType = JoinType.Animal;
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            UIHelper.instance.LoadPrefabAsync("Prefabs/home|home_view", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true, null, (panel) =>
            {
                PanelManager.instance.PushPanel(PanelName.HomeView, panel);
            });
        });
    }

    /*
    BtnPlay.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            //GameManager.instance.SetNextSceneName("home");
            //SceneManager.LoadScene("home");
            UIHelper.instance.LoadPrefabAsync("Prefabs/home|home_view", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true, null, (panel) =>
            {
                PanelManager.instance.PushPanel(PanelName.HomeView, panel);
            });
        });
    */

    /*
    void PlayButtonAni()
    {
        Sequence s = DOTween.Sequence();
        s.Append(BtnPlay.transform.DOScale(new Vector3(0.95f, 0.95f, 1f), 0.2f));
        s.Append(BtnPlay.transform.DOScale(new Vector3(1.1f, 1.1f, 1f), 0.3f));
        s.Append(BtnPlay.transform.DOScale(new Vector3(0.95f, 0.95f, 1f), 0.15f));
        s.Append(BtnPlay.transform.DOScale(new Vector3(1.05f, 1.05f, 1f), 0.2f));
        s.Append(BtnPlay.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f));
        s.Append(BtnPlay.transform.DOScale(new Vector3(1.05f, 1.05f, 1f), 0.6f));
        s.Append(BtnPlay.transform.DOScale(new Vector3(1f, 1f, 1f), 0.25f));
        s.AppendInterval(0.5f);
        s.SetLoops(-1);
    }
    */

    /*
    IEnumerator CorGenerateCloud()
    {
        while (true)
        {
            Transform cloud = gamePool.ExitPool().transform;
            InitCloud(cloud);
            yield return new WaitForSeconds(0.7f);
        }
    }
    */

        /*
    private void InitCloud(Transform cloud)
    {
        cloud.localPosition = Cloud.localPosition;
        cloud.SetAsFirstSibling();
        Image img = cloud.GetComponent<Image>();
        Color c = img.color;
        img.color = new Color(img.color.r, img.color.g, img.color.b, 255);
        cloud.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        cloud.name = "cloud";
    }
    */

        /*
    public void CloudEnterPool(GameObject cloud)
    {
        cloud.gameObject.SetActive(false);
        gamePool.EnterPool(cloud);
    }
    */
}
