using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDown : MonoBehaviour
{
    public Transform theDest;
    public GameObject bomb;
    public GameObject pbomb;
    public Rigidbody rb;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))

        {
            Destroy(bomb);
            pbomb.SetActive(true);
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }


        ////if (other.CompareTag("Wall")) 
        //{

        //    rb.constraints = RigidbodyConstraints.None;

        //}
    }

        public void Update()
    {
        if(Input.GetKey(KeyCode.R))
        { 
           rb.constraints = RigidbodyConstraints.None;
        }
    }



    //GetComponent<CapsuleCollider>().enabled = false;
    //GetComponent<Rigidbody>().useGravity = false;
    //this.transform.position = theDest.transform.position;

    //    }
    //else
    //{
    //    this.transform.parent = null;
    //    GetComponent<Rigidbody>().useGravity = true;
    //    GetComponent<CapsuleCollider>().enabled = true;

    //}


}
