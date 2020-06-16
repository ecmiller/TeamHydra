using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFinalBossCutscene : MonoBehaviour
{
    public void OnEnable()
    {
        SceneManager.LoadScene("BM_ActionBlock");
    }
}
