using UnityEngine;

public class ShopNPCInteraction : MonoBehaviour
{
    [SerializeField] private KeyCode interactionKey = KeyCode.G; // 상호작용 키
    [SerializeField] private GameObject interactionPopup; // 팝업 창
    [SerializeField] private int questID; // 퀘스트 ID

    private bool isInRange = false; // 플레이어가 일정 범위 내에 있는지 여부

    private void Update()
    {
        if (Input.GetKeyDown(interactionKey) && isInRange)
        {
            OpenInteractionPopup();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    private void OpenInteractionPopup()
    {
        // 팝업 창을 활성화하여 보이게 함
        interactionPopup.SetActive(true);
    }

    // 팝업 창에서 호출되는 메서드 (예: '닫기' 버튼을 눌렀을 때)
    public void CloseInteractionPopup()
    {
        // 팝업 창을 비활성화하여 가리기
        interactionPopup.SetActive(false);
    }

    // 대화 버튼을 눌렀을때 호출되는 메서드
    public void Dialogue()
    {
        QuestManager.I.CheckCurrentQuest(questID); // 현재 퀘스트 확인
        if (QuestManager.I.currentQuest.QuestID == questID)
        {
            interactionPopup.SetActive(false);
        }              
    }
}
