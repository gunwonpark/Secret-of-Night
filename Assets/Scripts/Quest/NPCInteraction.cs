using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRange = 3f; // 상호작용 범위
    [SerializeField] private KeyCode interactionKey = KeyCode.G; // 상호작용 키
    [SerializeField] private List<int> questID; // 퀘스트 ID
    public GameObject exclamationMark;
    public string npcName;


    private void Update()
    {
        // 플레이어가 상호작용 키를 누르고 있고, NPC와 일정 범위 내에 있을 때
        if (Input.GetKeyDown(interactionKey) && IsPlayerInRange())
        {
            foreach (int ID in questID)
            {
                QuestManager.I.CheckCurrentQuest(ID);
            }
        }

        switch (QuestManager.I.currentQuest.Queststatus)
        {
            case QuestStatus.Progress:
                foreach (int id in questID)
                {
                    if (QuestManager.I.currentQuest.QuestID == id)
                    {
                        exclamationMark.SetActive(true);
                    }
                }
                break;
            case QuestStatus.Complete:
                exclamationMark.SetActive(false);
                break;
        }

        SetNpcposition();
    }

    // 플레이어가 일정 범위 내에 있는지 확인하는 메서드
    private bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, Inventory.instance.transform.position) <= interactionRange;
    }

    private void SetNpcposition()
    {
        if (QuestManager.I.currentQuest.QuestID == 1008 && npcName == "seoriseori")
        {
            if (DialogueHandler.I.dialogueIndex == 5)
            {
                transform.position = new Vector3(-9.015747f, 0.5064697f, 131.2097f);
            }            
        }
        if (QuestManager.I.currentQuest.QuestID == 1009 && npcName == "seoriseori")
        {
            if (DialogueHandler.I.dialogueIndex == 7)
            {
                transform.position = new Vector3(11.20499f, 0.8099976f, 137.0612f);
            }
        }

        if (QuestManager.I.currentQuest.QuestID == 1015 && npcName == "buggubuggu")
        {
            transform.position = new Vector3(2.73f, 2f, 51.72f);
        }
        if (QuestManager.I.currentQuest.QuestID == 1017 && npcName == "buggubuggu")
        {
            if (DialogueHandler.I.dialogueIndex == 5)
            {
                transform.position = new Vector3(-2.631256f, 0.5870056f, 119.9609f);
            }
        }
        if (QuestManager.I.currentQuest.QuestID == 1028 && npcName == "gerogero")
        {
            transform.position = new Vector3(124.5736f, 6.09848f, -16.91287f);
        }
        if (QuestManager.I.currentQuest.QuestID == 1032 && npcName == "gerogero")
        {
            transform.position = new Vector3(11.13f, 0.8999939f, 119.57f);
        }
    }
}
