using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
   private int bounce = 2;
   public GameObject explosion;
   
    //Makes this object instantiate the explosion prefab after its second collision
    void OnCollisionEnter(Collision other)
    {
        bounce = bounce - 1;
        
        if (bounce <= 0 || (other.gameObject.CompareTag("Death")))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
