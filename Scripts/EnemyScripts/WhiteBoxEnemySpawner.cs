using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBoxEnemySpawner : MonoBehaviour
{
    [SerializeField] private ParticleSystem spawnParticles;
    [SerializeField] private GameObject spawnLocation;
    [SerializeField] private Collider trigger;

    public int spawnDelay = 1;

    // Start is called before the first frame update
    void Start()
    {
        spawnParticles.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spawnParticles.gameObject.SetActive(true);

            Invoke("Spawn", spawnDelay);
            
        }
    }

    private void Spawn()
    {
        GetComponent<Animator>().Play("Spawn");

        spawnParticles.gameObject.SetActive(false);
        trigger.enabled = false;
    }
}
