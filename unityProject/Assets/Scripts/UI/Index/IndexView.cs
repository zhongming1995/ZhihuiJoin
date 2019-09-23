using UnityEngine;
using UnityEngine.UI;
using GameMgr;
using AudioMgr;
using System.Runtime.InteropServices;

public class IndexView : MonoBehaviour
{
    public Button BtnLetter;
    public Button BtnNumber;
    public Button BtnAnimal;
    public Button BtnCalendar;
    public Button BtnPersonCenter;
    [DllImport("__Internal")]
    private static extern void UnityToIOS_GoToPersonalCenter();

    void Start()
    {
        if (PanelManager.instance.isEmpty())
        {
            PanelManager.instance.PushPanel(PanelName.IndexView, gameObject);
        }
        AddBtnListener();
    }

    private void OnEnable()
    {
        SetCalendarButton();
        CallManager.instance.UnityToPlayform_PauseTime();
    }

    private void SetCalendarButton()
    {
        int personNum = PersonManager.instance.GetPersonsNum();
        if (personNum > 0)
        {
            BtnCalendar.gameObject.SetActive(true);
        }
        else
        {
            BtnCalendar.gameObject.SetActive(false);
        }
    }

    private void AddBtnListener()
    {
        BtnCalendar.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            PersonManager.instance.CurPersonPageIndex = 0;
            GameManager.instance.SetNextSceneName(SceneName.Calendar);
            TransitionView.instance.OpenTransition();
        });

        BtnPersonCenter.onClick.AddListener(delegate {
            Debug.Log("个人中心~~~~~~~~~~");
            UnityToIOS_GoToPersonalCenter();
        });

        BtnLetter.onClick.AddListener(delegate {
            GameManager.instance.curJoinType = JoinType.Letter;
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            GameManager.instance.SetNextSceneName(SceneName.Home);
            TransitionView.instance.OpenTransition();
        });

        BtnNumber.onClick.AddListener(delegate {
            GameManager.instance.curJoinType = JoinType.Num;
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            GameManager.instance.SetNextSceneName(SceneName.Home);
            TransitionView.instance.OpenTransition();
        });

        BtnAnimal.onClick.AddListener(delegate {
            GameManager.instance.curJoinType = JoinType.Animal;
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            GameManager.instance.SetNextSceneName(SceneName.Home);
            TransitionView.instance.OpenTransition();
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
