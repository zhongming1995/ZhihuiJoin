using DataMgr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalenderItem : MonoBehaviour
{
    public Transform PersonParent;
    public Button BtnDelete;
    public Button BtnDetail;
   
    public void Init(PartDataWhole whole)
    {
        if (whole==null)
        {
            Debug.Log("null===");
        }
        GameObject person = DataManager.instance.GetPersonObj(whole.partDataList);
        Transform personParent = transform.Find("item_mask/person_parent").transform;
        person.transform.SetParent(personParent);

        BtnDetail.onClick.AddListener(delegate {
            Debug.Log("Detail");
        });

        BtnDelete.onClick.AddListener(delegate {
            Debug.Log("Delete");
        });
    }

    
}
