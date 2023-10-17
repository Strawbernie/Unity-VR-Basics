using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class valve : MonoBehaviour
{
    public float xRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eulerAngles = transform.eulerAngles; Quaternion currentRotation = transform.rotation;
        // Perform operations with the rotation
        xRotation = eulerAngles.x;
    }
}
