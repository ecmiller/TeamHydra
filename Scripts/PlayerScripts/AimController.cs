using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;


public class AimController : MonoBehaviour
{
    public Camera cam;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject PlayerCenter;

    //public GameObject CoalCenter;
    //public GameObject CrateCenter;
    //public GameObject SaltCenter;

    public bool hasSelected;

    //[DllImport ("user32.dll")]
    //static extern bool SetCursorPos (int X, int Y);

    // Start is called before the first frame update
    void Start()
    {
        //PlayerCenter = GameObject.Find("PlayerCenter");
        //CoalCenter = GameObject.Find("CoalCenter");
        //CrateCenter = GameObject.Find("CrateCenter");
        //SaltCenter = GameObject.Find("SaltCenter");
        //Player = GameObject.Find ("GameManager").GetComponent<GameManagerScript> ().Player;

    }

    // Update is called once per frame
    void Update ()
    {
        //if(SceneManager.GetActiveScene().name == "Tutorial")
        //{
        //    PlayerCenter = GameObject.Find("GameManager").GetComponent<GameManagerScript>().Player;
        //    CrateCenter = null;
        //    SaltCenter = null;
        //}

        //else if(hasSelected == false)
        //{
        //    if (CoalCenter.activeInHierarchy == true)
        //    {
        //        PlayerCenter = CoalCenter;
        //        hasSelected = true;
        //    }
        //    if (CrateCenter.activeInHierarchy == true)
        //    {
        //        PlayerCenter = CrateCenter;
        //        hasSelected = true;
        //    }
        //    if (SaltCenter.activeInHierarchy == true)
        //    {
        //        PlayerCenter = SaltCenter;
        //        hasSelected = true;
        //    }
        //}

       
        Player = GameObject.Find ("GameManager").GetComponent<GameManagerScript> ().Player;

            if (Player.name == "Coal")
            {
                PlayerCenter = Player.transform.Find ("CoalBody").gameObject.transform.Find ("CoalCenter").gameObject;
            }
            else if (Player.name == "Crate")
            {
                PlayerCenter = Player.transform.Find ("CrateBody").gameObject.transform.Find ("CrateCenter").gameObject;
            }
            else if (Player.name == "Salt")
            {
                PlayerCenter = Player.transform.Find ("SaltBody").gameObject.transform.Find ("SaltCenter").gameObject;
            }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Ray ray = cam.ViewportPointToRay (cam.ScreenToViewportPoint (Input.mousePosition));
        RaycastHit hit;
        if (Physics.Raycast (ray, out hit, 1000, 1 << LayerMask.NameToLayer("Aimable")))
            if (hit.collider)
            {
                //print ("I'm looking at " + hit.transform.name);
                Vector3 lookAtPosition = new Vector3 (hit.point.x, PlayerCenter.transform.position.y, hit.point.z);
                PlayerCenter.transform.LookAt (lookAtPosition);
                //hit.collider.gameObject.GetComponent<Renderer> ().material.color = Color.red;
            }
            else
                print ("I'm looking at nothing!");

        //this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.parent.transform.position.y, this.gameObject.transform.position.z);
    }
}
