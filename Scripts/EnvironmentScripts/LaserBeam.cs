using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam: MonoBehaviour
{
    [SerializeField] LineRenderer lr;
    [SerializeField] GameObject Coalburn;
    [SerializeField] GameObject Crateburn;
    [SerializeField] GameObject Saltburn;
    // public int burningduration = 2;
    public int burningshutoff = 1;
    [SerializeField] GameObject PauseMenu;

    // Start is called before the first frame update
    void Start ()
    {
        lr = GetComponent<LineRenderer> ();
        Coalburn.gameObject.SetActive(false);
        Crateburn.gameObject.SetActive(false);
        Saltburn.gameObject.SetActive(false);
        PauseMenu = GameObject.Find ("Pause").transform.Find ("AK_PauseMenu").gameObject;

    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        //lr.SetPosition (0, transform.position);
        //RaycastHit hit;
        //if (Physics.Raycast (transform.position, transform.forward, out hit))
        //{
        //    if (hit.collider.gameObject.tag == "LaserBox")
        //    {
        //        lr.SetPosition (1, hit.point);
        //    }
        //    else if (hit.collider.gameObject.tag == "Player")
        //    {
        //        hit.collider.gameObject.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.back * 50, ForceMode.Impulse);
        //        hit.collider.gameObject.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.up * 50, ForceMode.Impulse);
        //        hit.collider.gameObject.GetComponent<BR_PlayerHealth> ().DamagePlayer (1);
        //    }
        //}
        //else
        //{
        //    lr.SetPosition (1, transform.position * 5000);
        //}

        if (this.gameObject.transform.parent.CompareTag("LaserBox"))
        {
            lr.SetPosition (0, transform.position);
            GameObject parent = this.gameObject.transform.parent.gameObject;
            float distance = Vector3.Distance (this.transform.position, parent.transform.Find("LaserStoper").position);
            Debug.Log (distance);
            RaycastHit[] hits = Physics.RaycastAll (transform.position, transform.forward, distance);
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    if (PauseMenu.activeInHierarchy == false)
                    {
                        hit.collider.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0f, 0f, 0f);
                        hit.collider.gameObject.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.back * 50, ForceMode.Impulse);
                        hit.collider.gameObject.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.up * 50, ForceMode.Impulse);
                        hit.collider.gameObject.GetComponent<BR_PlayerHealth> ().DamagePlayer (1);
                        GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<BR_AudioManager> ().Play ("Laser");
                        Coalburn.gameObject.SetActive (true);
                        Invoke ("TurnOffParticles", burningshutoff);
                    }


                }
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    if (PauseMenu.activeInHierarchy == false)
                    {
                        hit.collider.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0f, 0f, 0f);
                        hit.collider.gameObject.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.back * 50, ForceMode.Impulse);
                        hit.collider.gameObject.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.up * 50, ForceMode.Impulse);
                        hit.collider.gameObject.GetComponent<BR_PlayerHealth> ().DamagePlayer (1);
                        GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<BR_AudioManager> ().Play ("Laser");
                        Saltburn.gameObject.SetActive (true);
                        Invoke ("TurnOffParticles", burningshutoff);
                        Crateburn.gameObject.SetActive (true);
                    }
                }
                    
                else if (hit.collider.gameObject.tag == "LaserBox")
                {
                    lr.SetPosition(1, hit.point);

                }
            }
        }

        if (this.gameObject.transform.parent.CompareTag ("MovingLaser"))
        {
            lr.SetPosition (0, transform.position);
            RaycastHit[] hits = Physics.RaycastAll (transform.position, -transform.up);
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    if (PauseMenu.activeInHierarchy == false)
                    {
                        hit.collider.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0f, 0f, 0f);
                        hit.collider.gameObject.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.back * 50, ForceMode.Impulse);
                        hit.collider.gameObject.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.up * 50, ForceMode.Impulse);
                        hit.collider.gameObject.GetComponent<BR_PlayerHealth> ().DamagePlayer (1);
                        GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<BR_AudioManager> ().Play ("Laser");
                        Coalburn.gameObject.SetActive (true);
                        Invoke ("TurnOffParticles", burningshutoff);
                    }
                }
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    if (PauseMenu.activeInHierarchy == false)
                    {
                        hit.collider.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0f, 0f, 0f);
                        hit.collider.gameObject.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.back * 50, ForceMode.Impulse);
                        hit.collider.gameObject.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.up * 50, ForceMode.Impulse);
                        hit.collider.gameObject.GetComponent<BR_PlayerHealth> ().DamagePlayer (1);
                        GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<BR_AudioManager> ().Play ("Laser");
                        Saltburn.gameObject.SetActive (true);
                        Invoke ("TurnOffParticles", burningshutoff);

                        Crateburn.gameObject.SetActive (true);

                    }
                }

                
                else if (hit.collider.gameObject.tag == "Ground")
                {
                    lr.SetPosition (1, hit.point);
                }
            }
        }
        
    }

    public void TurnOnParticles()
    {
        Coalburn.gameObject.SetActive(true);
        Crateburn.gameObject.SetActive(true);
        Saltburn.gameObject.SetActive(true);
    }
    public void TurnOffParticles()
    {
        Coalburn.gameObject.SetActive(false);
        Crateburn.gameObject.SetActive(false);
        Saltburn.gameObject.SetActive(false);
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("Laser(noise)");
        }
               
    }
}