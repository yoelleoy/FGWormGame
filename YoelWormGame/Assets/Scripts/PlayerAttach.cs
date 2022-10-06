using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttach : MonoBehaviour
{
    //If player touches this objects collider, become its parent so that they move together
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            other.transform.parent = transform;
        }
    }

    //If player moves out of this objects collider, unparent from it so they move separately again 
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
