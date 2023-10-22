using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenSlot : MonoBehaviour
{
    public bool hasOxygen;
    public OxygenManager oxygenManager;
    bool canbeUsed;
    public AudioSource AS;
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "OxygenTank")
        {
            OxygenTank oxygenTank = other.GetComponent<OxygenTank>();
            if (oxygenTank.OxygenLeft > 0)
            {
                hasOxygen = true;
                oxygenManager.CheckOxygen();
                if (canbeUsed)
                {
                    oxygenTank.DepleteOxygen();
                }
            }
            else
            {
                hasOxygen = false;
                oxygenManager.CheckOxygen();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        AS.Play();
    }
    public void ActivateTank()
    {
        canbeUsed= true;
    }
}
