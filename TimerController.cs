using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimerText;
    public float timer;
    [SerializeField] bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            timer += Time.deltaTime;
            UpdateText ();
        }
    }

    void UpdateText ()
    {
        float seconds = (timer % 60);
        float minutes = ((int) (timer / 60) % 60);
        TimerText.text = "Timer: " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void StartTimer ()
    {
        isActive = true;
    }

    public void StopTimer ()
    {
        isActive = false;
    }
}
