using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurretScript : MonoBehaviour
{

    [SerializeField] GameObject TurretBody;
    [SerializeField] GameObject RaycastPoint;
    [SerializeField] GameObject TurretWarning;
    [SerializeField] GameObject TurretFiring;
    [SerializeField] GameObject ChargingEffect;
    [SerializeField] Animator anim;
    public GameObject Coal;
    public GameObject Crate;
    public GameObject Salt;
    public GameObject PlayerWarning;
    public float TurretSights;
    GameObject Player;
    bool playerInRange = false;
    bool shootReset = false;
    bool playerCovered = false;
    bool turretRotating = true;

    [SerializeField] GameObject AudioManager;

    //[SerializeField] BR_AudioManager audioManager;


    private void Awake()
    {
        AudioManager = GameObject.FindGameObjectWithTag("AudioManager");
        Coal = GameObject.Find("Coal");
        Crate = GameObject.Find("Crate");
        Salt = GameObject.Find("Salt");
    }
    void Start()
    {
        anim.SetTrigger("turretRotating");
    }
    void Update()
    {
        if (Coal.activeInHierarchy == true)
        {
            Player = Coal;
        }
        else if (Crate.activeInHierarchy == true)
        {
            Player = Crate;
        }
        else if (Salt.activeInHierarchy == true)
        {
            Player = Salt;
        }        
        Vector3 targetposition = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);

        if (Player != null)
        {
            RaycastHit hit;
            int layerMask = 1;

            RaycastPoint.transform.LookAt(targetposition);
            //Debug.DrawRay(RaycastPoint.transform.position, RaycastPoint.transform.forward, Color.green, 15);

            if (Physics.Raycast(RaycastPoint.transform.position, RaycastPoint.transform.forward, out hit, TurretSights, layerMask))
            {
                //Debug.Log(hit.collider.name);

                if (hit.collider.CompareTag("Player"))
                {
                    playerCovered = false;
                    playerInRange = true;
                    Debug.Log(hit.collider.name);
                }
                else
                {
                    playerCovered = true;
                    playerInRange = false;
                  
                }
            }
            else if (playerInRange && playerCovered == false)
            {
                playerInRange = false;
                playerCovered = true;
            }
            if (playerInRange && playerCovered == false)
            {
                if (shootReset == false)
                {
                    ReturnShooting();
                }

                if(turretRotating == false)
                {
                    TurretBody.transform.LookAt(targetposition);
                }
                else if(turretRotating == true)
                {
                   
                }
                
                Vector3 forward = Player.transform.position * 1;
            }
            else
            {
                StopShooting();
               
            }
        }
    }

    [SerializeField] GameObject projectileFire; 
    [SerializeField] GameObject projectileSpawn;
    public float projectileSpeed;
    private void ShootPlayer()
    {
        if (playerInRange && playerCovered == false)
        {
            TurretFiring.SetActive(true);
            TurretWarning.SetActive(false);
            GameObject fireball = Instantiate(projectileFire, projectileSpawn.transform) as GameObject;
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            rb.velocity = projectileSpawn.transform.forward * projectileSpeed;
            rb.transform.parent = null;
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("Turret(shooting)");
        }
    }

    [SerializeField] float RateOfFire;
    public void ReturnShooting()
    {
        ChargingEffect.SetActive(true);
        gameObject.GetComponent<AudioSource>().Play();
        TurretWarning.SetActive(true);
        PlayerWarning.SetActive(true);
        InvokeRepeating("ShootPlayer", 1f, RateOfFire);
        shootReset = true;
        turretRotating = false;
        anim.enabled = false;
        
    }

    public void StopShooting()
    {
        gameObject.GetComponent<AudioSource>().Stop();
        ChargingEffect.SetActive(false);
        shootReset = false;
        TurretFiring.SetActive(false);
        TurretWarning.SetActive(false);
        PlayerWarning.SetActive(false);
        CancelInvoke("ShootPlayer");
        turretRotating = true;
        anim.enabled = true;
        

    }
    public void DestroyTurret()
    {
        StopShooting();
        gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Stop("Turret");
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("BombWall");
        }
    }

}
