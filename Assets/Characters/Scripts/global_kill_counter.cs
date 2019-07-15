using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class global_kill_counter : MonoBehaviour
{
    private int playerNumber;

    private int player1Kills;
    private int player2Kills;

    private Text player1KillsText;
    private Text player2KillsText;

    [SerializeField] private GameObject archerPlayer1;
    [SerializeField] private GameObject archerPlayer2;
    [SerializeField] private GameObject knightPlayer1;
    [SerializeField] private GameObject knightPlayer2;
    [SerializeField] private GameObject tankPlayer1;
    [SerializeField] private GameObject tankPlayer2;

    // Start is called before the first frame update
    void Start()
    {
        player1KillsText = GameObject.Find("Player1Kills").GetComponent<Text>();
        player2KillsText = GameObject.Find("Player2Kills").GetComponent<Text>();

         

        playerNumber = gameObject.GetComponent<global_stats>().playerNumber;
    }

    void Update()
    {
        if (playerNumber == 2)
        {
            player1KillsText.text = "Kills: " + player1Kills.ToString("0");
        }

        if (playerNumber == 1)
        {
            player2KillsText.text = "Kills: " + player2Kills.ToString("0");
        }
    }

    public void ScoreCounter()
    {
        print("ScoreCounter");
        if (playerNumber == 2)
        {
            print("Kills: " + player1Kills);
            print("ScoreCounter Player1");
            ++player1Kills;
            player1KillsText.text = "Kills: " + player1Kills.ToString("0");
            print("Kills: " + player1Kills);
        }

        if (playerNumber == 1)
        {
            print("ScoreCounter Player1");
            player2Kills = player2Kills + 1;
            player2KillsText.text = "Kills: " + player2Kills.ToString("0");
        }
    }
}
