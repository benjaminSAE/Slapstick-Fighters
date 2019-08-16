﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KT_RoundTimerScript : MonoBehaviour
{
    float currentTime = 0f;
    //time in seconds
    [SerializeField] public float startingTime = 180f;
    private Text CountdownText;

    void Start()
    {
        currentTime = startingTime;
        CountdownText = GameObject.Find("Timer").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //change 1 * deltatime if you want the game to countdown faster, 3 * for 3x faster etc
        currentTime -= 1 * Time.deltaTime;
        CountdownText.text = currentTime.ToString("0");
        if (currentTime <= 0)
        {
            currentTime = 0;
            BG_MusicAudio_InGame.Instance.StopMusic();
            SceneManager.LoadScene("KS_Leaderboard");
        }
    }
}