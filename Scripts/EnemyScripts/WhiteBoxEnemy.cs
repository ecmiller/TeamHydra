using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBoxEnemy : MonoBehaviour
{

    Animator anim;

    public float timer;
   
    public float pushBackForce;



    void Start()
    {
        
        anim = GetComponent<Animator>();
        anim.SetBool("isAttacking", true);
        pushBackForce = 125f;
        GameObject.Find("AudioManager").GetComponent<BR_AudioManager>().Play("Melee");
        GetComponentInChildren<MeshRenderer>().material.color = Color.white;
        timer = 0;
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.2f)
        {
            GetComponentInChildren<MeshRenderer>().material.color = Color.white;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Weapon"))
        {
            GameObject.Find("AudioManager").GetComponent<BR_AudioManager>().Play("WhiteBoxHit");
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * pushBackForce, ForceMode.Impulse);
            GetComponentInChildren<MeshRenderer>().material.color = Color.red;
            timer = 0;
            

        }

    }



}

