using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipCredits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Press any key or click any mouse button to skip credits");
    }

    // Exit back to the main menu when the user presses any key or mouse button.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("BR_MainMenu");
        }
    }
}
