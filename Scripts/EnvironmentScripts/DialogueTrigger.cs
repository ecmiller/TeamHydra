using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject dia;

    public bool diaActive = false;



    public void Start()
    {
        dia.SetActive(false);

    }

    public void OnTriggerEnter(Collider other)
    {
        if(dia != null)
        {
            if (other.CompareTag("Player"))
            {
                dia.SetActive(true);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                Invoke("DiaPause", 1.25f);
            }
        }
        
    }

    public void DiaPause()
    {
        FindObjectOfType<DialogueManager>().PauseDialogue();
    }







    //public void OnTriggerExit(Collider other)
    //{
    //    if(other.CompareTag("Player"))

    //        dia.SetActive(false);
    //        FindObjectOfType<DialogueManager>().EndDialogue();

    //}


}
