/******************************************************************************
Author: Evan Talavera

Name of Class: Sound

Description of Class: Contains variables that can be changed to adjust sound clip 

Date Created: 12/8/21
******************************************************************************/

using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Sound  
{
    public string name;

    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;
    [Range(0.1f,3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
