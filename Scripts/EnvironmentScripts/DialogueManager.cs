using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject diabox;
    public Animator animator;

    public bool gamePaused = false;

    private Queue<string> sentences;
    

    void Start()
    {
        sentences = new Queue<string>();
        Time.timeScale = 1f;
             
    }

   public void StartDialogue(Dialogue dialogue)
    {
        if(animator != null)
        animator.SetBool("isOpen", true);
        
        Debug.Log("Starting Convo.");

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

      
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        Destroy(diabox);
       //animator.SetBool("isOpen", false);
        Debug.Log("End of conversation.");
    }

    public void PauseDialogue()
    {
        gamePaused = true;
        //GameObject.Find("CameraHolder").GetComponent<HideMouse>().UnhideMouseCursor();
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        gamePaused = false;
        //GameObject.Find("Cube").GetComponent<DialogueTrigger>().dia.SetActive(false);
        //GameObject.Find("Cube").GetComponent<BoxCollider>().enabled = false;
        //Destroy(gameObject);
        EndDialogue();
        Time.timeScale = 1f;
    }

    public void Update()
    {

        if (gamePaused == true)
        {
            //GameObject.Find("CameraHolder").GetComponent<HideMouse>().UnhideMouseCursor();
            Time.timeScale = 0f;
        }
        if(gamePaused == false)
        {
            //GameObject.Find("CameraHolder").GetComponent<HideMouse>().HideMouseCursor();
            Time.timeScale = 1f;
        }

    }

}
