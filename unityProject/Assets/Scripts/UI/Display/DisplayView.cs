using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Helper;
using DataMgr;
using GameMgr;
using System.IO;
using System.Runtime.InteropServices;
using System;

public class DisplayView : MonoBehaviour
{
    public Button BtnHome;
    public Button BtnBack;
    public Button BtnSave;
    public Transform ImgDisplay;
    public Transform PosFlag;

    private JoinMainView joinMainView;
    private Vector2 rectImgDisplay;
    private Vector2 screenPosFlag;
    private string savePath = String.Empty;

    [DllImport("__Internal")]
    private static extern void UnityToIOS_SavePhotoToAlbum(string path);

    void Start()
    {
        rectImgDisplay = ImgDisplay.GetComponent<RectTransform>().sizeDelta;
        joinMainView = GameManager.instance.Root.GetComponentInChildren<JoinMainView>(true);
        AddEvent();
        Display();
        screenPosFlag = Camera.main.WorldToScreenPoint(PosFlag.position);
        Debug.Log(Camera.main.WorldToScreenPoint(PosFlag.position));
    }

    private void AddEvent()
    {
        BtnHome.onClick.AddListener(delegate
        {
            UIHelper.instance.LoadPrefab("prefabs/home|select_item_view", GameManager.instance.Root, Vector3.zero, Vector3.one, true);
            Destroy(gameObject);
            Destroy(joinMainView.gameObject);
        });

        BtnBack.onClick.AddListener(delegate
        {
            Destroy(gameObject);
            joinMainView.gameObject.SetActive(true);
        });
        BtnSave.onClick.AddListener(delegate
        {
            StartCoroutine(CutScreen());
            //DataManager.instance.TransformToPartsList(joinMainView.DrawPanel);
            //DataManager.instance.SerializePersonData();
        });
    }

    public void Display()
    {
        Transform displayItem = (Transform)Instantiate(joinMainView.DrawPanel, ImgDisplay);
        Vector2 vDisplayItem = displayItem.GetComponent<RectTransform>().sizeDelta;
        float rate = rectImgDisplay.x / vDisplayItem.x;
        displayItem.localScale = new Vector3(rate, rate, rate);
    }
    IEnumerator CutScreen()
    {
        Rect rect = new Rect(screenPosFlag.x,Screen.height-screenPosFlag.y+2*ImgDisplay.localPosition.y ,rectImgDisplay.x, rectImgDisplay.y);
        Debug.Log(ImgDisplay.localPosition.y);
        Debug.Log(Screen.height - screenPosFlag.y + 2 * ImgDisplay.localPosition.y);
        //图片大小  
        Texture2D tex = new Texture2D((int)rectImgDisplay.x, (int)rectImgDisplay.y, TextureFormat.RGB24, true);
        yield return new WaitForEndOfFrame();
        tex.ReadPixels(rect, 0, 0, true);
        tex.Apply();
        yield return tex;
        byte[] byt = tex.EncodeToPNG();
        string date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff").Replace(":", "-");
        string photoName = "MyPhoto_" + date + ".png";
        savePath = Application.persistentDataPath + "/" + photoName;
        //File.WriteAllBytes(path +"/"+ photoName, byt);
        FileStream fileStream = File.Open(savePath, FileMode.Create);
        fileStream.BeginWrite(byt, 0, byt.Length, new AsyncCallback(EndWrite), fileStream);
        Debug.Log("保存的沙河地址：------------"+savePath);

    }

    public void EndWrite(IAsyncResult result)
    {
        FileStream fileStream = (FileStream)result.AsyncState;
        fileStream.EndWrite(result);
        Debug.Log("异步完成------------");
        UnityToIOS_SavePhotoToAlbum(savePath);
    }

}
