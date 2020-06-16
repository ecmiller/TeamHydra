using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.SceneManagement;using UnityEngine.UI;

public class BattleArena : MonoBehaviour
{
    [SerializeField] private ArenaManager arenaManager;    [SerializeField] private BR_AudioManager audioManager;    public bool activateBoss;
    public bool bossBattle = false; // Check this box in the inspector if the final wave should trigger a boss fight

    public ArenaWave[] arenaWaves;
    private ArenaWave currentWave;
    public int waveIndex;

    public Slider waveProgressBar;
    public Text waveProgressText;

    public BoxCollider BattleCol;



    void Start()
    {
        arenaManager = GameObject.FindObjectOfType<ArenaManager>();

        if (!arenaManager)
        {
            Debug.Log("No arena manager was found");
        }

        activateBoss = false;

        if (waveProgressBar == null)
        {
            Debug.Log("The progress bar for arena battle " + gameObject.name + " was not assigned in the inspector.");
        }

        else
        {
            waveProgressBar.value = 0f;
        }

        if (waveProgressText == null)
        {
            Debug.Log("The progress text for arena battle " + gameObject.name + " was not assigned in the inspector.");
        }

        else
        {
            waveProgressText.text = (waveProgressBar.value * 100f).ToString("F0") + "%";
        }

        if(arenaWaves == null)
        {
            Debug.Log("No waves have been set up for the current arena battle.");
        }

        else
        {
            waveIndex = 0;
            currentWave = arenaWaves[waveIndex];
        }
    }

    public void EnemyDefeated()
    {
        currentWave.EnemyDefeated();

        if (waveProgressBar.gameObject.activeSelf == false)
        {
            waveProgressBar.gameObject.SetActive(true);
        }

        else
        {
            UpdateWaveProgressBar();
        }
    }

    private void UpdateWaveProgressBar()
    {
        waveProgressBar.value = (float)currentWave.enemiesDefeated / (float)currentWave.enemiesToDefeat;
        waveProgressText.text = (waveProgressBar.value * 100f).ToString("F0") + "%";
        Debug.Log("Current Wave Progress: " + waveProgressBar.GetComponent<Slider>().value * 100 + "%");
    }

    private void DisableBarriers()
    {
        GetComponent<BattleBarriers>().DisableBarriers();
    }

    private void DisableWaveProgressBar()
    {
        waveProgressBar.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            arenaManager.CurrentArena = this;
            arenaManager.arenaBattleActive = true;

            waveProgressBar.gameObject.SetActive(true);

            Debug.Log("Player entered a battle arena");
            arenaManager.DisableProgression();
            GetComponent<BattleBarriers>().EnableBarriers();
            BattleCol.enabled = false;
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("Fight");
            currentWave.BeginWave();
        }
    }

    public void NextWave()
    {
        waveIndex++;

        if (waveIndex >= arenaWaves.Length)
        {
            Debug.Log("Player cleared the final wave.");

            // If all waves are cleared, but there is a boss battle, activate the boss
            if (bossBattle)
            {
                GameObject.Find("BossHealthBar").GetComponent<BossHealthBar>().ActivateBoss();
                waveProgressBar.gameObject.SetActive(false);
                return;
            }

            else
            {
                EndBattle();
            }
        }

        else
        {
            currentWave = arenaWaves[waveIndex];
            waveProgressBar.value = 0f;
            Debug.Log("Starting next wave");
            currentWave.BeginWave();
        }
    }

    public void EndBattle()
    {
        waveProgressBar.gameObject.SetActive(false);
        DisableBarriers();
        Debug.Log("Battle Cleared");
        Invoke("DisableWaveProgressBar", 1f);
        arenaManager.EndBattle();
    }

    public void BossDefeated()
    {
        EndBattle();
    }

    public void Reset()
    {
        DisableBarriers();
        BattleCol.gameObject.SetActive(true);
        BattleCol.enabled = true;

        if (arenaWaves != null)
        {
            foreach (ArenaWave a in arenaWaves)
            {
                a.enemiesDefeated = 0;
            }
            currentWave = arenaWaves[0];
        }
    }
}
