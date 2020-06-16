using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    [SerializeField] LineRenderer laserLine;

    [SerializeField] GameObject Coalburn;
    [SerializeField] GameObject Crateburn;
    [SerializeField] GameObject Saltburn;

    public int burningshutoff = 1;
    [SerializeField] GameObject PauseMenu;

    public GameObject Coal;
    public GameObject Crate;
    public GameObject Salt;

    private void Awake()
    {
        Coal = GameObject.Find("Coal");
        Crate = GameObject.Find("Crate");
        Salt = GameObject.Find("Salt");

    }
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        laserLine.startWidth = .6f;
        laserLine.endWidth = .6f;

        Coalburn.gameObject.SetActive(false);
        Crateburn.gameObject.SetActive(false);
        Saltburn.gameObject.SetActive(false);
        PauseMenu = GameObject.Find("Pause").transform.Find("AK_PauseMenu").gameObject;
    }


    void FixedUpdate()
    {

        laserLine.SetPosition(0, startPoint.position);
        laserLine.SetPosition(1, endPoint.position);

        float distance = Vector3.Distance(startPoint.position, endPoint.position);
        RaycastHit[] hits = Physics.RaycastAll(startPoint.position, transform.forward, distance);
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                if (PauseMenu.activeInHierarchy == false)
                {
                    hit.collider.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
                    hit.collider.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * 50, ForceMode.Impulse);
                    hit.collider.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 50, ForceMode.Impulse);
                    hit.collider.gameObject.GetComponent<BR_PlayerHealth>().DamagePlayer(1);
                    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("Laser");
                    if (Coal.activeInHierarchy == true)
                    {
                        Coalburn.gameObject.SetActive(true);
                    }
                    else if (Crate.activeInHierarchy == true)
                    {
                        Crateburn.gameObject.SetActive(true);
                    }
                    else if (Salt.activeInHierarchy == true)
                    {
                        Saltburn.gameObject.SetActive(true);
                    }
                    Invoke("TurnOffParticles", burningshutoff);
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
        if (other.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("Laser(noise)");
        }

    }
}
