using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class global_damagable : MonoBehaviour
{
    private float maxHP;
    private float currentHP;
    private float attackDamage;

    private bool attacking;
    private bool damageBlocker;

    private int playerNumber;

    //private Text showHealth;

    private Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        playerNumber = gameObject.GetComponent<global_stats>().playerNumber;
        maxHP = gameObject.GetComponent<global_stats>().maxHealthPoints;
        currentHP = maxHP;

        if (playerNumber == 1)
        {
            //showHealth = GameObject.Find("ShowHealthPlayer1").GetComponent<Text>();
            healthBar = GameObject.Find("HealthBar Player1").GetComponent<Image>();
        }

        if (playerNumber == 2)
        {
            //showHealth = GameObject.Find("ShowHealthPlayer2").GetComponent<Text>();
            healthBar = GameObject.Find("HealthBar Player2").GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNumber == 1 || playerNumber == 2)
        {
            //showHealth.text = "Health: " + currentHP.ToString("F0");
            healthBar.fillAmount = currentHP / maxHP;
        }
        
        print("current health: " + gameObject + " " + currentHP);

        DoDamage();
    }

    void DoDamage()
    {
        if(currentHP <= 0)
        {
            print("dead: " + gameObject);

            if (playerNumber == 1)
            {
                global_kill_counter.Instance.ScoreCounterPlayer1();
                global_respawn.Instance.RespawnPlayer1();
            }

            if (playerNumber == 2)
            {
                global_kill_counter.Instance.ScoreCounterPlayer2();
                global_respawn.Instance.RespawnPlayer2();
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        GameObject objectCollided = collider.gameObject;

        if (objectCollided.CompareTag("Attacker") && currentHP > 0)
        {
            attackDamage = objectCollided.GetComponentInParent<global_stats>().attackDamage;
            currentHP -= attackDamage;
        }
    }
}
