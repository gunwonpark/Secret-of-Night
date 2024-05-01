using System;
using UnityEngine;
using UnityEngine.AI;

public class guriguriComponentHandler : MonoBehaviour
{
    private GuriGuriBoss guriguriBoss;
    private NavMeshAgent agent;
    [SerializeField] private GameObject sword;

    public void GuriGuriAddComponent()
    {
        if (agent == null) { agent = gameObject.AddComponent<NavMeshAgent>(); }
        if (guriguriBoss == null) { guriguriBoss = gameObject.AddComponent<GuriGuriBoss>(); }       
        gameObject.GetComponent<GuriGuriBoss>().enabled = true;
    }
    private void Update()
    {
        if ( QuestManager.I.currentQuest.QuestID == 1064)
        {
            sword.SetActive(true);
        }
    }
}
