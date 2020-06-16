using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFirewalls : MonoBehaviour
{
    [SerializeField] GameObject[] FireWalls;
    [SerializeField] GameObject[] LightningStrikes;

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < LightningStrikes.Length; i++)
        {
            LightningStrikes[i].SetActive(true);
        }

        Invoke("StartFireWall", 0.1f);
    }

    void StartFireWall()
    {
        for (int i = 0; i < FireWalls.Length; i++)
        {
            FireWalls[i].SetActive(true);
        }
    }
}
