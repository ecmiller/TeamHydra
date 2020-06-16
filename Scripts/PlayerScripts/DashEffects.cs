using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEffects : MonoBehaviour
{
    public TrailRenderer trail;
   

    // Start is called before the first frame update
    void Awake()
    {
        trail = GetComponent<TrailRenderer>();
        trail.enabled = false;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            trail.enabled = true;
            Invoke("TurnOff", 1f);
            
        }

        if (Input.GetKeyUp(KeyCode.Mouse2))
        {
            trail.enabled = false;
            
        }
    }

    public void TurnOff()
    {
        trail.enabled = false;
    }
}
