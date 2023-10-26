using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            repaired= false;
            renderer.material = damagedMaterial;
        }
        if (repaired && newDialogue && interacted)
        {
            newDialogue= false;
            shiphealth.SetHealth(shiphealth.Health = shiphealth.Health+ 10);
            DTtriggered = true;
        }
    }
    public void ApplyDamage()
    {
        hp = 50;
        DTtriggered2= true;
        shiphealth.SetHealth(shiphealth.Health = shiphealth.Health - 10);
    }
}
