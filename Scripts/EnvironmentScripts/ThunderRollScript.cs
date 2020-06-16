using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderRollScript : MonoBehaviour
{
    [SerializeField] GameObject[] ThunderAudioSources;
    [SerializeField] GameObject Flash;

    private void Start()
    {
        Invoke("Thunder1", 0.0f);
    }

    void Thunder1()
    {
        ThunderAudioSources[0].SetActive(true);
        Invoke("Thunder2", 6f);
        //Flash.SetActive(true);
        Invoke("FlashOn", 0.5f);
    }

    void Thunder2()
    {
        ThunderAudioSources[1].SetActive(true);
        Invoke("Thunder3", 2f);
    }

    void Thunder3()
    {
        ThunderAudioSources[2].SetActive(true);
        ThunderAudioSources[0].SetActive(false);
    }

    void FlashOff()
    {
        Flash.SetActive(false);
        Invoke("Thunder1", 12.174f);
    }

    void FlashOn()
    {
        Flash.SetActive(true);
        Invoke("FlashOff", 0.5f);
        //Invoke("Thunder1", 0.0f);

    }
}
