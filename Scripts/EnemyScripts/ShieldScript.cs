using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShieldScript : MonoBehaviour
{
    [SerializeField]
    public GameObject bossEnemy;

    public GameObject bossShield;

    [SerializeField]
    public GameObject bossShieldBarHolder;

    [SerializeField]
    public Slider bossShieldSlider;

    public bool isBossActive;

    public int bossDamageTaken;


    private void Awake()
    {
        bossDamageTaken = bossEnemy.GetComponent<Damage>().damageTaken;
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

    private void Start()
    {
        bossShieldBarHolder = GameObject.Find("ShieldBarHolder");

    }
    // Update is called once per frame
    void Update()
    {
        if (isBossActive == true)

        {
            if (bossEnemy != null)
            {
                bossShieldBarHolder.SetActive(true);
                bossShieldSlider.value = bossShield.GetComponent<Damage>().maxHealth - bossShield.GetComponent<Damage>().damageTaken;
            }
        }
        else
        {
            bossShieldBarHolder.SetActive(false);
        }
    }

    public void ActivateBoss()
    {
        bossEnemy.SetActive(true);
    }
}
