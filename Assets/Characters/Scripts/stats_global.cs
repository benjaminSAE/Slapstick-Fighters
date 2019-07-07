using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats_global : MonoBehaviour
{
    public float movementSpeed;
    public float attackDamage;
    public float attackSpeed;
    public float attackStamina;
    public float dodgeDistance;
    public float dodgeCooldown;
    public float dodgeSpeed;
    public float dodgeStamina;
    public bool damageBlocker = false;
    public float maxHealthPoints;
    public float maxStaminaPoints = 100.0f;
    public float staminaRegen = 0.1f;
    [HideInInspector]
    public float rotation = 0.1f;
    [HideInInspector]
    public float rotationSpeed = 100.0f;
}
