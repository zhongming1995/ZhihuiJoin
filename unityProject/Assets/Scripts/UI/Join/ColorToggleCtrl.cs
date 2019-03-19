using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ColorToggleCtrl : MonoBehaviour
{
    public List<Toggle> toggleLst = new List<Toggle>();
    ToggleGroup tg;
    JoinMainView joinMainView;
    // Use this for initialization
    void Start()
    {
        joinMainView = transform.GetComponentInParent<JoinMainView>();
        tg = transform.GetComponent<ToggleGroup>();
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
            int index = i;
            Toggle t = transform.GetChild(i).GetComponent<Toggle>();
            t.group = tg;
            if (i == 0)
            {

                t.isOn = true;
            }
            else
            {
                t.isOn = false;
            }
            t.onValueChanged.AddListener(delegate
            {
                SelectOneColor(t.isOn,index);
            });
            toggleLst.Add(t);
        }
    }

    private void SelectOneColor(bool isOn,int index) {
        if (isOn)
        {
            Debug.Log(index);
            joinMainView.ShowBackBtn(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
