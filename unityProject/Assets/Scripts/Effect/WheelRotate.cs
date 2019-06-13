using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WheelRotate : MonoBehaviour
{
    public float RotateSpeed = 1.5f;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * RotateSpeed, Space.World);
    }
}
