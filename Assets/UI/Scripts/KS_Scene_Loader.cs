using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KS_Scene_Loader : MonoBehaviour
{
    public void MapSelectionSwamp()
    {
        SceneManager.LoadScene("KT_SwampMap");
    }

    public void MapSelectionTundra()
    {
        SceneManager.LoadScene("NA_TundraMap");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("KS_Main_Menu");
    }

    public void MainMenuLeaderboard()
    {
        GameObject CharacterSelectValues = GameObject.Find("CharacterSelectValues");
        GameObject KillCounter = GameObject.Find("KillCounter");

        Destroy(CharacterSelectValues);
        Destroy(KillCounter);

        SceneManager.LoadScene("KS_Main_Menu");
    }
}
