using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class global_respawn : MonoBehaviour
{
    GameObject CharacterSelectValues;

    public static global_respawn Instance;

    [SerializeField] private Transform spawnPlayer1;
    [SerializeField] private Transform spawnPlayer2;

    [SerializeField] private GameObject archerPlayer1;
    [SerializeField] private GameObject knightPlayer1;
    [SerializeField] private GameObject tankPlayer1;
    [SerializeField] private GameObject archerPlayer2;
    [SerializeField] private GameObject knightPlayer2;
    [SerializeField] private GameObject tankPlayer2;

    int playerOne;
    int playerTwo;
    private Animator animatorPlayerOne;
    private Animator animatorPlayerTwo;

    private GameObject player2;
    private GameObject player1;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CharacterSelectValues = GameObject.Find("CharacterSelectValues");
        playerOne = CharacterSelectValues.GetComponent<BG_Player_Select>().characterPlayer1;
        playerTwo = CharacterSelectValues.GetComponent<BG_Player_Select>().characterPlayer2;
    }

    private void Update()
    {
        if (playerTwo == 1)
        {
            player2 = GameObject.Find("ArcherPlayer2(Clone)");
        }
        else if (playerTwo == 2)
        {
            player2 = GameObject.Find("KnightPlayer2(Clone)");
        }
        else if (playerTwo == 3)
        {
            player2 = GameObject.Find("TankPlayer2(Clone)");
        }

        if (playerOne == 1)
        {
            player1 = GameObject.Find("ArcherPlayer1(Clone)");
        }
        else if (playerOne == 2)
        {
            player1 = GameObject.Find("KnightPlayer1(Clone)");
        }
        else if (playerOne == 3)
        {
            player1 = GameObject.Find("TankPlayer1(Clone)");
        }
    }

    public void RespawnPlayer1()
    {
        if (playerOne == 1)
        {
            animatorPlayerOne = GameObject.Find("ArcherPlayer1(Clone)").GetComponent<Animator>();
            animatorPlayerOne.SetBool("isRespawning", true);
            Instantiate(archerPlayer1, spawnPlayer1.transform);
            StartCoroutine(COStunPause(1.2f));

            BG_CharacterAudio characterAudioInstance = player2.GetComponent<BG_CharacterAudio>();
            characterAudioInstance.PlayerSounds(BG_CharacterAudio.soundList.RespawnScreaming);
        }

        if (playerOne == 2)
        {
            animatorPlayerOne = GameObject.Find("KnightPlayer1(Clone)").GetComponent<Animator>();
            animatorPlayerOne.SetBool("isRespawning", true);
            Instantiate(knightPlayer1, spawnPlayer1.transform);
            StartCoroutine(COStunPause(1.2f));

            BG_CharacterAudio characterAudioInstance = player2.GetComponent<BG_CharacterAudio>();
            characterAudioInstance.PlayerSounds(BG_CharacterAudio.soundList.RespawnScreaming);
        }

        if (playerOne == 3)
        {
            animatorPlayerOne = GameObject.Find("TankPlayer1(Clone)").GetComponent<Animator>();
            animatorPlayerOne.SetBool("isRespawning", true);
            Instantiate(tankPlayer1, spawnPlayer1.transform);
            StartCoroutine(COStunPause(1.2f));

            BG_CharacterAudio characterAudioInstance = player2.GetComponent<BG_CharacterAudio>();
            characterAudioInstance.PlayerSounds(BG_CharacterAudio.soundList.RespawnScreaming);
        }
    }

    public void RespawnPlayer2()
    {
        if (playerTwo == 1)
        {
            animatorPlayerTwo = GameObject.Find("ArcherPlayer2(Clone)").GetComponent<Animator>();
            animatorPlayerTwo.SetBool("isRespawning", true);
            Instantiate(archerPlayer2, spawnPlayer2.transform);
            StartCoroutine(COStunPause(1.2f));

            BG_CharacterAudio characterAudioInstance = player2.GetComponent<BG_CharacterAudio>();
            characterAudioInstance.PlayerSounds(BG_CharacterAudio.soundList.RespawnScreaming);
        }

        if (playerTwo == 2)
        {
            animatorPlayerTwo = GameObject.Find("KnightPlayer2(Clone)").GetComponent<Animator>();
            animatorPlayerTwo.SetBool("isRespawning", true);
            Instantiate(knightPlayer2, spawnPlayer2.transform);
            StartCoroutine(COStunPause(1.2f));

            BG_CharacterAudio characterAudioInstance = player2.GetComponent<BG_CharacterAudio>();
            characterAudioInstance.PlayerSounds(BG_CharacterAudio.soundList.RespawnScreaming);
        }

        if (playerTwo == 3)
        {
            animatorPlayerTwo = GameObject.Find("TankPlayer2(Clone)").GetComponent<Animator>();
            animatorPlayerTwo.SetBool("isRespawning", true);
            Instantiate(tankPlayer2, spawnPlayer2.transform);
            StartCoroutine(COStunPause(1.2f));

            BG_CharacterAudio characterAudioInstance = player2.GetComponent<BG_CharacterAudio>();
            characterAudioInstance.PlayerSounds(BG_CharacterAudio.soundList.RespawnScreaming);
        }
    }

    public IEnumerator COStunPause(float pauseTime)
    {
        yield return new WaitForSeconds(pauseTime);
        animatorPlayerOne.SetBool("isRespawning", false);
        animatorPlayerTwo.SetBool("isRespawning", false);
    }
}
