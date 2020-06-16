using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawnLocation : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject spawnLocation;
    [SerializeField] private ParticleSystem spawnParticles;

    public int particleDelay = 0;
    public int spawnDelay = 1;

    // Start is called before the first frame update
    void Start()
    {
        spawnParticles.gameObject.SetActive(false);
    }

    public void SpawnEnemy()
    {
        Invoke("TurnOnParticles", particleDelay);
        gameObject.GetComponent<Animator>().Play("EnemySpawn");
        Invoke("InstantiateEnemy", spawnDelay);
        Invoke("ReleaseEnemy", spawnDelay);
    }

    public void ReleaseEnemy()
    {
        enemyPrefab.GetComponent<EnemyMovement>().EnableNav();
        enemyPrefab.GetComponent<EnemyMovement>().isActive = true;
        TurnOffParticles();
    }

    public void InstantiateEnemy ()
    {
        Instantiate(enemyPrefab, spawnLocation.transform.position, spawnLocation.transform.rotation, spawnLocation.transform);
        Debug.Log(name + " spawned " + enemyPrefab);
    }

    public void TurnOnParticles()
    {
        spawnParticles.gameObject.SetActive(true);
    }

    public void TurnOffParticles()
    {
        spawnParticles.gameObject.SetActive(false);
    }
}
