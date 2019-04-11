using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Data;

public class DisplayPartItem : MonoBehaviour
{
    //部位类型
    public PartType partType;
    private Animator animator;
    private RectTransform rectTransform;
    private string actionName = "Greeting";

    public void SetPartType(PartType type)
    {
        partType = type;
    }

    public void Init()
    {
        animator = GetComponent<Animator>();
        rectTransform = GetComponent<RectTransform>();

        AnimatorOverrideController overrideController = new AnimatorOverrideController();
        overrideController.runtimeAnimatorController = animator.runtimeAnimatorController;
        string clipName = "Animator/Greeting_" + partType.ToString();
        Debug.Log("clipName:" + clipName);
        overrideController[actionName] = Resources.Load<AnimationClip>(clipName) as AnimationClip;
        animator.runtimeAnimatorController = null;
        animator.runtimeAnimatorController = overrideController;

        //if (partType == PartType.Body || partType == PartType.LeftEye || partType == PartType.RightEye)
        //{
        //    rectTransform.pivot = new Vector2(0.5f, 0.5f);
        //}
        //else if (partType == PartType.LeftHand || partType==PartType.LeftLeg)
        //{
        //    rectTransform.pivot = new Vector2(1, 1);
        //}
        //else if (partType == PartType.RightLeg || partType == PartType.RightLeg)
        //{
        //    rectTransform.pivot = new Vector2(0, 1);
        //}

        PlayGreeting();
    }

    public void PlayGreeting()
    {
        animator.SetBool("isGreeting", true);
    }
}
