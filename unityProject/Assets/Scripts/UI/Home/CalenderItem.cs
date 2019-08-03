using DataMgr;
using GameMgr;
using Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalenderItem : MonoBehaviour
{
    public Transform PersonParent;
    public Button BtnDelete;
    public Button BtnDetail;
    public GameObject MaskDelete;

    private PartDataWhole curWhole;
    private string fileName;
    private int index;

    public void Init(int _index,string _fileName, PartDataWhole whole)
    {
        index = _index;
        fileName = _fileName;
        if (whole==null)
        {
            Debug.Log("null===");
        }
        curWhole = whole;

        //初始化显示
        GameObject person = DataManager.instance.GetPersonObj(whole.partDataList);
        Transform personParent = transform.Find("item_mask/person_parent").transform;
        person.transform.SetParent(personParent);
        person.transform.localPosition = Vector3.zero;
        person.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

        //默认隐藏删除按钮
        MaskDelete.SetActive(false);

        //按钮点击
        BtnDetail.onClick.AddListener(delegate {
            /*
            Debug.Log("fileName:" + fileName);
            GameManager.instance.homeSelectIndex = whole.ModelIndex;
            GameManager.instance.SetOpenType(OpenType.ReEdit);
            GameManager.instance.SetCurPartDataWhole(whole);
            PersonManager.instance.PersonFileName = fileName;
            GameManager.instance.JumpToJoin();
            */
            PersonManager.instance.CurPersonIndex = index;
            UIHelper.instance.LoadPrefab("Prefabs/calendar|calendar_detail_view", GameManager.instance.GetCanvas().transform, Vector3.zero, Vector3.one, true);
        });

        BtnDelete.onClick.AddListener(delegate {
            bool isDelete = PersonManager.instance.DeletePerson(fileName);
            if (isDelete)
            {
                CalenderController.instance.DeleteComplete(this);
            }
        });
    }

    public void ShowDelete(bool show)
    {
        MaskDelete.SetActive(show);
    }
    
}
