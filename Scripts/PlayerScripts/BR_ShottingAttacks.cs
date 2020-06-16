using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class BR_ShottingAttacks : MonoBehaviour
{
    public float pushBackForce;
    public GameObject projectileFire;
    public float projectileSpeed;
    public int damageToGive;

    [SerializeField] bool isSingleShot;
    //[SerializeField] bool isCharge;
    [SerializeField] float chargeTimer;
    [SerializeField] private float chargeShotRange = 100f;

    [SerializeField] LineRenderer line;
    [SerializeField] GameObject PlayerBody;



    // Start is called before the first frame update
    void Start()
    {
        pushBackForce = 10f;
        projectileSpeed = 30f;
        chargeTimer = 0;
        if (line == null)
        {
            line = gameObject.GetComponent<LineRenderer>();
        }
        line.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
            //if (Input.GetKey(KeyCode.Mouse0))
            //{

                //chargeTimer += Time.deltaTime;

                //if (chargeTimer <= 0.4f)
                //{
                    //RaycastHit[] hits = Physics.RaycastAll (transform.position, transform.forward, chargeShotRange);
                    //foreach (RaycastHit hit in hits)
                    //{
                    //    if (hit.collider.gameObject.CompareTag ("Enemy") || hit.collider.gameObject.CompareTag ("SpinningEnemy") || hit.collider.gameObject.CompareTag ("SpinningBoss") || hit.collider.gameObject.CompareTag("Shield"))
                    //    {
                    //        GameObject.FindGameObjectWithTag ("Player").transform.LookAt (hit.collider.transform.position);
                    //    }
                    //}
                    //isSingleShot = true;
                    //isCharge = false;
                    //line.enabled = false;
                //}

                //else if (chargeTimer > 0.4f)
                //{
                //    GameObject.Find ("Player").GetComponent<BR_PlayerMovement> ().isSlowed = true;
                //    isCharge = true;
                //    isSingleShot = false;

                //    line.SetPosition(0, this.transform.position);

                //    Ray ray = new Ray(transform.position, transform.forward);

                //    if(Physics.Raycast(ray, out RaycastHit hit))
                //    {
                //        if(hit.collider != null)
                //        {
                //            line.SetPosition(1, hit.collider.gameObject.transform.position);
                //        }
                //    }

                //    isCharge = true;
                //    isSingleShot = false;

                //    line.enabled = true;
                //}
                //return;
            //}

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
            // Check the timer. If above 0.4f, fire the charged shot. If below, fire the basic fireball.

                if (EventSystem.current.IsPointerOverGameObject ())
                {
                    return;
                }

                //if (isSingleShot == true)
                //{
                    GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<BR_AudioManager> ().Play ("Shoot");
                    //PlayerBody.GetComponent<Animator>().SetTrigger("isShooting");
                    PlayerBody.transform.localScale = new Vector3(0.8f, 1f, 0.8f);
                    GameObject fireball = Instantiate(projectileFire, transform) as GameObject;
                    Rigidbody rb = fireball.GetComponent<Rigidbody>();
                    rb.velocity = transform.forward * projectileSpeed;
                    fireball.transform.parent = null;
                    GameObject Player = GameObject.Find("Player");
                    //Player.GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * pushBackForce, ForceMode.Impulse);
                    isSingleShot = false;
                    return;
                //}

                //if (isCharge == true)
                //{
                    //GameObject.Find ("Player").GetComponent<BR_PlayerMovement> ().isSlowed = false;
                    //GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<BR_AudioManager> ().Play ("Laser");
                    //RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, chargeShotRange);

                    //// Order the list of colliders hit by the raycast based on distance from the player
                    //System.Array.Sort(hits, (x, y) => x.distance.CompareTo(y.distance));

                    //foreach (RaycastHit hit in hits)
                    //{
                    //    Debug.Log("The laser hit " + hit.collider.gameObject.name);

                    //    if (hit.collider.gameObject.CompareTag ("Enemy"))
                    //    {
                    //        if (hit.collider.gameObject.GetComponent<Damage> () == null)
                    //        {
                    //            Debug.Log ("Failed to find the damage script on " + hit.collider.gameObject.name);
                    //        }
                    //        else
                    //        {
                    //            hit.collider.gameObject.GetComponent<Damage> ().TakeDamage ();
                    //        }
                    //    }
                    //    else if (hit.collider.gameObject.CompareTag ("SpinningBoss"))
                    //    {
                    //        if (hit.collider.gameObject.GetComponent<Damage> () == null)
                    //        {
                    //            Debug.Log ("Failed to find the damage script on " + hit.collider.gameObject.name);
                    //        }
                    //        else
                    //        {
                    //            hit.collider.gameObject.GetComponent<Damage> ().TakeDamage ();
                    //        }
                    //    }
                    //    else if (hit.collider.gameObject.CompareTag ("SpinningEnemy"))
                    //    {
                    //        if (hit.collider.gameObject.GetComponent<Damage> () == null)
                    //        {
                    //            Debug.Log ("Failed to find the damage script on " + hit.collider.gameObject.name);
                    //        }
                    //        else
                    //        {
                    //            hit.collider.gameObject.GetComponent<Damage> ().TakeDamage ();
                    //        }
                    //    }
                    //    else if (hit.collider.gameObject.CompareTag("Shield"))
                    //    {
                    //        if (hit.collider.gameObject.GetComponent<Damage>() == null)
                    //        {
                    //            Debug.Log("Failed to find the damage script on " + hit.collider.gameObject.name);
                    //        }
                    //        else
                    //        {
                    //            hit.collider.gameObject.GetComponent<Damage>().TakeDamage();
                    //        }
                    //    }
                    //    else if (hit.collider.gameObject.CompareTag("ShieldBoss"))
                    //    {
                    //        if (hit.collider.gameObject.GetComponent<Damage>() == null)
                    //        {
                    //            Debug.Log("Failed to find the damage script on " + hit.collider.gameObject.name);
                    //        }
                    //        else
                    //        {
                    //            hit.collider.gameObject.GetComponent<Damage>().TakeDamage();
                    //        }
                    //    }
                    //    else if (hit.collider.gameObject.CompareTag("ShieldingEnemies"))
                    //    {
                    //        if (hit.collider.gameObject.GetComponent<Damage>() == null)
                    //        {
                    //            Debug.Log("Failed to find the damage script on " + hit.collider.gameObject.name);
                    //        }
                    //        else
                    //        {
                    //            hit.collider.gameObject.GetComponent<Damage>().TakeDamage();
                    //        }
                    //    }
                    //    else if (hit.collider.gameObject.CompareTag("Turret"))
                    //    {
                    //        if(hit.collider.gameObject.GetComponent<Damage>() == null)
                    //        {
                    //            Debug.Log("Failed to find the damage script on" + hit.collider.gameObject.name);
                    //        }
                    //        else
                    //        {
                    //            hit.collider.gameObject.GetComponent<Damage>().TakeDamage();
                    //        }
                    //    }
                    //    else if (hit.collider.gameObject.CompareTag("Bomb"))
                    //    {
                    //        hit.collider.gameObject.GetComponent<Bomb>().LightFuse();
                    //    }

                    //    // If the raycast hits a wall, register a hit, and stop the raycast.
                    //    else if (hit.collider.gameObject.CompareTag ("Wall"))
                    //    {
                    //        if (hit.collider.GetComponent<NormalWall>() != null)
                    //        {
                    //            hit.collider.GetComponent<NormalWall>().isHit = true;
                    //        }

                    //        isCharge = false;
                    //        return;
                    //    }
                    //}
                //}
            }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            //PlayerBody.GetComponent<Animator>().ResetTrigger("isShooting");
            PlayerBody.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        // Reset the charge timer when the button is released.
        //chargeTimer = 0;
        //line.SetPosition(1, new Vector3(transform.position.x, transform.position.y, 1000));
        //line.enabled = false;
        //isCharge = false;
        //return;
    }
}