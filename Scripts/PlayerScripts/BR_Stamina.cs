using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BR_Stamina : MonoBehaviour
{
    [SerializeField] float stamina;
    [SerializeField] float stamDecrease;
    [SerializeField] float maxStamina;
    [SerializeField] bool stamAtMax;
    [SerializeField] GameObject StaminaBar;
    [SerializeField] bool canStamDrain;

    private void Awake ()
    {
        stamina = 0;
        maxStamina = 100;
        stamDecrease = 80;
        stamAtMax = false;
        StaminaBar = GameObject.FindGameObjectWithTag ("StaminaBar");
        StaminaBar.SetActive (false);
        canStamDrain = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stamina > 0)
        {
            if (canStamDrain == true)
            {
                stamina -= stamDecrease * Time.deltaTime;
            }
            StaminaBar.SetActive (true);
        }
        else if (stamina < 0)
        {
            stamina = 0;
            StaminaBar.SetActive (false);
        }

        if (stamina >= maxStamina)
        {
            StartCoroutine (StaminaMaxed ());
        }
        else
        {
            stamAtMax = false;
            StaminaBar.GetComponent<MeshRenderer> ().material.color = Color.white;

        }

        StaminaBar.transform.localScale = new Vector3 (.2f, Mathf.InverseLerp (0, maxStamina, stamina), .1f);
    }

    private IEnumerator StaminaMaxed ()
    {

        canStamDrain = false;
        stamAtMax = true;
        StaminaBar.GetComponent<MeshRenderer> ().material.color = Color.red;

        yield return new WaitForSeconds (.1f);

        canStamDrain = true;
    }

    public bool StamAtMax ()
    {
        return stamAtMax;
    }

    public void StaminaCost (float staminaCost)
    {
        stamina += staminaCost;
    }

}
