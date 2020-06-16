using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public GameObject Canvas;

    public bool isPaused = false;



    void Start()
    {
     
        Canvas.SetActive(false);

        Time.timeScale = 1f;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Canvas.SetActive(true);
            PauseGame();
            
        }


    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }

    }

    public void Resume()
    {

        Canvas.SetActive(false);

        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    public void IntroResume()
    {

        Canvas.SetActive(false);


        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;

        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
       

    }

    public void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }
}
