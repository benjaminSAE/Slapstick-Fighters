using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class global_respawn : MonoBehaviour
{
    GameObject CharacterSelectValues;

    public static global_respawn Instance;

    [SerializeField] private Transform spawnPlayer1;
    [SerializeField] private Transform spawnPlayer2;

    [SerializeField] private GameObject archerPlayer1;
    [SerializeField] private GameObject knightPlayer1;
    [SerializeField] private GameObject tankPlayer1;
    [SerializeField] private GameObject archerPlayer2;
    [SerializeField] private GameObject knightPlayer2;
    [SerializeField] private GameObject tankPlayer2;

    int playerOne;
    int playerTwo;
    private Animator animator;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CharacterSelectValues = GameObject.Find("CharacterSelectValues");
        animator = this.gameObject.GetComponent<Animator>();
        playerOne = CharacterSelectValues.GetComponent<BG_Player_Select>().characterPlayer1;
        playerTwo = CharacterSelectValues.GetComponent<BG_Player_Select>().characterPlayer2;
       
    }

    public void RespawnPlayer1()
    {
        if (playerOne == 1)
        {
            animator.SetBool("isRespawning", true);
            Instantiate(archerPlayer1, spawnPlayer1.transform);          
            StartCoroutine(COStunPause(1.2f));
        }

        if (playerOne == 2)
        {
            animator.SetBool("isRespawning", true);
            Instantiate(knightPlayer1, spawnPlayer1.transform);            
            StartCoroutine(COStunPause(1.2f));
        }

        if (playerOne == 3)
        {
            animator.SetBool("isRespawning", true);
            Instantiate(tankPlayer1, spawnPlayer1.transform);
            StartCoroutine(COStunPause(1.2f));
        }
    }

    public void RespawnPlayer2()
    {


        if (playerTwo == 1)
        {
            animator.SetBool("isRespawning", true);
            Instantiate(archerPlayer2, spawnPlayer2.transform);           
            StartCoroutine(COStunPause(1.2f));
        }

        if (playerTwo == 2)
        {
            animator.SetBool("isRespawning", true);
            Instantiate(knightPlayer2, spawnPlayer2.transform);            
            StartCoroutine(COStunPause(1.2f));
        }

        if (playerTwo == 3)
        {
            animator.SetBool("isRespawning", true);
            Instantiate(tankPlayer2, spawnPlayer2.transform);            
            StartCoroutine(COStunPause(1.2f));
        }
    }
    public IEnumerator COStunPause(float pauseTime)
    {

        yield return new WaitForSeconds(pauseTime);
        animator.SetBool("isRespawning", false);
    }
}
