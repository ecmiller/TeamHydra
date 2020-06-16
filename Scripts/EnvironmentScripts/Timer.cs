using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public static Timer instance;
    private float startTime;
    public bool gameRestart;
    public GameObject deathMenu;

    // Start is called before the first frame update
    void Start()
    {
        deathMenu = GameObject.Find("DeathMenu");
        //deathMenu.SetActive(false);
        if (instance == null)
        {
            instance = this;
        }
            
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
        startTime = Time.time;
        gameRestart = false;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("00");

        timerText.text = minutes + ":" + seconds;

        if(t >= 120f)
        {
            SceneManager.LoadScene("LoseScene");
            
            Destroy(gameObject);
        }
        if (SceneManager.GetActiveScene().name == "WinScene")
        {
            Destroy(gameObject);
        }
        if(SceneManager.GetActiveScene().name == "BR_MainMenu")
        {
            Destroy(gameObject);
        }
        if(SceneManager.GetActiveScene().name == "LevelOne")
        {
            if(deathMenu != null)
            {
                if (deathMenu.activeInHierarchy == true)
                {
                    Destroy(this.gameObject);
                }
            }
            //if (deathMenu.activeInHierarchy == true)
            //{
            //    Destroy(this.gameObject);
            //}
        }

    }

}
