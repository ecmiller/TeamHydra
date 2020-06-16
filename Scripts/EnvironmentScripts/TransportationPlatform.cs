using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportationPlatform : MonoBehaviour
{
    [SerializeField] GameObject platform1;
    [SerializeField] GameObject platform2;
    [SerializeField] float timerA;
    [SerializeField] float timerB;
    [SerializeField] float maxtime;
    [SerializeField] bool activateA;
    [SerializeField] bool activateB;
    [SerializeField] GameObject player;


    // Start is called before the first frame update
    void Start()
    {
       
        timerA = 0;
        timerB = 0;
        maxtime = 2f;
        player = GameObject.FindGameObjectWithTag ("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // check if player is standing on the platform
        activateA = platform1.GetComponent<Transport1> ().activateA;
        activateB = platform2.GetComponent<Transport2> ().activateB;

        // what happens if player stand on platfrom 1
        PlatfromOneTeleporter ();

        // what happens if player stand on platfrom 2
        PlatfromTwoTeleporter ();

    }

    private void PlatfromOneTeleporter ()
    {
        // what happens if player stand on platfrom 1
        if (activateA == true)
        {
            // start timer
            timerA += Time.deltaTime;
            platform1.GetComponent<Renderer> ().material.color = Color.Lerp (Color.black, Color.green, timerA);

            // teleport player after 3 max time
            if (timerA >= maxtime)
            {
                player.gameObject.transform.position = new Vector3 (platform2.gameObject.transform.position.x, platform2.gameObject.transform.position.y + 2, platform2.gameObject.transform.position.z);
            }
        }
        else
        {
            timerA = 0;
            platform1.GetComponent<Renderer> ().material.color = Color.Lerp (Color.black, Color.green, timerA);
        }

    }

    private void PlatfromTwoTeleporter ()
    {
        
        if (activateB == true)
        {
            // start timer
            timerB += Time.deltaTime;
            platform2.GetComponent<Renderer> ().material.color = Color.Lerp (Color.black, Color.green, timerB);

            // teleport player after 3 max time
            if (timerB >= maxtime)
            {
                player.gameObject.transform.position = new Vector3 (platform1.gameObject.transform.position.x, platform1.gameObject.transform.position.y + 2, platform1.gameObject.transform.position.z);
            }
        }
        else
        {
            timerB = 0;
            platform2.GetComponent<Renderer> ().material.color = Color.Lerp (Color.black, Color.green, timerB);
        }

    }

}
