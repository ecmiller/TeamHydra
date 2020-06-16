using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenSwitch : MonoBehaviour
{
    [SerializeField] GameObject turret1;
    [SerializeField] GameObject turret2;
    [SerializeField] GameObject turret3;
    [SerializeField] GameObject WallGem1;
    [SerializeField] GameObject WallGem2;
    [SerializeField] GameObject WallGem3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (turret1 == null)
        {
            WallGem1.SetActive (false);
        }

        if (turret2 == null)
        {
            WallGem2.SetActive (false);
        }

        if (turret3 == null)
        {
            WallGem3.SetActive (false);
        }

        if (turret1 == null && turret2 == null && turret3 == null)
        {
            Destroy (this.gameObject);
        }

    }
}
