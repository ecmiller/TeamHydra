using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimIcon: MonoBehaviour
{
    [SerializeField] int currentAimPieces;
    [SerializeField] int maxAimPieces;
    [SerializeField] GameObject[] aimPieces;
    [SerializeField] int health;

    // Start is called before the first frame update
    void Start()
    {
        maxAimPieces = 7;
        currentAimPieces = maxAimPieces;
        aimPieces = GameObject.FindGameObjectsWithTag ("AimPieces");
        health = GameObject.FindGameObjectWithTag ("Player").GetComponent<BR_PlayerHealth> ().GetPlayerHealth ();
    }

    // Update is called once per frame
    void Update ()
    {
        UpdateAimPieces ();
    }

    public void UpdateAimPieces ()
    {
        health = GameObject.FindGameObjectWithTag ("Player").GetComponent<BR_PlayerHealth> ().GetPlayerHealth ();

        switch (health)
        {
            case 7:
                aimPieces[0].gameObject.SetActive (true);
                aimPieces[1].gameObject.SetActive (true);
                aimPieces[2].gameObject.SetActive (true);
                aimPieces[3].gameObject.SetActive (true);
                aimPieces[4].gameObject.SetActive (true);
                aimPieces[5].gameObject.SetActive (true);
                aimPieces[6].gameObject.SetActive (true);
                aimPieces[7].gameObject.SetActive (true);
                aimPieces[8].gameObject.SetActive (true);
                return;

            case 6:
                aimPieces[0].gameObject.SetActive (false);
                aimPieces[1].gameObject.SetActive (true);
                aimPieces[2].gameObject.SetActive (true);
                aimPieces[3].gameObject.SetActive (true);
                aimPieces[4].gameObject.SetActive (true);
                aimPieces[5].gameObject.SetActive (true);
                aimPieces[6].gameObject.SetActive (true);
                aimPieces[7].gameObject.SetActive (true);
                aimPieces[8].gameObject.SetActive (true);
                return;

            case 5:
                aimPieces[0].gameObject.SetActive (false);
                aimPieces[1].gameObject.SetActive (false);
                aimPieces[2].gameObject.SetActive (true);
                aimPieces[3].gameObject.SetActive (true);
                aimPieces[4].gameObject.SetActive (true);
                aimPieces[5].gameObject.SetActive (true);
                aimPieces[6].gameObject.SetActive (true);
                aimPieces[7].gameObject.SetActive (true);
                aimPieces[8].gameObject.SetActive (true);
                return;

            case 4:
                aimPieces[0].gameObject.SetActive (false);
                aimPieces[1].gameObject.SetActive (false);
                aimPieces[2].gameObject.SetActive (false);
                aimPieces[3].gameObject.SetActive (true);
                aimPieces[4].gameObject.SetActive (true);
                aimPieces[5].gameObject.SetActive (true);
                aimPieces[6].gameObject.SetActive (true);
                aimPieces[7].gameObject.SetActive (true);
                aimPieces[8].gameObject.SetActive (true);
                return;

            case 3:
                aimPieces[0].gameObject.SetActive (false);
                aimPieces[1].gameObject.SetActive (false);
                aimPieces[2].gameObject.SetActive (false);
                aimPieces[3].gameObject.SetActive (false);
                aimPieces[4].gameObject.SetActive (true);
                aimPieces[5].gameObject.SetActive (true);
                aimPieces[6].gameObject.SetActive (true);
                aimPieces[7].gameObject.SetActive (true);
                aimPieces[8].gameObject.SetActive (true);
                return;

            case 2:
                aimPieces[0].gameObject.SetActive (false);
                aimPieces[1].gameObject.SetActive (false);
                aimPieces[2].gameObject.SetActive (false);
                aimPieces[3].gameObject.SetActive (false);
                aimPieces[4].gameObject.SetActive (false);
                aimPieces[5].gameObject.SetActive (true);
                aimPieces[6].gameObject.SetActive (true);
                aimPieces[7].gameObject.SetActive (true);
                aimPieces[8].gameObject.SetActive (true);
                return;

            case 1:
                aimPieces[0].gameObject.SetActive (false);
                aimPieces[1].gameObject.SetActive (false);
                aimPieces[2].gameObject.SetActive (false);
                aimPieces[3].gameObject.SetActive (false);
                aimPieces[4].gameObject.SetActive (false);
                aimPieces[5].gameObject.SetActive (false);
                aimPieces[6].gameObject.SetActive (true);
                aimPieces[7].gameObject.SetActive (true);
                aimPieces[8].gameObject.SetActive (true);
                return;

            case 0:
                aimPieces[0].gameObject.SetActive (false);
                aimPieces[1].gameObject.SetActive (false);
                aimPieces[2].gameObject.SetActive (false);
                aimPieces[3].gameObject.SetActive (false);
                aimPieces[4].gameObject.SetActive (false);
                aimPieces[5].gameObject.SetActive (false);
                aimPieces[6].gameObject.SetActive (false);
                aimPieces[7].gameObject.SetActive (false);
                aimPieces[8].gameObject.SetActive (false);
                return;

            default:
                return;
        }

    }

}
