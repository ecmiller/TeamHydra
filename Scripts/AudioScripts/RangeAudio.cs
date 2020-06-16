using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAudio : MonoBehaviour
{
    public AudioClip triggerAudio;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
     if(other.CompareTag("Player"))
        {
           audioSource.Play();
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
           audioSource.Stop();
           
        }
    }
}
