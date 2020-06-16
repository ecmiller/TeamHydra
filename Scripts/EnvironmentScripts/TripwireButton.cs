using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TripwireButton : MonoBehaviour
{
    public Text text;
    public GameObject Panel;
    public GameObject[] TripWire;
    public GameObject[] BeamWire;
    public GameObject spikeWall;

    public bool button1;
    public bool button2;

    [SerializeField] GameObject Light;


    
    void Start()
    {
        TripWire = GameObject.FindGameObjectsWithTag("TripOne");
        BeamWire = GameObject.FindGameObjectsWithTag("TripTwo");
        spikeWall = GameObject.FindGameObjectWithTag("SpikeWall");
        text = GetComponentInChildren<Text>();
        text.enabled = false;
        Panel.SetActive(false);

        button1 = false;
        button2 = false;

        Light = this.transform.Find ("button").gameObject.transform.Find("Point Light").gameObject;

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Untagged"))
        {
            if(gameObject.CompareTag("ButtonOne"))
            {
                button1 = true;
            }
            if(gameObject.CompareTag("ButtonTwo"))
            {
                button2 = true;
            }

        }
        text.enabled = true;
        Panel.SetActive(true);
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Untagged"))
        {
            text.enabled = false;
            Panel.SetActive(false);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (button1)
            {
                Invoke("TurnOff1", 1f);
            }

            if (button2)
            {
                Invoke("TurnOff2", 1f);
            }
        }
    }

    public void TurnOff1()
    {
        
        foreach (GameObject tripwire in TripWire)
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("TripwireButton");
            tripwire.SetActive(false);
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("Tripwire");
            text.enabled = false;
            Panel.SetActive(false);
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            button1 = false;
            spikeWall.SetActive(false);
            Light.SetActive (false);
            this.transform.Find ("button").GetComponent<MeshRenderer> ().material.color = new Color (.5f, .5f, .5f);
        }
    }

    public void TurnOff2()
    {

        foreach (GameObject beam in BeamWire)
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("TripwireButton");
            beam.SetActive(false);
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("Tripwire");
            text.enabled = false;
            Panel.SetActive(false);
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            button2 = false;
            Light.SetActive (false);
            this.transform.Find ("button").GetComponent<MeshRenderer> ().material.color = new Color (.5f, .5f, .5f);

        }
    }

    public void ResetTrap()
    {
        foreach (GameObject tripwire in TripWire)
        {
            tripwire.SetActive(true);
            this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        }

        foreach (GameObject beam in BeamWire)
        {
            beam.SetActive(false);
            this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        }

        spikeWall.SetActive(true);
        text.enabled = false;
        Panel.SetActive(false);
        button1 = false;
        button2 = false;
        Light.SetActive (true);
        this.transform.Find ("button").GetComponent<MeshRenderer> ().material.color = new Color (0.9056604f, 0.05980774f, 0.05980774f);
    }
}
