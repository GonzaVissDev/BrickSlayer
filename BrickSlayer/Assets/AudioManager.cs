using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        //  DontDestroyOnLoad(gameObject);
        foreach (Sound S in sounds)
        {
            S.source = gameObject.AddComponent<AudioSource>();
            //  S.source.outputAudioMixerGroup = gameObject.GetComponent<AudioMixerGroup>();



            S.source.clip = S.clip;
            S.source.volume = S.volume;
            S.source.loop = S.Loop;
            S.source.outputAudioMixerGroup = S.effect;




        }
    }

    public void Play(string name)
    {
        Sound S = Array.Find(sounds, sound => sound.name == name);
        S.source.Play();



    }
    public void Stop(string name)
    {
        Sound S = Array.Find(sounds, sound => sound.name == name);
        if (S == null)
        {
            Debug.LogWarning("Sound:" + name + "Not FOund");
        }
        S.source.Stop();


    }
}
