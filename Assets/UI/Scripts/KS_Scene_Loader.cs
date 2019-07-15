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
}
