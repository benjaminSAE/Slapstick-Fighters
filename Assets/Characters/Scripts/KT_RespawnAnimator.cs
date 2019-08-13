using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KT_RespawnAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private KeyCode up;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(up))
        {
            animator.SetBool("isRespawning", true);
        }
        else
        {
            animator.SetBool("isRespawning", false);
        }
    }
}

