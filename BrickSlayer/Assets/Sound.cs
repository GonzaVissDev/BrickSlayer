using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


[System.Serializable]
public class Sound

{
    public string name;


    public AudioClip clip;
    public AudioMixerGroup effect;

    [Range(0f, 1f)]
    public float volume;



    public bool Loop;

    [HideInInspector]
    public AudioSource source;




}
