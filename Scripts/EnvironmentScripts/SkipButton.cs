using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipButton : MonoBehaviour
{
    public void SkipScene()
    {
        SceneManager.LoadScene("GB_LevelOne");
    }

    public void SkipSceneTwo()
    {
        SceneManager.LoadScene("GB_LevelTwo");
    }

    public void SkipSceneThree()
    {
        SceneManager.LoadScene("GB_LevelThree");
    }

    public void SkipFinalCutscene()
    {
        SceneManager.LoadScene("BM_ActionBlock");
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
