using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AS_DialougeManager : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.05f;

    [SerializeField] private bool PlayerSpeakingFirst;

    [SerializeField] private TextMeshProUGUI playerDialogueText;
    [SerializeField] private TextMeshProUGUI nPCDialougeText;

    [TextArea(3,10)]
    [SerializeField] private string[] playerDialougeSentences;
    [TextArea(3,10)]
    [SerializeField] private string[] nPCDialougeSentences;

    [SerializeField] private GameObject playerContinueButton;
    [SerializeField] private GameObject nPCContinueButton;

    private int playerIndex;
    private int nPCIndex;

    private void Start()
    {
        StartDialouge();
    }

    public void StartDialouge()
    {
        if (PlayerSpeakingFirst)
        {
            StartCoroutine(TypePlayerDialouge());
        }
        else
        {
            StartCoroutine(TypeNPCDialouge());
        }




        IEnumerator TypePlayerDialouge()
        {
            foreach (char letter in playerDialougeSentences[playerIndex].ToCharArray())
            {
                playerDialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }

            playerContinueButton.SetActive(true);

        }

         IEnumerator TypeNPCDialouge()
        {
            foreach (char letter in nPCDialougeSentences[nPCIndex].ToCharArray())
            {
                nPCDialougeText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }

            nPCContinueButton.SetActive(true);
        }

    }
}
