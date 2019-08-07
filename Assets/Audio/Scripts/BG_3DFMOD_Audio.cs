using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_3DFMOD_Audio : MonoBehaviour
{
    [HideInInspector] public enum soundList { Walking, SqueekyFeet, Whoosh, ArcherAttack, KnightAttack, TankAttack, Death, FallingDeath, Dodging, Flinching, ForwardMenu, BackwardMenu, HealthCollect, StaminaCollect, RespawnScreaming, VictoryShout, VictoryDance }

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
    [FMODUnity.EventRef] [SerializeField] private string forwardMenuClick;
    [FMODUnity.EventRef] [SerializeField] private string backwardMenuClick;
    [FMODUnity.EventRef] [SerializeField] private string healthCollectSounds;
    [FMODUnity.EventRef] [SerializeField] private string staminaCollectSounds;
    [FMODUnity.EventRef] [SerializeField] private string respawnScreamingSounds;
    [FMODUnity.EventRef] [SerializeField] private string victoryShoutSounds;
    [FMODUnity.EventRef] [SerializeField] private string victoryDanceSounds;

    FMOD.Studio.EventInstance player1SoundEvent;
    FMOD.Studio.EventInstance player2SoundEvent;

    public static BG_3DFMOD_Audio Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(player1SoundEvent, GetComponent<Transform>(), GetComponent<Rigidbody>());
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(player2SoundEvent, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }

    /// <summary>
    /// To use:  Player1Sounds(soundList. *name of sound* );  
    /// </summary>
    public void Player1Sounds(soundList whichSound)
    {
        switch (whichSound)
        {
            case soundList.Walking:
                //do something
                player1SoundEvent = FMODUnity.RuntimeManager.CreateInstance(walkingSounds);
                break;

            case soundList.SqueekyFeet:
                //do something
                player1SoundEvent = FMODUnity.RuntimeManager.CreateInstance(squeekyFeetSounds);
                break;

            case soundList.Whoosh:
                //do something
                player1SoundEvent = FMODUnity.RuntimeManager.CreateInstance(whooshSounds);
                break;

            case soundList.ArcherAttack:
                //do something
                player1SoundEvent = FMODUnity.RuntimeManager.CreateInstance(archerAttackSounds);
                break;

            case soundList.KnightAttack:
                //do something
                player1SoundEvent = FMODUnity.RuntimeManager.CreateInstance(knightAttackSounds);
                break;

            case soundList.TankAttack:
                //do something
                player1SoundEvent = FMODUnity.RuntimeManager.CreateInstance(tankAttackSounds);
                break;

            case soundList.Death:
                //do something
                player1SoundEvent = FMODUnity.RuntimeManager.CreateInstance(deathSounds);
                break;

            case soundList.FallingDeath:
                //do something
                player1SoundEvent = FMODUnity.RuntimeManager.CreateInstance(fallingDeathSounds);
                break;

            case soundList.Dodging:
                //do something
                player1SoundEvent = FMODUnity.RuntimeManager.CreateInstance(dodgingSounds);
                break;

            case soundList.Flinching:
                //do something
                player1SoundEvent = FMODUnity.RuntimeManager.CreateInstance(flinchingSounds);
                break;

            case soundList.ForwardMenu:
                //do something
                player1SoundEvent = FMODUnity.RuntimeManager.CreateInstance(forwardMenuClick);
                break;

            case soundList.BackwardMenu:
                //do something
                player1SoundEvent = FMODUnity.RuntimeManager.CreateInstance(backwardMenuClick);
                break;

            case soundList.HealthCollect:
                //do something
                player1SoundEvent = FMODUnity.RuntimeManager.CreateInstance(healthCollectSounds);
                break;

            case soundList.StaminaCollect:
                //do something
                player1SoundEvent = FMODUnity.RuntimeManager.CreateInstance(staminaCollectSounds);
                break;

            case soundList.RespawnScreaming:
                //do something
                player1SoundEvent = FMODUnity.RuntimeManager.CreateInstance(respawnScreamingSounds);
                break;

            case soundList.VictoryShout:
                //do something
                player1SoundEvent = FMODUnity.RuntimeManager.CreateInstance(victoryShoutSounds);
                break;

            case soundList.VictoryDance:
                //do something
                player1SoundEvent = FMODUnity.RuntimeManager.CreateInstance(victoryDanceSounds);
                break;
        }

        player1SoundEvent.start();
    }

    /// <summary>
    /// To use:  Player2Sounds(soundList. *name of sound* );  
    /// </summary>
    public void Player2Sounds(soundList whichSound)
    {
        switch (whichSound)
        {
            case soundList.Walking:
                //do something
                player2SoundEvent = FMODUnity.RuntimeManager.CreateInstance(walkingSounds);
                break;

            case soundList.SqueekyFeet:
                //do something
                player2SoundEvent = FMODUnity.RuntimeManager.CreateInstance(squeekyFeetSounds);
                break;

            case soundList.Whoosh:
                //do something
                player2SoundEvent = FMODUnity.RuntimeManager.CreateInstance(whooshSounds);
                break;

            case soundList.ArcherAttack:
                //do something
                player2SoundEvent = FMODUnity.RuntimeManager.CreateInstance(archerAttackSounds);
                break;

            case soundList.KnightAttack:
                //do something
                player2SoundEvent = FMODUnity.RuntimeManager.CreateInstance(knightAttackSounds);
                break;

            case soundList.TankAttack:
                //do something
                player2SoundEvent = FMODUnity.RuntimeManager.CreateInstance(tankAttackSounds);
                break;

            case soundList.Death:
                //do something
                player2SoundEvent = FMODUnity.RuntimeManager.CreateInstance(deathSounds);
                break;

            case soundList.FallingDeath:
                //do something
                player2SoundEvent = FMODUnity.RuntimeManager.CreateInstance(fallingDeathSounds);
                break;

            case soundList.Dodging:
                //do something
                player2SoundEvent = FMODUnity.RuntimeManager.CreateInstance(dodgingSounds);
                break;

            case soundList.Flinching:
                //do something
                player2SoundEvent = FMODUnity.RuntimeManager.CreateInstance(flinchingSounds);
                break;

            case soundList.ForwardMenu:
                //do something
                player2SoundEvent = FMODUnity.RuntimeManager.CreateInstance(forwardMenuClick);
                break;

            case soundList.BackwardMenu:
                //do something
                player2SoundEvent = FMODUnity.RuntimeManager.CreateInstance(backwardMenuClick);
                break;

            case soundList.HealthCollect:
                //do something
                player2SoundEvent = FMODUnity.RuntimeManager.CreateInstance(healthCollectSounds);
                break;

            case soundList.StaminaCollect:
                //do something
                player2SoundEvent = FMODUnity.RuntimeManager.CreateInstance(staminaCollectSounds);
                break;

            case soundList.RespawnScreaming:
                //do something
                player2SoundEvent = FMODUnity.RuntimeManager.CreateInstance(respawnScreamingSounds);
                break;

            case soundList.VictoryShout:
                //do something
                player2SoundEvent = FMODUnity.RuntimeManager.CreateInstance(victoryShoutSounds);
                break;

            case soundList.VictoryDance:
                //do something
                player2SoundEvent = FMODUnity.RuntimeManager.CreateInstance(victoryDanceSounds);
                break;
        }

        player2SoundEvent.start();
    }
}
