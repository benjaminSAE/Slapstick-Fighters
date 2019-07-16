using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BG_Leaderboard : MonoBehaviour
{
    private GameObject CharacterSelectValues;
    private GameObject KillCounter;

    private int player1Kills;
    private int player2Kills;

    private int player1Character;
    private int player2Character;

    //text objects for win/lose screen
    [SerializeField] private Text winnerWinnerPlayer;
    [SerializeField] private Text loserLoserPlayer;

    //text objects for main leaderboard
    [SerializeField] private Text winnerKills;
    [SerializeField] private Text winnerCharacter;
    [SerializeField] private Text winnerPlayer;
    [SerializeField] private Text loserKills;
    [SerializeField] private Text loserCharacter;
    [SerializeField] private Text loserPlayer;

    // Start is called before the first frame update
    void Start()
    {
        CharacterSelectValues = GameObject.Find("CharacterSelectValues");
        KillCounter = GameObject.Find("KillCounter");

        player1Character = CharacterSelectValues.GetComponent<BG_Player1_Select>().characterSelectP1;
        player2Character = CharacterSelectValues.GetComponent<BG_Player2_Select>().characterSelectP2;

        player1Kills = KillCounter.GetComponent<global_kill_counter>().player1Deaths;
        player2Kills = KillCounter.GetComponent<global_kill_counter>().player2Deaths;
        
        Leaderboard();
    }

    private void Leaderboard()
    {
        if (player1Kills > player2Kills)
        {
            //changing text values for win/lose
            winnerWinnerPlayer.text = "Player 1";

            //changing text values for main leaderboard
            winnerKills.text = player1Kills.ToString();
            winnerPlayer.text = "Player 1";

            if (player1Character == 1)
            {
                winnerCharacter.text = "Archer";
            }

            if (player1Character == 2)
            {
                winnerCharacter.text = "Knight";
            }

            if (player1Character == 3)
            {
                winnerCharacter.text = "Tank";
            }
        }
        else
        {
            //changing text values for win/lose
            winnerWinnerPlayer.text = "Player 2";

            //changing text values for main leaderboard
            winnerKills.text = player2Kills.ToString();
            winnerPlayer.text = "Player 2";

            if (player2Character == 1)
            {
                winnerCharacter.text = "Archer";
            }

            if (player2Character == 2)
            {
                winnerCharacter.text = "Knight";
            }

            if (player2Character == 3)
            {
                winnerCharacter.text = "Tank";
            }
        }

        if (player1Kills < player2Kills)
        {
            //changing text values for win/lose
            loserLoserPlayer.text = "Player 1";

            //changing text values for main leaderboard
            loserKills.text = player1Kills.ToString();
            loserPlayer.text = "Player 1";

            if (player1Character == 1)
            {
                loserCharacter.text = "Archer";
            }

            if (player1Character == 2)
            {
                loserCharacter.text = "Knight";
            }

            if (player1Character == 3)
            {
                loserCharacter.text = "Tank";
            }
        }
        else
        {
            //changing text values for win/lose
            loserLoserPlayer.text = "Player 2";

            //changing text values for main leaderboard
            loserKills.text = player2Kills.ToString();
            loserPlayer.text = "Player 2";

            if (player2Character == 1)
            {
                loserCharacter.text = "Archer";
            }

            if (player2Character == 2)
            {
                loserCharacter.text = "Knight";
            }

            if (player2Character == 3)
            {
                loserCharacter.text = "Tank";
            }
        }
    }
}
