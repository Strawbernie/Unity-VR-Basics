using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    public bool OnFire;
    public bool Explosion;
    public AudioSource Alarm;
    bool isPlaying;
    void FixedUpdate()
    {
        if (OnFire)
        {
            if (!isPlaying)
            {
                Alarm.Play();
                isPlaying= true;
            }
        }
        else if (Explosion)
        {
            if (!isPlaying)
            {
                Alarm.Play();
                isPlaying = true;
            }
        }
        else
        {
            Alarm.Stop();
            isPlaying = false;
        }
    }
}
