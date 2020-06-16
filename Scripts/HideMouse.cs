using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HideMouse: MonoBehaviour
{
    [SerializeField] GameObject GameManager;
    [SerializeField] GameObject PauseMenu;

    [SerializeField] bool isDead;

    // Start is called before the first frame update
    void Start ()
    {
        UnhideMouseCursor ();
        GameManager = GameObject.Find ("GameManager");
        PauseMenu = GameObject.Find("AK_PauseMenu");
        CenterCursor ();
    }

    // Update is called once per frame
    void Update ()
    {
        if (SceneManager.GetActiveScene ().name == "BR_MainMenu")
        {
            UnhideMouseCursor ();
        }
        else if (SceneManager.GetActiveScene ().name == "BR_Story")
        {
            UnhideMouseCursor ();
        }
        else if (SceneManager.GetActiveScene ().name == "BR_Options")
        {
            UnhideMouseCursor ();
        }
        else if (SceneManager.GetActiveScene ().name == "BR_Chapters")
        {
            UnhideMouseCursor ();
        }
        else if (SceneManager.GetActiveScene ().name == "BR_ActionBlock")
        {
            UnhideMouseCursor ();
        }
        else if (SceneManager.GetActiveScene ().name == "BR_Control")
        {
            UnhideMouseCursor ();
        }
        else if (SceneManager.GetActiveScene ().name == "WinScene")
        {
            UnhideMouseCursor ();
        }
        else if (SceneManager.GetActiveScene ().name == "LoseScene")
        {
            UnhideMouseCursor ();
        }
        else if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            UnhideMouseCursor();
        }
        //else
        //{
        //    if (GameManager.GetComponent<GameManagerScript> ().pausePaused == false && GameManager.GetComponent<GameManagerScript> ().gamePaused == false)
        //    {
        //        if (isDead == true)
        //        {
        //            UnhideMouseCursor ();
        //        }
        //        else
        //        {
        //            HideMouseCursor ();
        //        }
        //    }
        //    else if (GameManager.GetComponent<GameManagerScript> ().pausePaused == true && GameManager.GetComponent<GameManagerScript> ().gamePaused == false)
        //    {
        //        UnhideMouseCursor ();
        //    }
        //    else if (GameManager.GetComponent<GameManagerScript> ().pausePaused == false && GameManager.GetComponent<GameManagerScript> ().gamePaused == true)
        //    {
        //        UnhideMouseCursor ();
        //    }
        else if (GameManager != null && GameManager.GetComponent<GameManagerScript>().gamePaused == true)
        {
            UnhideMouseCursor();
        }
        //}

    }

    public void HideMouseCursor ()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnhideMouseCursor ()
    {
        //Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CenterCursor ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
    }

    public void IsDead ()
    {
        isDead = true;
    }

    public void NotDead ()
    {
        isDead = false;
    }
}
