using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    public GameObject CoalTransform;
    public GameObject CrateTransform;
    public GameObject SaltTransform;

    public bool hasSelected;

    private void Awake ()
    {
        CoalTransform = GameObject.Find("Coal");
        CrateTransform = GameObject.Find("Crate");
        SaltTransform = GameObject.Find("Salt");

        //if (hasSelected == false)
        //{
        //    if (GameObject.Find("Coal").activeInHierarchy == true)
        //    {
        //        target = CoalTransform.transform;
        //        hasSelected = true;
        //    }
        //    else if (GameObject.Find("Crate").activeInHierarchy == true)
        //    {
        //        target = CrateTransform.transform;
        //        hasSelected = true;
        //    }
        //    else if (GameObject.Find("Salt").activeInHierarchy == true)
        //    {
        //        target = SaltTransform.transform;
        //        hasSelected = true;
        //    }
        //}
        //target = GameObject.FindGameObjectWithTag ("Player").transform;
    }

    public void Update()
    {
        if (hasSelected == false)
        {
            if (CoalTransform.activeInHierarchy == true)
            {
                target = CoalTransform.transform;
                hasSelected = true;
            }
            else if (CrateTransform.activeInHierarchy == true)
            {
                target = CrateTransform.transform;
                hasSelected = true;
            }
            else if (SaltTransform.activeInHierarchy == true)
            {
                target = SaltTransform.transform;
                hasSelected = true;
            }
        }
    }
    private void FixedUpdate()
    {
        if( target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target);
        }

    }

}
