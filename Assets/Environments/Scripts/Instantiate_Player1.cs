using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate_Player1 : MonoBehaviour
{
    private int characterSelectP1;

    [SerializeField] private GameObject archerPrefab;
    [SerializeField] private GameObject knightPrefab;
    [SerializeField] private GameObject tankPrefab;

    [SerializeField] private Transform player1Spawn;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject characterSelect = GameObject.Find("CharacterSelectValues");

        characterSelectP1 = characterSelect.GetComponent<BG_Player_Select>().characterPlayer1;

        if (characterSelectP1 == 1)
        {
            Instantiate(archerPrefab, player1Spawn.position, transform.rotation);
        }

        if (characterSelectP1 == 2)
        {
            Instantiate(knightPrefab, player1Spawn.position, transform.rotation);
        }

        if (characterSelectP1 == 3)
        {
            Instantiate(tankPrefab, player1Spawn.position, transform.rotation);
        }
    }
}
