using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A simple script that allows you to switch between scenes (maps)
//Also includes a loading screen!

public class map_select : MonoBehaviour
{

    public GameObject keep; // This GameObject is what you would like to keep as the main menu changes to a map (see the top text when playing the scene).
    public GameObject loading; //This GameObject is going to be attached to LoadingImage (A loading screen basically)

    void Awake()
    {
        DontDestroyOnLoad(keep); //Whatever the "keep" is attached to. (I may write this in a seperate script because you have to attach this to the gameobject you want to keep as well as the canvas) see below for a more detailed explanation as to why its attached to the canvas.
    }

    public void LoadScene(int level) // MUST BE PUBLIC //level =  go to build settings and see the scenes that are included in the build (at the top) there is a number besides on the right next to each scene. This is the level variable thingy. see below on more instuctions
    {
        loading.SetActive(true);
        Application.LoadLevel(level);
    }

}

/*  Uhhhhh Explanation?? Also how to's
 
    Attach this script to the canvas that contains all the UI elements, including the buttons. BUTTONS MUST BE USED.
    Now click on the button in the editor and scroll down on the right side (>) till you see "On Click ()"
    Press the "+" button under "OnClick()"
    Attach Canvas to the gameobject in the "OnClick()" section
    Go to the function drop down box
    Select "map_select.LoadScene"
    Now for the box that has a number in it, it is dependant on what the button is trying to load
    For instance if the button was to load the Tundra map.
    You need to go to the build settings and see the scenes that are included. There should be a number on the right hand side next to the scenes, the main menu scene should have 0 and lets say Tundra has a 1. 
    We are trying to load tundra so we should place in the number box under "OnClick()" the number 1. 
    This lets unity recognize that we are refering to the scene 1 and that we would like to switch there. 
    
    Go back to Canvas. Attach the loading screen to the public gameobject box "loading"
    This is so that everytime the scene switches a small loading screen will play until the second scene is loaded.

    Now for the "keep" gameobject, Im debating to put this on another script due to you have to attach this script to the gameobject as well as keeping it attached to the canvas. Then dragging said gameobject into the box. 
    Its messy and confusing and I didnt realize it'd be a pain like this. But I forgot about the logic where if I was to just keep this script attached to the canvas, the canvas was obviously going to "delete" when the scene is switched.
    However what this  function does ("DontDestroyOnLoad(Keep)") is that whatever gameobject is identified as keep will stay when switching between scenes, I dont know what we can use this for but you never know!


    Okay thats most of it.
    If confused please Message Natasha.

    */