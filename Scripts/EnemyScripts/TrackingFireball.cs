using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingFireball : MonoBehaviour
{
    GameObject Player;
    public float Speed;
    [SerializeField] float ExplosionTimer;
    [SerializeField] GameObject TFBExplosion;
    Vector3 followDirection;

    void Start()
    {
        Invoke("ExplodeFireBall", ExplosionTimer);
    }

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(Player != null)
        {
            //Player = GameObject.FindGameObjectWithTag("Player");
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);
            transform.LookAt(Player.transform.position);
            transform.parent = null;
        }
    }
    
    public void ExplodeFireBall()
    {
        Instantiate(TFBExplosion, transform);
    }
}
