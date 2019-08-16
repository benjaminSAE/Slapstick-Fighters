using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_archer : MonoBehaviour
{
    //stating values for initialisation
    float attackDamage;
    float attackSpeed;
    float attackStamina;
    float attackCooldown;
    float currentStaminaPoints;

    float nextAttack;
    [SerializeField] private KeyCode attack;
    [SerializeField] private Animator animator;

    //changable values for everything to do with the archer's ranged attack
    float attackDistance;
    float attackDistanceBase = 0.017f;
    float attackDistanceBaseCorner = 0.6f;

    float rotation;

    [SerializeField] private GameObject archerArrow;
    [SerializeField] private float arrowSpeed = 100f;
    [SerializeField] private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();

        //initialising values according to this object's "global_stats"
        attackDistance = gameObject.GetComponent<global_stats>().attackDistance;
        attackDamage = gameObject.GetComponent<global_stats>().attackDamage;
        attackSpeed = gameObject.GetComponent<global_stats>().attackSpeed;
        attackStamina = gameObject.GetComponent<global_stats>().attackStamina;
        attackCooldown = gameObject.GetComponent<global_stats>().attackCooldown;

    }

    // Update is called once per frame
    void Update()
    {

        //updating "rotation" to equal the same value inside "global_movement_controls"
        rotation = gameObject.GetComponent<global_movement_controls>().rotation;

        //updating "currentStaminaPoints" to equal the same value inside "global_stamina"
        currentStaminaPoints = gameObject.GetComponent<global_stamina>().currentStaminaPoints;

        //when the while loop finishes transform the location of the arrow back to the archer


        //running custom method stated below
        ArcherAttack();
    }

    //everything that enables the archer's arrow shooting, stamina usage and cooldown
    void ArcherAttack()
    {

        if (currentStaminaPoints > attackStamina && Time.time > nextAttack && Input.GetKeyDown(attack))
        {
            animator.SetBool("isArcherAttacking", true);

            GameObject instArcherArrow = Instantiate(archerArrow, transform.position + offset, Quaternion.identity) as GameObject;
            Rigidbody instArcherArrowRigidbody = instArcherArrow.GetComponent<Rigidbody>();
            instArcherArrowRigidbody.AddForce(transform.forward * arrowSpeed);

            //setting the cooldown before the next attack can be activated
            nextAttack = Time.time + attackCooldown;

            //runs the method from "global_stamina" to use an amount of stamina points
            global_stamina stamina_globalInstance = GetComponent<global_stamina>();
            stamina_globalInstance.AttackStamina();

            BG_CharacterAudio characterAudioInstance = GetComponent<BG_CharacterAudio>();
            characterAudioInstance.PlayerSounds(BG_CharacterAudio.soundList.ArcherAttack);
        }
        else
        {
            animator.SetBool("isArcherAttacking", false);
        }
    }
}