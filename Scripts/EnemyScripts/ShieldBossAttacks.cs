using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBossAttacks : MonoBehaviour
{
    GameObject Player;
    bool withinRange = false;
    [SerializeField] bool ContactDamage = true;
    
    
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()
    {
        
    }
    void Update()
    {
        
    }

    [SerializeField] GameObject projectileFire;
    [SerializeField] GameObject FireballCharge;
    [SerializeField] GameObject projectileSpawn;
    [SerializeField] GameObject projectileSpawn1;
    [SerializeField] GameObject projectileSpawn2;
    private void ShootTrackingFireball()
    {
        if (ContactDamage == false)
        {
            Instantiate(projectileFire, projectileSpawn.transform);
            Instantiate(projectileFire, projectileSpawn1.transform);
            Instantiate(projectileFire, projectileSpawn2.transform);
            projectileFire.transform.parent = null;
            FireballCharge.SetActive(false);
        }
    }

    void ChargeFireball()
    {
        FireballCharge.SetActive(true);
        Invoke("ShootTrackingFireball", 1.5f);
    }

    public void ShootFireball()
    {
        InvokeRepeating("ChargeFireball", 1.0f, 6.0f);
    }

    public void StopShootingFireball()
    {
        CancelInvoke("ChargeFireball");
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if(ContactDamage == true)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Player = other.gameObject;
                withinRange = true;
                other.GetComponent<IgniteBurnEffect>().burnTick = 0;
                other.GetComponent<IgniteBurnEffect>().IgnitePlayer();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(ContactDamage == true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<Damage>().TakeDamage();
            }
        }
    }
}
