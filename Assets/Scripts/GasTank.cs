using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasTank : MonoBehaviour
{
    public float value;
    float EngineValue;
    public Slider engineSlider;
    public Slider progressSlider;
    public ParticleSystem fuelVFX;
    bool Gotpoints = false;
    bool filledUP = false;
    public GameObject parentObject;
    public GameObject prefabToInstantiate;
    public GameObject FuelStation;
    public GameObject Engine;
    public AudioSource pouring;
    bool pouringisPlaying;
    GameObject Arrow;
    bool holding = false;
    public Vector3 offset;


    private void Start()
    {
        if (parentObject != null && prefabToInstantiate != null)
        {
            Vector3 playerPosition = parentObject.transform.position;
            Vector3 spawnPosition = playerPosition + offset;
            GameObject newChildObject = Instantiate(prefabToInstantiate, spawnPosition, Quaternion.identity);
            Arrow = newChildObject;
            newChildObject.transform.parent = parentObject.transform;
            Arrow.GetComponent<GuideArrow>().target = transform;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "rightHand")
        {
            holding = true;
        }
        else if (other.transform.tag == "leftHand")
        {
            holding = true;
        }
        else
        {
            holding = false;
        }
        if (other.transform.tag == "Engine" && value > 0)
        {
            if (transform.eulerAngles.z > 225 && transform.eulerAngles.z < 315)
            {
                if (!fuelVFX.isPlaying) fuelVFX.Play();
                FuelUp(-1);
                EngineValue = EngineValue + 1;
                engineSlider.value = EngineValue;
            }
            else
            {
                if (fuelVFX.isPlaying) fuelVFX.Stop();
                if (pouringisPlaying) pouring.Stop();
            }
        }
        else if (other.transform.tag == "Engine" && !Gotpoints && filledUP&& value<=0)
        {
            ScoreManager.Score = ScoreManager.Score + 60;
            Gotpoints= true;
            Destroy(Arrow);
        }
    }
    public void FuelUp(float amount)
    {
        if (value < -.1f) { value = 0; return; }
        if (value > 100.1f) { value = 100; return; }

        value += amount;
        progressSlider.value = value;
        if (!pouringisPlaying)
        {
            pouring.Play();
            pouringisPlaying = true;
        }
    }

    private void FixedUpdate()
    {
        if (value <= 0)
        {
            if (fuelVFX.isPlaying) fuelVFX.Stop();
            if (pouringisPlaying) pouring.Stop();
                return;
        }
        if (value >= 100 && !filledUP)
        {
            filledUP= true;
            if (pouringisPlaying) pouring.Stop();
        }
        if (holding && value <= 0)
        {
            Arrow.GetComponent<GuideArrow>().target = FuelStation.transform;
        }
        else if(value>100)
        {
            Arrow.GetComponent<GuideArrow>().target = Engine.transform;
        }
    }
}
