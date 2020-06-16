using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShieldingEnemies : MonoBehaviour
{
    [SerializeField] GameObject FollowPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject != null)
        {
            transform.Rotate(0f, 150f * Time.deltaTime, 0f);

            if(FollowPoint != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, FollowPoint.transform.position, 1f);
            }
        }
    }
}
