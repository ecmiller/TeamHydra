using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningEnemy : MonoBehaviour
{
    public GameObject spinningenemy;
    public float pushBackForce;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
     
       
        if (anim == null)
        {
            Debug.Log("No animator component found on " + gameObject.name);
        }

        GetComponent<EnemyMovement>().isActive = true;

        pushBackForce = 100f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("isAttacking", true);
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("isAttacking", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            collision.gameObject.GetComponent<BR_PlayerHealth>().DamagePlayer(1);

                // Knocks the player away when hit
                collision.gameObject.GetComponent<Rigidbody>().AddForce(-10, 0, 0);

                anim.SetBool("isAttacking", false);
    
            return;
        }

      

        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log(name + " hit a wall");

            if (collision.gameObject.GetComponent<NormalWall>())
            {
                if (collision.gameObject != null)
                {
                    collision.gameObject.GetComponent<NormalWall>().isHit = true;
                    spinningenemy.GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * pushBackForce, ForceMode.Impulse);
                }
            }

            else
            {
                Debug.Log(name + " hit something tagged as wall but nothing happened");
            }
        }


    }
}
