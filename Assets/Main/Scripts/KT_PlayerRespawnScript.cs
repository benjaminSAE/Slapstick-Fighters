using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KT_PlayerRespawnScript : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        //I don't have anything to test it on so I just did on mouse click, add to score, and I had to put it under an Update method.
        //change method to OnDeath()
        if (Input.GetMouseButtonDown(0))
            GenerateRandomPosition();
    }

    public void GenerateRandomPosition()
    {
        float x = Random.Range(-5, 5);
        float y = 0.5f;
        float z = Random.Range(-5, 5);

        player.transform.position = new Vector3(x, y, z);
    }
}
