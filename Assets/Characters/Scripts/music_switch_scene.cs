using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code allows for music to be switched as the scene is switched
// Main menu will play one set of music then when a map is loaded a different set of music will play
// Any issues please message or talk to Natasha

public class music_switch_scene : MonoBehaviour
{ 
    public AudioClip map2Music;


    private AudioSource source;


    // Use this for initialization
    void Awake()
    {
      source = GetComponent<AudioSource>();
    }


    void OnLevelWasLoaded(int level)
    {
     if (level == 2)
        {
            source.clip = map2Music;
            source.Play();
        }

    }
}
