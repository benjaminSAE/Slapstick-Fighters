using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stamina_global : MonoBehaviour
{
    float maxStaminaPoints;
    float staminaRegen;
    float dodgeStamina;
    float attackStamina;
    [HideInInspector]
    public float currentStaminaPoints;

    public static stamina_global Instance;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        dodgeStamina = gameObject.GetComponent<stats_global>().dodgeStamina;
        attackStamina = gameObject.GetComponent<stats_global>().attackStamina;
        maxStaminaPoints = gameObject.GetComponent<stats_global>().maxStaminaPoints;
        staminaRegen = gameObject.GetComponent<stats_global>().staminaRegen;
        currentStaminaPoints = maxStaminaPoints;
        print(dodgeStamina);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentStaminaPoints < maxStaminaPoints)
        {
            currentStaminaPoints = currentStaminaPoints + staminaRegen;
        }
    }

    public void DodgeStamina()
    {
        print(dodgeStamina);
        currentStaminaPoints = currentStaminaPoints - dodgeStamina;
    }

    public void AttackStamina()
    {
        currentStaminaPoints = currentStaminaPoints - attackStamina;
    }
}
