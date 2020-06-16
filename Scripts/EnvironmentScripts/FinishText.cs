using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishText : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        //text = GameObject.Find("EndText").GetComponent<Text>();
        text.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.enabled = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
