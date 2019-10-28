using UnityEngine;

public class CalenderController : SingletonMono<CalenderController>
{
    public delegate void DeleteItemComplete(CalenderItem item);
    public static event DeleteItemComplete deleteItemComplete;

    public delegate void ChooseOneItem(CalenderItem item);
    public static event ChooseOneItem chooseOneItem;

    public int SelectItemId { get; set; }//人物总数
    public float PerPageWidth{get;set; }
    public float PerPageHeight{get; set; }
    public bool IsDelete;//处于删除状态
    public bool IsScrolling;//正在滑动中
    public bool HasDelete;//删除过元素
    public int ContentPosX;//定位x

    private void Awake()
    {
        instance = this;
        PersonManager.instance.GetPersonsList();
    }

    public void DeleteComplete(CalenderItem item)
    {
        int lastPageCount = PersonManager.instance.PageCount;
        PersonManager.instance.DeletePerson(item.FileName);
        PersonManager.instance.PersonPathList.Remove(item.FileName);
        PersonManager.instance.PersonCount--;
        int curPageCount = PersonManager.instance.OnlyGetPageNum(PersonManager.instance.PersonCount);
        if (deleteItemComplete != null)
        {
            deleteItemComplete(item);
        }
    }

    public void ItemChoosed(CalenderItem item)
    {
        if (chooseOneItem!=null)
        {
            chooseOneItem(item);
        }
    }
}