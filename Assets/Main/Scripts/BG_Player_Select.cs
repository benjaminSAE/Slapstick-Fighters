using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Player_Select : MonoBehaviour
{
    public void Player1Tank()
    {
        Debug.LogWarning("P1 TANK");
        BG_Player1_Select.Instance.TankSelect();
    }

    public void Player1Archer()
    {
        Debug.LogWarning("P1 ARCHER");
        BG_Player1_Select.Instance.ArcherSelect();
    }

    public void Player1Knight()
    {
        Debug.LogWarning("P1 KNIGHT");
        BG_Player1_Select.Instance.KnightSelect();
    }

    public void Player2Tank()
    {
        Debug.LogWarning("P2 TANK");
        BG_Player2_Select.Instance.TankSelect();
    }

    public void Player2Archer()
    {
        Debug.LogWarning("P2 ARCHER");
        BG_Player2_Select.Instance.ArcherSelect();
    }

    public void Player2Knight()
    {
        Debug.LogWarning("P2 KNIGHT");
        BG_Player2_Select.Instance.KnightSelect();
    }
}
