using Helper;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPartItem : MonoBehaviour
{
    //部位类型
    public PartType partType;
    //private Animator animator;
    private Animation item_animation;
    private RectTransform rectTransform;
    private string actionName = "Greeting_LeftEye";
    public string Greeting = "Greeting";
    public string Dancing1 = "Dance_1";
    public string Default = "Default";

    private void OnEnable()
    {
        Debug.Log("OnEnable");
        if (item_animation == null)
        {
            Debug.Log("animation==null");
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
        //string aniName = Greeting + "_" + partType.ToString();
        //if (animation.GetClip(aniName) != null)
        //{
        //    animation.Play(aniName);
        //}
        PlayDefault();
    }

    public void PlayDance1()
    {
        string aniName = Dancing1 + "_" + partType.ToString();
        if (item_animation == null)
        {
            Debug.Log("null1");
        }
        if (item_animation.GetClip(aniName)!=null)
        {
            if (item_animation.isPlaying)
            {
                item_animation.Stop();
                item_animation.Play(aniName);
            }
            else
            {
                item_animation.Play(aniName);
            }
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
}
