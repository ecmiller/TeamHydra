﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("GB_CharacterSelection");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("BR_MainMenu");
    }
}
