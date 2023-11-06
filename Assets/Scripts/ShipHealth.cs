using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShipHealth : MonoBehaviour
{
    public float Health;
    public Slider slider;
    public Slider WristSlider;
    public Slider OxygenWristSlider;

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }
    public void SetHealth(float Health)
    {
        slider.value = Health;
        WristSlider.value = Health;
    }

    public void SetOxygen(float Oxygen)
    {
        slider.value = Oxygen;
    }
}
