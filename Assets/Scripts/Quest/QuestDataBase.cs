using System.Collections.Generic;

public class QuestData
{
    public int QuestID; // 퀘스트 ID (1ABB - A: 챕터 번호, BB: 퀘스트 번호)
    public int QuestType;
    public string QuestTitle;
    public string Description; // 퀘스트 설명
    public string QuestGoal;
    public int GoalCount; // GoalCount 필요한 개수
    public int RewardID; // 보상 ID
    public int RewardCount; // 보상 개수
    public int QuestItemID; // 필요한 ID (고기 10개 가져오기, 스컹크 5마리 잡기 등)

    public RewardType rewardType; // 보상 타입
    public bool isContinue; // 이어서 퀘스트 진행 여부
    public bool isDirectClear; // 바로 퀘스트 클리어 여부 (대화가 끝나는 시점에 해당)
    public List<Dialogue> dialogues; // 대화 리스트
}
public class QuestDataBase : DataBase<int, QuestData>
{
    public List<QuestData> quests;

    protected override void LoadData()
    {
        foreach (QuestData quest in quests)
        {
            data.Add(quest.QuestID, quest);
        }
    }
}
