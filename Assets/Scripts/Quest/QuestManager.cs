using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager I;
    private Quest03Director quest03Director;

    private void Awake()
    {
        I = this;
        quest03Director = GetComponent<Quest03Director>();
    }

    [SerializeField] private DialogueHandler dialogueHandler;
    [SerializeField] private QuestGenerator questGenerator;

    [SerializeField] private TextMeshProUGUI questDescriptionText; // 퀘스트 설명 Text

    public List<Quest> quests; // 퀘스트 리스트
    private int questIndex = 0; // 퀘스트 인덱스
    public Quest currentQuest; // 현재 퀘스트

    private void Start()
    {
        quests = questGenerator.tempQuests; // 전체 퀘스트 리스트 설정 (임시)
        quests.Sort((x, y) => x.QuestID.CompareTo(y.QuestID)); // 퀘스트 ID 순으로 정렬

        questIndex = 0; // 퀘스트 인덱스 초기화

        SetCurrentQuest(); // 현재 퀘스트 설정

        InitDialogues(); // 대화 목록 초기화
    }

    private void Update()
    {
        // H키 누르면 퀘스트 클리어 (테스트용)
        if (Input.GetKeyDown(KeyCode.H))
        {
            QuestClear(); // 퀘스트 클리어
        }

        //// H 누르면 다음 퀘스트 보이기 (테스트용)
        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    InitDialogues(); // 대화 목록 초기화
        //}
    }

    // 현재 퀘스트 설정
    private void SetCurrentQuest()
    {
        if (questIndex >= quests.Count)
        {
            Debug.LogWarning("퀘스트가 더 이상 없습니다.");
            return;
        }

        currentQuest = quests[questIndex]; // 현재 퀘스트 설정
    }

    // 대화 목록 초기화
    private void InitDialogues()
    {
        dialogueHandler.InitDialogues(currentQuest.dialogues); // 대화 목록 초기화
    }

    // 퀘스트 설명 표시
    public void ShowQuestDescription()
    {
        questDescriptionText.text = currentQuest.Description; // 퀘스트 설명 표시
    }

    // 퀘스트 설명 숨기기
    public void HideQuestDescription()
    {
        questDescriptionText.text = ""; // 퀘스트 설명 숨기기
    }

    // 퀘스트 성공
    public void QuestClear()
    {
        // 퀘스트 보상이 있으면 보상 처리
        if (currentQuest.rewardType != RewardType.None)
            RewardProcess(); // 보상 처리

        // 연출 같은 특수 퀘스트 성공 처리
        if (currentQuest.QuestID == 1004)
        {
            SpecialQuestClear(); // 특수 퀘스트 성공
        }
        else
        {
            NextQuest(); // 다음 퀘스트로
        }
    }

    // 보상 처리
    private void RewardProcess()
    {
        switch (currentQuest.rewardType)
        {
            case RewardType.Item:
                // 아이템 보상 처리
                var itemId = currentQuest.RewardID; // 보상 아이템 ID
                var itemCount = currentQuest.RewardCount; // 보상 아이템 개수

                Item item = GameManager.Instance.dataManager.itemDataBase.GetData(itemId);

                Debug.LogWarning($"{item.ItemName} {itemCount}개 획득! (획득 처리 필요)");
                break;

            case RewardType.Skill:
                // 스킬 보상 처리
                var skillId = currentQuest.RewardID; // 보상 스킬 ID
                var skillName = GameManager.Instance.dataManager.playerSkillDataBase.GetData(skillId).Name;
                Debug.LogWarning($"{skillName} 스킬 획득! (획득 처리 필요)");
                break;
        }
    }

    // 특수 퀘스트 성공
    private void SpecialQuestClear()
    {
        quest03Director.StartQuestCompleteEffect();

        NextQuest(); // 다음 퀘스트로
    }

    // 다음 퀘스트로
    private void NextQuest()
    {
        questIndex++; // 퀘스트 인덱스 증가

        // 현재 퀘스트의 isContinue가 true라면
        if (currentQuest.isContinue)
        {
            SetCurrentQuest(); // 다음 퀘스트로 변경
            InitDialogues(); // 대화 목록 초기화
        }
        else
        {
            SetCurrentQuest(); // 다음 퀘스트로 변경
            HideQuestDescription(); // 퀘스트 설명 숨기기
        }
    }

    // 특정 몬스터를 죽였을 때 or 특정 아이템을 획득했을 때
    public void CheckCount(int id)
    {
        // 현재 퀘스트의 neededId와 id가 같다면
        if (currentQuest.QuestItemID == id)
        {
            currentQuest.GoalCount--; // 필요한 개수 감소

            // 필요한 개수가 0이 됐으면
            if (currentQuest.GoalCount <= 0)
            {
                QuestClear(); // 퀘스트 클리어
            }
        }
    }

    // NPC 상호작용, 아이템 사용, TriggerEnter 등에서 호출
    public void CheckCurrentQuest(int id)
    {
        // 현재 퀘스트의 questID와 id가 같다면
        if (currentQuest.QuestID == id)
            QuestClear(); // 퀘스트 클리어
        else if (currentQuest.QuestItemID == id)
            QuestClear();
    }

    // 바로 퀘스트 완료인지 확인
    public void CheckDirectQuestClear()
    {
        // 바로 퀘스트 클리어인 경우
        if (currentQuest.isDirectClear)
            QuestClear(); // 퀘스트 클리어
    }
}

// Quest
[Serializable]
public class Quest
{
    public int QuestID; // 퀘스트 ID (1ABB - A: 챕터 번호, BB: 퀘스트 번호)
    public int QuestType;
    public string QuestTitle;
    public string Description; // 퀘스트 설명
    public string QuestGoal;
    public int GoalCount; // GoalCount 필요한 개수
    public int RewardID; // 보상 ID
    public int RewardCount; // 보상 개수
    public int QuestItemID; // QuestType 필요한 ID (고기 10개 가져오기, 스컹크 5마리 잡기 등)    
    
    public RewardType rewardType; // 보상 타입
    public bool isContinue; // 이어서 퀘스트 진행 여부
    public bool isDirectClear; // 바로 퀘스트 클리어 여부 (대화가 끝나는 시점에 해당)
    public List<Dialogue> dialogues; // 대화 리스트

    public Quest(QuestData quest)
    {
        QuestID = quest.QuestID;
        QuestType = quest.QuestType;
        QuestTitle = quest.QuestTitle;
        Description = quest.Description;
        QuestGoal = quest.QuestGoal;
        GoalCount = quest.GoalCount;
        RewardID = quest.RewardID;
        RewardCount = quest.RewardCount;
        QuestItemID = quest.QuestItemID;
    }

    public Quest() { }
}
