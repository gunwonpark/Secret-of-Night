using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class guriguriComponentHandler : MonoBehaviour
{
    private GuriGuriBoss guriguriBoss;
    private NavMeshAgent agent;
    // Update is called once per frame
    void Update()
    {
        if (QuestManager.I.currentQuest.QuestID == 1065)
        {
            if (DialogueHandler.I.dialogueIndex == 4)
            {
                if (agent == null) { agent = gameObject.AddComponent<NavMeshAgent>(); }
                if (guriguriBoss == null) { guriguriBoss = gameObject.AddComponent<GuriGuriBoss>(); }
            }
        }
    }
}
