using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

////Author: Ben Murchie
////Purpose: PreProduction project

public class BossHealthBar : MonoBehaviour
{

    [SerializeField]
    public GameObject bossEnemy;

    [SerializeField]
    public GameObject bossHealthBarHolder;

    [SerializeField]
    public GameObject bossShieldHolder;
    
    [SerializeField]
    public Slider bossHealthSlider;

    public bool isBossActive;


    private void Awake ()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name != "BM_ActionBlock")
        {
            isBossActive = false;
            bossEnemy.SetActive(false);
        }
        else
        {
            isBossActive = true;
            bossEnemy.SetActive(true);
        }
    }

    private void Start ()
    {
        bossHealthBarHolder = GameObject.Find ("HealthBarHolder");
      
    }
    // Update is called once per frame
    void Update()
    {
        if (isBossActive == true)

        {
            if(bossEnemy != null)
            {
                bossHealthBarHolder.SetActive(true);
                bossHealthSlider.value = bossEnemy.GetComponent<Damage>().maxHealth - bossEnemy.GetComponent<Damage>().damageTaken;
            }
        }

        else
        {
            bossHealthBarHolder.SetActive(false);
        }
    }

    public void ActivateBoss ()
    {
        bossEnemy.SetActive (true);
    }

}
