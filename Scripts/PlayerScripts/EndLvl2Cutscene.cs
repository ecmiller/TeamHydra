using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLvl2Cutscene : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("GB_LevelTwo", LoadSceneMode.Single);

    }
}
