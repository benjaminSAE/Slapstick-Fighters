using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_MusicAudio_VictoryMenu : MonoBehaviour
{
    FMOD.Studio.EventInstance victoryMusic;
    [FMODUnity.EventRef] [SerializeField] private string victoryMusicMusic;

    // Start is called before the first frame update
    void Start()
    {
        victoryMusic = FMODUnity.RuntimeManager.CreateInstance(victoryMusicMusic);
        victoryMusic.start();
    }

    public void StopMusic()
    {
        victoryMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
