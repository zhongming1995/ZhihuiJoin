using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderExt : MonoBehaviour
{
    public Image FillImage;

    private Slider slider;

    void Start()
    {
        slider = transform.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        FillImage.fillAmount = slider.value;
    }
}
