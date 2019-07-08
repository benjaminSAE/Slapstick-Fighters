using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KT_PlayerLivesScript : MonoBehaviour
{
    public Text PlayerLives;
    public int Lives = 0;
   
    void PlayerDeath() 
    {
        //respawn
        ++Lives;
        PlayerLives.text = "Lives: " + Lives.ToString();
    }
}
