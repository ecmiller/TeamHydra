using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField] private float rotationSpeed = 20f;


    private void Update()
    {
        if (this.CompareTag ("Panel"))
        {
            //transform.Rotate (0, transform.rotation.y * Time.deltaTime * (rotationSpeed * 3), 0, Space.World);
            //transform.rotation = new Vector3 (45, transform.rotation.y * Time.deltaTime * rotationSpeed, 45);
            transform.Rotate (Vector3.up * Time.deltaTime * rotationSpeed * 2, Space.World);
        }
        else
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        }
        
    }
}
