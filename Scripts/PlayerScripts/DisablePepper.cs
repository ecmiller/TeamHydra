using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePepper : MonoBehaviour
{
    public GameObject pepper;
    // Start is called before the first frame update
    void Awake()
    {
        pepper = GameObject.Find("Pepper");
        pepper.SetActive(true);
    }

    public void OnEnable()
    {
        pepper.GetComponent<Rigidbody>().useGravity = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pepper")
        {
            pepper.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
