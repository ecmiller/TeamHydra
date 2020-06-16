using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BR_PlayerDash : MonoBehaviour
{
    new Rigidbody rigidbody;

    public float thrust;

    [SerializeField] GameObject DashMirage;
    [SerializeField] GameObject PlayerBody;
    public bool VictoryMenuActive;


    private void Awake ()
    {
        rigidbody = GetComponent<Rigidbody> ();
        DashMirage = GameObject.Find ("DashMirage");
        DashMirage.SetActive (false);
        VictoryMenuActive = false;

    }
    // Start is called before the first frame update
    void Start ()
    {
        thrust = 550f;
    }

    // Update is called once per frame
    void Update ()
    {
        if (VictoryMenuActive == false)
        {
            if (Input.GetKeyDown (KeyCode.Mouse2))
            {
                if (DashMirage.activeInHierarchy == true)
                {
                    DashMirage.SetActive (false);

                }

                if (this.gameObject.GetComponent<BR_PlayerJump> ().hasJumped == false)
                {
                    //PlayerBody.GetComponent<Animator>().SetTrigger("isDashing");
                    gameObject.transform.localScale = new Vector3(0.7f, 1.0f, 1.0f);
                    rigidbody.velocity = new Vector3 (0f, rigidbody.velocity.y, 0f);
                    DashMirage.SetActive (false);
                    GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<BR_AudioManager> ().Play ("Dash");
                    rigidbody.AddRelativeForce (Vector3.forward * thrust, ForceMode.Impulse);
                    //PlayerBody.GetComponent<Animator>().SetBool("isDashing", false);
                }
                else
                {
                    //PlayerBody.GetComponent<Animator>().SetTrigger("isDashing");
                    rigidbody.velocity = new Vector3 (0f, 0f, 0f);
                    DashMirage.SetActive (false);
                    GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<BR_AudioManager> ().Play ("Dash");
                    rigidbody.AddRelativeForce (Vector3.forward * (thrust - 50), ForceMode.Impulse);
                    //PlayerBody.GetComponent<Animator>().SetBool("isDashing", false);
                }
            }

            if (Input.GetKeyUp(KeyCode.Mouse2))
            {
                gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }
    }
}