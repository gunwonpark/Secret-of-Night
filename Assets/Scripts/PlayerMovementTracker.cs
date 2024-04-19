using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementTracker : MonoBehaviour
{
    private Vector3 previousPosition;
    private float totalDistance;
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