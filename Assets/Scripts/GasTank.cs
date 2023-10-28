using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasTank : MonoBehaviour
{
    public float value;
    public Slider progressSlider;
    public ParticleSystem fuelVFX;
    bool Gotpoints = false;

    public void FuelUp(float amount)
    {
        if (value < -.1f) { value = 0; return; }
        if (value > 100.1f) { value = 100; return; }

        value += amount;
        progressSlider.value = value;
    }

    private void FixedUpdate()
    {
        if (value <= 0)
        {
            if (fuelVFX.isPlaying) fuelVFX.Stop();
            return;
        }
        if (value >= 100 && !Gotpoints)
        {
            Gotpoints= true;
            ScoreManager.Score = ScoreManager.Score + 60;
        }

        if (transform.eulerAngles.z > 225 && transform.eulerAngles.z < 315)
        {
            if (!fuelVFX.isPlaying) fuelVFX.Play();
            FuelUp(-1);
        }
        else
        {
            if (fuelVFX.isPlaying) fuelVFX.Stop();
        }
    }
}
