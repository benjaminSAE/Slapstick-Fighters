using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Player_Select : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Player1Tank()
    {
        BG_Player1_Select.Instance.TankSelect();
    }

    public void Player1Archer()
    {
        BG_Player1_Select.Instance.ArcherSelect();
    }

    public void Player1Knight()
    {
        BG_Player1_Select.Instance.KnightSelect();
    }

    public void Player2Tank()
    {
        BG_Player2_Select.Instance.TankSelect();
    }

    public void Player2Archer()
    {
        BG_Player2_Select.Instance.ArcherSelect();
    }

    public void Player2Knight()
    {
        BG_Player2_Select.Instance.KnightSelect();
    }
}
