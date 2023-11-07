using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fire : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float currentIntensity = 1.0f;

    private float[] startIntensities = new float[0];
    float timeLastWatered = 0;
    [SerializeField] private float regenDelay = 2.5f;
    [SerializeField] private float regenRate = .1f;
    
    [SerializeField] private ParticleSystem [] fireParticleSystems = new ParticleSystem[0];
    public GameObject parentObject;
    public GameObject prefabToInstantiate;
    public bool isLit = true;
    public bool receivedPoints = false;
    public AlarmTrigger alarm;
    GameObject Arrow;
    public Vector3 offset;
    public ShipHealth shiphealth;
    public OxygenManager oxygen;
    public bool inTutorial = false;

    private void Start()
    {

        startIntensities = new float[fireParticleSystems.Length];
        for (int i = 0; i < fireParticleSystems.Length; i++)
        {
            startIntensities[i] = fireParticleSystems[i].emission.rateOverTime.constant;
        }
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

    

    private void Update()
    {
        if (isLit && currentIntensity < 1.0f && Time.time - timeLastWatered >= regenDelay)
        {
            currentIntensity += regenRate* Difficulty.difficulty * Time.deltaTime;
            ChangeIntensity();
        }
        if (isLit)
        {
            alarm.OnFire = true;
            shiphealth.SetHealth(shiphealth.Health = shiphealth.Health - 0.004f * Difficulty.difficulty);
        }
        if (oxygen.NoOxygen && !inTutorial)
        {
            timeLastWatered = Time.time;
            currentIntensity -= 1;
            ChangeIntensity();
        }
    }

    public bool TryExtinguish(float amount)
    {
        timeLastWatered = Time.time;

        currentIntensity -= amount;

        ChangeIntensity();

        if (currentIntensity <= 0)
        {
            isLit = false;
            if (!receivedPoints)
            {
                ScoreManager.Score = ScoreManager.Score + 30;
                Destroy(Arrow);
                receivedPoints = true;
                alarm.OnFire = false;
                gameObject.SetActive(false);
            }
            return true;
        }

        return false; // fire is still lit
    }

    private void ChangeIntensity()
    {
        for (int i = 0; i < fireParticleSystems.Length; i++)
        {
            var emission = fireParticleSystems[i].emission;
            emission.rateOverTime = currentIntensity * startIntensities[i];
        }
    }
}
