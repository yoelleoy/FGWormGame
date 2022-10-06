using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBobbing : MonoBehaviour
{
    public float speed = 0.7f;
    Vector3 pointA;
    Vector3 pointB;
    public float maxY =3.5f;
    public float minY =1.25f;

    //Sets the two points for this gameobject to move between
    void Start()
    {
        pointA = new Vector3(transform.position.x, minY, transform.position.z);
        pointB = new Vector3(transform.position.x, maxY, transform.position.z);
    }

   //Moves gameobject between the two points at a certain speed, to make the arrow bob up and down
    void Update()
    {
    float time = Mathf.PingPong(Time.time * speed, 1);
    transform.position = Vector3.Lerp(pointA, pointB, time);
    }


}
 