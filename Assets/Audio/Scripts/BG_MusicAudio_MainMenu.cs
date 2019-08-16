using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_MusicAudio_MainMenu : MonoBehaviour
{
    FMOD.Studio.EventInstance mainMenuMusicMusic;
    [FMODUnity.EventRef] [SerializeField] private string mainMenuMusic;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuMusicMusic = FMODUnity.RuntimeManager.CreateInstance(mainMenuMusic);
        mainMenuMusicMusic.start();
    }

    public void EndMusic()
    {
        mainMenuMusicMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
