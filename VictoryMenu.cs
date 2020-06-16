using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
//using UnityEditorInternal;

public class VictoryMenu: MonoBehaviour
{
    [SerializeField] TextMeshProUGUI time;
    [SerializeField] TextMeshProUGUI coins;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI rank;

    [SerializeField] GameObject ScoreKeeper;
    [SerializeField] GameObject CoinCounter;
    [SerializeField] GameObject Timer;
    [SerializeField] Scene scene;
    public bool isActive;
    public GameObject Coal;
    public GameObject Crate;
    public GameObject Salt;
    [SerializeField] GameObject GameManager;
    [SerializeField] GameObject Player;

    private void OnEnable ()
    {
        //GameObject.Find ("GameManager").GetComponent<GameManagerScript> ().gamePaused = true;
        isActive = true;
        float Score = ScoreKeeper.GetComponent<ScoreScript> ().score;
        int Coins = CoinCounter.GetComponent<TestCanvasScript> ().coinCount;
        float timerCount = Timer.GetComponent<TimerController> ().timer;


        float seconds = (timerCount % 60);
        float minutes = ((int) (timerCount / 60) % 60);
        time.text = "Timer: " + minutes.ToString ("00") + ":" + seconds.ToString ("00");

        coins.text = "Coins: " + Coins;
        score.text = "Score: " + Score;

        float rankScore = Score + (Coins * 50);

        if (GameManager != null)
        {
            GameManager.GetComponent<GameManagerScript> ().VictoryMenuActive = true;
        }

        else
        {
            GameManager = FindObjectOfType<GameManagerScript> ().gameObject;

            if (GameManager == null)
            {
                Debug.Log ("The victory menu found no GameManagerScript in the scene");
            }

            else
            {
                GameManager.GetComponent<GameManagerScript> ().VictoryMenuActive = true;
            }
        }

        if (Player == Coal)
        {
            Coal.GetComponent<BR_PlayerJump> ().VictoryMenuActive = true;
            Coal.GetComponent<BR_PlayerDash> ().VictoryMenuActive = true;
        }
        else if (Player == Crate)
        {
            Crate.GetComponent<BR_PlayerJump> ().VictoryMenuActive = true;
            Crate.GetComponent<BR_PlayerDash> ().VictoryMenuActive = true;
        }
        else if (Player == Salt)
        {
            Salt.GetComponent<BR_PlayerJump> ().VictoryMenuActive = true;
            Salt.GetComponent<BR_PlayerDash> ().VictoryMenuActive = true;
        }

        switch (SceneManager.GetActiveScene ().name)
        {
            case ("GB_LevelOne"):
                if (rankScore >= 8000)
                {
                    rank.text = "A";
                }
                else if (rankScore < 8000 && rankScore >= 7000)
                {
                    rank.text = "B";
                }
                else if (rankScore < 7000 && rankScore >= 6000)
                {
                    rank.text = "C";
                }
                else
                {
                    rank.text = "F";
                }
                break;

            case ("GB_LevelTwo"):

                if (rankScore >= 13000)
                {
                    rank.text = "A";
                }
                else if (rankScore < 13000 && rankScore >= 10000)
                {
                    rank.text = "B";
                }
                else if (rankScore < 10000 && rankScore >= 8000)
                {
                    rank.text = "C";
                }
                else
                {
                    rank.text = "F";
                }
                break;
            case ("GB_LevelThree"):
                if (rankScore >= 110000)
                {
                    rank.text = "A";
                }
                else if (rankScore < 110000 && rankScore >= 80000)
                {
                    rank.text = "B";
                }
                else if (rankScore < 80000 && rankScore >= 50000)
                {
                    rank.text = "C";
                }
                else
                {
                    rank.text = "F";
                }
                break;
            default:
                Debug.Log ("No score requirements set for level " + SceneManager.GetActiveScene ().name);
                break;
        }
    }

    private void OnDisable ()
    {
        isActive = false;
        //GameObject.Find ("GameManager").GetComponent<GameManagerScript> ().gamePaused = false;
        GameManager.GetComponent<GameManagerScript> ().VictoryMenuActive = false;

        //if (Player == Coal)
        //{
        //    if (Coal.GetComponent<BR_PlayerJump> () != null && Coal.GetComponent<BR_PlayerDash> () != null)
        //    {
        //        Coal.GetComponent<BR_PlayerJump> ().VictoryMenuActive = false;
        //        Coal.GetComponent<BR_PlayerDash> ().VictoryMenuActive = false;
        //    }
        //}
        //else if (Player == Crate)
        //{
        //    if (Crate.GetComponent<BR_PlayerJump> () != null && Crate.GetComponent<BR_PlayerDash> () != null)
        //    {
        //        Crate.GetComponent<BR_PlayerJump> ().VictoryMenuActive = false;
        //        Crate.GetComponent<BR_PlayerDash> ().VictoryMenuActive = false;
        //    }
        //}
        //else if (Player == Salt)
        //{
        //    if (Salt.GetComponent<BR_PlayerJump> () != null && Salt.GetComponent<BR_PlayerDash> () != null)
        //    {
        //        Salt.GetComponent<BR_PlayerJump> ().VictoryMenuActive = false;
        //        Salt.GetComponent<BR_PlayerDash> ().VictoryMenuActive = false;
        //    }
        //}
    }

    private void Awake ()
    {
        scene = SceneManager.GetActiveScene ();
        Player = GameManager.GetComponent<GameManagerScript> ().Player;

    }

    public void NextLevel ()
    {
        GameObject.Find ("AudioManager").GetComponent<BR_AudioManager> ().Play ("ButtonClick");
        GameObject.Find ("NextLevelTrigger").GetComponent<NextLevel> ().NextScene ();
    }

    public void TryAgain ()
    {
        GameObject.Find ("AudioManager").GetComponent<BR_AudioManager> ().Play ("ButtonClick");
        SceneManager.LoadScene (scene.name);
    }

    public void Quit ()
    {
        GameObject.Find ("AudioManager").GetComponent<BR_AudioManager> ().Play ("ButtonClick");
        Application.Quit ();
    }
}
