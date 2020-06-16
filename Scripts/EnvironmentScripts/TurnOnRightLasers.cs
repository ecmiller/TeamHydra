using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnRightLasers : MonoBehaviour
{
    public GameObject[] rightBeams;
    public GameObject hiddenWall;


    // Start is called before the first frame update
    void Awake()
    {
        rightBeams = GameObject.FindGameObjectsWithTag("RightBeam");
        hiddenWall.SetActive(false);

        foreach (GameObject rightB in rightBeams)
        {
            rightB.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.tag == "RightBeamTriggerBox")
            {
                foreach (GameObject rightB in rightBeams)
                {
                    rightB.SetActive(true);
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
