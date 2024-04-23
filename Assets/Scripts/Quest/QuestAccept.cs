using System.Collections.Generic;
using UnityEngine;

public class QuestAccept : MonoBehaviour
{
    [SerializeField] private float interactionRange = 2f; // 상호작용 범위
    [SerializeField] private KeyCode interactionKey = KeyCode.G; // 상호작용 키
    public List<int> questID; // 퀘스트 ID
    public GameObject questionMark;

    public QuestStatus questStatus;

    private void Update()
    {
        questStatus = QuestManager.I.currentQuest.Queststatus;
        if (Input.GetKeyDown(interactionKey) && IsPlayerInRange())
        {
            foreach (int id in questID)
            {
                QuestManager.I.AcceptQuest(id);               
            }                       
        }

        switch (QuestManager.I.currentQuest.Queststatus)
        {
            case QuestStatus.Wait:
                foreach (int id in questID)
                {
                    if (QuestManager.I.currentQuest.QuestID == id)
                    {
                        questionMark.SetActive(true);
                    }
                }
                break;
            case QuestStatus.Progress:
                questionMark.SetActive(false);
                break;
        }
    }

    // 플레이어가 일정 범위 내에 있는지 확인하는 메서드
    private bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, Inventory.instance.transform.position) <= interactionRange;
    }
}
