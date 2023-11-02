using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityBox : MonoBehaviour
{
    public HingeJoint lever;
    public bool isOn;

    void Update()
    {
        if (lever.angle > 170 && !isOn)
        {
            print("Is on");
            isOn = true;
        }

        if (lever.angle < 10 && isOn)
        {
            print("Is off");
            isOn = false;
        }
    }
}
