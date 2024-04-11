using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRange = 3f; // 상호작용 범위
    [SerializeField] private KeyCode interactionKey = KeyCode.G; // 상호작용 키
    [SerializeField] private List<int> questID; // 퀘스트 ID

    private void Update()
    {
        // 플레이어가 상호작용 키를 누르고 있고, NPC와 일정 범위 내에 있을 때
        if (Input.GetKeyDown(interactionKey) && IsPlayerInRange())
        {            
            foreach (int ID in questID)
            {
                QuestManager.I.CheckCurrentQuest(ID); // 현재 퀘스트 확인  
            }                     
        }
        
    }

    // 플레이어가 일정 범위 내에 있는지 확인하는 메서드
    private bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, Inventory.instance.transform.position) <= interactionRange;
    }
}
