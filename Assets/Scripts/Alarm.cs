using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public float speed;
    GameObject lights;

    void Start()
    {
        lights = transform.GetChild(0).gameObject;    
    }

    void FixedUpdate()
    {
        if (lights.activeInHierarchy) lights.transform.Rotate(Vector3.up, speed);
    }

    public void Switch() => lights.SetActive(!lights.activeInHierarchy);
}
