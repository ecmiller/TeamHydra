using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{

    public float Score;
    public int Coins;
    public float timerCount;
    [SerializeField] GameObject CoinCounter;
    [SerializeField] GameObject ScoreKeeper;
    [SerializeField] GameObject Timer;

    

    void Update()
    {
        Score = ScoreKeeper.GetComponent<ScoreScript>().score;
        Coins = CoinCounter.GetComponent<TestCanvasScript>().coinCount;
        timerCount = Timer.GetComponent<TimerController> ().timer;

        if (CoinCounter == null)
        {
            Instantiate (CoinCounter);
        }
    }

    public void UpdateLevelOneScore ()
    {
        //float rankScore = PlayerPrefs.GetFloat ("levelOneRank", 0);
        //if (rankScore <= Score + (Coins * 50))
        //{
            PlayerPrefs.SetFloat ("levelOneScore", Score);
            PlayerPrefs.SetInt ("levelOneCoinAmount", Coins);
            PlayerPrefs.SetFloat ("levelOneTimer", timerCount);
        //}
    }

    public void UpdateLevelTwoScore ()
    {
        float rankScore = PlayerPrefs.GetFloat ("levelTwoRank", 0);
        if (rankScore <= Score + (Coins * 50))
        {
            PlayerPrefs.SetFloat ("levelTwoScore", Score);
            PlayerPrefs.SetInt ("levelTwoCoinAmount", Coins);
            PlayerPrefs.SetFloat ("levelTwoTimer", timerCount);
        }
    }

    public void UpdateLevelThreeScore ()
    {
        float rankScore = PlayerPrefs.GetFloat ("levelThreeRank", 0);
        if (rankScore <= Score + (Coins * 50))
        {
            PlayerPrefs.SetFloat ("levelThreeScore", Score);
            PlayerPrefs.SetInt ("levelThreeCoinAmount", Coins);
            PlayerPrefs.SetFloat ("levelThreeTimer", timerCount);
        }
    }
}
