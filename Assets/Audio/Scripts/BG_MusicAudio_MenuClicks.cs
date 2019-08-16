using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_MusicAudio_MenuClicks : MonoBehaviour
{
    FMOD.Studio.EventInstance forwardClick;
    FMOD.Studio.EventInstance backwardsClick;
    FMOD.Studio.EventInstance selectClick;

    [FMODUnity.EventRef] [SerializeField] private string forwardClickSound;
    [FMODUnity.EventRef] [SerializeField] private string backwardsClickSound;
    [FMODUnity.EventRef] [SerializeField] private string selectClickSound;

    // Start is called before the first frame update
    void Start()
    {
        forwardClick = FMODUnity.RuntimeManager.CreateInstance(forwardClickSound);
        backwardsClick = FMODUnity.RuntimeManager.CreateInstance(backwardsClickSound);
        selectClick = FMODUnity.RuntimeManager.CreateInstance(selectClickSound);
    }

    public void ForwardsClick()
    {
        forwardClick.start();
    }

    public void BackwardsClick()
    {
        backwardsClick.start();
    }

    public void SelectClick()
    {
        selectClick.start();
    }
}
