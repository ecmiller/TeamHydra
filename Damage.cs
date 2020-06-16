using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

/// <summary>
/// Add this script to whatever can take damage
/// </summary>
public class Damage : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    [SerializeField] public int damageTaken;
    public GameObject myPrefab;
    public int prefabQuantity = 6;
    public BR_CameraShake cameraShake;
    public GameObject deathEffect;
    private float time;
    private GameObject instantiatedObj;
    public bool isShieldDown;
    [SerializeField] GameObject ScoreKeeper;
    //[SerializeField] GameObject Multiplier;



    private void Awake()
    {

        if (gameObject.CompareTag("Player"))
        {
            damageTaken = 0;
            maxHealth = gameObject.GetComponent<BR_PlayerHealth>().GetMaxPlayerHealth();
            myPrefab = null;
       
            // deactivate camara shake
            GameObject.Find("Main Camera").GetComponent<BR_CameraShake>().enabled = false;
        }

        else if (gameObject.CompareTag("Enemy"))
        {
            damageTaken = 0;
            maxHealth = 13;
        }
        else if (gameObject.CompareTag("SpinningBoss"))
        {
            damageTaken = 0;
            maxHealth = 24;
        }
        else if (gameObject.CompareTag("SpinningEnemy"))
        {
            damageTaken = 0;
            maxHealth = 1;
        }
        else if (gameObject.CompareTag("ShieldBoss"))
        {
            damageTaken = 0;
            maxHealth = 80;
        }
        else if (gameObject.CompareTag("Shield"))
        {
            isShieldDown = false;
            damageTaken = 0;
            maxHealth = 18;
        }
        else if (gameObject.CompareTag("ShieldingEnemies"))
        {
            damageTaken = 0;
            maxHealth = 1;
        }
        else if (gameObject.CompareTag("Turret"))
        {
            damageTaken = 0;
            maxHealth = 3;
        }
        else if (gameObject.CompareTag("HealthBarrel"))
        {
            damageTaken = 0;
            maxHealth = 1;
        }
        else
        {
            Debug.Log(name + " doesnt have a tag to damage");
        }

        ScoreKeeper = GameObject.FindGameObjectWithTag ("Scorekeeper");
        //Multiplier = ScoreKeeper.transform.Find ("Canvas").transform.Find ("Multiplier").gameObject;
    }

    private void Start()
    {
        if (cameraShake == null)
        {
            cameraShake = GameObject.Find("Main Camera").GetComponent<BR_CameraShake>();
        }

       
        deathEffect.SetActive(false);
        
    }
    private void Update()
    {
        if (damageTaken >= maxHealth)
        {
            if (gameObject.CompareTag("Player"))
            {

                deathEffect.SetActive(true);

                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("EnemyDeath");
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Stop("Turret");

                instantiatedObj = Instantiate(deathEffect, gameObject.transform.position, deathEffect.transform.rotation);
                GameObject.Find("GameManager").GetComponent<GameManagerScript>().DeathPause();
                gameObject.SetActive(false);
                ScoreKeeper.GetComponent<ScoreScript>().DecreaseScore(1000);
            }

            // Before an enemy is destroyed, check to see if a wave battle is in progress
            if (gameObject.CompareTag("Enemy"))
            {
                deathEffect.SetActive(true);
                //GetComponent<EnemyPointValue> ().UpdateScore ();
                if (ScoreKeeper != null)
                {
                    ScoreKeeper.GetComponent<ScoreScript>().AddToScore();
                }
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("EnemyDeath");
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("WhiteBoxHit");
                SpawnItems(prefabQuantity);
                ArenaUpdate();

            }
            else if (gameObject.CompareTag("SpinningEnemy"))
            {
                deathEffect.SetActive(true);
                //GetComponent<EnemyPointValue> ().UpdateScore ();
                if (ScoreKeeper != null)
                {
                    ScoreKeeper.GetComponent<ScoreScript>().AddToScore();
                }
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("EnemyDeath");
                SpawnItems(prefabQuantity);
                ArenaUpdate();
            }
            else if (gameObject.CompareTag("SpinningBoss"))
            {
                deathEffect.SetActive(true);
                //GetComponent<EnemyPointValue> ().UpdateScore ();
                if (ScoreKeeper != null)
                {
                    ScoreKeeper.GetComponent<ScoreScript>().AddToScore();
                }
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("EnemyDeath");
                SpawnItems(prefabQuantity);
                GameObject.Find("ArenaManager").GetComponent<ArenaManager>().CurrentArena.BossDefeated();
                GameObject.Find("BossHealthBar").SetActive(false);
            }
            else if (gameObject.CompareTag("Shield"))
            {
                GameObject.FindGameObjectWithTag("ShieldBoss").GetComponent<Damage>().isShieldDown = true;
                if (ScoreKeeper != null)
                {
                    ScoreKeeper.GetComponent<ScoreScript>().AddToScore();
                }
                GameObject.FindGameObjectWithTag("ShieldBoss").GetComponent<ResetBossShield>().StartFire();
                deathEffect.SetActive(true);
                gameObject.SetActive(false);
            }
            else if (gameObject.CompareTag("ShieldBoss"))
            {
                deathEffect.SetActive(true);
                if (ScoreKeeper != null)
                {
                    ScoreKeeper.GetComponent<ScoreScript>().AddToScore();
                }
                GameObject.Find("BossHealthBar").SetActive(false);
                GameObject.Find("BossShieldBar").SetActive(false);
                GetComponent<ResetBossShield>().BossKilled();
                Destroy(gameObject);
            }
            
            else if (gameObject.CompareTag("ShieldingEnemies"))
            {
                GameObject.Find("Shield").GetComponent<Damage>().damageTaken = 
                    GameObject.Find("Shield").GetComponent<Damage>().damageTaken + 6;
                if (ScoreKeeper != null)
                {
                    ScoreKeeper.GetComponent<ScoreScript>().AddToScore();
                }
                deathEffect.SetActive(true);
                gameObject.SetActive(false);
            }
            else if (gameObject.CompareTag("Turret"))
            {
                if (ScoreKeeper != null)
                {
                    ScoreKeeper.GetComponent<ScoreScript>().AddToScore();
                }
                SpawnItems (prefabQuantity);
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("KillTurret");
                gameObject.GetComponent<TurretScript>().DestroyTurret();
                deathEffect.SetActive(true);
            }
            else if (gameObject.CompareTag("HealthBarrel"))
            {
                deathEffect.SetActive(true);
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("HealthBarrel");
                SpawnItems(prefabQuantity);
                Destroy(gameObject);
            }

            //StartCoroutine(cameraShake.Shake (.5f, 50f));
            // deactivate camara shake

            GameObject.Find("Main Camera").GetComponent<BR_CameraShake>().enabled = true;

            gameObject.SetActive(false);
            
        }
    }

    private void SpawnItems(int prefabQuantity)
    {

        for (int i = 0; i < prefabQuantity; i++)
        {
            Instantiate(myPrefab, transform.position, transform.rotation);
            instantiatedObj = Instantiate(deathEffect, gameObject.transform.position, deathEffect.transform.rotation);
            Destroy(instantiatedObj, 1.5f);
            //Destroy(deathEffect, 2f);
            myPrefab.transform.parent = null;
            
            //deathEffect.transform.parent = null;
        }

    }

    public bool resettingShield = false;

    public void TakeDamage()
    {
        if (gameObject.CompareTag ("Player"))
        {
           
            gameObject.GetComponent<BR_PlayerHealth>().DamagePlayer(1);
            return;
           
        }

        else if (gameObject.CompareTag ("Enemy"))
        {
            damageTaken++;
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("WhiteBoxHit");
            gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
            gameObject.GetComponent<WhiteBoxEnemy>().timer = 0;
            if (ScoreKeeper != null)
            {
                ScoreKeeper.GetComponent<ScoreScript>().activateMultiplier = true;
                ScoreKeeper.GetComponent<ScoreScript>().timer = 3;
                if (ScoreKeeper.GetComponent<ScoreScript>().multiplierNumber <= 5)
                {
                    ScoreKeeper.GetComponent<ScoreScript>().multiplierNumber += .5f;                   
                }
                ScoreKeeper.transform.Find ("Canvas").transform.Find ("Multiplier").gameObject.GetComponent<ScoreEffect> ().TextEffect ();
                return;
            }
        }
        else if (gameObject.CompareTag ("SpinningBoss"))
        {
            damageTaken++;
            if (ScoreKeeper != null)
            {
                ScoreKeeper.GetComponent<ScoreScript>().activateMultiplier = true;
                ScoreKeeper.GetComponent<ScoreScript>().timer = 3;
                if (ScoreKeeper.GetComponent<ScoreScript>().multiplierNumber <= 5)
                {
                    ScoreKeeper.GetComponent<ScoreScript>().multiplierNumber += .5f;
                }
                ScoreKeeper.transform.Find ("Canvas").transform.Find ("Multiplier").gameObject.GetComponent<ScoreEffect> ().TextEffect ();
                return;
            }
        }
        else if (gameObject.CompareTag ("SpinningEnemy"))
        {
            damageTaken++;
            if (ScoreKeeper != null)
            {
                ScoreKeeper.GetComponent<ScoreScript>().activateMultiplier = true;
                ScoreKeeper.GetComponent<ScoreScript>().timer = 3;
                if (ScoreKeeper.GetComponent<ScoreScript>().multiplierNumber <= 5)
                {
                    ScoreKeeper.GetComponent<ScoreScript>().multiplierNumber += .5f;
                }
                ScoreKeeper.transform.Find ("Canvas").transform.Find ("Multiplier").gameObject.GetComponent<ScoreEffect> ().TextEffect ();
                return;
            }
        }
        else if (gameObject.CompareTag ("ShieldBoss"))
        {

            if (resettingShield == true)
            {
                if (damageTaken == 20)
                {
                    gameObject.GetComponent<ResetBossShield> ().ResetShield ();
                    gameObject.GetComponent<ResetBossShield>().PhaseTwo = true;
                    gameObject.GetComponent<ResetBossShield>().currentFireEffect++;
                }

                if (damageTaken == 40)
                {
                    gameObject.GetComponent<ResetBossShield> ().ResetShield ();
                    gameObject.GetComponent<ResetBossShield>().PhaseThree = true;
                    gameObject.GetComponent<ResetBossShield>().currentFireEffect++;
                }

                if(damageTaken == 60)
                {
                    gameObject.GetComponent<ResetBossShield>().ResetShield();
                }
            }

            if (isShieldDown == true)
            {
                damageTaken++;
                resettingShield = true;
                if (ScoreKeeper != null)
                {
                    ScoreKeeper.GetComponent<ScoreScript>().activateMultiplier = true;
                    ScoreKeeper.GetComponent<ScoreScript>().timer = 3;
                    if (ScoreKeeper.GetComponent<ScoreScript>().multiplierNumber <= 5)
                    {
                        ScoreKeeper.GetComponent<ScoreScript>().multiplierNumber += .5f;
                    }
                    ScoreKeeper.transform.Find ("Canvas").transform.Find ("Multiplier").gameObject.GetComponent<ScoreEffect> ().TextEffect ();
                    return;
                }
            }
            else
                return;

        }
        else if (gameObject.CompareTag ("Shield"))
        {
            damageTaken++;
            if (ScoreKeeper != null)
            {
                ScoreKeeper.GetComponent<ScoreScript>().activateMultiplier = true;
            }
            return;
        }
        else if (gameObject.CompareTag ("ShieldingEnemies"))
        {
            if (GameObject.FindGameObjectWithTag ("ShieldBoss").GetComponent<Damage> ().isShieldDown == false)
            {
                damageTaken++;
                if (ScoreKeeper != null)
                {
                    ScoreKeeper.GetComponent<ScoreScript>().activateMultiplier = true;
                    ScoreKeeper.GetComponent<ScoreScript>().timer = 3;
                    if (ScoreKeeper.GetComponent<ScoreScript>().multiplierNumber <= 5)
                    {
                        ScoreKeeper.GetComponent<ScoreScript>().multiplierNumber += .5f;
                    }
                    ScoreKeeper.transform.Find ("Canvas").transform.Find ("Multiplier").gameObject.GetComponent<ScoreEffect> ().TextEffect ();
                    return;
                }
            }

        }
        else if (gameObject.CompareTag ("HealthBarrel"))
        {
            damageTaken++;
        }
        else if (gameObject.CompareTag ("Turret"))
        {
            damageTaken++;
            if (ScoreKeeper != null)
            {
                ScoreKeeper.GetComponent<ScoreScript>().activateMultiplier = true;
                ScoreKeeper.GetComponent<ScoreScript>().timer = 3;
                if (ScoreKeeper.GetComponent<ScoreScript>().multiplierNumber <= 5)
                {
                    ScoreKeeper.GetComponent<ScoreScript>().multiplierNumber += .5f;
                }
                ScoreKeeper.transform.Find ("Canvas").transform.Find ("Multiplier").gameObject.GetComponent<ScoreEffect> ().TextEffect ();
                return;
            }
        }
        else
        {
            damageTaken++;
        }

    }


    public void UpdateDamage(int damage)
    {
        if(ScoreKeeper != null)
        {
            ScoreKeeper.GetComponent<ScoreScript>().DeactivateMultiplier();
        }

        damageTaken += damage;
    }

    // If an enemy is defeated while a wave battle is active, increment the counter
    private void ArenaUpdate()
    {
        ArenaManager arenaManager = GameObject.FindObjectOfType<ArenaManager>();

        if (arenaManager == null)
        {
            Debug.Log("No arena manager script was found in the scene.");
            return;
        }

        if (arenaManager.arenaBattleActive == true)
        {
            arenaManager.CurrentArena.EnemyDefeated();
            Debug.Log(name + " was defeated during an arena battle");
        }
    }

    //private void OnDestroy()
    //{
    //    if (gameObject.GetComponent<EnemyPointValue>() != null)
    //    {
    //        gameObject.GetComponent<EnemyPointValue>().UpdateScore();
    //    }
    //}

    public void HealPlayer()
    {
        damageTaken -= 1;
      
    }
}
