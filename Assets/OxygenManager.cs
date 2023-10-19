using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenManager : MonoBehaviour
{
    public OxygenSlot OxygenSlot1;
    public OxygenSlot OxygenSlot2;
    public OxygenSlot OxygenSlot3;
    public bool isRunning1 = false;
    public bool isRunning2 = false;
    public bool isRunning3 = false;
    public bool NoOxygen = true;

public void CheckOxygen()
    {
        if (OxygenSlot1.hasOxygen && !isRunning2 && !isRunning3)
        {
            isRunning1 = true;
            OxygenSlot1.ActivateTank();
            NoOxygen= false;
        }
        else if (OxygenSlot2.hasOxygen && !isRunning1 && !isRunning3)
        {
            isRunning2 = true;
            OxygenSlot2.ActivateTank();
            NoOxygen = false;
        }
        else if (OxygenSlot3.hasOxygen && !isRunning1 && !isRunning2)
        {
            isRunning3 = true;
            OxygenSlot3.ActivateTank();
            NoOxygen = false;
        }
        else
        {
            isRunning1 = false;
            isRunning2= false;
            isRunning3 = false;
            NoOxygen = true;
        }
    }
}
