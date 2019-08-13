using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class global_kill_counter : MonoBehaviour
{
    public static global_kill_counter Instance;

    private bool player1;
    private bool player2;

    [HideInInspector] public int player1Deaths;
    [HideInInspector] public int player2Deaths;

    private Text player1KillsText;
    private Text player2KillsText;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        player1KillsText = GameObject.Find("Player1Kills").GetComponent<Text>();
        player2KillsText = GameObject.Find("Player2Kills").GetComponent<Text>();
    }

    void Update()
    {
        player1KillsText.text = player1Deaths.ToString();
        player2KillsText.text = player2Deaths.ToString();
    }

    public void ScoreCounterPlayer1()
    {
        ++player2Deaths;
    }

    public void ScoreCounterPlayer2()
    {
        ++player1Deaths;
    }
}
