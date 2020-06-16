using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class BR_AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public AudioMixer audioMixer;
    int _musicVol = 5;
    int _sfxVol = 5;

    public int MusicVol { get =>  _musicVol; set => _musicVol = value; }
    public int SFXVol { get => _sfxVol; set => _sfxVol = value; }

    public static BR_AudioManager instance;
    

    private void Awake ()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy (gameObject);
            return;
        }

        DontDestroyOnLoad (gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource> ();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.mixerGroup;
        }

        SetAudioMixerValues();
    }

    public void Play (string name)
    {
        Sound s = Array.Find (sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning ("Sound: " + name + " not found!");
            return;
        }

        if(s != null)
        {
            s.source.Play();
        }

        //s.source.Play ();
    }

    public void Stop (string name)
    {
        Sound s = Array.Find (sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning ("Sound: " + name + " not found!");
            return;
        }

        s.source.Stop ();
        
    }


    public void ButtonSound ()
    {
        Play ("ButtonClick");
    }

    public void PlayLevelTheme ()
    {
        if (SceneManager.GetActiveScene ().name == "MainMenu" || SceneManager.GetActiveScene().name == "BR_MainMenu")
        {
            
            Stop ("GB_LevelOne");
            Stop ("GB_LevelTwo"); 
            Stop ("GB_LevelThree");
            Stop("BM_ActionBlock");
            Stop("ArenaMusic");
            Stop("Tutorial");
            Stop("WinSceneMusic");
            Stop("LoseSceneMusic");
            Play("MainMenuMusic");
        } 
        else if(SceneManager.GetActiveScene().name == "GB_CharacterSelection")
        {
            Stop("MainMenuMusic");
            Play("CharacterSelection");
        }
        else if (SceneManager.GetActiveScene ().name == "OpeningCutscene")
        {
            Stop("MainMenuMusic");
            Stop("CharacterSelection");
            Play("OpeningCutsceneMusic");
        }
        else if (SceneManager.GetActiveScene().name == "OpeningCutsceneCrate")
        {
            Stop("MainMenuMusic");
            Stop("CharacterSelection");
            Play("OpeningCutsceneMusic");
        }
        else if (SceneManager.GetActiveScene().name == "OpeningCutsceneSalt")
        {
            Stop("MainMenuMusic");
            Stop("CharacterSelection");
            Play("OpeningCutsceneMusic");
        }
        else if(SceneManager.GetActiveScene().name == "GB_Level2Cutscene")
        {
            Stop("GB_LevelOne");
            Play("2ndCutscene");
        }
        else if (SceneManager.GetActiveScene().name == "GB_Level2CutsceneCrate")
        {
            Stop("GB_LevelOne");
            Play("2ndCutscene");
        }
        else if (SceneManager.GetActiveScene().name == "GB_Level2CutsceneSalt")
        {
            Stop("GB_LevelOne");
            Play("2ndCutscene");
        }
        else if(SceneManager.GetActiveScene().name == "GB_Level3Cutscene")
        {
            Stop("GB_LevelTwo");
            Play("3rdCutscene");
        }
        else if (SceneManager.GetActiveScene().name == "GB_Level3CutsceneCrate")
        {
            Stop("GB_LevelTwo");
            Play("3rdCutscene");
        }
        else if (SceneManager.GetActiveScene().name == "GB_Level3CutsceneSalt")
        {
            Stop("GB_LevelTwo");
            Play("3rdCutscene");
        }
        else if (SceneManager.GetActiveScene().name == "FinalBossCutscenePartOne")
        {
            Stop("GB_LevelThree");
            Play("FinalBossCutscene");
        }
        else if (SceneManager.GetActiveScene().name == "FinalBossCutscenePartOneCrate")
        {
            Stop("GB_LevelThree");
            Play("FinalBossCutscene");
        }
        else if (SceneManager.GetActiveScene().name == "FinalBossCutscenePartOneSalt")
        {
            Stop("GB_LevelThree");
            Play("FinalBossCutscene");
        }
        else if (SceneManager.GetActiveScene ().name == "GB_LevelOne")
        {
            Stop("MainMenuMusic");
            Stop("Tutorial");
            Stop ("OpeningCutsceneMusic");
            Stop("ArenaMusic");
            Stop("GB_LevelTwo");
            Stop("GB_LevelThree");
            Stop("WinSceneMusic");
            Stop("LoseSceneMusic");
            Stop("CharacterSelection");
            Play ("GB_LevelOne");
           
        }
        else if (SceneManager.GetActiveScene ().name == "GB_LevelTwo")
        {
            Stop("GB_LevelOne");
            Stop("2ndCutscene");
            Stop("ArenaMusic");
            Stop("MainMenuMusic");

            Play ("GB_LevelTwo");
        }
        else if (SceneManager.GetActiveScene ().name == "GB_LevelThree")
        {
            Stop("GB_LevelTwo");
            Stop("ArenaMusic");
            Stop("MainMenuMusic");
            Stop("3rdCutscene");

            Play ("GB_LevelThree");
        }
        
        else if (SceneManager.GetActiveScene().name == "BM_ActionBlock")
        {
            Stop("GB_LevelTwo");
            Stop("GB_LevelThree");
            Stop("MainMenuMusic");
            Stop("FinalBossCutscene");

            Play("FinalBoss");
        }
        
        else if (SceneManager.GetActiveScene ().name == "Tutorial")
        {
            Stop("MainMenuMusic");
            Play("Tutorial");
        }

        else if (SceneManager.GetActiveScene ().name == "LevelFour")
        {
            Stop("LevelThreeMusic");
            Stop("MainMenuMusic");

            Play("LevelFourMusic");
        }
        else if (SceneManager.GetActiveScene ().name == "LevelFive")
        {
            Stop("LevelFourMusic");
            Stop("MainMenuMusic");

            Play("LevelFiveMusic");
        }

        else if (SceneManager.GetActiveScene ().name == "LoseScene")
        {
            Stop("MainMenuMusic");
            Stop("Tutorial");
            Stop("Arena");
            Stop("GB_LevelOne");
            Stop("GB_LevelTwo");
            Stop("GB_LevelThree");
            Stop("LevelFourMusic");
            Stop("LevelFiveMusic");

            Play("LoseSceneMusic");

        }
        else if (SceneManager.GetActiveScene ().name == "WinScene")
        {
            Stop("GB_LevelThree");
            Stop("MainMenuMusic");
            Stop("ArenaMusic");
            Stop("FinalBoss");

            Play("WinSceneMusic");
        }
    }

    public void StopSongs(string[] songs)
    {
        foreach(string s in songs)
        {
            Stop(s);
        }
    }

    public void SetAudioMixerValues()
    {
        if (_musicVol == 0)
        {
            audioMixer.SetFloat("Music", -80f);
        }
        else
        {
            audioMixer.SetFloat("Music", Mathf.Log10(_musicVol / 50f) * 10);
        }

        if (_sfxVol == 0)
        {
            audioMixer.SetFloat("SFX", -80f);
        }
        else
        {
            audioMixer.SetFloat("SFX", Mathf.Log10(_sfxVol / 50f) * 10);
        }
    }
}
