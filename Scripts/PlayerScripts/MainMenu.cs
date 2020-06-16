using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject Credits;
    [SerializeField] GameObject Options;

    private void Start ()
    {
        Credits = GameObject.Find ("Credits");
        Credits.gameObject.SetActive (false);

        // create player prefs
        PlayerPrefs.GetInt ("levelReached", 0);

        PlayerPrefs.GetFloat ("levelOneScore", 0);
        PlayerPrefs.GetInt ("levelOneCoinAmount", 0);
        PlayerPrefs.GetFloat ("levelOneTimer", 0);
        PlayerPrefs.GetFloat ("levelOneRank", 0);

        PlayerPrefs.GetFloat ("levelTwoScore", 0);
        PlayerPrefs.GetInt ("levelTwoCoinAmount", 0);
        PlayerPrefs.GetFloat ("levelTwoTimer", 0);
        PlayerPrefs.GetFloat ("levelOneRank", 0);

        PlayerPrefs.GetFloat("levelThreeScore", 0);
        PlayerPrefs.GetInt ("levelThreeCoinAmount", 0);
        PlayerPrefs.GetFloat ("levelThreeTimer", 0);
        PlayerPrefs.GetFloat ("levelOneRank", 0);
        //
    }

    public void OpenCredits ()
    {
        GameObject.Find ("AudioManager").GetComponent<BR_AudioManager> ().Play ("ButtonClick");
        SceneManager.LoadScene ("BR_Credits");
    }

    public void OpenOptions ()
    {
        GameObject.Find ("AudioManager").GetComponent<BR_AudioManager> ().Play ("ButtonClick");
        Options.gameObject.SetActive (true);
    }

    public void LoadOptionsScene ()
    {
        GameObject.Find ("AudioManager").GetComponent<BR_AudioManager> ().Play ("ButtonClick");
        SceneManager.LoadScene ("BR_Options");
    }

    public void CloseCredits ()
    {
        GameObject.Find ("AudioManager").GetComponent<BR_AudioManager> ().Play ("ButtonClick");
        Credits.gameObject.SetActive (false);
    }

    public void CloseOptions ()
    {
        GameObject.Find ("AudioManager").GetComponent<BR_AudioManager> ().Play ("ButtonClick");
        Options.gameObject.SetActive (false);
    }

    public void PlayGame()
    {
        GameObject.Find ("AudioManager").GetComponent<BR_AudioManager> ().Play ("ButtonClick");
        SceneManager.LoadScene("OpeningCutscene");
    }

    public void Story ()
    {
        GameObject.Find ("AudioManager").GetComponent<BR_AudioManager> ().Play ("ButtonClick");
        SceneManager.LoadScene ("BR_Story");
    }

    public void Metrics()
    {
        GameObject.Find ("AudioManager").GetComponent<BR_AudioManager> ().Play ("ButtonClick");
        SceneManager.LoadScene("MetricsScene");
    }

    public void ActionBlock ()
    {
        GameObject.Find ("AudioManager").GetComponent<BR_AudioManager> ().Play ("ButtonClick");
        SceneManager.LoadScene ("Tutorial");
    }

    public void Controls ()
    {
        GameObject.Find ("AudioManager").GetComponent<BR_AudioManager> ().Play ("ButtonClick");
        SceneManager.LoadScene ("BR_Control");
    }

    public void QuitGame()
    {
        GameObject.Find ("AudioManager").GetComponent<BR_AudioManager> ().Play ("ButtonClick");
        Debug.Log("Quit!");
        Application.Quit();
    }
}
