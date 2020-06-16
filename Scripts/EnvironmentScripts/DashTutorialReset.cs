using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTutorialReset : MonoBehaviour
{
    public GameObject resetTrigger;
    public GameObject resetSpot;
    public GameObject player;

    Animator anim;

    public bool isReset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //resetTrigger.SetActive(false);
        resetSpot.SetActive(false);
        anim = GetComponentInParent<Animator>();
        isReset = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            resetSpot.SetActive(true);
            resetSpot.GetComponent<BoxCollider>().enabled = true;
            anim.SetBool("isOpening", true);
            anim.SetBool("isClosing", false);
            player.transform.position = resetSpot.transform.position;
        }
    }
}
