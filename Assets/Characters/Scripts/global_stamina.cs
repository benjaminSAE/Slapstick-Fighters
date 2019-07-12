using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class global_stamina : MonoBehaviour
{
    float maxStaminaPoints;
    float staminaRegen;
    float dodgeStamina;
    float attackStamina;
    [HideInInspector]
    public float currentStaminaPoints;

    public static global_stamina Instance;

    //[SerializeField] private Text showStamina;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        dodgeStamina = gameObject.GetComponent<global_stats>().dodgeStamina;
        attackStamina = gameObject.GetComponent<global_stats>().attackStamina;
        maxStaminaPoints = gameObject.GetComponent<global_stats>().maxStaminaPoints;
        staminaRegen = gameObject.GetComponent<global_stats>().staminaRegen;
        currentStaminaPoints = maxStaminaPoints;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentStaminaPoints < maxStaminaPoints)
        {
            currentStaminaPoints = currentStaminaPoints + staminaRegen;
        }

       // showStamina.text = "Stamina: " + currentStaminaPoints.ToString();
    }

    public void DodgeStamina()
    {
        currentStaminaPoints = currentStaminaPoints - dodgeStamina;
    }

    public void AttackStamina()
    {
        currentStaminaPoints = currentStaminaPoints - attackStamina;
    }
}
