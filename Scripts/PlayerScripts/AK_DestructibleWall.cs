using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_DestructibleWall : MonoBehaviour
{
    public GameObject wallEffect;
    public GameObject wallEffect2;
    public GameObject normWall;


    // Start is called before the first frame update
    void Awake()
    {
       

        wallEffect.SetActive(false);
        wallEffect2.SetActive(false);

    }

    void Update()
    {
        if(normWall.GetComponent<NormalWall>().isHit == true)
        {
            normWall.SetActive(false);
            wallEffect.SetActive(true);
            wallEffect2.SetActive(true);


            Invoke("DestroyWall", 2f);
        }
    }

    private void DestroyWall()
    {
        Destroy(this.gameObject);
    }
}
