using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetricsCoins : MonoBehaviour
{
    public int rotationSpeed = 400;

    private void Start()
    {

        transform.rotation = Quaternion.Euler(90, 0, 0);
       
    }

    private void Update()
    {
       
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            TestCanvasScript.instance.coinCount++;
            TestCanvasScript.instance.UpdateCoinCounterUI();
            Destroy(gameObject);
        }
    }
}
