using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(SceneManager.GetActiveScene().name == ("GB_LevelOne"))
            {
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("Splash");
            }
            else if(SceneManager.GetActiveScene().name == ("GB_LevelTwo"))
            {
                if(other.gameObject.name == ("Salt"))
                {
                    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("Splash");
                    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("Splash2Girl");
                }
                else
                {
                    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("Splash");
                    GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("Splash2Guy");
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
