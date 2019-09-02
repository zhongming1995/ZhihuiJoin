using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Helper;
using DG.Tweening;

public class FruitItem : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler,IPointerClickHandler
{
    [HideInInspector]
    public int depthIndex;
    Vector3 offset;
    private Vector3 oriPos;
    private RectTransform rt;
    private Image img_fruit;
    private ParticleSystem ps_Number;
    private Material material;
    private bool canTouch = true;
    private bool isDragging = false;

    private void Awake()
    {
        rt = transform.GetComponent<RectTransform>();
        img_fruit = transform.GetComponent<Image>();
        ps_Number = transform.Find("particle_number").GetComponent<ParticleSystem>();
        material = ps_Number.transform.GetComponent<Renderer>().material;
    }

    //初始化一个水果对象
    public void InitItem(int type,int index)
    {
        oriPos = transform.position;
        //rt = transform.GetComponent<RectTransform>();
        //img_fruit = transform.GetComponent<Image>();
        string path = "Sprite/ui_sp/fruit_sp|fruit_icon_" + type.ToString();
        UIHelper.instance.SetImage(path, img_fruit, true);
        //ps_Number = transform.Find("particle_number").GetComponent<ParticleSystem>();
        //material = ps_Number.transform.GetComponent<Renderer>().material;
        depthIndex = index;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (canTouch)
        {
            isDragging = true;
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, screenPos.z));
            FruitController.instance.OperationStart();
            FruitController.instance.DepthChangeStart(this);
          }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canTouch)
        {
            Vector3 globalMousePos;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, eventData.pressEventCamera, out globalMousePos);
            transform.position = globalMousePos + offset;

            if (FruitController.instance.isFruitInBasketRect(rt))
            {
                Debug.Log("======接触到热区");
                FruitController.instance.OperationEnd();
                canTouch = false;
                isDragging = false;
                FruitController.instance.FruitToBasketBegin(this);
                Vector3 desPos = FruitController.instance.GetFruitDesPos();
                transform.DOMove(desPos, 0.3f).OnComplete(()=> {
                    FruitController.instance.FruitToBasketEnd(this);
                });
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canTouch)
        {
            FruitController.instance.OperationEnd();
            FruitController.instance.DepthChangeEnd(this);
            isDragging = false;
            transform.DOMove(oriPos, 0.3f);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isDragging==false && canTouch)
        {
            canTouch = false;
            FruitController.instance.OperationEnd();
            FruitController.instance.FruitToBasketBegin(this);
            FruitController.instance.DepthChangeStart(this);
            DoLinerPathMove();
        }
    }

    private void DoLinerPathMove()
    {
        Vector3 desPos = FruitController.instance.GetFruitDesPos();//OutQuint
        //transform.DOPath(new Vector3[] { new Vector3(transform.position.x - 1f, transform.position.y + 0.1f, 0), desPos }, 1f, PathType.CatmullRom).SetEase(Ease.OutQuint);
        transform.DOPath(new Vector3 []{new Vector3(transform.position.x-1f,transform.position.y+0.1f,0),desPos},1f,PathType.CatmullRom).SetEase(Ease.OutQuint).OnComplete(()=> {
            //FruitController.instance.FruitToBasketEnd(this);
            FruitController.instance.DepthChangeEnd(this);
        });
        Invoke("InvokeFruitToBasketEnd", 0.7f);
    }

    private void InvokeFruitToBasketEnd()
    {
        FruitController.instance.FruitToBasketEnd(this);
    }

    public void PlayParticle(int number)
    {
        string path = "Sprite/ui_sp/fruit_sp|fruit_number_" + number.ToString();
        material.mainTexture = UIHelper.instance.LoadSprite(path).texture;
        ps_Number.Play();
    }
}
