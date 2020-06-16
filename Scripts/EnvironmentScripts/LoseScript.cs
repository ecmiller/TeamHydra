using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("BR_MainMenu");
    }
}
