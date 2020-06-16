using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombNormalWall : MonoBehaviour
{
    public bool bombwallisHit;

    

    public void Awake()
    {
        bombwallisHit = false;
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("BombWall");
        }
    }

    public void Update()
    {
        
    }
}
