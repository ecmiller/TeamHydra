using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BR_MeleeAttacks : MonoBehaviour
{
    [SerializeField] GameObject PlayerMelee;
    [SerializeField] GameObject ChargeMelee;
    [SerializeField] GameObject PlayerBody;
    public bool isMeleeActive;
    public bool isChargeActive;
    [SerializeField] float speed;
    [SerializeField] float attackTimer;
    [SerializeField] bool isMelee;
    public bool isCharge;
    [SerializeField] float chargeTimer;
    public bool chargeCanHurt;
    public Animator anim;


    private void OnEnable ()
    {
        this.gameObject.GetComponent<BR_PlayerMovement> ().isSlowed = false;

        this.gameObject.transform.localScale = new Vector3 (1, 1, 1);
    }


    private void Awake ()
    {
        //PlayerMelee = GameObject.Find ("Melee");

        if (this.gameObject.name == ("Coal"))
        {
            ChargeMelee = this.gameObject.transform.Find ("ChargeMelee").gameObject;
            //PlayerMelee = this.gameObject.transform.Find("Melee").gameObject;
        } 
        else if (this.gameObject.name == ("Crate"))
        {
            ChargeMelee = this.gameObject.transform.Find ("ChargeMelee").gameObject;
            //PlayerMelee = this.gameObject.transform.Find("Melee").gameObject;
        } 
        else if (this.gameObject.name == ("Salt"))
        {
            ChargeMelee = this.gameObject.transform.Find ("ChargeMelee").gameObject;
            //PlayerMelee = this.gameObject.transform.Find("Melee").gameObject;
        }

        PlayerMelee.SetActive (false);
        ChargeMelee.SetActive (false);
        attackTimer = 0;
        speed = 300f;
        chargeTimer = 0;
        chargeCanHurt = false;

        anim = gameObject.GetComponent<Animator>();
        //Commented out the line below for testing the movement animations for the player characters//
        

    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerMelee == null)
        {
            PlayerMelee = GameObject.Find ("Spikes");
        }

        if (ChargeMelee == null)
        {
            ChargeMelee = GameObject.Find ("ChargeMelee");
        }

        isCharge = false;

        anim.enabled = false;

        isMelee = false;
    }

    // Update is called once per frame
    void Update()
    {

            if (Input.GetKey (KeyCode.Mouse1))
            {
                chargeTimer += Time.deltaTime;


            if (chargeTimer <= .3f)
            {
                isMelee = true;
                isCharge = false;

                ChargeMelee.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
            }
            else if (chargeTimer > .3f && chargeTimer < 3f)
            {
                anim.enabled = true;

                anim.SetBool("isCharging", true);
                //GameObject.Find ("Player").GetComponent<BR_PlayerMovement> ().isSlowed = true;
                gameObject.GetComponent<BR_PlayerMovement>().isSlowed = true;
                isCharge = true;
                isMelee = false;
                ChargeMelee.SetActive(true);
                PlayerMelee.SetActive(false);
                ChargeMelee.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }

            if (Input.GetKeyUp (KeyCode.Mouse1))
            {
                // check if timer if its low do melle if high do charge attack
                
                if (isMelee == true)
                {
                    isMeleeActive = true;
                    isChargeActive = false;
                    GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<BR_AudioManager> ().Play ("Melee");
                }

                if (isCharge == true)
                {
                    anim.SetBool("isCharging", false);
                    anim.SetBool("isIdle", true);
                    
                    //GameObject.Find ("Player").GetComponent<BR_PlayerMovement> ().isSlowed = false;
                    gameObject.GetComponent<BR_PlayerMovement>().isSlowed = false;

                    isChargeActive = true;
                    isMeleeActive = false;
                    GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<BR_AudioManager> ().Play ("ChargeMelee");
                    Invoke("TurnOffAnim", 0.5f);
                    isCharge = false;
                }

                chargeTimer = 0;
            }

        MeleeAttack ();

        ChargeAttack ();
    }
    public void TurnOffAnim()
    {
        anim.enabled = false;
    }

    private void ChargeAttack ()
    {
        if (isChargeActive == true)
        {
            if (attackTimer <= .1)
            {
                ChargeMelee.SetActive (true);
                ChargeMelee.gameObject.GetComponent<MeshRenderer> ().material.color = Color.red;
                ChargeMelee.transform.position = this.transform.position;
                attackTimer += Time.deltaTime;
                chargeCanHurt = true;
            }
            else
            {
                attackTimer = 0;
                ChargeMelee.SetActive (false);
                isChargeActive = false;
                chargeCanHurt = false;
                this.gameObject.transform.localScale = new Vector3 (1, 1, 1);
                
            }
            
        }
    }

    private void MeleeAttack ()
    {
        if (isMeleeActive == true)
        {
            if (attackTimer <= .5f)
            {
                PlayerMelee.SetActive (true);
                PlayerMelee.transform.Rotate (0, speed * Time.deltaTime, 0, Space.World);
                PlayerMelee.transform.position = this.transform.position;
                attackTimer += Time.deltaTime;
                PlayerBody.GetComponent<Animator>().SetBool("isMelee", true);
            }
            else
            {
                attackTimer = 0;
                isMeleeActive = false;
                PlayerMelee.transform.localRotation = Quaternion.identity;
                PlayerMelee.transform.position = this.transform.position;
            }
        }
        else
        {
            PlayerMelee.SetActive (false);
            PlayerBody.GetComponent<Animator>().SetBool("isMelee", false);
        }
    }

    public void RevertPlayerChargeMelee()
    {
        GetComponent<Animator>().enabled = false;
        transform.localScale = new Vector3(1f, 1f, 1f);
        PlayerMelee.SetActive(false);
        ChargeMelee.SetActive(false);
        isCharge = false;
        isMelee = false;
    }
}
