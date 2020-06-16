using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCheckpoint : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    GameObject Player;
    [SerializeField] public bool checkPointActivated = false;
    public GameObject[] triggersToReset;
    GameObject[] checkpoints;
    public int checkpointIndex; // Assign each checkpoint a number, starting with 0
    public int currentHealth;
    public bool CheckpointActive = false;
    public Collider c;
    public GameObject Camera;

    public void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        c = GetComponent<BoxCollider>();
        CheckpointActive = false;
        gameManager = GameObject.Find("GameManager");
        checkpoints = gameManager.GetComponent<GameManagerScript>().Checkpoints;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            c.enabled = false;
            CheckpointActive = true;

            for (int i = checkpointIndex; i > 0; i--)
            {
                //Check to see if the preceding checkpoints have colliders, and if they are enabled, disable them
                if ((checkpoints[i - 1].GetComponent<Collider>() != null) && (checkpoints[i - 1].GetComponent<Collider>().enabled == true))
                {
                    checkpoints[i - 1].GetComponent<Collider>().enabled = false;
                }
            }

            if (other.gameObject.name == ("Coal"))
            {
                checkPointActivated = true;
                gameManager.GetComponent<GameManagerScript>().currentCheckpoint = gameObject;
                Debug.Log("Player has reached a checkpoint.");
                currentHealth = other.gameObject.GetComponent<BR_PlayerHealth>().health;
                gameManager.GetComponent<GameManagerScript>().SaveScene();
            }
            else if (other.gameObject.name == ("Crate"))
            {
                checkPointActivated = true;
                gameManager.GetComponent<GameManagerScript>().currentCheckpoint = gameObject;
                Debug.Log("Player has reached a checkpoint.");
                currentHealth = other.gameObject.GetComponent<BR_PlayerHealth>().health;
                gameManager.GetComponent<GameManagerScript>().SaveScene();
            }
            else if (other.gameObject.name == ("Salt"))
            {
                checkPointActivated = true;
                gameManager.GetComponent<GameManagerScript>().currentCheckpoint = gameObject;
                Debug.Log("Player has reached a checkpoint.");
                currentHealth = other.gameObject.GetComponent<BR_PlayerHealth>().health;
                gameManager.GetComponent<GameManagerScript>().SaveScene();
            }

        }

    }

    public void Reset()
    {
        foreach (GameObject t in triggersToReset)
        {
            // Reset any individual spawners tied to this checkpoint.
            if (t.GetComponent<Spawning>())
            {
                t.GetComponent<Spawning>().Reset();
            }

            // Reset any battle arenas tied to this checkpoint.
            else if (t.GetComponent<BattleArena>())
            {
                t.GetComponent<BattleArena>().Reset();
            }

            // Reset any trap doors
            else if (t.GetComponent<TripwireReset>())
            {
                t.GetComponent<TripwireReset>().Reset();
            }

            // Reset the rotation of any reflective walls
            else if (t.GetComponent<ReflectiveWalls>())
            {
                t.GetComponent<ReflectiveWalls>().ResetReflectiveWalls();
            }
        }
    }

}
