using UnityEngine;
using System.Collections;

public class MouseCursor : MonoBehaviour
{
    bool cLock;

    private void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if(cLock == true)
        //    {
        //        Cursor.lockState = CursorLockMode.Locked;
        //        cLock = false;
        //    }
        //    else
        //    {
        //        Cursor.lockState = CursorLockMode.None;
        //        cLock = true;
        //    }
        //}
    }
}
