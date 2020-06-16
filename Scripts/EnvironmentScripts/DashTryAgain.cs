using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTryAgain : MonoBehaviour
{
    public GameObject Canvas;

    public bool isPaused = false;

    // Start is called before the first frame update
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
            pauseGame();

        }
        
    }

    public void Resume()
    {
        Canvas.SetActive(false);
        gameObject.GetComponent<BoxCollider>().enabled = false;
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

    public void pauseGame()
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
