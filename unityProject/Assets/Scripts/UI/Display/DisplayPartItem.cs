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


    public void PlayGreeting()
    {
        string aniName = Greeting + "_" + partType.ToString();
        Debug.Log("aniName:" + aniName);
        if (item_animation.GetClip(aniName) != null)
        {
            item_animation.Play(aniName);
        }
    }

    public void PlayDefault()
    {
        string aniName = Default + "_" + partType.ToString();
        if (item_animation.GetClip(aniName) != null)
        {
            item_animation.Play(aniName);
        }
    }

    //跳舞动作 1左抬腿 2翻跟斗 3右抬腿 
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
}
