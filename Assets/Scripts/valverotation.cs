using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class valverotation : MonoBehaviour
{
    // Start is called before the first frame update
    public valve valve;

    // Update is called once per frame
    void Update()
    {
        Quaternion newRotation = Quaternion.Euler(valve.xRotation, 90f, 0f); // Assuming you only want to set the X-axis rotation

        // Assign the new rotation to the target object's Transform
        transform.rotation = newRotation;
    }
}
