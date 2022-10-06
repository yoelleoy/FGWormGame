using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeRising : MonoBehaviour
{
    public float timer = 60f;
    //Gets the hinge of the gameobject, and changes its state on a timer
    void Start()
    {
        var hinge = GetComponent<HingeJoint>();
        hinge.useMotor = false;
        InvokeRepeating("BridgeControl", timer, timer);
    }

    //Toggles the state of the hinge to lift and lower bridge
    void BridgeControl()
    {
        var hinge = GetComponent<HingeJoint>();
        if (!Input.GetKey(KeyCode.F))
        {
            if (hinge.useMotor == false)
            {
                hinge.useMotor = true;
            }

            else if (hinge.useMotor == true)
            {
                hinge.useMotor = false;
            }
        }
    }
}

    

