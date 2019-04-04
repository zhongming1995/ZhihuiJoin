using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScripts : MonoBehaviour
{
    public Texture2D t;
    // Start is called before the first frame update
    void Start()
    {
        Color[] colors = t.GetPixels();
        for (int i = 0; i < colors.Length; i++)
        {
            Debug.Log(colors[i].ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
