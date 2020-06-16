using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BR_HealthPiece : MonoBehaviour
{
    [SerializeField] Renderer rend;
    [SerializeField] int health;

    [SerializeField] Material[] healthMaterials;
    // Material indexes: [0] green, [1] yellow, [2] red
    

    private void Awake ()
    {
        rend = this.gameObject.GetComponent<MeshRenderer> ();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = GameObject.FindGameObjectWithTag ("Player").GetComponent<BR_PlayerHealth> ().GetPlayerHealth();

        UpdateHealthColor ();
    }

    void UpdateHealthColor ()
    {
        switch (health)
        {
            case 7:
                rend.material = healthMaterials[0];
                return;

            case 6:
                rend.material = healthMaterials[0];
                return;

            case 5:
                rend.material = healthMaterials[1];
                return;

            case 4:
                rend.material = healthMaterials[1];
                return;

            case 3:
                rend.material = healthMaterials[1];
                return;

            case 2:
                rend.material = healthMaterials[2];
                return;

            case 1:
                rend.material = healthMaterials[2];
                return;

            case 0:
                rend.material = healthMaterials[2]; ;
                return;

            default:
                return;
        }
    }
}
