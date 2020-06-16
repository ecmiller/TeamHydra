using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TFBExplosion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<BR_PlayerHealth>().DamagePlayer(2);
        }
    }
}
