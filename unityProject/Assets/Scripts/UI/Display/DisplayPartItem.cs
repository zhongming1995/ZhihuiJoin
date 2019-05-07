using Helper;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPartItem : MonoBehaviour
{
    //部位类型
    public PartType partType;
    //private Animator animator;
    private Animation animation;
    private RectTransform rectTransform;
    private string actionName = "Greeting_LeftEye";
    public string Greeting = "Greeting";
    public string Dancing1 = "Dance_1";

    public void SetPartType(PartType type)
    {
        partType = type;
    }

    public void Init()
    {
        animation = GetComponent<Animation>();
        /*
        rectTransform = GetComponent<RectTransform>();

        //修改锚点
        if (partType == PartType.Body || partType == PartType.LeftEye || partType == PartType.RightEye)
        {
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
        }
        else if (partType == PartType.LeftHand || partType==PartType.LeftLeg)
        {
            rectTransform.pivot = new Vector2(1, 1);
            Vector3 oriPos = transform.localPosition;
            RectTransform rectImg = rectTransform.Find("img_item").GetComponent<RectTransform>();
            //rectImg.offsetMin = new Vector2(1, 1);
            //rectImg.offsetMax = new Vector2(1, 1);
            rectImg.pivot = new Vector2(1, 1);
            transform.localPosition = new Vector3(oriPos.x + rectTransform.sizeDelta.x / 2, oriPos.y + rectTransform.sizeDelta.y / 2, oriPos.z);
            //rectImg.transform.localPosition = 
        }
        else if (partType == PartType.RightHand || partType == PartType.RightLeg)
        {
            rectTransform.pivot = new Vector2(0, 1);
            Vector3 oriPos = transform.localPosition;
            transform.localPosition = new Vector3(oriPos.x - rectTransform.sizeDelta.x / 2, oriPos.y + rectTransform.sizeDelta.y / 2, oriPos.z);
        }
        */

        //设置对应的动画
        //AddDanceAnimationClip();
        //打招呼的动作
        PlayDance1();
    }

    public void AddGreetingAnimationClip()
    {
        string clipName = "Animator/Greeting|Greeting_" + partType.ToString();
        animation = GetComponent<Animation>();
        AnimationClip clip = UIHelper.instance.LoadAnimationClip(clipName);
        if (clip!=null)
        {
            animation.AddClip(clip, Greeting);
        }
    }

    public void AddDanceAnimationClip()
    {
        string clipName = "Animator/Dance|Dance_1_" + partType.ToString();
        animation = GetComponent<Animation>();
        AnimationClip clip = UIHelper.instance.LoadAnimationClip(clipName);
        if (clip != null)
        {
            animation.AddClip(clip, Dancing1);
        }
    }

    public void PlayGreeting()
    {
        //string aniName = Greeting + "_" + partType.ToString();
        //if (animation.GetClip(aniName) != null)
        //{
        //    animation.Play(aniName);
        //}
        PlayDance1();
    }

    public void PlayDance1()
    {
        string aniName = Dancing1 + "_" + partType.ToString();
        if (animation.GetClip(aniName)!=null)
        {
            animation.Play(aniName);
        }
    }
}
