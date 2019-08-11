using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_MusicAudio_InGame : MonoBehaviour
{
    FMOD.Studio.EventInstance instrumentalMusic;
    FMOD.Studio.EventInstance battleMusic;
    FMOD.Studio.EventInstance battleMusic1;
    FMOD.Studio.EventInstance battleMusic2;
    FMOD.Studio.EventInstance battleMusic3;

    [FMODUnity.EventRef] [SerializeField] private string instrumentalMusicMusic;
    [FMODUnity.EventRef] [SerializeField] private string battleMusicMusic;
    [FMODUnity.EventRef] [SerializeField] private string battleMusic1Music;
    [FMODUnity.EventRef] [SerializeField] private string battleMusic2Music;
    [FMODUnity.EventRef] [SerializeField] private string battleMusic3Music;

    private int randomMusic;

    private Transform player1;
    private Transform player2;

    private float distance;

    private float minDistance = 10;

    // Start is called before the first frame update
    void Start()
    {
        instrumentalMusic = FMODUnity.RuntimeManager.CreateInstance(instrumentalMusicMusic);
        battleMusic = FMODUnity.RuntimeManager.CreateInstance(battleMusicMusic);
        battleMusic1 = FMODUnity.RuntimeManager.CreateInstance(battleMusic1Music);
        battleMusic2 = FMODUnity.RuntimeManager.CreateInstance(battleMusic2Music);
        battleMusic3 = FMODUnity.RuntimeManager.CreateInstance(battleMusic3Music);

        GameObject CharacterSelectValues = GameObject.Find("CharacterSelectValues");
        //int whichPlayer1 = CharacterSelectValues.GetComponent<BG_Player_Select>.characterPlayer1;
        //player1 = GameObject.Find("ArcherPlayer1").GetComponent<Transform>();
        //player2 = GameObject.Find("ArcherPlayer2").GetComponent<Transform>();
        //player1 = GameObject.Find("KnightPlayer1").GetComponent<Transform>();
        //player2 = GameObject.Find("KnightPlayer2").GetComponent<Transform>();
        //player1 = GameObject.Find("TankPlayer1").GetComponent<Transform>();
        //player2 = GameObject.Find("TankPlayer2").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player1.position, player2.position);

        MusicChanger();
    }

    private void MusicChanger()
    {
        if (distance < minDistance)
        {
            instrumentalMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            battleMusic1.start();
        }
        else
        {
            battleMusic1.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            instrumentalMusic.start();
        }
    }
}
