using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTurretBullet : MonoBehaviour
{
    float timer;
    public GameObject explosionVFX;
    GameObject Player;

    private void Awake()
    {
        timer = 0;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1.5f)
        {
            Destroy(this.gameObject);
            Instantiate(explosionVFX, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Turret")
        {
            if(other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<Damage>().TakeDamage();
                Destroy(gameObject);
                Instantiate(explosionVFX, transform.position, transform.rotation);
            }
        }
    }
}
