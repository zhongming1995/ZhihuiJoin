using Helper;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPartItem : MonoBehaviour
{
    //部位类型
    public PartType partType;
    //private Animator animator;
    public Animation item_animation;
    private RectTransform rectTransform;
    private string actionName = "Greeting_LeftEye";
    public string Greeting = "Greeting";
    public string Dance = "Dance_";
    public string Default = "Default";
    public string Breathe = "Breathe";

    private void OnEnable()
    {
        if (item_animation == null)
        {
            item_animation = GetComponent<Animation>();
        }
    }

    public void SetPartType(PartType type)
    {
        partType = type;
    }

    public void Init()
    {
        item_animation = GetComponent<Animation>();
    }


    public float PlayGreeting()
    {
        float aniTime = 0;
        string aniName = Greeting + "_" + partType.ToString();
        AnimationClip clip = item_animation.GetClip(aniName);
        if ( clip != null)
        {
            aniTime = clip.length;
            item_animation.Play(aniName);
        }
        return aniTime;
    }

    public void PlayDefault()
    {
        string aniName = Default + "_" + partType.ToString();
        if (item_animation.GetClip(aniName) != null)
        {
            item_animation.Play(aniName);
        }
    }

    //跳舞动作 1跳起来双手挥舞双脚打开 2翻跟斗 3右抬腿 4左抬腿
    public void PlayDance(int index)
    {
        string aniName = Dance + index.ToString() + "_" + partType.ToString();
        if (item_animation.GetClip(aniName) != null)
        {
            if (item_animation.isPlaying)
            {
                return;
            }
            else
            {
                item_animation.Play(aniName);
            }
        }
    }

    //就是跳舞动作 1跳起来双手挥舞双脚打开
    public void PlayJumpAndWave()
    {
        string aniName = Dance + "1_" + partType.ToString();
        if (item_animation.GetClip(aniName) != null)
        {
            item_animation.Play(aniName);
        }
    }

    //呼吸动作
    public void PlayBreathe()
    {
        string aniName = Breathe + "_" + partType.ToString();
        if (item_animation.GetClip(aniName) != null)
        {
            item_animation.Play(aniName);
        }
    }
}
