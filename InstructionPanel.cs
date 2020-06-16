using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEditor;
using System.Net.Http.Headers;

public class InstructionPanel : MonoBehaviour
{
    //[SerializeField] GameObject Player;

    [SerializeField] GameObject InstructionCanvas;

    [SerializeField] TextMeshProUGUI InstructionsText;

    [SerializeField] int InstructPanelNumber;
    [SerializeField] GameObject ActivateCanvas;

    public bool isOn;
    public bool canActivate;

    //public GameObject Coal;
    //public GameObject Crate;
    //public GameObject Salt;

    //[SerializeField] GameObject Ring;
    [SerializeField] GameObject Light;

    [SerializeField] Color coalColor;
    [SerializeField] Color crateColor;
    [SerializeField] Color saltColor;
    public Color currentColor;

    [SerializeField] GameObject GameManager;

    // Start is called before the first frame update
    void Start()
    {
        InstructionCanvas.gameObject.SetActive (false);
        ActivateCanvas.gameObject.SetActive (false);
        Light.GetComponent<Light> ().color = Color.white;
        coalColor = new Color (0.01568628f, 0.627451f, 1f);
        crateColor = new Color (1, 0.5782526f, 0);
        saltColor = new Color (0.8584906f, 0, 0.5635675f);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.E) && canActivate)
        {
            if (canActivate == true)
            {
                InstructionPanelActivation();
            }
        }
    }

    private void InstructionPanelActivation ()
    {
        isOn = !isOn;

        if (isOn == true)
        {
            InstructionCanvas.gameObject.SetActive (true);
            ActivateCanvas.gameObject.SetActive (false);
            GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<BR_AudioManager> ().Play ("PanelOn");

            if (InstructPanelNumber == 0)
            {
                InstructionsText.text =
                    "Gate closed." + "\n" +
                    "Activate switch to proceed." + "\n" +
                    "(Good luck with that.)";
            }
            else if (InstructPanelNumber == 1)
            {
                InstructionsText.text =
                    "Laser pit active." + "\n" +
                    "Power the lasers off for safety.";
            }
            else if (InstructPanelNumber == 2)
            {
                InstructionsText.text =
                "Unauthorized personnel will be attacked.";
            }
            else if (InstructPanelNumber == 3)
            {
                InstructionsText.text =
                    "Caution: Bombs go KABOOM.";
            }
            else if (InstructPanelNumber == 4)
            {
                InstructionsText.text =
                    "Do not play with the laser." + "\n" +
                    "(It tends to melt things.)";
            }
            else if (InstructPanelNumber == 5)
            {
                InstructionsText.text =
               "Entering Anti-Cube Territory";
            }
            else if (InstructPanelNumber == 6)
            {
                InstructionsText.text =
               "Temperature: 117º Fahrenheit" + "\n" +
               "Humidity: 40% ";
            }
            else if (InstructPanelNumber == 7)
            {
                InstructionsText.text =
               "ERROR" + "\n" +
               "System Failure Detected" + "\n" +
               "ERROR";
            }
            else if (InstructPanelNumber == 8)
            {
                InstructionsText.text =
               "WARNING:" + "\n" +
               "Barrier requires 3 AA crystals" + "\n" +
               "to function." + "\n" + "(Sold separately)";
            }

        }
        else
        {
            InstructionCanvas.gameObject.SetActive (false);
            GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<BR_AudioManager> ().Play ("PanelOff");
        }
    
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canActivate = true;

            switch (other.gameObject.name)
            {
                case ("Coal"):
                    currentColor = coalColor;
                    break;
                case ("Crate"):
                    currentColor = crateColor;
                    break;
                case ("Salt"):
                    currentColor = saltColor;
                    break;
                default:
                    Debug.Log("Failed to identify the player character interacting with instrcution panel");
                    break;
            }

            //Ring.GetComponent<MeshRenderer> ().material.color = Color.green;
            Light.GetComponent<Light> ().color = currentColor;

            if (isOn == false)
            {
                ActivateCanvas.gameObject.SetActive (true);
            }
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.CompareTag ("Player"))
        {            
            if (isOn == true)
            {
                GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<BR_AudioManager> ().Play ("PanelOff");
            }

            canActivate = false;
            isOn = false;
            InstructionCanvas.SetActive (false);
            ActivateCanvas.gameObject.SetActive (false);
            //Ring.GetComponent<MeshRenderer> ().material.color = Color.white;
            Light.GetComponent<Light> ().color = Color.white;
        }
    }

    public void Close ()
    {
        isOn = false;
        InstructionCanvas.SetActive (false);
        ActivateCanvas.gameObject.SetActive (false);
        GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<BR_AudioManager> ().Play ("PanelOff");
    }
}
