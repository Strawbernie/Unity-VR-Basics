using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTank : MonoBehaviour
{
    public float OxygenLeft = 100.0f;
    float OxygenDecrease = 0.1f;
    public Transform OxygenMeter;
    public bool isEmpty;
    public void DepleteOxygen()
    {
        if (OxygenLeft > 0.0f)
        {
            OxygenLeft = OxygenLeft - OxygenDecrease * Time.deltaTime;
            Debug.Log("Oxygen Left:" + OxygenLeft);
            Vector3 newScale = OxygenMeter.localScale;
            newScale.y = OxygenLeft/33;
            OxygenMeter.localScale = newScale;
        }
    }
}
