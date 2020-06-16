using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using System.Runtime.CompilerServices;

public class ScoreScript : MonoBehaviour

{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiplierText;
    public bool activateMultiplier;
    public float multiplierNumber;
    public float score = 0;
    public float timer;

    public float playTime;
    private float startTime;
    [SerializeField] GameObject MultiplierBar;


    // Start is called before the first frame update

    void Start()
    {
        score = 0;
        activateMultiplier = false;
        timer = 3;
        multiplierText.enabled = false;
        multiplierNumber = 1;

        startTime = Time.time;
        MultiplierBar.SetActive (false);
    }

    public void Update()
    {
        scoreText.text = "Score: " + score;
        multiplierText.text = "x" + multiplierNumber;


        if (activateMultiplier == true)
        {
            multiplierText.enabled = true;
            MultiplierBar.SetActive (true);

            if (timer > 0)
            {
                timer -= Time.deltaTime;
                MultiplierBar.GetComponent<Slider> ().value = timer;
            }
            else
            {
                activateMultiplier = false;
            }
        }
        else
        {
            multiplierText.enabled = false;
            MultiplierBar.SetActive (false);
            timer = 3;
            multiplierNumber = 1;
        }

        if (multiplierNumber >= 5)
        {
            multiplierNumber = 5;
        }
    }

    public void AddToScore ()
    {
        score += (75 + multiplierNumber) * 10;
    }

    public void DecreaseScore (float remove)
    {
        score -= remove;
    }

    public void DeactivateMultiplier ()
    {
        activateMultiplier = false;
        multiplierText.enabled = false;
        timer = 3;
        multiplierNumber = 1;
    }
}