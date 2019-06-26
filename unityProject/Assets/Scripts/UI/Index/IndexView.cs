using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Common.ObjectPool;
using GameMgr;
using AudioMgr;

public class IndexView : MonoBehaviour
{
    public Button BtnPlay;
    public GameObjectPool gamePool;
    public Transform TrainHead;
    public Transform Cloud;
    // Start is called before the first frame update
    void Start()
    {
        PlayButtonAni();
        BtnPlay.onClick.AddListener(delegate
        {
            AudioManager.instance.PlayAudio(EffectAudioType.Option, null);
            //GameManager.instance.SetNextSceneName("home");
            SceneManager.LoadScene("home");
        });

        StartCoroutine(CorGenerateCloud());
    }

    void PlayButtonAni()
    {
        Sequence s = DOTween.Sequence();
        s.Append(BtnPlay.transform.DOScale(new Vector3(0.95f, 0.95f, 1f), 0.2f));
        s.Append(BtnPlay.transform.DOScale(new Vector3(1.1f, 1.1f, 1f), 0.3f));
        s.Append(BtnPlay.transform.DOScale(new Vector3(0.95f, 0.95f, 1f), 0.15f));
        s.Append(BtnPlay.transform.DOScale(new Vector3(1.05f, 1.05f, 1f), 0.2f));
        s.Append(BtnPlay.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f));
        s.Append(BtnPlay.transform.DOScale(new Vector3(1.05f, 1.05f, 1f), 0.6f));
        s.Append(BtnPlay.transform.DOScale(new Vector3(1f, 1f, 1f), 0.25f));
        s.AppendInterval(0.5f);
        s.SetLoops(-1);
    }

    IEnumerator CorGenerateCloud()
    {
        while (true)
        {
            Transform cloud = gamePool.ExitPool().transform;
            InitCloud(cloud);
           

            //Transform cloud = Instantiate(Cloud,Cloud.parent);
            //cloud.gameObject.SetActive(true);
            //cloud.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            //cloud.SetAsFirstSibling();
            yield return new WaitForSeconds(0.7f);
        }
    }

    private void InitCloud(Transform cloud)
    {
        cloud.localPosition = Cloud.localPosition;
        cloud.SetAsFirstSibling();
        Image img = cloud.GetComponent<Image>();
        Color c = img.color;
        img.color = new Color(img.color.r, img.color.g, img.color.b, 255);
        cloud.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        cloud.name = "cloud";

    }

    public void CloudEnterPool(GameObject cloud)
    {
        cloud.gameObject.SetActive(false);
        gamePool.EnterPool(cloud);
    }
}
