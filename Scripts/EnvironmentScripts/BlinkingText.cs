using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlinkingText : MonoBehaviour
{
    //Text text;
    TextMeshProUGUI textP;

    [SerializeField] public float blinkTime;

    void Start()
    {
        //text = GetComponent<Text>();
        textP = GetComponent<TextMeshProUGUI>();
        blinkTime = 1.5f;
        StartBlinking();
    }

    IEnumerator Blink()
    {
        while (true)
        {
            switch (textP.color.a.ToString())
            {
                case "0":
                    textP.color = new Color(textP.color.r, textP.color.g, textP.color.b, 1);
                    //Play Sound
                    yield return new WaitForSeconds(blinkTime);
                    break;
                case "1":
                    textP.color = new Color(textP.color.r, textP.color.g, textP.color.b, 0);
                    //Play Sound
                    yield return new WaitForSeconds(blinkTime);
                    break;
            }
        }
    }

    void StartBlinking()
    {
        StopCoroutine("Blink");
        StartCoroutine("Blink");
    }

    void StopBlinking()
    {
        StopCoroutine("Blink");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
