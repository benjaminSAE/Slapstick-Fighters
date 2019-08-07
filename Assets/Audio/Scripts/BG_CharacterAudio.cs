using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_CharacterAudio : MonoBehaviour
{
    [HideInInspector] public enum soundList { Walking, SqueekyFeet, Whoosh, ArcherAttack, KnightAttack, TankAttack, Death, FallingDeath, Dodging, Flinching, HealthCollect, StaminaCollect, RespawnScreaming, VictoryShout, VictoryDance }

    [FMODUnity.EventRef] [SerializeField] private string walkingSounds;
    [FMODUnity.EventRef] [SerializeField] private string squeekyFeetSounds;
    [FMODUnity.EventRef] [SerializeField] private string whooshSounds;
    [FMODUnity.EventRef] [SerializeField] private string archerAttackSounds;
    [FMODUnity.EventRef] [SerializeField] private string knightAttackSounds;
    [FMODUnity.EventRef] [SerializeField] private string tankAttackSounds;
    [FMODUnity.EventRef] [SerializeField] private string deathSounds;
    [FMODUnity.EventRef] [SerializeField] private string fallingDeathSounds;
    [FMODUnity.EventRef] [SerializeField] private string dodgingSounds;
    [FMODUnity.EventRef] [SerializeField] private string flinchingSounds;
    [FMODUnity.EventRef] [SerializeField] private string healthCollectSounds;
    [FMODUnity.EventRef] [SerializeField] private string staminaCollectSounds;
    [FMODUnity.EventRef] [SerializeField] private string respawnScreamingSounds;
    [FMODUnity.EventRef] [SerializeField] private string victoryShoutSounds;
    [FMODUnity.EventRef] [SerializeField] private string victoryDanceSounds;

    FMOD.Studio.EventInstance playerSoundEvent;
    FMOD.Studio.EventInstance player2SoundEvent;

    public static BG_CharacterAudio Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(playerSoundEvent, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }

    /// <summary>
    /// To use:  Player1Sounds(soundList. *name of sound* );  
    /// </summary>
    public void PlayerSounds(soundList whichSound)
    {
        switch (whichSound)
        {
            case soundList.Walking:
                //do something
                playerSoundEvent = FMODUnity.RuntimeManager.CreateInstance(walkingSounds);
                break;

            case soundList.SqueekyFeet:
                //do something
                playerSoundEvent = FMODUnity.RuntimeManager.CreateInstance(squeekyFeetSounds);
                break;

            case soundList.Whoosh:
                //do something
                playerSoundEvent = FMODUnity.RuntimeManager.CreateInstance(whooshSounds);
                break;

            case soundList.ArcherAttack:
                //do something
                playerSoundEvent = FMODUnity.RuntimeManager.CreateInstance(archerAttackSounds);
                break;

            case soundList.KnightAttack:
                //do something
                playerSoundEvent = FMODUnity.RuntimeManager.CreateInstance(knightAttackSounds);
                break;

            case soundList.TankAttack:
                //do something
                playerSoundEvent = FMODUnity.RuntimeManager.CreateInstance(tankAttackSounds);
                break;

            case soundList.Death:
                //do something
                playerSoundEvent = FMODUnity.RuntimeManager.CreateInstance(deathSounds);
                break;

            case soundList.FallingDeath:
                //do something
                playerSoundEvent = FMODUnity.RuntimeManager.CreateInstance(fallingDeathSounds);
                break;

            case soundList.Dodging:
                //do something
                playerSoundEvent = FMODUnity.RuntimeManager.CreateInstance(dodgingSounds);
                break;

            case soundList.Flinching:
                //do something
                playerSoundEvent = FMODUnity.RuntimeManager.CreateInstance(flinchingSounds);
                break;

            case soundList.HealthCollect:
                //do something
                playerSoundEvent = FMODUnity.RuntimeManager.CreateInstance(healthCollectSounds);
                break;

            case soundList.StaminaCollect:
                //do something
                playerSoundEvent = FMODUnity.RuntimeManager.CreateInstance(staminaCollectSounds);
                break;

            case soundList.RespawnScreaming:
                //do something
                playerSoundEvent = FMODUnity.RuntimeManager.CreateInstance(respawnScreamingSounds);
                break;

            case soundList.VictoryShout:
                //do something
                playerSoundEvent = FMODUnity.RuntimeManager.CreateInstance(victoryShoutSounds);
                break;

            case soundList.VictoryDance:
                //do something
                playerSoundEvent = FMODUnity.RuntimeManager.CreateInstance(victoryDanceSounds);
                break;
        }

        playerSoundEvent.start();
    }
}
