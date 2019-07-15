using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Player1_Select : MonoBehaviour
{
    //creating a value to determine which character player one selected: 1 = Archer, 2 = Knight and 3 = Tank
    [HideInInspector] public int characterSelectP1;
     
    public static BG_Player1_Select Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ArcherSelect()
    {
        characterSelectP1 = 1;
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
