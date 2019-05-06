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

    public void SetPartType(PartType type)
    {
        partType = type;
    }

    public void Init()
    {
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
            transform.localPosition = new Vector3(oriPos.x + rectTransform.sizeDelta.x / 2, oriPos.y + rectTransform.sizeDelta.y / 2, oriPos.z);
        }
        else if (partType == PartType.RightHand || partType == PartType.RightLeg)
        {
            rectTransform.pivot = new Vector2(0, 1);
            Vector3 oriPos = transform.localPosition;
            transform.localPosition = new Vector3(oriPos.x - rectTransform.sizeDelta.x / 2, oriPos.y + rectTransform.sizeDelta.y / 2, oriPos.z);
        }

        //设置对应的动画
        UpdateAnimationClip();
        //打招呼的动作
        PlayGreeting();
    }

    public void UpdateAnimationClip()
    {
        string clipName = "Animator/Greeting|Greeting_" + partType.ToString();
        animation = GetComponent<Animation>();
        //AnimationClip clip = Resources.Load<AnimationClip>(clipName) as AnimationClip;
        AnimationClip clip = UIHelper.instance.LoadAnimationClip(clipName);
        if (clip!=null)
        {
            animation.AddClip(clip, "greeting");
        }

        /*
         *   用Animator的做法，后来改成Animation     
        animator = GetComponent<Animator>();

        AnimatorOverrideController overrideController = new AnimatorOverrideController();
        overrideController.runtimeAnimatorController = animator.runtimeAnimatorController;
        string clipName = "Animator/Greeting_" + partType.ToString();
        Debug.Log("clipName:" + clipName);
        overrideController[actionName] = Resources.Load<AnimationClip>(clipName) as AnimationClip;
        if (overrideController[actionName] == null)
        {
            Debug.Log("null");
        }
        animator.runtimeAnimatorController = null;
        animator.runtimeAnimatorController = overrideController;
        */

    }

    public void PlayGreeting()
    {
        animation.Play("greeting");
    }
}
