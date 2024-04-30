using System;
using UnityEngine;

public class NPCAnimatorController : MonoBehaviour
{
    private Animator animator;
    public static Action NPCAnimationHandler;
    public string npcName;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        //NPCAnimationHandler += DieAnimation;
    }

    private void Update()
    {
        if(QuestManager.I.currentQuest.QuestID == 1027 && npcName == "buggubuggu" )
        {
            Destroy(gameObject);
        }

        else if (QuestManager.I.currentQuest.QuestID == 1035 && npcName == "gerogero")
        {
            Destroy(gameObject);
        }
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
