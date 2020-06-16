using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BR_MeleeDamage : MonoBehaviour
{

    public bool meleePushbackEnabled = false;
    public ForceMode pushbackForceMode = ForceMode.Impulse;

    private void OnTriggerEnter (Collider other)
    {
        if (other.isTrigger == false)
        {
            if (other.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Damage>().TakeDamage();
            }
            else if (other.CompareTag("SpinningBoss"))
            {
                other.gameObject.GetComponent<Damage>().TakeDamage();
            }
            /*
            else if (other.CompareTag("SpinningEnemy"))
            {
                other.gameObject.GetComponent<Damage>().TakeDamage();
            }
            */

            if (meleePushbackEnabled && other.gameObject.GetComponentInParent<Rigidbody>() != null)
            {
                // Push the enemy back
                other.gameObject.GetComponentInParent<Rigidbody>().AddForceAtPosition(other.gameObject.transform.position, transform.position, pushbackForceMode);
            }
        }

        if (other.CompareTag("Wall"))
        {
            Debug.Log(name + " hit a wall");

            if (other.gameObject.GetComponent<NormalWall>())
            {
                if (other.gameObject != null)
                {
                    other.gameObject.GetComponent<NormalWall>().isHit = true;
                    //  spinningenemy.GetComponent<Rigidbody>().AddRelativeForce(Vector3.back* pushBackForce, ForceMode.Impulse);
                }
            }

            else
            {
                Debug.Log(name + " hit something tagged as wall but nothing happened");
            }
        }

    }
}
