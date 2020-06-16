using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalWall : MonoBehaviour
{
    public bool isHit;

    private void Awake ()
    {
        isHit = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            isHit = true;
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("MainWall");
        }
    }

}
