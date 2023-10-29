using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public float speed;
    GameObject lights;
    public AlarmTrigger AT;

    void Start()
    {
        lights = transform.GetChild(0).gameObject;    
    }

    void FixedUpdate()
    {
        if(AT.OnFire)
        {
            lights.SetActive(true);
        }
        else if (AT.Explosion)
        {
            lights.SetActive(true);
        }
        else
        {
            lights.SetActive(false);
        }
        if (lights.activeInHierarchy) lights.transform.Rotate(Vector3.up, speed);
    }

    public void Switch() => lights.SetActive(!lights.activeInHierarchy);
}
