﻿using System.Collections;
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

    private float staminaPickup;

    //private Text showStamina;

    private Image staminaBar;

    int playerNumber;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerNumber = gameObject.GetComponent<global_stats>().playerNumber;
        dodgeStamina = gameObject.GetComponent<global_stats>().dodgeStamina;
        attackStamina = gameObject.GetComponent<global_stats>().attackStamina;
        maxStaminaPoints = gameObject.GetComponent<global_stats>().maxStaminaPoints;
        staminaRegen = gameObject.GetComponent<global_stats>().staminaRegen;
        currentStaminaPoints = maxStaminaPoints;

        if (playerNumber == 1)
        {
            //showStamina = GameObject.Find("ShowStaminaPlayer1").GetComponent<Text>();
            staminaBar = GameObject.Find("StaminaBar Player1").GetComponent<Image>();
        }

        if (playerNumber == 2)
        {
            //showStamina = GameObject.Find("ShowStaminaPlayer2").GetComponent<Text>();
            staminaBar = GameObject.Find("StaminaBar Player2").GetComponent<Image>();
        }

        staminaPickup = maxStaminaPoints / 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentStaminaPoints < maxStaminaPoints)
        {
            currentStaminaPoints = currentStaminaPoints + staminaRegen;
        }

        //showStamina.text = "Stamina: " + currentStaminaPoints.ToString("F0");
        staminaBar.fillAmount = currentStaminaPoints / maxStaminaPoints;
    }

    public void DodgeStamina()
    {
        currentStaminaPoints = currentStaminaPoints - dodgeStamina;
    }

    public void AttackStamina()
    {
        currentStaminaPoints = currentStaminaPoints - attackStamina;
    }

    public void StaminaPickupMethod()
    {
        if (currentStaminaPoints + staminaPickup < maxStaminaPoints)
        {
            currentStaminaPoints += staminaPickup;
        }
        else
        {
            currentStaminaPoints = maxStaminaPoints;
        }
    }
}
