using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public Light thisLight;
    public bool flicker = false;

    [Tooltip("Turning on randomization will add some amount of delay to each flicker based on the range specified")]
    public bool randomize = false;
    public float minTimeOn = 0.1f;
    public float maxTimeOn = 2f;

    [Tooltip("The number of times per second this light will flicker, if not randomized")]
    public float flickerRate = 2f;

    private float nextFlickerTime = 0f;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        if (!thisLight)
        {
            thisLight = GetComponent<Light>();

            if (!thisLight)
            {
                Debug.Log("No light component found on " + gameObject.name);
            }
        }

        audioSource = GetComponent<AudioSource>();

        if(audioSource== null)
        {
            Debug.Log("No audioSourcesource was found for the flickering light.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (flicker)
        {
            if (Time.time >= nextFlickerTime)
            {
                if (flickerRate == 0)
                {
                    Debug.Log(gameObject.name + " cannot flicker because it's frequency is set to 0");
                }

                else
                {
                    if (randomize)
                    {
                        float rand = Random.Range(minTimeOn, maxTimeOn);
                        Invoke("Flicker", rand);
                        nextFlickerTime = Time.time + 1f / (flickerRate + rand);
                    }

                    else
                    {
                        Flicker();
                        nextFlickerTime = Time.time + 1f / flickerRate;
                    }
                }
            }
        }
    }

    public void Flicker()
    {
        thisLight.GetComponent<Light>().enabled = !thisLight.GetComponent<Light>().enabled;
        audioSource.Play();
    }
}
