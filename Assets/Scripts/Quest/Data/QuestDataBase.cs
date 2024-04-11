using System.Collections.Generic;

[System.Serializable]
public class QuestData
{
    public int QuestID; // 퀘스트 ID (1ABB - A: 챕터 번호, BB: 퀘스트 번호)
    public int QuestType;
    public string QuestTitle;
    public string Description; // 퀘스트 설명
    public string QuestGoal;
    public int GoalCount; // GoalCount 필요한 개수
    public int RewardID; // 보상 ID
    public string RewardItem;
    public int RewardCount; // 보상 개수
    public int QuestItemID; // 필요한 ID (고기 10개 가져오기, 스컹크 5마리 잡기 등)   
}

[System.Serializable]
public class QuestDataBase : DataBase<int, QuestData>
{
    public List<QuestData> Quest;

    protected override void LoadData()
    {
        foreach (QuestData quest in Quest)
        {
            data.Add(quest.QuestID, quest);
        }
    }
}
