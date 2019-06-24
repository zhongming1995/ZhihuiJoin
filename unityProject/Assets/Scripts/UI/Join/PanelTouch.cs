using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelTouch : MonoBehaviour,IPointerDownHandler
{
    JoinMainView joinMainView;
    void Start()
    {
        joinMainView = GetComponentInParent<JoinMainView>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        joinMainView.SetSelectResObj(null);
    }
}
