using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

[System.Serializable]
public class ArenaWave
{
    public int enemiesToDefeat = 3;
    public int enemiesDefeated = 0;
    public float spawnDelay = 2f;

    [SerializeField] private BattleArena battleArena;
    public EnemySpawnLocation[] spawnCircles;

    // Start is called before the first frame update
    void Start()
    {
        if(battleArena == null)
        {
            Debug.Log("All enemy waves have not been assigned to their corresponding arena battle(s)");
        }
    }

    public void BeginWave()
    {
        SpawnAgents();
        Debug.Log("Wave began");
    }

    private void ShowParticles()
    {
        foreach (EnemySpawnLocation esl in spawnCircles)
        {
            esl.gameObject.GetComponentInChildren<ParticleSystem>(true).gameObject.SetActive(true);
        }
    }

    private void HideParticles()
    {
        foreach (EnemySpawnLocation esl in spawnCircles)
        {
            esl.gameObject.GetComponentInChildren<ParticleSystem>(true).gameObject.SetActive(false);
        }
    }

    private void SpawnAgents()
    {
        foreach (EnemySpawnLocation esl in spawnCircles)
        {
            esl.SpawnEnemy();
        }
    }

    private IEnumerable Delay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
    }

    public void EnemyDefeated()
	{
        enemiesDefeated++;
        if(enemiesDefeated == enemiesToDefeat)
		{
            Debug.Log("Wave Cleared");
            battleArena.NextWave();
		}
	}
}
