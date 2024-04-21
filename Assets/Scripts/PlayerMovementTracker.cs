using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementTracker : MonoBehaviour
{
    private Vector3 previousPosition;
    private float totalDistance;
    private float maxDistance = 30f;
    private int maxcount = 1;

    public DayNightCycle dayNightCycle;

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            if (QuestManager.I.currentQuest.QuestID == 1002)
            {
                for (int i = 0; i < maxcount; i++)
                {
                    ResetPreviousPosition();

                    maxcount--;
                }

                Vector3 currentPosition = transform.position;

                float distanceThisFrame = Vector3.Distance(currentPosition, previousPosition);

                previousPosition = currentPosition;

                totalDistance += distanceThisFrame;

                // 거리에 따라 해가 점진적으로 지도록 조정
                float normalizedDistance = totalDistance / maxDistance; // maxDistance는 미리 정해진 최대 이동 거리
                dayNightCycle.time = Mathf.Lerp(0.4f, 0.8f, normalizedDistance);

                if (totalDistance >= 30f)
                {
                    QuestManager.I.CheckCurrentQuest(1002);
                    dayNightCycle.time = 0.8f;
                }
            }
        }
    }

    // 이전 위치 초기화 함수
    public void ResetPreviousPosition()
    {
        previousPosition = transform.position;
    }
}