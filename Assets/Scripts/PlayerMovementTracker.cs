using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementTracker : MonoBehaviour
{
    private Vector3 previousPosition; 
    private float totalDistance;

    public DayNightCycle dayNightCycle;

    void Start()
    {        
        previousPosition = transform.position;
    }

    void Update()
    {            
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            if (QuestManager.I.currentQuest.QuestID == 1002)
            {
                Vector3 currentPosition = transform.position;   // 현재 프레임에서 플레이어의 위치를 가져옵니다.

                float distanceThisFrame = Vector3.Distance(currentPosition, previousPosition);  // 이전 위치와 현재 위치 간의 거리를 계산합니다.

                previousPosition = currentPosition; // 현재 위치를 이전 위치로 설정합니다.

                totalDistance += distanceThisFrame; // 이동 거리를 총 이동 거리에 더합니다.

                // 이동 거리가 30 유닛 이상인지 확인합니다.
                if (totalDistance >= 30f)
                {
                    QuestManager.I.CheckCurrentQuest(1002);
                    dayNightCycle.time = 0.8f;
                }
            }
        }        
    }   
}
