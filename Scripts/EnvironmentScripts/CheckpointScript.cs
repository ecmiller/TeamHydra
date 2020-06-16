using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CheckpointScript : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    GameObject Player;
    [SerializeField] public bool checkPointActivated = false;
    public GameObject[] triggersToReset;
    GameObject[] checkpoints;
    public int checkpointIndex; // Assign each checkpoint a number, starting with 0
    public int currentHealth;
   // public AudioClip CheckpointSound;
    //public AudioClip CheckpointDone;
    //AudioSource audioSource;
    //public ParticleSystem particles;
    //public GameObject radius;

    public GameObject wall;
    public GameObject EffectBody;
    public GameObject Scanner;
    public GameObject Canvas;
    public bool CheckpointActive = false;
    public Collider c;
    Animator anim;

    private GameObject Camera;

    //int previousCheckpoint;

    //public GameObject Coal;
    //public GameObject Crate;
    //public GameObject Salt;

    //public bool hasSelected;

    // Start is called before the first frame update
    public void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        c = GetComponent<BoxCollider>();
        //audioSource = GetComponentInChildren<AudioSource>();
        wall.SetActive(false);
        EffectBody.SetActive(false);
        Canvas.SetActive(false);
        Scanner.GetComponent<MeshRenderer>().enabled = false;
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("CheckpointActive", false);
        CheckpointActive = false;

        //particles = GetComponentInChildren<ParticleSystem>();
        //particles.GetComponent<ParticleSystemRenderer>().material.color = Color.red ;
        //radius.GetComponent<Renderer>().material.color = Color.red;

        gameManager = GameObject.Find("GameManager");
        checkpoints = gameManager.GetComponent<GameManagerScript>().Checkpoints;

        //previousCheckpoint = checkpointIndex - 1;
        //Coal = GameObject.Find("Coal");
        //Crate = GameObject.Find("Crate");
        //Salt = GameObject.Find("Salt");
        //if (hasSelected == false)
        //{
        //    if (Coal.activeInHierarchy == true)
        //    {
        //        Player = Coal;
        //        hasSelected = true;
        //    }
        //    else if (Crate.activeInHierarchy == true)
        //    {
        //        Player = Crate;
        //        hasSelected = true;
        //    }
        //    else if (Salt.activeInHierarchy == true)
        //    {
        //        Player = Salt;
        //        hasSelected = true;
        //    }
        //}
        //Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("Checkpoint");
            // particles.GetComponent<ParticleSystemRenderer>().material.color = new Color(0.12f, 0.9f, 0.02f, 1);
            // radius.GetComponent<Renderer>().material.color = new Color(0.12f, 0.9f, 0.02f, 1);
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("CheckpointSound");
            //GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("CPAnalyzing");
            //audioSource.PlayOneShot(CheckpointSound, 1f);
            wall.SetActive(true);
            EffectBody.SetActive(true);
            Scanner.GetComponent<MeshRenderer>().enabled = true;
            anim.SetBool("CheckpointActive", true);
            c.enabled = false;
            CheckpointActive = true;
            Invoke("TurnOffCheckpoint", 2f);
            //if (checkpointIndex >= 1)
            //{
            //    Checkpoints[previousCheckpoint].GetComponent<Collider>().enabled = false;
            //}

            for (int i = checkpointIndex; i > 0; i--)
            {
                //Check to see if the preceding checkpoints have colliders, and if they are enabled, disable them
                if ((checkpoints[i - 1].GetComponent<Collider>() != null) && (checkpoints[i - 1].GetComponent<Collider>().enabled == true))
                {
                    checkpoints[i - 1].GetComponent<Collider>().enabled = false;
                }
            }
            if(checkpointIndex == 0)
            {
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Stop("CheckpointSound");
                wall.SetActive(false);
                EffectBody.SetActive(false);
                Scanner.SetActive(false);
                Canvas.SetActive(false);
                CheckpointActive = false;
                anim = null;
            }

            //gameObject.GetComponent<Collider>().enabled = false;

            if (other.gameObject.name == ("Coal"))
            {
                checkPointActivated = true;
                gameManager.GetComponent<GameManagerScript>().currentCheckpoint = gameObject;
                //gameObject.GetComponent<Renderer>().material.color = new Color(0.12f, 0.9f, 0.02f, 1);
                Debug.Log("Player has reached a checkpoint.");
                currentHealth = other.gameObject.GetComponent<BR_PlayerHealth>().health;
                //Player.GetComponent<Player>().SavePlayer();
                gameManager.GetComponent<GameManagerScript>().SaveScene();
            }
            else if (other.gameObject.name == ("Crate"))
            {
                checkPointActivated = true;
                gameManager.GetComponent<GameManagerScript>().currentCheckpoint = gameObject;
                Debug.Log("Player has reached a checkpoint.");
                currentHealth = other.gameObject.GetComponent<BR_PlayerHealth>().health;
                //Player.GetComponent<Player>().SavePlayer();
                gameManager.GetComponent<GameManagerScript>().SaveScene();
            }
            else if (other.gameObject.name == ("Salt"))
            {
                checkPointActivated = true;
                gameManager.GetComponent<GameManagerScript>().currentCheckpoint = gameObject;
                //gameObject.GetComponent<Renderer>().material.color = new Color(0.12f, 0.9f, 0.02f, 1);
                Debug.Log("Player has reached a checkpoint.");
                currentHealth = other.gameObject.GetComponent<BR_PlayerHealth>().health;
                //Player.GetComponent<Player>().SavePlayer();
                gameManager.GetComponent<GameManagerScript>().SaveScene();
            }
        }
        
    }

    private void Update()
    {
        Canvas.transform.LookAt(Camera.transform.position);
    }

    public void TurnOffCheckpoint()
    {
        if (CheckpointActive)
        {
            wall.SetActive(false);
            EffectBody.SetActive(false);
            Scanner.SetActive(false);
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("CheckpointDone");
            //GameObject.FindGameObjectWithTag("AudioManager").GetComponent<BR_AudioManager>().Play("CPComplete");
            //audioSource.PlayOneShot(CheckpointDone, 1f);
            Canvas.SetActive(true);
        }

    }

    public void Reset()
	{
        foreach(GameObject t in triggersToReset)
		{
            // Reset any individual spawners tied to this checkpoint.
            if(t.GetComponent<Spawning>())
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
            else if(t.GetComponent<ReflectiveWalls>())
            {
                t.GetComponent<ReflectiveWalls>().ResetReflectiveWalls();
            }
        }
	}

    //public void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        Invoke("StopAudio", 1f);
    //    }
    //}

    //public void StopAudio()
    //{
    //    audioSource.enabled = false;
    //}
}
