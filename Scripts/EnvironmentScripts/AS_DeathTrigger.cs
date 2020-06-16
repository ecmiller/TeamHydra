using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



public class AS_DeathTrigger : MonoBehaviour
{
    public BoxCollider box;
    public GameObject player;
    public GameObject myManager;

    public GameObject Coal;
    public GameObject Crate;
    public GameObject Salt;

    public bool hasSelected;


    public void Awake()
    {
        Coal = GameObject.Find("Coal");
        Crate = GameObject.Find("Crate");
        Salt = GameObject.Find("Salt");
    }
    void Start()
    {

        //player = GameObject.FindGameObjectWithTag("Player");
        myManager = GameObject.Find("GameManager");

    }

    // Update is called once per frame
    public void Update()
    {
        if (hasSelected == false)
        {
            if (Coal.activeInHierarchy == true)
            {
                player = Coal;
                hasSelected = true;

            }
            else if (Crate.activeInHierarchy == true)
            {
                player = Crate;
                hasSelected = true;

            }
            else if (Salt.activeInHierarchy == true)
            {
                player = Salt;
                hasSelected = true;

            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<BR_PlayerHealth>().DamagePlayer(8);
            //player.SetActive(false); 
            //myManager.GetComponent<GameManagerScript>().Invoke("DeathPause", 1f);

        }
     }

}