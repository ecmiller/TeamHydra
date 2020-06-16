using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BR_PlayerHealth : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] public int maxHealth;
    [SerializeField] GameObject[] healthPieces;
    [SerializeField] private bool isInvincible;
    [SerializeField] private float invincibiltyDuration = 1f;
    public GameObject myManager;
    public float timer;
    [SerializeField] GameObject VictoryMenu;



    private void Awake ()
    {
        // if you increase or decrease the life make sure you edit the amount of health pieces on the player
        // also edit the HealthPieces script
        maxHealth = 7;
        health = maxHealth;
        //healthPieces = GameObject.FindGameObjectsWithTag ("HeartPiece");
        isInvincible = false;
        myManager = GameObject.Find("GameManager");
        timer = 0;
        isDebugMenu = false;
        invincibiltyDuration = .3f;
        if (VictoryMenu == null)
        {
            VictoryMenu = GameObject.Find ("VictoryMenu");
        }
        
    }

    private void Update ()
    {
        if (VictoryMenu.GetComponent<VictoryMenu> ().isActive == true)
        {
            isInvincible = true;
        }
    }

    public int GetPlayerHealth ()
    {
        return health;

    }

    public int GetMaxPlayerHealth ()
    {
        return maxHealth;
    }

    public bool isDebugMenu = false;
    public void DamagePlayer (int damage)
    {

        if (isInvincible == false)
        {

            health -= damage;
            UpdateHealthPieces();
            GetComponent<Damage>().UpdateDamage(damage);
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("PlayerHit");
            

            if(isDebugMenu == false)
            {
                isInvincible = true;
                Invoke("ToggleInvincibility", invincibiltyDuration);
            }
            
        }
   

    }

    public void UpdateHealthPieces ()
    {
        for (int i = 0; i < maxHealth; i++)
        {
            healthPieces[i].SetActive (false);
        }

        for (int i = 0; i < health; i++)
        {
            healthPieces[i].SetActive (true);
        }
    }

 
    public void MakeHealthMax ()
    {
        health = maxHealth;
        UpdateHealthPieces();
    }

    public void ToggleInvincibility()
    {
        isInvincible = !isInvincible;
    }

    public void HealPlayerHealth()
    {
        health = health + 1;
        UpdateHealthPieces();
    }

    //public void SetVictoryMenu ()
    //{
    //    VictoryMenu = GameObject.Find ("VictoryMenu");
    //}
}
