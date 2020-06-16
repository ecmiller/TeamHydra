using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lvl1toLvl2 : MonoBehaviour
{
    //public Animator texttransition;
    public float transitionTime = 1f;
    public bool canProgress = true;
    [SerializeField] private string loadLevel;



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canProgress)
        {

            StartCoroutine(LoadLevel());
        }

    }

    IEnumerator LoadLevel()
    {
        //texttransition.SetTrigger("Start");
        GameObject.Find ("GameManager").GetComponent<GameManagerScript> ().WinLevel ();
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(loadLevel);

    }


}
