using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField] GameObject Camera;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1.5f;
        Camera.transform.position = new Vector3 (0, 9, 5.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1f;
        Camera.transform.position += new Vector3 (0, 0, -speed * Time.deltaTime);
        if (Camera.transform.position.z < -96)
        {
            SceneManager.LoadScene ("BR_MainMenu");
        }

        if (Camera.transform.position.z > 6)
        {
            Camera.transform.position = new Vector3 (0, 9, 6);
            speed = -.1f;
            
        }

        if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            speed -= .1f;
        }

        if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            speed += .1f;
        }

        if (speed > 15)
        {
            speed = 15;
        }

        if (speed < -15)
        {
            speed = -15;
        }

        if (Input.GetKeyDown (KeyCode.Escape))
        {
            SceneManager.LoadScene ("BR_MainMenu");
        }
    }
}
