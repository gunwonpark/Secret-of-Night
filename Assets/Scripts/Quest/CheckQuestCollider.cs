using UnityEngine;

public class CheckQuestCollider : MonoBehaviour
{
    [SerializeField] private int questID; // 퀘스트 ID

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("퀘스트 확인");
            QuestManager.I.CheckCurrentQuest(questID); // 현재 퀘스트 확인
        }
    }
}
