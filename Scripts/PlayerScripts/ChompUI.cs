using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChompUI : MonoBehaviour
{
    [SerializeField] int specialPoints;
    [SerializeField] int maxSpecialPoints;
    [SerializeField] BR_PlayerSpecialAbility chomp;
    [SerializeField] Image chompSlider;
    [SerializeField] GameObject pressE;
    [SerializeField] GameObject chompText;

    // Start is called before the first frame update
    void Start()
    {
        chomp = GameObject.FindGameObjectWithTag ("Player").GetComponent<BR_PlayerSpecialAbility>();
        chompSlider = GameObject.Find ("AbilityAmount").GetComponent<Image>();
        pressE = GameObject.Find ("PressE");
        pressE.SetActive (false);
        chompText = GameObject.Find ("ChompText");
    }

    // Update is called once per frame
    void Update()
    {
        specialPoints = chomp.GetSpecialPoints ();
        maxSpecialPoints = chomp.GetMaxSpecialPoints ();

        chompSlider.fillAmount = (float) specialPoints / (float) maxSpecialPoints;

        if (specialPoints >= maxSpecialPoints)
        {
            pressE.SetActive (true);
            pressE.gameObject.GetComponent<TextMeshProUGUI> ().color = Color.Lerp (Color.magenta, Color.blue, Mathf.PingPong (Time.time, 1));
            chompSlider.color = Color.Lerp (Color.magenta, Color.blue, Mathf.PingPong (Time.time, 1));
            chompText.gameObject.GetComponent<TextMeshProUGUI>().color = Color.Lerp (Color.magenta, Color.blue, Mathf.PingPong (Time.time, 1));
        }
        else
        {
            pressE.SetActive (false);
            pressE.gameObject.GetComponent<TextMeshProUGUI> ().color = Color.white;
            chompSlider.color = Color.white;
            chompText.gameObject.GetComponent<TextMeshProUGUI> ().color = Color.white;
        }
    }
}
