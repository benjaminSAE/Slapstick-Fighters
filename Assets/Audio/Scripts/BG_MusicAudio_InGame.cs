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

    private bool startBattleMusic = false;
    private bool startInstrumentalMusic = true;

    // Awake is called as soon as the object loads
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LateStart(1));

        instrumentalMusic = FMODUnity.RuntimeManager.CreateInstance(instrumentalMusicMusic);
        battleMusic = FMODUnity.RuntimeManager.CreateInstance(battleMusicMusic);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player1.position, player2.position);

        MusicChanger();
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

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
    }

    private void MusicChanger()
    {
        if (distance < minDistance)
        {
            startInstrumentalMusic = true;
            if (startBattleMusic == true)
            {
                print("battleMusic.start();");
                instrumentalMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                //battleMusic.start();
                startBattleMusic = false;
            }
        }
        else
        {
            startBattleMusic = true;
            if (startInstrumentalMusic == true)
            {
                print("instrumentalMusic.start();");
                battleMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                instrumentalMusic.start();
                startInstrumentalMusic = false;
            }
        }
    }
}
