using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    GameObject lights;

    void Start()
    {
        lights = transform.GetChild(0).gameObject;    
    }

    void Update()
    {
        if (lights.activeInHierarchy) lights.transform.Rotate(Vector3.up, .5f);
    }

    public void Switch() => lights.SetActive(!lights.activeInHierarchy);
}
