using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_knight : MonoBehaviour
{
    float attackDamage;
    float attackSpeed;
    float attackStamina;
    float attackCooldown;
    float currentStaminaPoints;
    float nextAttack;
    public KeyCode attack;

    float attackDistance;
    float attackDistanceBase = 0.17f;
    float attackDistanceBaseCorner = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        attackDistance = gameObject.GetComponent<global_stats>().attackDistance;
        attackDamage = gameObject.GetComponent<global_stats>().attackDamage;
        attackSpeed = gameObject.GetComponent<global_stats>().attackSpeed;
        attackStamina = gameObject.GetComponent<global_stats>().attackStamina;
        attackCooldown = gameObject.GetComponent<global_stats>().attackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
