using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StartCutScene : MonoBehaviour
{
    public PlayableDirector myDirector;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            myDirector.GetComponent<PlayableAsset>();
            myDirector.Play();
        }
    }
}
