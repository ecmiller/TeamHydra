using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to the empty gameobject holding the spikes
public class WhiteBoxSpikes : MonoBehaviour
{
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("isSpiking", true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && anim.GetBool("isSpiking") == true)
        {
            other.gameObject.GetComponent<BR_PlayerHealth>().DamagePlayer(1);
            anim.SetBool("isSpiking", false);
        }

        else if(other.CompareTag("Wall") && anim.GetBool("isSpiking") == true)
        {
            if (other.gameObject != null)
            {
                other.gameObject.GetComponent<NormalWall>().isHit = true;
            }
        }
    }

}
