using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KS_Scene_Loader : MonoBehaviour
{
    int mapSelect;

    private void Start()
    {
        mapSelect = 1;
    }

    public void MapSelectionSwamp()
    {
        mapSelect = 1;
    }

    public void MapSelectionTundra()
    {
        mapSelect = 2;
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

    public void MapSelection()
    {
        if (mapSelect == 1)
        {
            SceneManager.LoadScene("KS_SwampMap");
        }

        if (mapSelect == 2)
        {
            SceneManager.LoadScene("KS_Tundra_Map");
        }
    }
}
