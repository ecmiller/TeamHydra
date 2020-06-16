using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WhiteBoxEnemyMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator anim;
    private GameObject thePlayer;
    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {        
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            Debug.Log("No nav agent found on " + name);
        }

        anim = GetComponent<Animator>();

        if(anim == null)
        {
            Debug.Log("No animtor component found on " + name);
        }

        thePlayer = GameObject.FindGameObjectWithTag("Player");

        if(thePlayer == null)
        {
            Debug.Log("Player not found.");
        }

        isActive = true;
        anim.SetBool("isHopping", true);
    }

    void Update()
    {
        if (isActive && anim.GetBool("isAttacking") == true) // This is toggle ON by the spawner script
        {
            SeekPlayer();
            
        }

        //Vector3 thePlayerPosition = new Vector3(thePlayer.transform.position.x, transform.position.y, thePlayer.transform.position.z);
       // transform.LookAt(thePlayerPosition);
        //Quaternion.LookRotation(thePlayer.transform.position, thePlayer.transform.position);
    }

    public IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }

    public void EnableNav()
    {
        gameObject.GetComponent<NavMeshAgent>().enabled = true;
        isActive = true;
        Debug.Log(name + " should now be moving.");
    }

    public void SeekPlayer()
    {
        if(thePlayer != null)
        {
            agent.SetDestination(thePlayer.transform.position);
            anim.SetBool("isHopping", true);
            //Quaternion.LookRotation(thePlayer.transform.position, thePlayer.transform.position);
        }
        
    }
}
