using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BR_DashMirage : MonoBehaviour
{
    float timer;

    private void OnEnable ()
    {
        this.transform.SetParent (null, true);
        this.gameObject.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        timer = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= .5)
        {
            this.gameObject.SetActive (false);
        }
    }
}
