using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleToggle : MonoBehaviour
{
    int[] player1Row = new int[2];
    int[] player2Row = new int[2];

    bool[] player1Selected = new bool[2];
    bool[] player2Selected = new bool[2];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ArcherButtonP1()
    {
        player1Selected[0] = true;
        player1Selected[1] = false;
        player1Selected[2] = false;
    }

    private void KnightButtonP1()
    {
        player1Selected[0] = false;
        player1Selected[1] = true;
        player1Selected[2] = false;
    }

    private void TankButtonP1()
    {
        player1Selected[0] = false;
        player1Selected[1] = false;
        player1Selected[2] = true;
    }

    private void ArcherButtonP2()
    {
        player2Selected[0] = true;
        player2Selected[1] = false;
        player2Selected[2] = false;
    }

    private void KnightButtonP2()
    {
        player2Selected[0] = false;
        player2Selected[1] = true;
        player2Selected[2] = false;
    }

    private void TankButtonP2()
    {
        player2Selected[0] = false;
        player2Selected[1] = false;
        player2Selected[2] = true;
    }
}
