using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tripwire : MonoBehaviour
{

    [SerializeField] LineRenderer line;
    [SerializeField] GameObject trapDoor;

    [SerializeField] GameObject Coalburn;
    [SerializeField] GameObject Crateburn;
    [SerializeField] GameObject Saltburn;
    public int burningshutoff = 1;

    [SerializeField] GameObject explosion;

    public float pushBackForce;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        trapDoor.SetActive(true);

        Coalburn.gameObject.SetActive(false);
        Crateburn.gameObject.SetActive(false);
        Saltburn.gameObject.SetActive(false);

        explosion.gameObject.SetActive(false);

        pushBackForce = 125f;
    }

    void Update()
    {
        if (this.gameObject.transform.parent.CompareTag("Tripwire"))
        {
            line.SetPosition(0, transform.position);
            GameObject parent = this.gameObject.transform.parent.gameObject;
            float distance = Vector3.Distance(this.transform.position, parent.transform.Find("TripwireStop").position);
            //Debug.Log(distance);
            RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, distance);
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
       

                    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("TripwireHit");
                    trapDoor.SetActive(false);
                    hit.collider.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * pushBackForce, ForceMode.Impulse);
                    Coalburn.gameObject.SetActive(true);
                    Invoke("TurnOffParticles", burningshutoff);

                    explosion.gameObject.SetActive(true);
                    Invoke("TurnOffParticles", burningshutoff);

                }
                else if (hit.collider.gameObject.tag == "Tripwire")
                {
                    line.SetPosition(1, hit.point);
                }
            }
        }
    }

    public void TurnOnParticles()
    {
        Coalburn.gameObject.SetActive(true);
        Crateburn.gameObject.SetActive(true);
        Saltburn.gameObject.SetActive(true);
        explosion.gameObject.SetActive(true);
    }
    public void TurnOffParticles()
    {
        Coalburn.gameObject.SetActive(false);
        Crateburn.gameObject.SetActive(false);
        Saltburn.gameObject.SetActive(false);
        explosion.gameObject.SetActive(false);
    }

}
