using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaManager : MonoBehaviour
{
    [SerializeField] BattleArena[] battleArenas;
    [SerializeField] private BattleArena currentArena;
    [SerializeField] GameObject progressionTrigger; // Set this in the inspector
    [SerializeField] BR_AudioManager audioManager;

    public bool arenaBattleActive = false;
    private int arenaIndex = 0;

    public BattleArena CurrentArena
    {
        get { return currentArena; }
        set => currentArena = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        battleArenas = GameObject.FindObjectsOfType<BattleArena>();

        currentArena = battleArenas[arenaIndex];
        if(progressionTrigger == null)
        {
            FindLevelTrigger();
        }

        audioManager = GameObject.FindObjectOfType<BR_AudioManager>();

        if (!audioManager)
        {
            Debug.Log("No audio manager was found");
        }
    }

    public void EndBattle()
    {
        arenaBattleActive = false;
        currentArena.gameObject.SetActive(false);

        arenaIndex++;

        if (arenaIndex < battleArenas.Length)
        {
            currentArena = battleArenas[arenaIndex];
        }

        else
        {
            Debug.Log("All arenas in the level have been cleared.");
        }

        // Re-enable level transition triggers when the wave is cleared
        EnableProgression();
    }

    public void EnableProgression()
    {
        if(progressionTrigger.GetComponent<NextLevel>())
        {
            progressionTrigger.GetComponent<NextLevel>().canProgress = true;
        }
        else if (progressionTrigger.GetComponent<EndGame>())
        {
            progressionTrigger.GetComponent<EndGame>().canProgress = true;
        }

        //Resume the current level's music when an arena is completed
        audioManager.Stop("ArenaMusic");
        audioManager.Play(SceneManager.GetActiveScene().name);
    }

    public void DisableProgression()
    {
        if (progressionTrigger.GetComponent<NextLevel>())
        {
            progressionTrigger.GetComponent<NextLevel>().canProgress = false;
        }
        else if (progressionTrigger.GetComponent<EndGame>())
        {
            progressionTrigger.GetComponent<EndGame>().canProgress = false;
        }

        // Stop the current level's music, and play the battle theme (currently the level one theme)
        audioManager.Stop(SceneManager.GetActiveScene().name);
        audioManager.Play("ArenaMusic");
    }

    private void FindLevelTrigger()
    {
        if (GameObject.FindObjectOfType<NextLevel>())
        {
            progressionTrigger = GameObject.FindObjectOfType<NextLevel>().gameObject;
        }

        else if (GameObject.FindObjectOfType<EndGame>())
        {
            progressionTrigger = GameObject.FindObjectOfType<EndGame>().gameObject;
        }
    }
}
