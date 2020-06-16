using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpText : MonoBehaviour
{
    public GameObject pText;

    // Start is called before the first frame update
    void Start()
    {
        pText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
         if(other.CompareTag("Player"))
        {
            pText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            pText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
