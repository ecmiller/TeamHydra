using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgniteBurnEffect : MonoBehaviour
{
    [SerializeField] GameObject BurnEffect;
    public int burnTick = 0;

    private void Update()
    {
        
    }

    public void IgnitePlayer()
    {
        InvokeRepeating("BurnDOT", 0.3f, 1f);
    }

    private void BurnDOT()
    {
        gameObject.GetComponent<Damage>().TakeDamage();
        burnTick++;

        if (gameObject != null)
        {
            BurnOn();
            if (burnTick == 2)
            {
                CancelInvoke("BurnDOT");
                BurnOff();
            }
        }
    }

    public void BurnOn()
    {
        BurnEffect.SetActive(true);
    }

    public void BurnOff()
    {
        BurnEffect.SetActive(false);
    }
}
