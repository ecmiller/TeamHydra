using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AS_Switch: MonoBehaviour
{
    Animator anim;
    public bool Unlocked;
   
    //public GameObject oSwitch;

    private void Start()
    {
        anim = GetComponent<Animator>();
        Unlocked = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ChargeMelee"))
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("SwitchFlip");
            anim.SetBool("isFlipped", true);
            Unlocked = true;

            //StartCoroutine(jOnce());
        }
        //StartCoroutine(playAnim());
        //Invoke("playAnim", 1f);
    }


    //Was IEnumerator, changed it to public void
    //public void playAnim()
    //{

    //    //yield return new WaitForSeconds(3);
    //    GetComponent<Animator>().SetBool("isUnlocked", true);
    //    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("GateOpen");
    //    // anim.SetBool("isUnlocked", true);
    //}

    //IEnumerator jOnce()
    //{
    //    yield return new WaitForSeconds(1);
    //    oSwitch.SetActive(true);
    //    Destroy(gameObject);
    //}
}