using System.Collections;
using UnityEngine;

public class SpecialQuest : MonoBehaviour
{
    public DayNightCycle dayNightCycle;
    public float blackoutDuration = 3.0f; // 어두워지는 시간
    public float delayBeforeFade = 2.0f; // 대화가 끝난 후 페이드 시작 전 딜레이 시간
    public GameObject player;
    public GameObject blackScreen; // 화면을 가리는 오브젝트
    public GameObject timeLineObject;
    public GameObject timeLineObject2;
    public GameObject timeLineObject3;
    public GameObject timeLineObject4;
    public GameObject timeLineObject5;

    private int playerstopcount = 1;
    private int playerstopcount2 = 1;
    private int playerstopcount3 = 1;
    private int playerstopcount4 = 1;
    private int playerstopcount5 = 1;

    private void Start()
    {
        blackScreen.SetActive(false); // 시작할 때는 화면 가리기 비활성화
    }

    private void Update()
    {
        if (QuestManager.I.currentQuest.QuestID == 1038)
        {

            for (int i = 0; i < playerstopcount; i++)
            {
                timeLineObject.SetActive(true);
                GameManager.Instance.inputManager.DisablePlayerAction();
                playerstopcount--;
            }
        }

        else if (QuestManager.I.currentQuest.QuestID == 1051)
        {

            for (int i = 0; i < playerstopcount2; i++)
            {
                timeLineObject2.SetActive(true);
                //timeLineObject2.GetComponent<PlayableDirector>().enabled = true;
                GameManager.Instance.inputManager.DisablePlayerAction();
                playerstopcount2--;
            }
        }

        else if (QuestManager.I.currentQuest.QuestID == 1054)
        {
            for (int i = 0; i < playerstopcount3; i++)
            {
                timeLineObject3.SetActive(true);
                GameManager.Instance.inputManager.DisablePlayerAction();
                playerstopcount3--;
            }
        }

        else if (QuestManager.I.currentQuest.QuestID == 1064)
        {
            if (DialogueHandler.I.dialogueIndex == 3)
            {
                for (int i = 0; i < playerstopcount4; i++)
                {
                    timeLineObject4.SetActive(true);
                    GameManager.Instance.inputManager.DisablePlayerAction();
                    playerstopcount4--;
                }
            }
        }

        else if (QuestManager.I.currentQuest.QuestID == 1065)
        {

            for (int i = 0; i < playerstopcount4; i++)
            {
                timeLineObject5.SetActive(true);
                GameManager.Instance.inputManager.DisablePlayerAction();
                playerstopcount5--;
            }

        }
    }

    // 퀘스트 완료 후 연출을 시작하기 위한 메서드
    public void StartQuestCompleteEffect()
    {
        StartCoroutine(PerformFade());
    }

    // 어두워지고 다시 밝아지는 효과를 처리하는 코루틴
    private IEnumerator PerformFade()
    {
        yield return new WaitForSeconds(delayBeforeFade); // 페이드 시작 전 딜레이

        // 화면 어두워지는 효과
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(blackoutDuration);

        // 화면 다시 밝아지는 효과
        blackScreen.SetActive(false);
        dayNightCycle.OnQuest03Complete();

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForEndOfFrame();
            player.transform.position = new Vector3(-2.3763936f, 0.8f, 126.779488f);
        }
    }
}
