using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Centered_Listener : MonoBehaviour
{
    private Transform player1;
    private Transform player2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject CharacterSelectValues = GameObject.Find("CharacterSelectValues");
        int whichPlayer1 = CharacterSelectValues.GetComponent<BG_Player_Select>().characterPlayer1;
        int whichPlayer2 = CharacterSelectValues.GetComponent<BG_Player_Select>().characterPlayer2;

        if (whichPlayer2 == 1)
        {
            player2 = GameObject.Find("ArcherPlayer2(Clone)").GetComponent<Transform>();
        }
        else if (whichPlayer2 == 2)
        {
            player2 = GameObject.Find("KnightPlayer2(Clone)").GetComponent<Transform>();
        }
        else if (whichPlayer2 == 3)
        {
            player2 = GameObject.Find("TankPlayer2(Clone)").GetComponent<Transform>();
        }

        if (whichPlayer1 == 1)
        {
            player1 = GameObject.Find("ArcherPlayer1(Clone)").GetComponent<Transform>();
        }
        else if (whichPlayer1 == 2)
        {
            player1 = GameObject.Find("KnightPlayer1(Clone)").GetComponent<Transform>();
        }
        else if (whichPlayer1 == 3)
        {
            player1 = GameObject.Find("TankPlayer1(Clone)").GetComponent<Transform>();
        }

        Move();
    }

    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        transform.position = centerPoint;
    }

    private Vector3 GetCenterPoint()
    {
        var bounds = new Bounds(player1.position, Vector3.zero);

        bounds.Encapsulate(player1.position);
        bounds.Encapsulate(player2.position);

        return bounds.center;
    }
}
