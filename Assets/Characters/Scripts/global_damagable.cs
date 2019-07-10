using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class global_damagable : MonoBehaviour
{
    private float maxHP;
    private float currentHP;
    private float attackDamage;

    bool attacking;
    bool damageBlocker;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = gameObject.GetComponent<global_stats>().maxHealthPoints;
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        DoDamage();
    }

    void DoDamage()
    {
        if(currentHP <= 0)
        {
            //run player life method
            print("dead: " + gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        GameObject objectCollided = collider.gameObject;
        damageBlocker = objectCollided.GetComponentInParent<global_movement_controls>().damageBlocker;

        if (damageBlocker = false && objectCollided.CompareTag("Attacker") && currentHP > 0)
        {
            attackDamage = objectCollided.GetComponentInParent<global_stats>().attackDamage;
            currentHP -= attackDamage;
        }
    }
}
