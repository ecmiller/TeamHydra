using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0.35f;
        }
    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 1f;
        }
    }
}
