using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{    private GameObject instantiatedObj;
    public GameObject bombPrefab;
    public float bombFuseLength = 1.25f;
    public GameObject bombSpawnPoint;
    public float spawnDelay = 0.5f;
    public bool spawnerReady;
    public MeshRenderer[] meshes;

    // Start is called before the first frame update
    void Start()
    {
        if(bombPrefab == null)
        {
            Debug.Log("No bomb prefab found for " + gameObject.name);
        }

        if (meshes.Length == 0)
        {
            Debug.Log("No mesh renderers found for the bomb spawner " + gameObject.name);
        }

        else
        {
            ChangeColor(Color.green);
        }

        spawnerReady = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (spawnerReady)
        {
            if (other.CompareTag("Player") && other.isTrigger == false)
            {
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("BombSpawnRed");
                Invoke("SpawnBomb", spawnDelay);
                spawnerReady = false;
            }

            else if (other.CompareTag("Bomb"))
            {
                other.gameObject.GetComponent<Bomb>().LightFuse(bombFuseLength);
                spawnerReady = false;
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("BombSpawnRed");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Bomb"))
        {
            if (other.GetComponent<Bomb>().isLit == false)
            {
                other.GetComponent<Bomb>().LightFuse();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bomb"))
        {
            ResetTrigger();
        }
    }

    public void Update()
    {
        if (spawnerReady)
        {
            ChangeColor(Color.green);
        }

        else
        {
            ChangeColor(Color.red);
        }
    }    public void NoBomb()
    {
        if (instantiatedObj != null)
        {
            Destroy(instantiatedObj);
        }
    }

    public void SpawnBomb()
    {
        instantiatedObj = Instantiate(bombPrefab, bombSpawnPoint.transform.position, bombSpawnPoint.transform.rotation);
        Invoke("ResetTrigger", 3.2f);
    }

    public void ResetTrigger()
    {
        ChangeColor(Color.green);
        spawnerReady = true;
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("BombSpawnGreen");
    }

    private void ChangeColor (Color color)
    {
        foreach(MeshRenderer m in meshes)
        {
            m.material.color = color;
        }
    }
}
