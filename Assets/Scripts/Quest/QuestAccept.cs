using UnityEngine;

public class QuestAccept : MonoBehaviour
{
    [SerializeField] private float interactionRange = 3f; // 상호작용 범위
    [SerializeField] private KeyCode interactionKey = KeyCode.G; // 상호작용 키
    public int questID; // 퀘스트 ID

    private void Update()
    {                   
        if (Input.GetKeyDown(interactionKey) && IsPlayerInRange())
        {
            QuestManager.I.AcceptQuest(questID);
            
        }
    }

    // 플레이어가 일정 범위 내에 있는지 확인하는 메서드
    private bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, Inventory.instance.transform.position) <= interactionRange;
    }
}
