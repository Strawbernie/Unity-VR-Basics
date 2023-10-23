using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private float explosionDamage;
    [SerializeField] private HealthController healthController = null;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            healthController.currentPlayerHealth -= explosionDamage;
            healthController.TakeDamage();
            gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }
}
