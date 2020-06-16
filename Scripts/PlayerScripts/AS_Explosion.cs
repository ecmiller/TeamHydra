using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AS_Explosion : MonoBehaviour
{
    public GameObject explosionVFX;



    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        Destroy(gameObject);
        Instantiate(explosionVFX, transform.position, transform.rotation);
    }
}
