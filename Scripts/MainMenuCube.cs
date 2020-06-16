using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (Vector3.up * 300 * Time.deltaTime);
        transform.Rotate (Vector3.right * 300 * Time.deltaTime);

        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp (Color.blue, Color.red, Mathf.PingPong (Time.time, 1));
    }
}
