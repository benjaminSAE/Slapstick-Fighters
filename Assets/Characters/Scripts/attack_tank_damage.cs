using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_tank_damage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collider)
    {
        GameObject objectCollided = collider.gameObject;
        if(objectCollided.CompareTag("Enemy"))
        {

        }
    }
}
