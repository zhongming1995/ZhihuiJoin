using System.Collections;
using AudioMgr;
using UnityEngine;
using DG.Tweening;

public class FruitGuide : MonoBehaviour
{
    //操作定义：点击暂停，点击水果，拖动水果
    private int noOperatipnTimeLimit = 5;
    private float operationStartTime;//用于判断无操作的时间
    private bool isOperating;//是否正在操作

    private FruitView fruitView;

    private Coroutine cor_Reminder;

    public Transform tranFruitNumber;

    void Start()
    {
        AddListener();
        cor_Reminder = StartCoroutine("CorReminder");
        fruitView = GetComponent<FruitView>();
    }

    private void OnDestroy()
    {
        RemoveListener();
    }

    void AddListener()
    {
        FruitController.operationStart += OperationStart;
        FruitController.operationEnd += OperationEnd;
    }

    void RemoveListener()
    {
        FruitController.operationStart -= OperationStart;
        FruitController.operationEnd -= OperationEnd;
    }

    IEnumerator CorReminder()
    {
        operationStartTime = 0;
        while (true)
        {
            if (isOperating == false)
            {
                operationStartTime += 0.1f;
                if (operationStartTime > noOperatipnTimeLimit)
                {
                    Debug.Log("做一次提示11111-----------");
                    DoReminder();
                    operationStartTime = 0;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void OperationStart()
    {
        isOperating = true;
        if (cor_Reminder != null)
        {
            StopCoroutine("CorReminder");
        }
        //BreakReminder();
    }

    public void OperationEnd()
    {
        if (cor_Reminder != null)
        {
            StopCoroutine("CorReminder");
            cor_Reminder = StartCoroutine("CorReminder");
        }
        isOperating = false;
        //BreakReminder();
    }

    private void DoReminder()
    {
        Sequence s = DOTween.Sequence();
        s.Append(tranFruitNumber.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 0.25f));
        s.Append(tranFruitNumber.DOScale(new Vector3(1f, 1f, 1f), 0.25f));
        s.SetLoops(3);

        fruitView.Greeting(true);
    }
}
