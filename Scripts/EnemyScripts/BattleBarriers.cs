using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script it attached to the trigger volume/object for the battle

public class BattleBarriers : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] barriers;

    // Start is called before the first frame update
    void Start()
    {
        barriers = gameObject.GetComponentsInChildren<ParticleSystem>(true);
        DisableBarriers();
    }

    public void DisableBarriers()
    {
        foreach (ParticleSystem barrier in barriers)
        {
            barrier.gameObject.SetActive(false);
        }
    }

    public void EnableBarriers()
    {
        foreach (ParticleSystem barrier in barriers)
        {
            barrier.gameObject.SetActive(true);
        }
    }
}
