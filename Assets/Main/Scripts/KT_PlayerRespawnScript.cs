using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class KT_PlayerRespawnScript : MonoBehaviour
{
    public Transform player;
    public Animator animator;
    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        //I don't have anything to test it on so I just did on mouse click, add to score, and I had to put it under an Update method.
        //change method to OnDeath()
        if (Input.GetMouseButtonDown(0))
        {
            GenerateRandomPosition();
            animator.SetBool("isRespawning", true);
            StartCoroutine(COStunPause(1.2f));

        }   
           

    }
    public IEnumerator COStunPause(float pauseTime)
    {

        yield return new WaitForSeconds(pauseTime);
        animator.SetBool("isRespawning", false);
    }

    public void GenerateRandomPosition()
    {
        float x = Random.Range(-5, 5);
        float y = 10f;
        float z = Random.Range(-5, 5);

        player.transform.position = new Vector3(x, y, z);
    }

   
}


