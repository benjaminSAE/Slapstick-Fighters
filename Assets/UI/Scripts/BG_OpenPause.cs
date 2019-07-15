using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_OpenPause : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] private KeyCode pause = KeyCode.Escape;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(pause) && isPaused == false)
        {
            //open pause menu
        }

        if (Input.GetKey(pause) && isPaused == true)
        {
            //close pause menu
        }
    }
}
