using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_M : MonoBehaviour
{

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
        yield return new WaitForSeconds(.1f);
        render.material.color = Color.black;
        yield return new WaitForSeconds(.05f);
        render.material.color = Color.white;
        yield return new WaitForSeconds(.1f);
        render.material.color = Color.black;
        yield return new WaitForSeconds(.05f);
        Destroy(gameObject);
    }
}
