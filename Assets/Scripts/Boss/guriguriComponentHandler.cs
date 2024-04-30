using System;
using UnityEngine;
using UnityEngine.AI;

public class guriguriComponentHandler : MonoBehaviour
{
    private GuriGuriBoss guriguriBoss;
    private NavMeshAgent agent;      

    public void GuriGuriAddComponent()
    {
        if (agent == null) { agent = gameObject.AddComponent<NavMeshAgent>(); }
        if (guriguriBoss == null) { guriguriBoss = gameObject.AddComponent<GuriGuriBoss>(); }       
        gameObject.GetComponent<GuriGuriBoss>().enabled = true;
    }   
}
