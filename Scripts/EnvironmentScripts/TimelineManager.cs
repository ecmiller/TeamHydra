using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimelineManager : MonoBehaviour
{
    public PlayableDirector director;

    public static TimelineManager instance;


    private void OnEnable ()
    {

    }

    private void Awake ()
    {
        director = this.gameObject.GetComponent<PlayableDirector> ();
        director.time = 0;
        //director.Stop ();
        //director.Evaluate ();
        Debug.Log ("Please Work");
        director.Play ();

    }

    private void Start ()
    {

    }

    private void Update ()
    {

    }
    ////public GameObject openText;

    ////public GameObject endTrigger;

    //public bool isActive;
    //public bool textActive;

    //public void Start()
    //{


    //    director.time = 0;
    //    director.enabled = false;
    //        //openText.SetActive(true);

    //        //director.Pause();

    //        isActive = false;

    //        textActive = true;


    //        Invoke("PlayCutscene", 3f);




    //}
    //private void OnEnable()
    //{
    //    Invoke("PlayCutscene", 3f);
    //}
    //// Update is called once per frame
    //void Update()
    //{
    //    if (isActive == true && SceneManager.GetActiveScene().name == "OpeningCutscene")
    //    {
    //        director.Play();
    //    }

    //}

    //public void PlayCutscene()
    //{
    //    //openText.SetActive(false);
    //    director.time = 0;
    //    director.enabled = true;

    //    isActive = true;
    //    textActive = false;

    //}

}
