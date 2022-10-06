using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    public float lifetime =0.5f;
    //destroys this gameobject after delay

    void Start()
    {
        Destroy(gameObject, lifetime);
    } 
}
