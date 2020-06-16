using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndCutScene : MonoBehaviour
{

    private void OnEnable()
    {
        SceneManager.LoadScene("GB_LevelOne", LoadSceneMode.Single);
        
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Player")
    //    {
    //        SceneManager.LoadScene("LevelOne");
    //        SceneManager.GetSceneByName("LevelOne");
    //    }
    //}
}
