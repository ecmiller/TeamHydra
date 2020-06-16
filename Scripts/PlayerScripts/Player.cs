using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int health;
    //public int savedLevel;
    public bool isReloaded = false;
    GameObject Character;
    GameObject GameManager;

    private void Awake()
    {
        GameManager = GameObject.Find("GameManager");

        Character = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        health = gameObject.GetComponent<BR_PlayerHealth>().health;
        //GameManager.GetComponent<GameManagerScript>().levelSaved = savedLevel;
    }

    public void SavePlayer()
    {
        SaveLoadManager.SavePlayer(this);
    }
}
