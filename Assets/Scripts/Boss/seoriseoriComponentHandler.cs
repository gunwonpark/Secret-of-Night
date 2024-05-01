using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class seoriseoriComponentHandler : MonoBehaviour
{
    private SeoriSeoriBoss seoriseoriBoss;
    private NavMeshAgent agent;
    [SerializeField] private GameObject sword;
    // Update is called once per frame
    void Update()
    {
        if (QuestManager.I.currentQuest.QuestID == 1053)
        {
            if (DialogueHandler.I.dialogueIndex == 4)
            {
                if (agent == null ) { agent = gameObject.AddComponent<NavMeshAgent>();}
                if (seoriseoriBoss == null) { seoriseoriBoss = gameObject.AddComponent<SeoriSeoriBoss>(); }
                sword.SetActive(true);
            }
        }
    }
}
