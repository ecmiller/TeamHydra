using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;
using UnityEditor;


//Author: Ben Murchie
//Purpose: PreProduction game 
//Using tutorial - Brackeys - https://youtu.be/YOaYQrN1oYQ

public class SettingsScript : MonoBehaviour
{
    
    public AudioMixer audioMixer;
    public BR_AudioManager audioManager;
    [SerializeField] private float volumeTuningValue = 0.1f;
    public Slider sfxSlider;
    public Slider musicSlider;

    //public TMP_Dropdown qualityDropdown;
    //public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start()
    {
        audioManager = GameObject.FindObjectOfType<BR_AudioManager>();
           
        if(gameObject.name == "ControlsMenu")
        {
            sfxSlider = null;
            musicSlider = null;
        }

        if(sfxSlider && musicSlider != null)
        {
            sfxSlider.value = audioManager.SFXVol;
            musicSlider.value = audioManager.MusicVol;
        }
            

        resolutions = Screen.resolutions;

        //resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && 
               resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        //resolutionDropdown.AddOptions(options);
        //resolutionDropdown.value = currentResolutionIndex;
        //resolutionDropdown.RefreshShownValue();

        audioManager = GameObject.FindObjectOfType<BR_AudioManager>();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // Logarithmic audio slider tutorial: https://gamedevbeginner.com/the-right-way-to-make-a-volume-slider-in-unity-using-logarithmic-conversion/
    public void SetMusicVolume()
    {
        //audioMixer.SetFloat("Music", Mathf.Log10(volume)*20);
        audioManager.MusicVol = (int)musicSlider.value;
        audioManager.SetAudioMixerValues();
    }

    public void SetSFXVolume()
    {
        /*
        if (volume == 0f)
        {
            audioMixer.SetFloat("SFX", 0f);
        }

        else
        {
            audioMixer.SetFloat("SFX", Mathf.Log10(volume / 50f) * 10);
        }
        */
        audioManager.SFXVol = (int) sfxSlider.value;
        audioManager.SetAudioMixerValues();
    }

    // If using buttons to increment/decrement volume, call these functions when the buttons are pressed
    public void IncreaseMusicVol()
    {
        audioMixer.GetFloat("Music", out float value);
        audioMixer.SetFloat("Music", Mathf.Clamp((value + volumeTuningValue), 0.0001f, 1f));
    }

    public void DecreaseMusicVol()
    {
        audioMixer.GetFloat("Music", out float value);
        audioMixer.SetFloat("Music", Mathf.Clamp((value - volumeTuningValue), 0.0001f, 1f));
    }

    public void IncreaseSFXVol()
    {
        audioMixer.GetFloat("SFX", out float value);
        audioMixer.SetFloat("SFX", Mathf.Clamp((value + volumeTuningValue), 0.0001f, 1f));
    }

    public void DecreaseSFXVol()
    {
        audioMixer.GetFloat("SFX", out float value);
        audioMixer.SetFloat("SFX", Mathf.Clamp((value - volumeTuningValue), 0.0001f, 1f));
    }

    public void SetQuality (int qualityIndex)
    {
        //qualityIndex = qualityDropdown.value;
        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SFXTest()
    {
        audioManager.Play("Shoot");
    }
}
