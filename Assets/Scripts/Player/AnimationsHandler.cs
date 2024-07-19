using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsHandler : MonoBehaviour
{
    [SerializeField]private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        PlayAnimations();
    }


    private void PlayAnimations() 
    {
        if (MovementManager.instance.forwardButtonPressed) 
        {
            animator.SetBool("Idle",false);
            animator.SetBool("Run",true);
            animator.SetBool("Jump",false);
        }
        else if (MovementManager.instance.backButtonPressed) 
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Run", true);
            animator.SetBool("Jump", false);
        }
        else if (MovementManager.instance.jumpButtonPressed) 
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Run", false);
            animator.SetBool("Jump", false);
        }
        else
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Run", false);
            animator.SetBool("Jump", false);
        }
    }

}
