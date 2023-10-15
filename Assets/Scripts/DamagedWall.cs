using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedWall : MonoBehaviour
{
    public float hp = 50;
    public float repairRate = 5;
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "blowtorch")
        {
            hp += repairRate * Time.deltaTime;
            hp = Mathf.Clamp(hp, 0.0f, 100.0f);
            Debug.Log("" + hp);
        }
    }
}
