using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Player1_Select : MonoBehaviour
{
    //creating a value to determine which character player one selected: 1 = Archer, 2 = Knight and 3 = Tank
    public int characterSelectP1 = 3;
    public CharacterType characterPlayer1 = CharacterType.Undefined;
    public CharacterType characterPlayer2 = CharacterType.Undefined;

    public static BG_Player1_Select Instance;

    private void Start()
    {
        Debug.LogWarning("START BG 1 SELECT 2");
        characterSelectP1 = 2;
    }

    private void Awake()
    {
        Debug.LogWarning("AWAKE BG 1 SELECT 2");
        Instance = this;
    }

    public void ArcherSelect()
    {
        characterSelectP1 = 1;
        characterPlayer1 = CharacterType.Archer;
    }

    public void KnightSelect()
    {
        characterSelectP1 = 2;
    }

    public void TankSelect()
    {
        characterSelectP1 = 3;
    }
}
