using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageShieldingEnemies : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            gameObject.GetComponent<Damage>().TakeDamage();
        }
    }
}
