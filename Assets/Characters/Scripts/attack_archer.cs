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

    [SerializeField] private GameObject archer;
    [SerializeField] private GameObject archerArrow;



    //true/false statement to determine when the Coroutine's while loop finishes
    bool whileLoop = false;

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
        if (whileLoop == false)
        {
            archerArrow.transform.position = archer.transform.position;
            animator.SetBool("isAttacking", false);
        }

        //running custom method stated below
        ArcherAttack();

        whileLoop = false;
        
    }

    //everything that enables the archer's arrow shooting, stamina usage and cooldown
    void ArcherAttack()
    {
        
        if (currentStaminaPoints > attackStamina && Time.time > nextAttack && Input.GetKeyDown(attack))
        {
            //upwards attack movement
            if (rotation > -22 && rotation < 22)
            {
                animator.SetBool("isAttacking", true);
                //setting the direction of the Coroutine and starting the Coroutine
                Vector3 top = new Vector3(0, 0, attackDistance * attackDistanceBase);
                StartCoroutine(smooth_move(top, 1f));

                //setting the cooldown before the next attack can be activated
                nextAttack = Time.time + attackCooldown;

                //runs the method from "global_stamina" to use an amount of stamina points
                global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                stamina_globalInstance.AttackStamina();
            }

            //upwards/right attack movement
            if (rotation > 23 && rotation < 67)
            {
                animator.SetBool("isAttacking", true);
                //setting the direction of the Coroutine and starting the Coroutine
                Vector3 topRight = new Vector3(attackDistance * attackDistanceBase * attackDistanceBaseCorner, 0, attackDistance * attackDistanceBase * attackDistanceBaseCorner);
                StartCoroutine(smooth_move(topRight, 1f));

                //setting the cooldown before the next attack can be activated
                nextAttack = Time.time + attackCooldown;

                //runs the method from "global_stamina" to use an amount of stamina points
                global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                stamina_globalInstance.AttackStamina();
            }

            //right attack movement
            if (rotation > 68 && rotation < 112)
            {
                animator.SetBool("isAttacking", true);
                //setting the direction of the Coroutine and starting the Coroutine
                Vector3 right = new Vector3(attackDistance * attackDistanceBase, 0, 0);
                StartCoroutine(smooth_move(right, 1f));

                //setting the cooldown before the next attack can be activated
                nextAttack = Time.time + attackCooldown;

                //runs the method from "global_stamina" to use an amount of stamina points
                global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                stamina_globalInstance.AttackStamina();
            }

            //downwards/right attack movement
            if (rotation > 113 && rotation < 157)
            {
                animator.SetBool("isAttacking", true);
                //setting the direction of the Coroutine and starting the Coroutine
                Vector3 bottomRight = new Vector3(attackDistance * attackDistanceBase * attackDistanceBaseCorner, 0, -attackDistance * attackDistanceBase * attackDistanceBaseCorner);
                StartCoroutine(smooth_move(bottomRight, 1f));

                //setting the cooldown before the next attack can be activated
                nextAttack = Time.time + attackCooldown;

                //runs the method from "global_stamina" to use an amount of stamina points
                global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                stamina_globalInstance.AttackStamina();
            }

            //downwards attack movement
            if (rotation > 158 && rotation < 200 || rotation > -200 && rotation < -158)
            {
                animator.SetBool("isAttacking", true);
                //setting the direction of the Coroutine and starting the Coroutine
                Vector3 bottom = new Vector3(0, 0, -attackDistance * attackDistanceBase);
                StartCoroutine(smooth_move(bottom, 1f));

                //setting the cooldown before the next attack can be activated
                nextAttack = Time.time + attackCooldown;

                //runs the method from "global_stamina" to use an amount of stamina points
                global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                stamina_globalInstance.AttackStamina();
            }

            //downwards/left attack movement
            if (rotation > -157 && rotation < -113)
            {
                animator.SetBool("isAttacking", true);
                //setting the direction of the Coroutine and starting the Coroutine
                Vector3 bottomLeft = new Vector3(-attackDistance * attackDistanceBase * attackDistanceBaseCorner, 0, -attackDistance * attackDistanceBase * attackDistanceBaseCorner);
                StartCoroutine(smooth_move(bottomLeft, 1f));

                //setting the cooldown before the next attack can be activated
                nextAttack = Time.time + attackCooldown;

                //runs the method from "global_stamina" to use an amount of stamina points
                global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                stamina_globalInstance.AttackStamina();
            }

            //left attack movement
            if (rotation > -112 && rotation < -68)
            {
                animator.SetBool("isAttacking", true);
                //setting the direction of the Coroutine and starting the Coroutine
                Vector3 left = new Vector3(-attackDistance * attackDistanceBase, 0, 0);
                StartCoroutine(smooth_move(left, 1f));

                //setting the cooldown before the next attack can be activated
                nextAttack = Time.time + attackCooldown;

                //runs the method from "global_stamina" to use an amount of stamina points
                global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                stamina_globalInstance.AttackStamina();
            }

            //upwards/left attack movement
            if (rotation > -67 && rotation < -23)
            {
                animator.SetBool("isAttacking", true);
                //setting the direction of the Coroutine and starting the Coroutine
                Vector3 topLeft = new Vector3(-attackDistance * attackDistanceBase * attackDistanceBaseCorner, 0, attackDistance * attackDistanceBase * attackDistanceBaseCorner);
                StartCoroutine(smooth_move(topLeft, 1f));

                //setting the cooldown before the next attack can be activated
                nextAttack = Time.time + attackCooldown;

                //runs the method from "global_stamina" to use an amount of stamina points
                global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                stamina_globalInstance.AttackStamina();
            }

            BG_CharacterAudio characterAudioInstance = GetComponent<BG_CharacterAudio>();
            characterAudioInstance.PlayerSounds(BG_CharacterAudio.soundList.ArcherAttack);
        }
        
    }

    //method that runs the Coroutine
    IEnumerator smooth_move(Vector3 direction, float speed)
    {
        float startime = Time.time;
        Vector3 start_pos = transform.position; //Starting position.
        Vector3 end_pos = transform.position + direction; //Ending position.

        while (start_pos != end_pos && ((Time.time - startime) * speed) < 1f)
        {
            float move = Mathf.Lerp(0, 1, (Time.time - startime) * speed);

            archerArrow.transform.position += direction * move;

            whileLoop = true;

            yield return null;
        }
    }
}
