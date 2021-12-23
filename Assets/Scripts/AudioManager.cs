/******************************************************************************
Author: Evan Talavera

Name of Class: AudioManager

Description of Class: Contains function to control when sounds are played in game.

Date Created: 12/8/21
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    void Awake()
    {
        //Ensures there is only one audio manager at any time
        if(instance == null) 
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        //Assigns the variables to the corresponding values
        foreach (Sound s in sounds) 
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("BGM");
    }
    public void Play(string name) 
    {
        //Searches through the entire array for the specified sound and assigns it to "s".
        Sound s =Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Stop(string name) 
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound:" + name + "wasn't found");
            return;
        }
        s.source.Stop();
    }
}
