using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    GameObject Player;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            if (Player.GetComponent<Damage>().damageTaken != 0 && Player.GetComponent<BR_PlayerHealth>().health != 7)
            {
                Player.GetComponent<Damage>().HealPlayer();
                Player.GetComponent<BR_PlayerHealth>().HealPlayerHealth();
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("HealthPickUp");
                Destroy(gameObject);
            }
            
            //Destroy(gameObject);
        }
    }
}
