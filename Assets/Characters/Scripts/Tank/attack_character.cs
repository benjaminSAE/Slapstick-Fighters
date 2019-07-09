using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_character : MonoBehaviour
{
    float attackDamage;
    float attackSpeed;
    float attackStamina;
    public KeyCode attack;
    [HideInInspector] public bool attacking = false;

    float attackDistance;
    float attackDistanceBase = 0.17f;
    float attackDistanceBaseCorner = 0.6f;

    float rotation;

    float currentStaminaPoints;

    // Start is called before the first frame update
    void Start()
    {
        attackDistance = gameObject.GetComponent<global_stats>().attackDistance;
        attackDamage = gameObject.GetComponent<global_stats>().attackDamage;
        attackSpeed = gameObject.GetComponent<global_stats>().attackSpeed;
        attackStamina = gameObject.GetComponent<global_stats>().attackStamina;
    }

    // Update is called once per frame
    void Update()
    {
        rotation = gameObject.GetComponent<global_movement_controls>().rotation;

        currentStaminaPoints = gameObject.GetComponent<global_stamina>().currentStaminaPoints;

        TankAttack();
        print(attacking);
    }

    void TankAttack()
    {
        
        if (Input.GetKeyDown(attack))
        {
            if (rotation > -3 && rotation < 3)
            {
                Vector3 top = new Vector3(0, 0, attackDistance * attackDistanceBase);
                StartCoroutine(smooth_move(top, 1f));

                //runs the method from "global_stamina" to use an amount of stamina points
                global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                stamina_globalInstance.AttackStamina();
            }

            if (rotation > 42 && rotation < 48)
            {
                Vector3 topRight = new Vector3(attackDistance * attackDistanceBase * attackDistanceBaseCorner, 0, attackDistance * attackDistanceBase * attackDistanceBaseCorner);
                StartCoroutine(smooth_move(topRight, 1f));

                //runs the method from "global_stamina" to use an amount of stamina points
                global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                stamina_globalInstance.AttackStamina();
            }

            if (rotation > 87 && rotation < 93)
            {
                Vector3 right = new Vector3(attackDistance * attackDistanceBase, 0, 0);
                StartCoroutine(smooth_move(right, 1f));

                //runs the method from "global_stamina" to use an amount of stamina points
                global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                stamina_globalInstance.AttackStamina();
            }

            if (rotation > 132 && rotation < 138)
            {
                Vector3 bottomRight = new Vector3(attackDistance * attackDistanceBase * attackDistanceBaseCorner, 0, -attackDistance * attackDistanceBase * attackDistanceBaseCorner);
                StartCoroutine(smooth_move(bottomRight, 1f));

                //runs the method from "global_stamina" to use an amount of stamina points
                global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                stamina_globalInstance.AttackStamina();
            }

            if (rotation > 177 && rotation < 183 || rotation > -183 && rotation < -177)
            {
                Vector3 bottom = new Vector3(0, 0, -attackDistance * attackDistanceBase);
                StartCoroutine(smooth_move(bottom, 1f));

                //runs the method from "global_stamina" to use an amount of stamina points
                global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                stamina_globalInstance.AttackStamina();
            }

            if (rotation > -138 && rotation < -132)
            {
                Vector3 bottomLeft = new Vector3(-attackDistance * attackDistanceBase * attackDistanceBaseCorner, 0, -attackDistance * attackDistanceBase * attackDistanceBaseCorner);
                StartCoroutine(smooth_move(bottomLeft, 1f));

                //runs the method from "global_stamina" to use an amount of stamina points
                global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                stamina_globalInstance.AttackStamina();
            }

            if (rotation > -93 && rotation < -87)
            {
                Vector3 left = new Vector3(-attackDistance * attackDistanceBase, 0, 0);
                StartCoroutine(smooth_move(left, 1f));

                //runs the method from "global_stamina" to use an amount of stamina points
                global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                stamina_globalInstance.AttackStamina();
            }

            if (rotation > -48 && rotation < -42)
            {
                Vector3 topLeft = new Vector3(-attackDistance * attackDistanceBase * attackDistanceBaseCorner, 0, attackDistance * attackDistanceBase * attackDistanceBaseCorner);
                StartCoroutine(smooth_move(topLeft, 1f));

                //runs the method from "global_stamina" to use an amount of stamina points
                global_stamina stamina_globalInstance = GetComponent<global_stamina>();
                stamina_globalInstance.AttackStamina();
            }
        }
        else
        {
            attacking = false;
        }
    }

    IEnumerator smooth_move(Vector3 direction, float speed)
    {
        float startime = Time.time;
        Vector3 start_pos = transform.position; //Starting position.
        Vector3 end_pos = transform.position + direction; //Ending position.

        while (start_pos != end_pos && ((Time.time - startime) * speed) < 1f)
        {
            float move = Mathf.Lerp(0, 1, (Time.time - startime) * speed);

            attacking = true;

            transform.position += direction * move;

            yield return null;
        }
    }
}
