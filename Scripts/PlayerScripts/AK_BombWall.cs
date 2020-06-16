using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_BombWall : MonoBehaviour
{

    public GameObject bombwallEffect;
    public GameObject bombnormWall;

    void Awake()
    {
        bombwallEffect.SetActive(false);
    }


    void Update()
    {
        if (bombnormWall.GetComponent<BombNormalWall>().bombwallisHit == true)
        {
            bombnormWall.SetActive(false);
            bombwallEffect.SetActive(true);


            Invoke("DestroyWall", 2f);
        }
    }

    private void DestroyWall()
    {
        Destroy(this.gameObject);
    }
}
