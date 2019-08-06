using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Player2_Select : MonoBehaviour
{
    //creating a value to determine which character player two selected: 1 = Archer, 2 = Knight and 3 = Tank
    public int characterSelectP2 = 3;

    public static BG_Player2_Select Instance;

    private void Start()
    {
        Debug.LogWarning("START BG 2 SELECT 2");
        characterSelectP2 = 2;    
    }

    private void Awake()
    {
        Debug.LogWarning("AWAKE BG 2 SELECT 2");
        Instance = this;
    }

    public void ArcherSelect()
    {
        characterSelectP2 = 1;
    }

    public void KnightSelect()
    {
        characterSelectP2 = 2;
    }

    public void TankSelect()
    {
        characterSelectP2 = 3;
    }
}
