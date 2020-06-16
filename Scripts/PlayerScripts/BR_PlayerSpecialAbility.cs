using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BR_PlayerSpecialAbility : MonoBehaviour
{
    [SerializeField] GameObject SpecialAbility;
    [SerializeField] bool consumedEnemy;
    [SerializeField] int specialPoints;
    [SerializeField] int maxSpecialPoints;

    private void Awake ()
    {
        SpecialAbility = GameObject.FindGameObjectWithTag ("SpecialAbility");
        SpecialAbility.SetActive (false);
        specialPoints = 0;
        maxSpecialPoints = 15;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
        //consumedEnemy = GameObject.FindGameObjectWithTag ("SpecialAbility").GetComponent<SpecialAbility> ().ConsumedEnemy ();
        if (specialPoints >= maxSpecialPoints)
        {
            GameObject.Find ("Shooter").GetComponent<MeshRenderer> ().material.color = Color.red;

            if (Input.GetKeyDown (KeyCode.E))
            {
                SpecialAbility.SetActive (true);
                GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<BR_AudioManager> ().Play ("SpecialAbilityActivate");
            }

            if (SpecialAbility.GetComponent<SpecialAbility> ().ConsumedEnemy () == true)
            {
                SpecialAbility.SetActive (false);
                
                SpecialAbility.GetComponent<SpecialAbility> ().ResetAbility ();
            }
        }
        else
        {
            GameObject.Find ("Shooter").GetComponent<MeshRenderer> ().material.color = Color.white;
        }
    }

    public void AddSpecialPoints ()
    {
        specialPoints++;
    }

    public int GetSpecialPoints ()
    {
        return specialPoints;
    }

    public int GetMaxSpecialPoints ()
    {
        return maxSpecialPoints;
    }

    public void ResetSpecialPoints ()
    {
        specialPoints = 0;
    }

    public void TurnOffSpecialAbility ()
    {
        SpecialAbility.SetActive (false);
    }
}
