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
    public GameObject parentObject;
    public GameObject prefabToInstantiate;
    public GameObject FuelStation;
    public GameObject Engine;
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
        if (other.transform.tag == "Engine" && holding && !Gotpoints && value > 0)
        {
            value -= 10;
        }
        else if (other.transform.tag == "Engine" && holding && Gotpoints && value<=0)
        {
            ScoreManager.Score = ScoreManager.Score + 60;
            Destroy(Arrow);
        }
    }
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
        }
        if (holding && value <= 0)
        {
            Arrow.GetComponent<GuideArrow>().target = FuelStation.transform;
        }
        else if(value>100)
        {
            Arrow.GetComponent<GuideArrow>().target = Engine.transform;
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
