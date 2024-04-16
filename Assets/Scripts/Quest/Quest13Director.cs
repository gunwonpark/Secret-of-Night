using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Quest13Director : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform targetPos;
    public GameObject questSkunk;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();       
    }

    private void Update()
    {
        if(QuestManager.I.currentQuest.QuestID == 1012)
        {
            if (DialogueHandler.I.dialogueIndex == 2)
            {
                agent.SetDestination(targetPos.position);
            }
        }          
    }
}
