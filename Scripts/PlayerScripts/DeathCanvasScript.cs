using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathCanvasScript : MonoBehaviour
{
    GameObject GameManager;

    private void Start()
    {
        GameManager = GameObject.Find("GameManager");
        GameObject.Find ("CameraHolder").GetComponent<HideMouse> ().IsDead ();
    }


    public void DeadPlayAgain()
    {
        GameObject.Find("AudioManager").GetComponent<BR_AudioManager>().Play("ButtonClick");
        //GameObject.Find ("CameraHolder").GetComponent<HideMouse> ().HideMouseCursor ();

        // If the player chooses to play again, but has not reached a checkpoint, reload the scene
        if (GameManager.GetComponent<GameManagerScript>().currentCheckpoint == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);   
        }
        else
        {
            GameManager.GetComponent<GameManagerScript>().RespawnPlayer();
        }
        gameObject.SetActive(false);
        GameObject.Find ("CameraHolder").GetComponent<HideMouse> ().NotDead ();
        //GameManager.GetComponent<GameManagerScript> ().isRespawning = false;
    }   

    public void DeadMainMenu()
    {
        GameObject.Find ("AudioManager").GetComponent<BR_AudioManager> ().Play ("ButtonClick");
        SceneManager.LoadScene("BR_MainMenu");
        gameObject.SetActive(false);
    }

}
