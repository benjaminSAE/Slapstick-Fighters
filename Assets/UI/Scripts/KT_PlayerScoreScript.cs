using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KT_PlayerScoreScript : MonoBehaviour
{
    public Text PlayerScore;
    public int Score = 0;

    void Update()
    {
        //I don't have anything to test it on so I just did on mouse click, add to score, and I had to put it under an Update method
        if (Input.GetMouseButtonDown(0))
         //respawn (not done yet)
         ++Score;
        PlayerScore.text = "Score: " + Score.ToString();
    }
}