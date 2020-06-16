using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BR_PlayerJump : MonoBehaviour
{
    new Rigidbody rigidbody;

    public float jumpForce;
    public float maxJumpForce;
    public float minJumpForce;
    public float chargeForce;
    public bool hasJumped;
    [SerializeField] int timesJumped;
    [SerializeField] GameObject PlayerBody;
    public bool VictoryMenuActive;

    private void Awake ()
    {
        rigidbody = GetComponent<Rigidbody> ();
        hasJumped = false;
        timesJumped = 0;
        VictoryMenuActive = false;
    }

    // Start is called before the first frame update
    void Start ()
    {
        jumpForce = 300f;
    }

    // Update is called once per frame
    void Update ()
    {
        if (VictoryMenuActive == false)
        {
            Jump ();
        }
    }

    private void Jump ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(timesJumped == 0)
            {
                PlayerBody.GetComponent<Animator>().SetBool("isJumping", true);
            }
            else if(timesJumped == 1)
            {
                PlayerBody.GetComponent<Animator>().SetBool("isDoubleJumping", true);
            }
            if (timesJumped < 2)
            {
                PlayerBody.GetComponent<Animator>().SetBool("playerGrounded", false);
                PlayerBody.transform.localScale = new Vector3(1, 1, 1);
                rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0f, 0f);
                rigidbody.AddRelativeForce(Vector3.up * jumpForce, ForceMode.Impulse);
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("Jump");
                hasJumped = true;
                timesJumped++;
            }
        }
        
    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            PlayerBody.GetComponent<Animator>().SetBool("playerGrounded", true);
            PlayerBody.GetComponent<Animator>().SetBool("isJumping", false);
            PlayerBody.GetComponent<Animator>().SetBool("isDoubleJumping", false);
            hasJumped = false;
            timesJumped = 0;
        }
    }
}
