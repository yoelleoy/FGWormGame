using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCamMovement : MonoBehaviour
{

    public float speed = 0.5f;
    public Vector3 centerPt;
    public float radius = 50f; 

    //Moves map camera and limits its movements to within a circle
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 newPos = transform.position + movement *speed;
        Vector3 offset = newPos - centerPt;
        transform.position = centerPt + Vector3.ClampMagnitude(offset, radius);
    }
}
