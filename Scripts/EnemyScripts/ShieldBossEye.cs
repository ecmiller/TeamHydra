using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBossEye : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Coal;
    [SerializeField] GameObject Crate;
    [SerializeField] GameObject Salt;

    private void Awake()
    {
        
    }
    private void Update()
    {
        if (Coal.activeInHierarchy == true)
        {
            Player = Coal;
        }

        else if (Crate.activeInHierarchy == true)
        {
            Player = Crate;
        }

        else if (Salt.activeInHierarchy == true)
        {
            Player = Salt;
        }
        gameObject.transform.LookAt(Player.transform.position);
    }
}
