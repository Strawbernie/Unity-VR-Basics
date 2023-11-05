using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class DamagedWall : MonoBehaviour
{
    public float hp = 50;
    public float repairRate = 5;
    public bool repaired = false;
    public int changedColor = 0;
    public Material fixedMaterial;
    public Material damagedMaterial;
    private Renderer renderer;
    private bool newDialogue = true;
    private bool interacted = false;
    public bool DTtriggered = false;
    public bool DTtriggered2 = false;
    public ShipHealth shiphealth;
    public GameObject parentObject;
    public GameObject prefabToInstantiate;
    GameObject Arrow;
    public AlarmTrigger alarm;
    public ScoreManager SM;
    public Vector3 offset;
    public bool inTutorial = false;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        //var damagedWallRenderer = gameObject.GetComponent<Renderer>();
        //Color DamagedColor = new Color(255f, 0f, 0f, 105f);
        //Color GettingFixedColor = new Color(255f, 0f, 0f, 105f);
    }  
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "blowtorch")
        {
            hp += repairRate * Time.deltaTime;
            hp = Mathf.Clamp(hp, 0.0f, 100.0f);
            Debug.Log("" + hp);
            interacted = true;
        }
    }

private void Update()
    {
        if (hp >= 100)
        {
            repaired = true;
            renderer.material = fixedMaterial;
        }
        else
        {
            alarm.Explosion = true;
            repaired = false;
            renderer.material = damagedMaterial;
        }
        if (repaired && newDialogue && interacted && DTtriggered2)
        {
            DTtriggered = true;
            newDialogue = false;
            shiphealth.SetHealth(shiphealth.Health = shiphealth.Health+ 10 * Difficulty.difficulty);
            ScoreManager.Score = ScoreManager.Score + 30;
            Destroy(Arrow);
            alarm.Explosion = false;
            if (!inTutorial)
            {
                Destroy(gameObject);
            }
        }

        if (repaired == false) //&& changedColor == 0)
        {
            if (hp >= 60)
            {
                renderer.material.color = new Color32(255, 100, 100, 255);
            }
            if (hp >= 70)
            {
                renderer.material.color = new Color32(255, 150, 150, 255);
            }
            if (hp >= 80)
            {
                renderer.material.color = new Color32(255, 200, 200, 255);
            }
            if (hp >= 90)
            {
                renderer.material.color = new Color32(255, 230, 230, 255);
            }


            //renderer.material.color = new Color32(120, 80, 230, 255);


            //changedColor++;
            //var damagedWallRenderer = gameObject.GetComponent<Renderer>();
            //Color GettingFixedColor = new Color(120f, 0f, 0f, 105f);
            //damagedWallRenderer.material.SetColor("_Color", GettingFixedColor);
            //Debug.Log("updated color");
        }

    }
    public void ApplyDamage()
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
        hp = 50;
        DTtriggered2= true;
        alarm.Explosion = true;
        shiphealth.SetHealth(shiphealth.Health = shiphealth.Health - 10 * Difficulty.difficulty);
    }
}
