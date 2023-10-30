using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DamagedWall : MonoBehaviour
{
    public float hp = 50;
    public float repairRate = 5;
    public bool repaired = false;
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
    private void Start()
    {
        renderer = GetComponent<Renderer>();
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
            newDialogue= false;
            shiphealth.SetHealth(shiphealth.Health = shiphealth.Health+ 10 * Difficulty.difficulty);
            ScoreManager.Score = ScoreManager.Score + 30;
            Destroy(Arrow);
            DTtriggered = true;
            alarm.Explosion = false;
        }
    }
    public void ApplyDamage()
    {
        if (parentObject != null && prefabToInstantiate != null)
        {
            GameObject newChildObject = Instantiate(prefabToInstantiate);
            newChildObject.transform.parent = parentObject.transform;
            Arrow = newChildObject;
            Arrow.GetComponent<GuideArrow>().target = transform;
        }
        hp = 50;
        DTtriggered2= true;
        alarm.Explosion = true;
        shiphealth.SetHealth(shiphealth.Health = shiphealth.Health - 10 * Difficulty.difficulty);
    }
}
