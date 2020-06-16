using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFireball : MonoBehaviour
{
    public GameObject explosionVFX;
    public float timer;

    private void Awake()
    {
        timer = 0;
    }
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 3f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag != "Player")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Debug.Log ("Shot Enemy");
                collision.gameObject.GetComponent<Damage> ().TakeDamage ();
                
            }
            else if (collision.gameObject.tag == "SpinningBoss")
            {
                Debug.Log ("Shot Boss");
                collision.gameObject.GetComponent<Damage> ().TakeDamage ();
            }
            else if (collision.gameObject.tag == "SpinningEnemy")
            {
                Debug.Log ("Shot Spiked Enemy");
                collision.gameObject.GetComponent<Damage> ().TakeDamage ();
            }
            else if (collision.gameObject.tag == "ShieldingEnemies")
            {
                Debug.Log("Shot Shield");
                collision.gameObject.GetComponent<Damage>().TakeDamage();
            }
            else if (collision.gameObject.tag == "ShieldBoss")
            {
                Debug.Log("Shot ShieldBoss");
                collision.gameObject.GetComponent<Damage>().TakeDamage();
            }
            else if (collision.gameObject.tag == "Turret")
            {
                Debug.Log("Shot Turret");
                collision.gameObject.GetComponent<Damage>().TakeDamage();
            }
            else if (collision.gameObject.tag == "HealthBarrel")
            {
                collision.gameObject.GetComponent<Damage>().TakeDamage();
                Debug.Log("Shot Health Barrel");
            }
            Destroy(this.gameObject);
           // Debug.Log(other);
            Destroy(gameObject);
            Instantiate(explosionVFX, transform.position, transform.rotation);
        }
    }
}
