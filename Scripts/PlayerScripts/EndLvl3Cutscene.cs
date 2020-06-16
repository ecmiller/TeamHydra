using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLvl3Cutscene : MonoBehaviour
{
    public void OnEnable()
    {
        SceneManager.LoadScene("GB_LevelThree");
    }
}
