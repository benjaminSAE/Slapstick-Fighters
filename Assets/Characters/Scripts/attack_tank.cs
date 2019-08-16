using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_tank : MonoBehaviour
{
    //stating values for initialisation
    float attackDamage;
    float attackSpeed;
    float attackStamina;
    float attackCooldown;
    float currentStaminaPoints;
    float nextAttack;

    //customisable control option that can be set in the inspector
    public KeyCode attack;

    //stating movement related values for initialisation
    float attackDistance;
    float attackDistanceBase = 0.017f;
    float attackDistanceBaseCorner = 0.6f;
    float rotation;
    bool whileLoop;

    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        //initialising values from "global_stats"
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

        //running custom method stated below
        TankAttack();



    }

    //everything that enables the tank's attack movement, stamina usage and cooldown
    void TankAttack()
    {
        if (currentStaminaPoints > attackStamina && Time.time > nextAttack && Input.GetKeyDown(attack))
        {
            animator.SetBool("isTankAttacking", true);
            //start clockwise rotation of sword with a Coroutine;
            //StartCoroutine(RotateMe(Vector3.up * 90, 0.8f));

            //setting time before second swing


            //setting the cooldown before the next attack can be activated
            nextAttack = Time.time + attackCooldown;

            //runs the method from "global_stamina" to use an amount of stamina points
            global_stamina stamina_globalInstance = GetComponent<global_stamina>();
            stamina_globalInstance.AttackStamina();

            BG_CharacterAudio characterAudioInstance = GetComponent<BG_CharacterAudio>();
            characterAudioInstance.PlayerSounds(BG_CharacterAudio.soundList.TankAttack);
        }
        else
        {
            animator.SetBool("isTankAttacking", false);
        }
    }
}

//    //method that runs the Coroutine
//    IEnumerator smooth_move(Vector3 direction, float speed)
//    {
//        float startime = Time.time;
//        Vector3 start_pos = transform.position; //Starting position.
//        Vector3 end_pos = transform.position + direction; //Ending position.

//        while (start_pos != end_pos && ((Time.time - startime) * speed) < 1f)
//        {
//            float move = Mathf.Lerp(0, 1, (Time.time - startime) * speed);

//            transform.position += direction * move;

//            whileLoop = true;

//            yield return null;
//        }
//    }
//}
