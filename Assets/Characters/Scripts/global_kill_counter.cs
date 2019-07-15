using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class global_kill_counter : MonoBehaviour
{
    private int playerNumber;

    // Start is called before the first frame update
    void Start()
    {
        playerNumber = gameObject.GetComponent<global_stats>().playerNumber;
    }

    public void PlayerKill()
    {

    }
}
