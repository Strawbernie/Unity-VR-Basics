using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AlarmTrigger AT;
    bool emergencymusic = false;
    bool normalmusic = false;
    public AudioSource emergency;
    public AudioSource normal;

    // Update is called once per frame
    void Update()
    {
        if (AT.OnFire)
        {
            if(!emergencymusic)
            {
                emergencymusic = true;
                normalmusic = false;
                emergency.Play();
                normal.Stop();
            }
        }
        else if (AT.Explosion)
        {
            if (!emergencymusic)
            {
                emergencymusic = true;
                normalmusic = false;
                emergency.Play();
                normal.Stop();
            }
        }
        else
        {
            if (!normalmusic)
            {
                normalmusic = true;
                emergencymusic = false;
                emergency.Stop();
                normal.Play();
            }
        }
    }
}
