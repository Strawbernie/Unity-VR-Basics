using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenManager : MonoBehaviour
{
    public OxygenSlot OxygenSlot1;
    public OxygenSlot OxygenSlot2;
    public OxygenSlot OxygenSlot3;
    public bool isRunning1 = false;
    public bool isRunning2 = false;
    public bool isRunning3 = false;
    public bool NoOxygen = true;
    public AudioSource AS;
    bool isplayingAudio = false;
    public GameObject parentObject;
    public GameObject prefabToInstantiate;
    public GameObject mainFrame;
    GameObject Arrow;
    public Vector3 offset;
    bool arrowActive = false;

    private void Start()
    {
        CheckOxygen();
    }
    public void CheckOxygen()
    {
        if (OxygenSlot1.hasOxygen && !isRunning2 && !isRunning3)
        {
            isRunning1 = true;
            OxygenSlot1.ActivateTank();
            NoOxygen= false;
            if (!isplayingAudio) 
            { 
                AS.Play(); 
                isplayingAudio= true;
            }
            
        }
        else if (OxygenSlot2.hasOxygen && !isRunning1 && !isRunning3)
        {
            isRunning2 = true;
            OxygenSlot2.ActivateTank();
            NoOxygen = false;
            if (!isplayingAudio)
            {
                AS.Play();
                isplayingAudio = true;
            }
        }
        else if (OxygenSlot3.hasOxygen && !isRunning1 && !isRunning2)
        {
            isRunning3 = true;
            OxygenSlot3.ActivateTank();
            NoOxygen = false;
            if (!isplayingAudio)
            {
                AS.Play();
                isplayingAudio = true;
            }
        }
        else
        {
            isRunning1 = false;
            isRunning2= false;
            isRunning3 = false;
            NoOxygen = true;
            AS.Stop();
            isplayingAudio= false;
        }
        if (NoOxygen)
        {
            if (parentObject != null && prefabToInstantiate != null &&!arrowActive)
            {
                Vector3 playerPosition = parentObject.transform.position;
                Vector3 spawnPosition = playerPosition + offset;
                GameObject newChildObject = Instantiate(prefabToInstantiate, spawnPosition, Quaternion.identity);
                Arrow = newChildObject;
                newChildObject.transform.parent = parentObject.transform;
                Arrow.GetComponent<GuideArrow>().target = mainFrame.transform;
                arrowActive= true;
            }
        }
        else if (!NoOxygen)
        {
            Destroy(Arrow);
            arrowActive = false;
        }
    }
}
