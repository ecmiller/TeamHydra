using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public bool canProgress = true;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canProgress)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
