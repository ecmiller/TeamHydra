using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

////Author: Ben Murchie
////Purpose: PreProduction project

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject PauseMenuUI;
    [SerializeField] GameObject DeathMenu;
    [SerializeField] GameObject DebugMenuUI;

    public GameObject[] Checkpoints;
    public GameObject currentCheckpoint;

    public bool gamePaused = false;
    bool debugPaused = false;
    public bool pausePaused = false;

    public int levelSaved;

    private BR_AudioManager audioManager;

    public GameObject Player;
    [SerializeField] GameObject PlayerShooter;
    public string nextLevel = "LevelTwo";
    public int levelToUnlock = 2;

    public GameObject Coal;
    public GameObject Crate;
    public GameObject Salt;
    public GameObject CoalShooter;
    public GameObject CrateShooter;
    public GameObject SaltShooter;

    public bool hasSelected;

    public bool VictoryMenuActive;

    public void Awake()
    {
        VictoryMenuActive = false;
        playerPosition.x = PlayerPrefs.GetFloat("XPosition");
        playerPosition.y = PlayerPrefs.GetFloat("YPosition");
        playerPosition.z = PlayerPrefs.GetFloat("ZPosition");
        healthSaved = PlayerPrefs.GetInt("health");
        damageTaken = PlayerPrefs.GetInt("damageTaken");

        Coal = GameObject.Find("Coal");
        Crate = GameObject.Find("Crate");
        Salt = GameObject.Find("Salt");
        CoalShooter = GameObject.Find("CoalProjectileexit");
        CrateShooter = GameObject.Find("CrateProjectileexit");
        SaltShooter = GameObject.Find("SaltProjectileexit");
    }
   
    public void Start()
    {
        if(SceneManager.GetActiveScene().name == "Tutorial")
        {
            Player = Coal;
            PlayerShooter = CoalShooter;
        }
        else if(hasSelected == false)
        {
            if (Coal.activeInHierarchy == true)
            {
                Player = Coal;
                PlayerShooter = CoalShooter;
                hasSelected = true;
            }
            else if (Crate.activeInHierarchy == true)
            {
                Player = Crate;
                PlayerShooter = CrateShooter;
                hasSelected = true;
            }
            else if (Salt.activeInHierarchy == true)
            {
                Player = Salt;
                PlayerShooter = SaltShooter;
                hasSelected = true;
            }
        }


        if (PlayerPrefs.GetInt("reloading") == 1 && SceneManager.GetActiveScene().name != "Tutorial")
        {
            if (Coal.activeInHierarchy == true)
            {
                Coal.transform.position = playerPosition;
                Coal.GetComponent<BR_PlayerHealth>().health = healthSaved;
                Coal.GetComponent<Damage>().damageTaken = damageTaken;
                Coal.GetComponent<BR_PlayerHealth>().UpdateHealthPieces();
                PlayerPrefs.SetInt("reloading", 0);
                hasSelected = true;
            }
            if (Crate.activeInHierarchy == true)
            {
                Crate.transform.position = playerPosition;
                Crate.GetComponent<BR_PlayerHealth>().health = healthSaved;
                Crate.GetComponent<Damage>().damageTaken = damageTaken;
                Crate.GetComponent<BR_PlayerHealth>().UpdateHealthPieces();
                PlayerPrefs.SetInt("reloading", 0);
                hasSelected = true;
            }
            if (Salt.activeInHierarchy == true)
            {
                Salt.transform.position = playerPosition;
                Salt.GetComponent<BR_PlayerHealth>().health = healthSaved;
                Salt.GetComponent<Damage>().damageTaken = damageTaken;
                Salt.GetComponent<BR_PlayerHealth>().UpdateHealthPieces();
                PlayerPrefs.SetInt("reloading", 0);
                hasSelected = true;
            }
        }
        Time.timeScale = 1f;

        audioManager = GameObject.FindObjectOfType<BR_AudioManager>();

        if(audioManager == null)
        {
            UnityEngine.Debug.Log("No audio manager found");
        }

        if (Checkpoints != null)
        {
            if (Checkpoints.Length == 0)
            {
                // If no checkpoints are assigned in the inspector, try finding them by tag
                Checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");

                if (Checkpoints.Length > 0)
                {
                    // If any checkpoints are in the array at this point, set the current checkpoint to the first element of the array
                    currentCheckpoint = Checkpoints[0];
                }

                else
                {
                    currentCheckpoint = null;
                }
            }
        }

        else
            Checkpoints = null;

        if (DeathMenu == null)
        {
            DeathMenu = GameObject.Find("DeathMenu");
        }
        if (DebugMenuUI == null)
        {
            DebugMenuUI = GameObject.Find("DebugMenu");
        }
        if (PauseMenuUI == null)
        {
            PauseMenuUI = GameObject.Find("AK_PauseMenu");
        }
    }

    public void LoadMainMenu()
    {
        GameObject.Find ("AudioManager").GetComponent<BR_AudioManager> ().Play ("ButtonClick");
        SceneManager.LoadScene("BR_MainMenu");
        Pause();
    }

    public void QuitGame()
    {
        GameObject.Find ("AudioManager").GetComponent<BR_AudioManager> ().Play ("ButtonClick");
        Application.Quit();
    }

    public void Resume()
    {
        GameObject.Find ("AudioManager").GetComponent<BR_AudioManager> ().Play ("ButtonClick");
        gamePaused = false;
        pausePaused = false;
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameObject.Find ("CameraHolder").GetComponent<HideMouse> ().UnhideMouseCursor ();
    }

    void Pause()
    {
        pausePaused = !pausePaused;

        if (pausePaused)
        {
            GameObject.Find("AudioManager").GetComponent<BR_AudioManager>().Play("ButtonClick");
            gamePaused = true;
            PauseMenuUI.SetActive(true);

            Time.timeScale = 0f;
        }

        else
        {
            gamePaused = false;
            PauseMenuUI.SetActive(false);
            GameObject.Find ("CameraHolder").GetComponent<HideMouse> ().UnhideMouseCursor ();

            Time.timeScale = 1f;
            if(SceneManager.GetActiveScene().name == "Tutorial")
            {
                Player.GetComponent<BR_PlayerMovement>().enabled = true;
            }
        }
    }

    public void DeathPause()
    {
        GameObject.Find("CameraHolder").GetComponent<HideMouse>().UnhideMouseCursor();
        GameObject.Find("AudioManager").GetComponent<BR_AudioManager>().Play("ButtonClick");
        DeathMenu.SetActive(true);
        DebugMenuUI.SetActive(false);
    }


    public void DebugMenuPause()
    {
        debugPaused = !debugPaused;

        if (debugPaused)
        {
            if(hasSelected == true)
            {
                if(Coal.activeInHierarchy == true)
                {
                    gamePaused = true;
                    DebugMenuUI.SetActive(true);
                    Time.timeScale = 0f;
                    Coal.GetComponent<BR_PlayerHealth>().isDebugMenu = true;
                    hasSelected = true;
                }
                else if (Crate.activeInHierarchy == true)
                {
                    gamePaused = true;
                    DebugMenuUI.SetActive(true);
                    Time.timeScale = 0f;
                    Crate.GetComponent<BR_PlayerHealth>().isDebugMenu = true;
                    hasSelected = true;
                }
                else if (Salt.activeInHierarchy == true)
                {
                    gamePaused = true;
                    DebugMenuUI.SetActive(true);
                    Time.timeScale = 0f;
                    Salt.GetComponent<BR_PlayerHealth>().isDebugMenu = true;
                    hasSelected = true;
                }
            }
        }

        else
        {
            if (hasSelected == true)
            {
                if (Coal.activeInHierarchy == true)
                {
                    gamePaused = false;
                    DebugMenuUI.SetActive(false);
                    Time.timeScale = 1f;
                    Coal.GetComponent<BR_PlayerHealth>().isDebugMenu = false;
                    hasSelected = true;
                }
                else if (Crate.activeInHierarchy == true)
                {
                    gamePaused = false;
                    DebugMenuUI.SetActive(false);
                    Time.timeScale = 1f;
                    Crate.GetComponent<BR_PlayerHealth>().isDebugMenu = false;
                    hasSelected = true;
                }
                else if (Salt.activeInHierarchy == true)
                {
                    gamePaused = false;
                    DebugMenuUI.SetActive(false);
                    Time.timeScale = 1f;
                    Salt.GetComponent<BR_PlayerHealth>().isDebugMenu = false;
                    hasSelected = true;
                }
            }

        }
    }

    public void RespawnPlayer()
    {
        // Kill all enemies in the scene before respawning the player
        EnemyPointValue[] enemies = GameObject.FindObjectsOfType<EnemyPointValue>();

        foreach (EnemyPointValue e in enemies)
        {
            e.enabled = false;
            Destroy(e.gameObject);
        }

        // Remove all bombs from the scene before respawning the player
        Bomb[] bombs = GameObject.FindObjectsOfType<Bomb>();

        foreach (Bomb b in bombs)
        {
            b.enabled = false;
            Destroy(b.gameObject);
        }

        // Stop the arena music if it is playing, and return to the level theme
        if (audioManager != null)
        {
            audioManager.Stop("ArenaMusic");
            audioManager.Stop("BombFuse");
            audioManager.Stop("BombBeep");
            audioManager.Stop("BombExplosion");
            audioManager.Play(SceneManager.GetActiveScene().name);
        }

        Time.timeScale = 1f;
        gamePaused = false;
        DeathMenu.SetActive(false);

        Player.GetComponent<BR_MeleeAttacks>().RevertPlayerChargeMelee();

        if (currentCheckpoint == null)
        {
            // If the player has yet to reach a checkpoint (or no checkpoint exixts), reload the scene upon player death/respawn
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        else 
        {
            if(Checkpoints.Length == 0)
            {
                Player.GetComponent<BR_PlayerHealth>().health = currentCheckpoint.GetComponent<StartCheckpoint>().currentHealth;
                currentCheckpoint.GetComponent<StartCheckpoint>().Reset();
                Player.transform.position = currentCheckpoint.transform.position;
            }
            else if(Checkpoints.Length > 0)
            {
                Player.GetComponent<BR_PlayerHealth>().health = currentCheckpoint.GetComponent<CheckpointScript>().currentHealth;
                currentCheckpoint.GetComponent<CheckpointScript>().Reset();
                Player.transform.position = currentCheckpoint.transform.position;
            }
            //Player.GetComponent<BR_PlayerHealth>().health = currentCheckpoint.GetComponent<CheckpointScript>().currentHealth;

            //currentCheckpoint.GetComponent<CheckpointScript>().Reset();
            //Player.transform.position = currentCheckpoint.transform.position;
        }

        Player.GetComponent<Damage>().damageTaken = damageTaken;
        Player.GetComponent<BR_PlayerHealth>().UpdateHealthPieces();
        Player.SetActive(true);
    }

    public void RespawnEnemies(int checkpointIndex)
    {
        for (int i = checkpointIndex; i < Checkpoints.Length; i++)
        {
            Checkpoints[i].GetComponent<CheckpointScript>().Reset();
        }
    }
    

    public int healthSaved;
    public int damageTaken;
    public int isReloading;
    public int savedLevel;
    Vector3 playerPosition;

    public void SaveScene()
    {
        if (Coal.activeInHierarchy == true)
        {
            playerPosition = Coal.transform.position;
            savedLevel = SceneManager.GetActiveScene().buildIndex;
            healthSaved = Coal.GetComponent<BR_PlayerHealth>().health;
            damageTaken = Coal.GetComponent<Damage>().damageTaken;
            PlayerPrefs.SetInt("damageTaken", damageTaken);
            PlayerPrefs.SetInt("health", healthSaved);
            PlayerPrefs.SetInt("savedScene", savedLevel);
            PlayerPrefs.SetFloat("XPosition", playerPosition.x);
            PlayerPrefs.SetFloat("YPosition", playerPosition.y);
            PlayerPrefs.SetFloat("ZPosition", playerPosition.z);
            hasSelected = true;
        }
        else if (Crate.activeInHierarchy == true)
        {
            playerPosition = Crate.transform.position;
            savedLevel = SceneManager.GetActiveScene().buildIndex;
            healthSaved = Crate.GetComponent<BR_PlayerHealth>().health;
            damageTaken = Crate.GetComponent<Damage>().damageTaken;
            PlayerPrefs.SetInt("damageTaken", damageTaken);
            PlayerPrefs.SetInt("health", healthSaved);
            PlayerPrefs.SetInt("savedScene", savedLevel);
            PlayerPrefs.SetFloat("XPosition", playerPosition.x);
            PlayerPrefs.SetFloat("YPosition", playerPosition.y);
            PlayerPrefs.SetFloat("ZPosition", playerPosition.z);
            hasSelected = true;
        }
        else if (Salt.activeInHierarchy == true)
        {
            playerPosition = Salt.transform.position;
            savedLevel = SceneManager.GetActiveScene().buildIndex;
            healthSaved = Salt.GetComponent<BR_PlayerHealth>().health;
            damageTaken = Salt.GetComponent<Damage>().damageTaken;
            PlayerPrefs.SetInt("damageTaken", damageTaken);
            PlayerPrefs.SetInt("health", healthSaved);
            PlayerPrefs.SetInt("savedScene", savedLevel);
            PlayerPrefs.SetFloat("XPosition", playerPosition.x);
            PlayerPrefs.SetFloat("YPosition", playerPosition.y);
            PlayerPrefs.SetFloat("ZPosition", playerPosition.z);
            hasSelected = true;
        }
    }
    public void LoadPlayer()
    {
        PlayerPrefs.SetInt("reloading", 1);
        savedLevel = PlayerPrefs.GetInt("savedScene");
        
        SceneManager.LoadScene(savedLevel);
    }
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "Tutorial")
        {
            if (Coal.activeInHierarchy == true)
            {
                Player = Coal;
                PlayerShooter = CoalShooter;
                //hasSelected = true;
            }
            else if (Crate.activeInHierarchy == true)
            {
                Player = Crate;
                PlayerShooter = CrateShooter;
                //hasSelected = true;
            }
            else if (Salt.activeInHierarchy == true)
            {
                Player = Salt;
                PlayerShooter = SaltShooter;
                //hasSelected = true;
            }
        }
    
        if (SceneManager.GetActiveScene().name == "OpeningCutscene")
        {
            Player = null;
        }
        if(SceneManager.GetActiveScene().name == "Tutorial")
        {
            Player = Coal;
            Crate = null;
            Salt = null;
        }

        //For testing purposes
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    SceneManager.LoadScene("BR_MainMenu");
        //}


        ////For testing Save / Load feature
        //if (Input.GetKeyDown(KeyCode.Alpha9))
        //{
        //    Player.transform.position = playerPosition;
        //}

        if (gamePaused == true)
        {
            //GameObject.Find ("CameraHolder").GetComponent<HideMouse> ().UnhideMouseCursor ();
        }
        //else
        //{
        //    if(Player != null)
        //    {
        //        if (Player.GetComponentInChildren<BR_PlayerHealth>().GetPlayerHealth() <= 0)
        //        {
        //            //GameObject.Find("CameraHolder").GetComponent<HideMouse>().UnhideMouseCursor();
        //        }
        //        else
        //        {
        //            //GameObject.Find("CameraHolder").GetComponent<HideMouse>().HideMouseCursor();
        //        }
        //    }
            

        //}

        if (Player != null)
        {

            if (VictoryMenuActive == false)
            {
                if (Input.GetKeyDown (KeyCode.Escape))
                {
                    Pause ();
                }

                if (Input.GetKeyDown (KeyCode.BackQuote))
                {
                    DebugMenuPause ();
                }
            }
            else
            {
                gamePaused = true;
            }
           

            if(SceneManager.GetActiveScene ().name == "OpeningCutscene")
            {
                Player = null;
            }

            if (gamePaused == true)
            {
                if(Player != null)
                {
                    Player.GetComponent<BR_MeleeAttacks>().enabled = false;
                    Player.GetComponent<BR_PlayerMovement>().enabled = false;
                    PlayerShooter.GetComponent<BR_ShottingAttacks>().enabled = false;
                    Player.GetComponent<BR_PlayerJump> ().VictoryMenuActive = true;
                    Player.GetComponent<BR_PlayerDash> ().VictoryMenuActive = true;


                }
                
            }
            if (gamePaused != true)
            {
                if(Player != null && SceneManager.GetActiveScene().name != "Tutorial")
                {
                    Player.GetComponent<BR_MeleeAttacks>().enabled = true;
                    Player.GetComponent<BR_PlayerMovement>().enabled = true;
                    PlayerShooter.GetComponent<BR_ShottingAttacks>().enabled = true;
                }
                  
                Player.GetComponent<BR_PlayerJump> ().VictoryMenuActive = false;
                Player.GetComponent<BR_PlayerDash> ().VictoryMenuActive = false;

            }
        }

        if (SceneManager.GetActiveScene().name == "LevelOne")
        {
            if (PlayerPrefs.GetInt("levelReached") == 0)
            {
                PlayerPrefs.SetInt("levelReached", 1);
            }
        }
    }

    public void WinLevel()
    {
        if (levelToUnlock > PlayerPrefs.GetInt("levelReached"))
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }

    }

    public GameObject GetPlayer()
    {
        return Player;
    }

    //public void AssignMenus ()
    //{
    //    PauseMenuUI = GameObject.Find("AK_PauseMenu");
    //    DebugMenuUI = GameObject.Find("DebugMenu");
    //    DeathMenu = GameObject.Find("DeathMenu");

    //    DeathMenu.SetActive(false);
    //    PauseMenuUI.SetActive(false);
    //    DebugMenuUI.SetActive(false);

    //}
    
}
