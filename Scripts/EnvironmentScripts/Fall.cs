﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    //public GameObject platform;
    // Animator anim;
    //public float flashTime;
  

    public void Start()
    {
        //anim = GetComponent<Animator>();
      

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            StartCoroutine(Flashing());
           //anim.SetBool("isShaking", true);
           
        }                
  
    }



    IEnumerator Flashing()
    {
        Renderer render = GetComponent<Renderer>();
        render.material.color = Color.white;
        yield return new WaitForSeconds(.2f);
        render.material.color = Color.black;
        yield return new WaitForSeconds(.2f);
        render.material.color = Color.white;
        yield return new WaitForSeconds(.2f);
        render.material.color = Color.black;
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }

}
