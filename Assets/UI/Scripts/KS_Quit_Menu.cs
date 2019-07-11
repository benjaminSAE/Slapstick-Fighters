using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KS_Quit_Menu : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
