﻿using System.Collections;
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

    float swordRotation;
    float setSwordRotation = 90;
    float rotationSpeed = 20;
    [SerializeField] private GameObject swordHilt;
    
    float swordSwing2 = 9999999f;

    /*
    swordRotation -= Time.deltaTime * rotationSpeed;
    transform.rotation = Quaternion.Euler(0, swordRotation, 0);
    */

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
        //updating "currentStaminaPoints" to equal the same value inside "global_stamina"
        currentStaminaPoints = gameObject.GetComponent<global_stamina>().currentStaminaPoints;

        KnightAttack();

        if (swordSwing2 < Time.time)
        {
            //start clockwise rotation of sword with a Coroutine;
            StartCoroutine(RotateMe(Vector3.up * -90, 0.8f));

            swordSwing2 = 9999999f;
        }
    }

    //everything that enables the archer's arrow shooting, stamina usage and cooldown
    void KnightAttack()
    {
        if (swordSwing2 == 9999999f && currentStaminaPoints > attackStamina && Time.time > nextAttack && Input.GetKeyDown(attack))
        {
            //start clockwise rotation of sword with a Coroutine;
            StartCoroutine(RotateMe(Vector3.up * 90, 0.8f));

            //setting time before second swing
            swordSwing2 = Time.time + 0.7f;

            //setting the cooldown before the next attack can be activated
            nextAttack = Time.time + attackCooldown;

            //runs the method from "global_stamina" to use an amount of stamina points
            global_stamina stamina_globalInstance = GetComponent<global_stamina>();
            stamina_globalInstance.AttackStamina();
        }
    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = swordHilt.transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            swordHilt.transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);

            global_movement_controls global_movement_controlsInstance = GetComponent<global_movement_controls>();
            global_movement_controlsInstance.StopRotation();

            yield return null;
        }
    }
}
