using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IndexView : MonoBehaviour
{
    public Button BtnPlay;
    // Start is called before the first frame update
    void Start()
    {
        PlayButtonAni();
        BtnPlay.onClick.AddListener(delegate
        {
            SceneManager.LoadScene("home");
        });
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
}
