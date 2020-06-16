using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretHealthScript : MonoBehaviour
{
    [SerializeField] GameObject Turret;
    [SerializeField] Slider HealthSlider;
    private GameObject Camera;

    private void Awake()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        HealthSlider.value = Turret.GetComponent<Damage>().maxHealth - Turret.GetComponent<Damage>().damageTaken;

        gameObject.transform.LookAt(Camera.transform.position);
    }
}
