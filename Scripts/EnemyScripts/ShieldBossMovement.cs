using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShieldBossMovement : MonoBehaviour
{
    public GameObject Player;
    private NavMeshAgent agent;
    public GameObject Coal;
    public GameObject Crate;
    public GameObject Salt;
    // Start is called before the first frame update

    private void Awake()
    {
        Coal = GameObject.Find("Coal");
        Crate = GameObject.Find("Crate");
        Salt = GameObject.Find("Salt");
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Coal.activeInHierarchy == true)
        {
            Player = Coal;
            //hasSelected = true;
        }
        else if (Crate.activeInHierarchy == true)
        {
            Player = Crate;
            //hasSelected = true;
        }
        else if (Salt.activeInHierarchy == true)
        {
            Player = Salt;
            //hasSelected = true;
        }
        if (Player != null)
        {
            agent.SetDestination(Player.transform.position);
            Quaternion.LookRotation(Player.transform.position, Player.transform.position);
        }
    }

    private void FixedUpdate()
    {
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), Player.GetComponent<Collider>(), ignore: true);
    }
}
