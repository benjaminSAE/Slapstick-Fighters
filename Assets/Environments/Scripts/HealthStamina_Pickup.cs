using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStamina_Pickup : MonoBehaviour
{
    [SerializeField] private bool whichGain;
    //if whichGain == false, health. if true, stamina.
    [SerializeField] private float pickupCooldown;
    private float pickupCooldownTimer;
    
    void Update()
    {
        if(pickupCooldownTimer > Time.time)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        GameObject objectCollided = collider.gameObject;

        if (pickupCooldownTimer < Time.time)
        {
            if (objectCollided.CompareTag("Player"))
            {
                pickupCooldownTimer = Time.time + pickupCooldown;
                print("object collected");

                if (whichGain == false)
                {
                    global_damagable stamina_globalInstance = objectCollided.GetComponent<global_damagable>();
                    stamina_globalInstance.HealthPickupMethod();

                    BG_CharacterAudio characterAudioInstance = objectCollided.GetComponent<BG_CharacterAudio>();
                    characterAudioInstance.PlayerSounds(BG_CharacterAudio.soundList.HealthCollect);
                }

                if (whichGain == true)
                {
                    global_stamina stamina_globalInstance = objectCollided.GetComponent<global_stamina>();
                    stamina_globalInstance.StaminaPickupMethod();

                    BG_CharacterAudio characterAudioInstance = objectCollided.GetComponent<BG_CharacterAudio>();
                    characterAudioInstance.PlayerSounds(BG_CharacterAudio.soundList.StaminaCollect);
                }
            }
        }
    }
}
