using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject player;
    public GameObject shooter;
    public GameObject introTrig;
    public GameObject startSpot;

    public bool meleeOn = false;
    public bool shooterOn = false;




    private void Awake()
    {
        player = GameObject.Find("Coal");
        shooter = GameObject.Find("CoalProjectileexit");
        introTrig = GameObject.Find("IntroductionTrigger");
        startSpot = GameObject.Find("StartSpot");
        startSpot.SetActive(true);
        player.transform.position = startSpot.transform.position;
    }
    void Start()
    {
        //if(shooter != null)
        player.GetComponent<BR_PlayerJump>().enabled = false;
        player.GetComponent<BR_PlayerDash>().enabled = false;
        //player.GetComponent<TrailRenderer>().enabled = false;
        player.GetComponentInChildren<DashEffects>().enabled = false;
        shooter.SetActive(false);
        //player.GetComponent<BR_MeleeAttacks>().ChargeAttack();
        //player.transform.position = startSpot.transform.position;
        //shooter.GetComponent<ShootingEffect>().enabled = false;

    }

    void Update()
    {
        if(meleeOn == false)
        {
            player.gameObject.GetComponent<BR_MeleeAttacks>().enabled = false;
        }
        
        if(meleeOn == true)
        {
            player.gameObject.GetComponent<BR_MeleeAttacks>().enabled = true;
        }

        if(shooterOn == false)
        {
            shooter.GetComponentInParent<ShootingEffect>().enabled = false;
        }

        if(shooterOn == true)
        {
            shooter.GetComponentInParent<ShootingEffect>().enabled = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Tutorial_Intro"))
        //{
        //    startSpot.SetActive(false);
        //}
        if (other.gameObject.CompareTag("Tutorial_Jump"))
        {
            player.GetComponent<BR_PlayerJump>().enabled = true;
        }
        if (other.gameObject.CompareTag("Tutorial_Dash"))
        {
            player.GetComponent<BR_PlayerDash>().enabled = true;
            //player.GetComponent<TrailRenderer>().enabled = true;
            player.GetComponentInChildren<DashEffects>().enabled = true;
        }
        if (other.gameObject.CompareTag("Tutorial_ChargedMelee"))
        {
            meleeOn = true;
        }
        if(other.gameObject.CompareTag("Tutorial_Shoot"))
        {
            shooterOn = true;
            shooter.SetActive(true);
            
        }
 

    }
}