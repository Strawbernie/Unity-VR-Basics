using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideArrow : MonoBehaviour
{
    public Transform target;
    public float speed;

    void Update()
    {
        Quaternion _lookRotation = Quaternion.LookRotation((target.position - transform.position).normalized);
        _lookRotation = new Quaternion(0, _lookRotation.y, 0, _lookRotation.w);

        //over time
        transform.rotation = Quaternion.Lerp(transform.rotation, _lookRotation, Time.deltaTime * speed);

    }
}
