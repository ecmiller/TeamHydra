using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningEnemySpikes : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.GetComponent<Animator>().GetBool("isAttacking") && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<BR_PlayerHealth>().DamagePlayer(1);
            gameObject.GetComponentInParent<Animator>().SetBool("isAttacking", false);
        }
    }
}
