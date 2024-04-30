using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineCallback : MonoBehaviour
{
    private PlayableDirector playableDirector;
    [SerializeField] private guriguriComponentHandler guriguriComponentHandler;
    [SerializeField] private GameObject Boss;
    private void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();        
        // 타임라인 종료 콜백 함수 등록
        playableDirector.stopped += OnTimelineStopped;
    } 

    // 타임라인 종료 시 호출되는 콜백 함수
    private void OnTimelineStopped(PlayableDirector director)
    {
        Debug.Log("타임라인이 종료되었습니다.");
        Boss?.SetActive(true);
        GameManager.Instance.inputManager.EnablePlayerAction();
        if (QuestManager.I.currentQuest.QuestID == 1054 )
        {
            QuestManager.I.QuestClear();
        }

        else if (QuestManager.I.currentQuest.QuestID == 1065)
        {
            Inventory.instance.transform.position = new Vector3 (-17.7f, 0.2069961f, 120.8f);
            Inventory.instance.transform.rotation = Quaternion.Euler(0f, -94.449f, 0f);
            guriguriComponentHandler?.GuriGuriAddComponent(); 
        }
        // 타임라인 종료 시 필요한 작업 수행
    }
}
