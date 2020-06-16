using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuTextScript : MonoBehaviour
{
    public void BounceText()
    {
        gameObject.GetComponent<Animator>().SetBool("isBouncing", true);
    }

    public void StopBouncingText()
    {
        gameObject.GetComponent<Animator>().SetBool("isBouncing", false);
    }
}
