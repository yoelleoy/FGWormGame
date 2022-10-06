using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalAim : MonoBehaviour
{
    float verticalSpeed = -2.0f;
    //Move gun joint up and down
    void Update()
    {
        if (!Input.GetKey(KeyCode.F))
        {
            float v = verticalSpeed * Input.GetAxis("Mouse Y");
            transform.Rotate(v, 0, 0);
        }
    }
}
