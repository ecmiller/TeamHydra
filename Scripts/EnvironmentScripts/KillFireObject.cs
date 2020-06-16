using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFireObject : MonoBehaviour
{
    public float KillTime;
    [SerializeField] GameObject FlamePillar;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("KillFlame", KillTime);
    }

    void KillFlame()
    {
        if(gameObject.CompareTag("FireSpark"))
        {
            Instantiate(FlamePillar, gameObject.transform.position, gameObject.transform.rotation);
        }
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
