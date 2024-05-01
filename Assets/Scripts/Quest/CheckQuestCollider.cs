using System;
using System.Collections.Generic;
using UnityEngine;

public class CheckQuestCollider : MonoBehaviour
{
    [SerializeField] private List<int> questID; // 퀘스트 ID

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (int id in questID)
            {
                QuestManager.I.CheckCurrentQuest(id); // 현재 퀘스트 확인
            }            
        }

        else if (other.CompareTag("Player") && QuestManager.I.isKillMonsterClear == true)
        {
            foreach (int id in questID)
            {
                QuestManager.I.CheckCurrentQuest(id); // 현재 퀘스트 확인
            }
        }
    }
}
