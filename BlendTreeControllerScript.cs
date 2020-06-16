using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendTreeControllerScript : MonoBehaviour
{
    [SerializeField] GameObject PlayerBody;

    private void Awake()
    {
        PlayerBody.transform.position = gameObject.transform.position;
    }

    void ResetDeath()
    {
        PlayerBody.GetComponent<Animator>().SetBool("isDead", false);
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    PlayerBody.GetComponent<Animator>().SetBool("isDead", true);
        //    Invoke("ResetDeath", 3.0f);
        //}
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        if(movement.x != 0.0f || movement.z != 0.0f)
        {
            PlayerBody.GetComponent<Animator>().SetFloat("Speed", 1.0f);
        }

        else if(movement.x == 0.0f && movement.z == 0.0f)
        {
            PlayerBody.GetComponent<Animator>().SetFloat("Speed", 0.0f);
        }

        if (gameObject.GetComponent<BR_MeleeAttacks>().isCharge == true)
        {
            PlayerBody.transform.position = gameObject.transform.position;
            PlayerBody.GetComponent<Animator>().enabled = false;
        }
        else
        {
            PlayerBody.GetComponent<Animator>().enabled = true;
        }

        //else
        //    return;
    }
}
