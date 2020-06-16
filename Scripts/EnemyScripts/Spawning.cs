using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    [SerializeField] private ParticleSystem spawnParticles;
    [SerializeField] private EnemySpawnLocation spawnCircle;
    [SerializeField] private GameObject spawnTrigger;

    // Start is called before the first frame update
    void Start()
    {
        spawnCircle.TurnOffParticles();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spawnCircle.SpawnEnemy();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            spawnTrigger.SetActive(false);
        }
    }

    private void TurnOnParticles()
    {
        spawnCircle.TurnOnParticles();
    }

    private void Spawn()
    {
        spawnCircle.InstantiateEnemy();
    }

    private void Release()
    {
        spawnCircle.TurnOffParticles(); ;

        spawnCircle.ReleaseEnemy();
    }

    public void Reset()
    {
        spawnTrigger.SetActive(true);
    }
}
