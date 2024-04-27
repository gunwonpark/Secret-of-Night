using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRange = 2f; // 상호작용 범위
    [SerializeField] private KeyCode interactionKey = KeyCode.G; // 상호작용 키
    [SerializeField] private List<int> questID; // 퀘스트 ID
    [SerializeField] private List<int> killMonsterQuestID;
    private SkinnedMeshRenderer[] meshRenderers;
    public GameObject exclamationMark;
    public string npcName;

    private void Start()
    {
        meshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
    }
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
        if (Input.GetKeyDown(interactionKey) && IsPlayerInRange() && QuestManager.I.isKillMonsterClear == true)
        {
            foreach (int ID in killMonsterQuestID)
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
        if (QuestManager.I.currentQuest.QuestID == 1009 && npcName == "seoriseori")
        {
            if (DialogueHandler.I.dialogueIndex == 6)
            {
                transform.position = new Vector3(-9.03f, 0.4570007f, 133.7497f);
            }
        }
        else if (QuestManager.I.currentQuest.QuestID == 1010 && npcName == "seoriseori")
        {
            if (DialogueHandler.I.dialogueIndex == 9)
            {
                transform.position = new Vector3(11.20499f, 0.8099976f, 137.0612f);
            }
        }

        else if (QuestManager.I.currentQuest.QuestID == 1015 && npcName == "buggubuggu")
        {
            meshRenderers[0].enabled = false;
            meshRenderers[1].enabled = false;
        }
        else if (QuestManager.I.currentQuest.QuestID == 1027 && npcName == "buggubuggu")
        {
            meshRenderers[0].enabled = true;
            meshRenderers[1].enabled = true;
        }
        else if (QuestManager.I.currentQuest.QuestID == 1028 && npcName == "gerogero")
        {
            meshRenderers[0].enabled = false;
            meshRenderers[1].enabled = false;
        }
        else if (QuestManager.I.currentQuest.QuestID == 1035 && npcName == "gerogero")
        {
            meshRenderers[0].enabled = true;
            meshRenderers[1].enabled = true;
        }
        else if (QuestManager.I.currentQuest.QuestID == 1038 && npcName == "diridiri")
        {
            meshRenderers[0].enabled = false;
            meshRenderers[1].enabled = false;
        }
        else if (QuestManager.I.currentQuest.QuestID == 1039 && npcName == "diridiri")
        {
            meshRenderers[0].enabled = true;
            meshRenderers[1].enabled = true;
        }
        else if (QuestManager.I.currentQuest.QuestID == 1048 && npcName == "hihi")
        {
            meshRenderers[0].enabled = false;
            meshRenderers[1].enabled = false;
        }     
    }
}
