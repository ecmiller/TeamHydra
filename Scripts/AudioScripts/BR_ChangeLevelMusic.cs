using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BR_ChangeLevelMusic : MonoBehaviour
{

    private void Start ()
    {
        GameObject.Find ("AudioManager").GetComponent<BR_AudioManager> ().PlayLevelTheme ();
        //Destroy (this);
    }
}
