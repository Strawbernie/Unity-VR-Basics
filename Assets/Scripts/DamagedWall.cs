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
            renderer.material = damagedMaterial;
        }
    }
    public void ApplyDamage()
    {
        hp = 50;
    }
}
