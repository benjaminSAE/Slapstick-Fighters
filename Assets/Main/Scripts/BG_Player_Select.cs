using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Player_Select : MonoBehaviour
{
    //creating a value to determine which character player one selected: 1 = Archer, 2 = Knight and 3 = Tank
    /*[HideInInspector]*/ public int characterPlayer1 = 2;
    /*[HideInInspector]*/ public int characterPlayer2 = 2;

    private void Awake()
    {
        characterPlayer1 = 2;
        characterPlayer2 = 2;
    }

    public void Player1Tank()
    {
        Debug.LogWarning("P1 TANK");
        characterPlayer1 = 3;
    }

    public void Player1Archer()
    {
        Debug.LogWarning("P1 ARCHER");
        characterPlayer1 = 1;
    }

    public void Player1Knight()
    {
        Debug.LogWarning("P1 KNIGHT");
        characterPlayer1 = 2;
    }

    public void Player2Tank()
    {
        Debug.LogWarning("P2 TANK");
        characterPlayer2 = 3;
    }

    public void Player2Archer()
    {
        Debug.LogWarning("P2 ARCHER");
        characterPlayer2 = 1;
    }

    public void Player2Knight()
    {
        Debug.LogWarning("P2 KNIGHT");
        characterPlayer2 = 2;
    }
}
