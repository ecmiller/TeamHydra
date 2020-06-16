using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    private GameObject[] characterList;
    private int index;

    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");

        characterList = new GameObject[transform.childCount];

        // This fills the array with each character. Character must be a child of the character list.
        for (int i = 0; i < transform.childCount; i++)
            characterList[i] = transform.GetChild(i).gameObject;

        // This turns off the character's renderer.
        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
            if (SceneManager.GetActiveScene().name == "GB_CharacterSelection")
            {
                go.GetComponent<BR_PlayerMovement>().enabled = false;
                go.GetComponent<BR_PlayerJump>().enabled = false;
                go.GetComponentInChildren<ShootingEffect>().enabled = false;
                go.GetComponentInChildren<BR_ShottingAttacks>().enabled = false;
            }
            if (SceneManager.GetActiveScene().name == "GB_LevelOne")
            {
                go.GetComponent<BR_PlayerMovement>().enabled = true;
                go.GetComponent<BR_PlayerJump>().enabled = true;
                go.GetComponentInChildren<ShootingEffect>().enabled = true;
                go.GetComponentInChildren<BR_ShottingAttacks>().enabled = true;
            }

        }

        // This makes the first character in the index active when the character selection scene is loaded.
        if (characterList[index])
            characterList[index].SetActive(true);
               
        
    }

    public void ToggleLeft()
    {
        // Toggle off the current character
        characterList[index].SetActive(false);
        index--;
        if (index < 0)
            index = characterList.Length - 1;

        // Toggle on the new character
        characterList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        // Toggle off the current character
        characterList[index].SetActive(false);
        index++;
        if (index == characterList.Length)
            index = 0;

        // Toggle on the new character
        characterList[index].SetActive(true);
    }

    public void Confirm()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        if(index == 0)
        {
            SceneManager.LoadScene("OpeningCutscene");
        }
        else if(index == 1)
        {
            SceneManager.LoadScene("OpeningCutsceneCrate");
        }
        else if (index == 2)
        {
            SceneManager.LoadScene("OpeningCutsceneSalt");
        }
        //SceneManager.LoadScene("GB_LevelOne");
    }
}

