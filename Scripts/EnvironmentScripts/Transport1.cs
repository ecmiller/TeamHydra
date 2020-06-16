using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport1 : MonoBehaviour
{
    public bool activateA;

    // Start is called before the first frame update
    void Start()
    {
        activateA = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag ("Player"))
        {
            activateA = true;
        }
    }

    private void OnCollisionExit (Collision collision)
    {
        if (collision.gameObject.CompareTag ("Player"))
        {
            activateA = false;
        }
    }
}
