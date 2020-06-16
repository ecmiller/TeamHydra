using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.SceneManagement;

////Author: Ben Murchie
////Purpose: PreProduction project

public class DebugSettingsScript : MonoBehaviour
{
    public GameObject Player;
    public bool immortalPlayer = false;
    public bool canGoToNextCheckpoint = true;
    GameObject[] Enemies;
    GameObject[] SpinningEnemies;
    GameObject[] Turrets;
    GameObject SpinningBoss;
    GameObject ShieldBoss;

    private void OnEnable ()
    {
        if (Player == null)
        {
           Player = GameObject.Find ("GameManager").GetComponent<GameManagerScript> ().Player;
        }
    }

    void Start()
    {
        KeepVariables.keepLevelName = SceneManager.GetActiveScene().name;

        // Get the player from the GameManager
        Player = FindObjectOfType<GameManagerScript>().GetPlayer();
    }

    void OnLevelWasLoaded(int level)
    {
        // If the player was not assigned in the Start function for some reason, assign it here
        if (Player == null)
        {
            if (GameObject.Find("Coal").activeInHierarchy)
            {
                Player = GameObject.Find("Coal");
            }

            else if (GameObject.Find("Crate").activeInHierarchy)
            {
                Player = GameObject.Find("Crate");
            }

            else if (GameObject.Find("Salt").activeInHierarchy)
            {
                Player = GameObject.Find("Salt");
            }
        }
    }

    public void PlayerImmortal()
    {
        immortalPlayer = !immortalPlayer;

        if (immortalPlayer)
        {
            Player.GetComponent<Damage>().enabled = false;
            Player.GetComponent<BR_PlayerHealth>().ToggleInvincibility();
        }

        else
        {
            Player.GetComponent<Damage>().enabled = true;
            Player.GetComponent<BR_PlayerHealth>().ToggleInvincibility();
        }

    }

    public void DamagePlayer()
    {
        if (Player != null)
        {
            if (immortalPlayer == false)
            {
                //Player.GetComponent<Damage>().TakeDamage();

                Player.GetComponent<BR_PlayerHealth>().DamagePlayer(1);
            }
        }
    }
    public void KillPlayer()
    {
        if (Player != null)
        {
            if (immortalPlayer == false)
            {
                Player.GetComponent<BR_PlayerHealth>().DamagePlayer(7);
            }
        }
    }

    public void KillEnemies()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        SpinningEnemies = GameObject.FindGameObjectsWithTag("SpinningEnemy");

        SpinningBoss = GameObject.FindGameObjectWithTag("SpinningBoss");

        ShieldBoss = GameObject.FindGameObjectWithTag("ShieldBoss");

        Turrets = GameObject.FindGameObjectsWithTag("Turret");


        for (int i = 0; i < Enemies.Length; i++)
        {
            if (Enemies[i] != null)
            {
                Enemies[i].GetComponent<Damage>().UpdateDamage(Enemies[i].GetComponent<Damage>().maxHealth);
            }
            Debug.Log("Destroyed " + i + " Steves");
        }

        for (int i = 0; i < SpinningEnemies.Length; i++)
        {
            if (SpinningEnemies[i] != null)
            {
                SpinningEnemies[i].GetComponent<Damage>().UpdateDamage(SpinningEnemies[i].GetComponent<Damage>().maxHealth);
            }
            Debug.Log("Destroyed " + i + " spinners");
        }

        for (int i = 0; i < Turrets.Length; i++)
        {
            if (Turrets[i] != null)
            {
                Turrets[i].GetComponent<Damage>().UpdateDamage(Turrets[i].GetComponent<Damage>().maxHealth);
            }
            Debug.Log("Destroyed " + i + " turrets");
        }

        if (SpinningBoss != null && SpinningBoss.activeInHierarchy)
        {
            SpinningBoss.GetComponent<Damage>().UpdateDamage(SpinningBoss.GetComponent<Damage>().maxHealth);
            Debug.Log("Destroyed the spinning boss");
        }

        if (ShieldBoss != null && ShieldBoss.activeInHierarchy)
        {
            ShieldBoss.GetComponent<Damage>().UpdateDamage(ShieldBoss.GetComponent<Damage>().maxHealth);
            GameObject.FindGameObjectWithTag("Shield").SetActive(false);
            GameObject.Find("ShieldingEnemies").SetActive(false);
            Debug.Log("Destroyed Hilda");
        }
    }

    public void NextCheckpoint()
    {
        GameManagerScript gm = FindObjectOfType<GameManagerScript>();

        // If there's no GameManager, print a message to the console
        if (gm == null)
        {
            Debug.Log("No game manager was found in the scene.");
            return;
        }

        else
        {
            if (canGoToNextCheckpoint)
            {
                // If there's a GM but the player hasn't reached a checkpoint, move them to the first checkpoint in the array
                if (gm.currentCheckpoint == null)
                {
                    gm.currentCheckpoint = gm.Checkpoints[0];
                    Player.transform.position = gm.currentCheckpoint.transform.position;
                }

                // If the player has reached a checkpoint, but is not at the end of the array, move them to the next checkpoint
                else if (gm.currentCheckpoint.GetComponent<CheckpointScript>().checkpointIndex < (gm.Checkpoints.Length - 1))
                {
                    gm.currentCheckpoint = gm.Checkpoints[gm.currentCheckpoint.GetComponent<CheckpointScript>().checkpointIndex + 1];
                    Player.transform.position = gm.currentCheckpoint.transform.position;
                }

                // If the player is at the end of the checkpoint array, move them to the end of the level
                else if (gm.currentCheckpoint.GetComponent<CheckpointScript>().checkpointIndex == gm.Checkpoints.Length - 1)
                {
                    canGoToNextCheckpoint = false;
                    if (FindObjectOfType<NextLevel>() != null)
                    {
                        Player.transform.position = FindObjectOfType<NextLevel>().gameObject.transform.position;
                        Debug.Log("Moved the player to the level exit.");
                        return;
                    }

                    else
                    {
                        Debug.Log("Reached the end of the checkpoint array but could not find any object with a NextLevel script component");
                        return;
                    }
                }
                // If the player was moved to a checkpoint successfully, print a message to the console
                Debug.Log("Moved the player to checkpoint: " + gm.currentCheckpoint.GetComponent<CheckpointScript>().checkpointIndex);
            }

            // If the player absolutely cannot move any further through the level, print a message
            else
            {
                Debug.Log("End of level reached.");
            }
        }
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(KeepVariables.keepLevelName);
    }

    public void SkipLevel()
    {
        string currentLevel = SceneManager.GetActiveScene().name;
        
                switch (currentLevel)
                {
                    case "GB_LevelOne":
                        SceneManager.LoadScene("GB_LevelTwo");
                        break;
                    case "GB_LevelTwo":
                        SceneManager.LoadScene("GB_LevelThree");
                        break;
                    case "GB_LevelThree":
                        SceneManager.LoadScene("WinScene");
                        break;
                    case "Tutorial":
                        SceneManager.LoadScene("BR_MainMenu");
                        break;
                    default:
                        SceneManager.LoadScene("BR_MainMenu");
                        break;
                }
                

        Debug.Log("Not yet working 100%");
    }
}
