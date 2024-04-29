using System;
using UnityEngine;

public class NPCAnimatorController : MonoBehaviour
{
    private Animator animator;
    public static Action NPCAnimationHandler;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        //NPCAnimationHandler += DieAnimation;
    }

    public void DieAnimation()
    {
        animator.SetBool("IsDie", true);
    }

    //private void OnDestroy()
    //{
    //    NPCAnimationHandler -= DieAnimation;
    //}
}
