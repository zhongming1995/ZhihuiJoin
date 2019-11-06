using UnityEngine;
using UnityEngine.UI;
using GameMgr;
using AudioMgr;
using System.Runtime.InteropServices;
using Helper;

public class IndexView : MonoBehaviour
{
    public ButtonScaleAni BtnLetter;
    public ButtonScaleAni BtnNumber;
    public ButtonScaleAni BtnAnimal;
    public ButtonScaleAni BtnCalendar;
    public ButtonScaleAni BtnPersonCenter;
    public Transform TransLand;
    public Transform TransSky;

    void Start()
    {
        AddBtnListener();
        InitLandWidth();
    }

    private void OnEnable()
    {
        SetCalendarButton();
        CallManager.instance.UnityToPlayform_PauseTime();
    }

    private void InitLandWidth()
    {
        Vector2 realScreen = UIHelper.instance.GetRealScreen();
        for (int i = 0; i < TransLand.childCount; i++)
        {
            TransLand.GetChild(i).GetComponent<RectTransform>().sizeDelta = new Vector2(realScreen.x, TransLand.GetChild(i).GetComponent<RectTransform>().sizeDelta.y);
            TransSky.GetChild(i).GetComponent<RectTransform>().sizeDelta = new Vector2(realScreen.x, TransLand.GetChild(i).GetComponent<RectTransform>().sizeDelta.y);
        }
    }

    private void SetCalendarButton()
    {
        int personNum = PersonManager.instance.OnlyGetPersonNum();
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
        BtnPersonCenter.buttonClickEvent += PersonCenterClick;
        BtnLetter.buttonClickEvent += LetterClick;
        BtnNumber.buttonClickEvent += NumberClick;
        BtnAnimal.buttonClickEvent += AnimalClick;
        BtnCalendar.buttonClickEvent += CalenderClick;
    }

    private void PersonCenterClick()
    {
        CallManager.instance.UnityToPlatform_GoToPersonalCenter();
    }

    private void LetterClick()
    {
        GameManager.instance.curJoinType = JoinType.Letter; 
        GameManager.instance.SetNextSceneName(SceneName.Home);
        TransitionView.instance.OpenTransition();
    }

    private void NumberClick()
    {
        GameManager.instance.curJoinType = JoinType.Num;
        GameManager.instance.SetNextSceneName(SceneName.Home);
        TransitionView.instance.OpenTransition();
    }

    private void AnimalClick()
    {
        GameManager.instance.curJoinType = JoinType.Animal;
        GameManager.instance.SetNextSceneName(SceneName.Home);
        TransitionView.instance.OpenTransition();
    }

    private void CalenderClick()
    {
        PersonManager.instance.CurPersonPageIndex = 0;//从首页进来每次都是第一页
        GameManager.instance.CalendarDetailShow = false;//从首页进来是不打开某个详情页的
        GameManager.instance.SetNextSceneName(SceneName.Calendar);
        TransitionView.instance.OpenTransition();
    }

    private void OnDestroy()
    {
        BtnLetter.buttonClickEvent -= LetterClick;
        BtnNumber.buttonClickEvent -= NumberClick;
        BtnAnimal.buttonClickEvent -= AnimalClick;
    }

    private void Update()
    {
        TransLand.transform.Translate(Vector3.right * Time.deltaTime *0.4f);
        TransSky.transform.Translate(Vector3.right * Time.deltaTime * 0.1f);
        if (TransLand.transform.localPosition.x>0)
        {
            TransLand.GetChild(2).SetAsFirstSibling();
            TransLand.localPosition -= new Vector3(UIHelper.instance.GetRealScreen().x, 0, 0);
        }
        if (TransSky.transform.localPosition.x>0)
        {
            TransSky.GetChild(2).SetAsFirstSibling();
            TransSky.localPosition -= new Vector3(UIHelper.instance.GetRealScreen().x, 0, 0);
        }
    }

}
