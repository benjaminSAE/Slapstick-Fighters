using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate_Player2 : MonoBehaviour
{
    int characterSelectP2;

    [SerializeField] private GameObject archerPrefab;
    [SerializeField] private GameObject knightPrefab;
    [SerializeField] private GameObject tankPrefab;

    [SerializeField] private Transform player2Spawn;

    // Start is called before the first frame update
    void Start()
    {
        GameObject characterSelect = GameObject.Find("CharacterSelectValues");

        characterSelectP2 = characterSelect.GetComponent<BG_Player_Select>().characterPlayer2;

        if (characterSelectP2 == 1)
        {
            Instantiate(archerPrefab, player2Spawn.position, transform.rotation);
        }

        if (characterSelectP2 == 2)
        {
            Instantiate(knightPrefab, player2Spawn.position, transform.rotation);
        }

        if (characterSelectP2 == 3)
        {
            Instantiate(tankPrefab, player2Spawn.position, transform.rotation);
        }
    }
}
