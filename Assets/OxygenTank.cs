using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTank : MonoBehaviour
{
    float OxygenLeft = 100.0f;
    float OxygenDecrease = 0.1f;
    public Transform OxygenMeter;
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "OxygenInteractor" && OxygenLeft > 0.0f)
        {
            OxygenLeft = OxygenLeft - OxygenDecrease * Time.deltaTime;
            Debug.Log("Oxygen Left:" + OxygenLeft);
            Vector3 newScale = OxygenMeter.localScale;
            newScale.y = OxygenLeft/33;
            OxygenMeter.localScale = newScale;
        }
    }
}
