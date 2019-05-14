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
        Debug.Log("Play------");
        string aniName = Greeting + "_" + partType.ToString();
        Debug.Log("aniName:"+aniName);
        if (item_animation.GetClip(aniName) != null)
        {
            Debug.Log("zhen play-----");
            item_animation.Play(aniName);
        }
    }

    public void PlayDance1()
    {
        string aniName = Dancing1 + "_" + partType.ToString();
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
