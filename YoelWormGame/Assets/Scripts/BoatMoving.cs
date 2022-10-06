using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMoving : MonoBehaviour
{
    public float speed = 1f;
   
    //Spins this gameobject over time so that its children move in a circle, making the boats circle the map
    void Update()
    {
        if (!Input.GetKey(KeyCode.F))
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
    }
}
