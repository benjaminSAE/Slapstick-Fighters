using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KT_AnimatorScript : MonoBehaviour
{
    public Animator animator;
    public float InputX;
    public float InputY;

    void Start()
    {
        //start the animator
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InputX = Input.GetAxis("Horizontal");
        animator.SetFloat("InputX", InputX);
        InputY = Input.GetAxis("Vertical");
        animator.SetFloat("InputY", InputY);
    }
}
