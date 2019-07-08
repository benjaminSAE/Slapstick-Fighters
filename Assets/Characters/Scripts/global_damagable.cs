using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class global_damagable : MonoBehaviour
{
    private float maxHP;
    private float currentHP;
    private float attackDamage;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = gameObject.GetComponent<global_stats>().maxHealthPoints;
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DoDamage()
    {
        if(currentHP < 0)
        {
            //run player life method
        }
    }

    private void OnCollisionEnter(Collision collider)
    {
        GameObject objectCollided = collider.gameObject;
        if (objectCollided.CompareTag("Attacker"))
        {
            attackDamage = objectCollided.GetComponentInParent<global_stats>().attackDamage;
            currentHP -= attackDamage;
        }

    }
}
