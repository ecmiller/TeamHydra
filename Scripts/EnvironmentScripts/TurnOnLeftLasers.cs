using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLeftLasers : MonoBehaviour
{
    public GameObject[] leftBeams;
    public GameObject hiddenWall;

    // Start is called before the first frame update
    void Awake()
    {
        leftBeams = GameObject.FindGameObjectsWithTag("LeftBeam");
        hiddenWall.SetActive(false);

        foreach (GameObject leftB in leftBeams)
        {
            leftB.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(gameObject.tag == "LeftBeamTriggerBox")
            {
                foreach (GameObject leftB in leftBeams)
                {
                    leftB.SetActive(true);
                    hiddenWall.SetActive(true);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
