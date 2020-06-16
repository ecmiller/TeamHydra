using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel: MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public bool canProgress = true;
    [SerializeField] private string loadLevel;
    [SerializeField] GameObject ScoreSystem;
    [SerializeField] GameObject player;
    [SerializeField] GameObject VictoryMenu;


    private void Start ()
    {
        ScoreSystem = GameObject.FindGameObjectWithTag ("ScoreSystem");
        VictoryMenu = ScoreSystem.gameObject.transform.Find ("VictoryMenu").gameObject;
        VictoryMenu.SetActive (false);


        // if player hasnt played the game yet set the level reached to level 1 
        if (PlayerPrefs.GetInt ("levelReached") < 1)
        {
            PlayerPrefs.SetInt ("levelReached", 1);
        }

        ScoreSystem.gameObject.transform.Find ("VictoryMenu").gameObject.SetActive (false);
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag ("Player") && canProgress)
        {
            if (other.gameObject.name == "Coal")
            {
                player = other.gameObject;
            }
            else if (other.gameObject.name == "Crate")
            {
                player = other.gameObject;
            }
            else if (other.gameObject.name == "Salt")
            {
                player = other.gameObject;
            }

            VictoryMenu.SetActive (true);
            ScoreSystem.gameObject.transform.Find ("Timer").GetComponent<TimerController> ().StopTimer ();

            if (SceneManager.GetActiveScene ().name == "GB_LevelOne")
            {
                float rankScore = PlayerPrefs.GetFloat ("levelOneRank", 0);
                if (rankScore <= (ScoreSystem.GetComponent<ScoreSystem> ().Score + (ScoreSystem.GetComponent<ScoreSystem> ().Coins * 50)))
                {
                    ScoreSystem.GetComponent<ScoreSystem> ().UpdateLevelOneScore ();
                }
            }
            else if (SceneManager.GetActiveScene ().name == "GB_LevelTwo")
            {
                float rankScore = PlayerPrefs.GetFloat ("levelTwoRank", 0);
                if (rankScore <= (ScoreSystem.GetComponent<ScoreSystem> ().Score + (ScoreSystem.GetComponent<ScoreSystem> ().Coins * 50)))
                {
                    ScoreSystem.GetComponent<ScoreSystem> ().UpdateLevelTwoScore ();
                }
            }
            else if (SceneManager.GetActiveScene ().name == "GB_LevelThree")
            {
                float rankScore = PlayerPrefs.GetFloat ("levelThreeRank", 0);
                if (rankScore <= (ScoreSystem.GetComponent<ScoreSystem> ().Score + (ScoreSystem.GetComponent<ScoreSystem> ().Coins * 50)))
                {
                    ScoreSystem.GetComponent<ScoreSystem> ().UpdateLevelThreeScore ();
                }
            }
        }
    }

    public IEnumerator LoadLevel ()
    {
        transition.SetTrigger ("Start");
        GameObject.Find ("GameManager").GetComponent<GameManagerScript> ().WinLevel ();
        yield return new WaitForSeconds (transitionTime);
        SceneManager.LoadScene (loadLevel);
    }

    public void NextScene ()
    {
        if (SceneManager.GetActiveScene ().name == "GB_LevelOne")
        {
            if (player.gameObject.name == "Coal")
            {
                SceneManager.LoadScene ("GB_Level2Cutscene");
            }
            else if (player.gameObject.name == "Crate")
            {
                SceneManager.LoadScene ("GB_Level2CutsceneCrate");
            }
            else if (player.gameObject.name == "Salt")
            {
                SceneManager.LoadScene ("GB_Level2CutsceneSalt");
            }
            //ScoreSystem.GetComponent<ScoreSystem> ().UpdateLevelOneScore ();
        }
        else if (SceneManager.GetActiveScene ().name == "GB_LevelTwo")
        {
            if (player.gameObject.name == "Coal")
            {
                SceneManager.LoadScene ("GB_Level3Cutscene");
            }
            else if (player.gameObject.name == "Crate")
            {
                SceneManager.LoadScene ("GB_Level3CutsceneCrate");
            }
            else if (player.gameObject.name == "Salt")
            {
                SceneManager.LoadScene ("GB_Level3CutsceneSalt");
            }
            //ScoreSystem.GetComponent<ScoreSystem> ().UpdateLevelTwoScore ();
        }
        else if (SceneManager.GetActiveScene ().name == "GB_LevelThree")
        {
            if (player.gameObject.name == "Coal")
            {
                SceneManager.LoadScene ("FinalBossCutscenePartOne");
            }
            else if (player.gameObject.name == "Crate")
            {
                SceneManager.LoadScene ("FinalBossCutscenePartOneCrate");
            }
            else if (player.gameObject.name == "Salt")
            {
                SceneManager.LoadScene ("FinalBossCutscenePartOneSalt");
            }
            //ScoreSystem.GetComponent<ScoreSystem> ().UpdateLevelThreeScore ();
        }
        else if (SceneManager.GetActiveScene ().name == "BM_ActionBlock")
        {
            if (player.gameObject.name == "Coal")
            {
                SceneManager.LoadScene ("BR_Win");
            }
            else if (player.gameObject.name == "Crate")
            {
                SceneManager.LoadScene ("BR_Win");
            }
            else if (player.gameObject.name == "Salt")
            {
                SceneManager.LoadScene ("BR_Win");
            }
        }
        else if (SceneManager.GetActiveScene ().name == "Tutorial")
        {
            if (player.gameObject.name == "Coal")
            {
                SceneManager.LoadScene ("BR_MainMenu");
            }
        }
        StartCoroutine (LoadLevel ());
    }
}
