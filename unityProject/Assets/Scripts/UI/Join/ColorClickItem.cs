using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ColorClickItem : MonoBehaviour, IPointerClickHandler
{
    int index = 0;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(transform.GetSiblingIndex());
    }

    void Start()
    {
        index = transform.GetSiblingIndex();
        if (index == 0)
        {
           ShowSelectState(true);
        }
        else
        {
            ShowSelectState(false);
        }
    }

    private void ShowSelectState(bool show)
    {
        transform.GetChild(0).gameObject.SetActive(!show);
        transform.GetChild(1).gameObject.SetActive(show);
    }
}
