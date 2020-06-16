using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EruptFlamePillar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField] Vector3 spawnValues;
    [SerializeField] GameObject FireSpark;
    private void FlamePillars()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), Random.Range(-spawnValues.z, spawnValues.z));
        Instantiate(FireSpark, spawnPosition + transform.TransformPoint(0, 0, 0), FireSpark.transform.rotation);
    }

    public void StartFlamePillar()
    {
        InvokeRepeating("FlamePillars", 1f, 1f);
    }

    public void StopFlamePillars()
    {
        CancelInvoke("FlamePillars");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
