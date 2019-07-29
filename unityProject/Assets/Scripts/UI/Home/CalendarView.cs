using DataMgr;
using Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarView : MonoBehaviour
{
    public Button BtnBack;
    public Button BtnDelete;
    public Button BtnDefault;
    public Transform ListContent;

    private List<CalenderItem> personList = new List<CalenderItem>();

    void Start()
    {
        AddBtnListener();
        AddEventListener();
        RefreshList();
        SwitchDelBtn(true);
    }

    private void AddEventListener()
    {
        CalenderController.deleteItemComplete += DeleteItemComplete;
    }

    private void RemoveEventListener()
    {
        CalenderController.deleteItemComplete -= DeleteItemComplete;
    }

    public void RefreshList()
    {
        StartCoroutine(LoadPersonList(CalenderController.instance.GetPersonList()));
    }

    private void AddBtnListener()
    {
        BtnBack.onClick.AddListener(delegate {
            Destroy(gameObject);
        });

        BtnDelete.onClick.AddListener(delegate {
            ShowDeleteBtn(true);
            SwitchDelBtn(false);
        });

        BtnDefault.onClick.AddListener(delegate {
            ShowDeleteBtn(false);
            SwitchDelBtn(true);
        });
    }
    
    IEnumerator LoadPersonList(List<string> pathList)
    {
        Debug.Log(pathList.Count);
        int index = 0;
        while (index < pathList.Count)
        {
            UIHelper.instance.LoadPrefabAsync("Prefabs/calendar|calendar_item", ListContent, Vector3.zero, Vector3.one, false, null, (item) => {
                Debug.Log(pathList[index]);
                PartDataWhole whole = PersonManager.instance.DeserializePerson(pathList[index]);
                item.name = pathList[index];
                CalenderItem calenderItem = item.GetComponent<CalenderItem>();
                calenderItem.Init(pathList[index],whole);
                personList.Add(calenderItem);
                index += 1;
            });
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void ShowDeleteBtn(bool show)
    {
        Debug.Log(personList.Count);
        for (int i = 0; i < personList.Count; i++)
        {
            personList[i].ShowDelete(show);
        }
    }

    public void SwitchDelBtn(bool isDelete)
    {
        BtnDelete.gameObject.SetActive(isDelete);
        BtnDefault.gameObject.SetActive(!isDelete);
    }

    public void DeleteItemComplete(CalenderItem deleteItem)
    {
        if (deleteItem != null)
        {
            personList.Remove(deleteItem);
            DestroyImmediate(deleteItem.gameObject);
        }
    }

    private void OnDestroy()
    {
        RemoveEventListener();
    }
}
