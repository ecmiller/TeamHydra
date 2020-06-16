using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaycastReflection : MonoBehaviour
{

    [SerializeField] int reflections;
    [SerializeField] float maxLength;

    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Ray ray;
    [SerializeField] RaycastHit hit;
    [SerializeField] Vector3 direction;
    [SerializeField] GameObject MetalWall;
    [SerializeField] GameObject PauseMenu;


    [SerializeField] GameObject Coalburn;
    [SerializeField] GameObject Crateburn;
    [SerializeField] GameObject Saltburn;
    public int burningshutoff = 1;


    private void Awake ()
    {
        lineRenderer = GetComponent<LineRenderer> ();
        PauseMenu = GameObject.Find("Pause").transform.Find("AK_PauseMenu").gameObject;

        // Coal
        if (Coalburn != null)
        {
            Coalburn.gameObject.SetActive(false);
        }
        else
        {
            AssignBurn(Coalburn);
        }

        // Crate
        if (Crateburn != null)
        {
            Crateburn.gameObject.SetActive(false);
        }

        else
        {
            AssignBurn(Crateburn);
        }

        // Salt
        if (Saltburn != null)
        {
            Saltburn.gameObject.SetActive(false);
        }
        else
        {
            AssignBurn(Saltburn);
        }
    }

    private void FixedUpdate ()
    {
        ray = new Ray (transform.position, transform.forward);

        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition (0, transform.position);
        float remainingLength = maxLength;
        int layerMask = 1;

        for (int i = 0; i < reflections; i++)
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength, layerMask))
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
                remainingLength -= Vector3.Distance(ray.origin, hit.point);
                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));

                if (!hit.collider.CompareTag("ReflectiveWall"))
                {
                    if (hit.collider.CompareTag("Wall"))
                    {
                        lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
                        break;
                    }

                    if (hit.collider.CompareTag("MetalWall"))
                    {
                        if (MetalWall != null)
                        {
                            MetalWall.GetComponent<NewMetalWall>().MeltWall();
                        }
                    }

                    if (hit.collider.CompareTag("Crystal"))
                    {
                        MetalWall = hit.collider.gameObject;
                        hit.collider.gameObject.GetComponent<MetalWall>().heatUp = true;
                    }

                    else if (MetalWall != null)
                    {
                        MetalWall.GetComponent<MetalWall>().heatUp = false;
                    }


                    if (hit.collider.gameObject.CompareTag("Player"))
                    {
                        if (PauseMenu.activeInHierarchy == false)
                        {
                            hit.collider.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
                            hit.collider.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * 50, ForceMode.Impulse);
                            hit.collider.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 50, ForceMode.Impulse);
                            hit.collider.gameObject.GetComponent<BR_PlayerHealth>().DamagePlayer(1);
                            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("Laser");

                            TurnOnParticles();
                            Invoke("TurnOffParticles", burningshutoff);
                        }
                    }
                    break;
                }
            }

            else
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * remainingLength);

                if (hit.collider.GetComponent<MeshRenderer>() != null && hit.collider.GetComponent<MeshRenderer>().enabled == true)
                {
                    hit.collider.GetComponent<MeshRenderer>().material.color = Color.red;
                    Color color = hit.collider.GetComponent<MeshRenderer>().material.color;
                    hit.collider.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", color *= 3.5f);
                }
            }
        }
    }

    private void AssignBurn(GameObject burn)
    {
        burn = GameObject.Find("GameManager").GetComponent<GameManagerScript>().GetPlayer().GetComponentInChildren<BurnScript>().gameObject;
        burn.SetActive(false);
    }

    private void OnCollisionEnter (Collision collision)
    {
        Debug.Log (collision.gameObject.name);
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

    public void DeactivateLaser ()
    {
        this.gameObject.SetActive (false);
    }
}
