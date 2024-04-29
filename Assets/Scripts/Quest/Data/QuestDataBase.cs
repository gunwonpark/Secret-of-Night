using System.Collections.Generic;

[System.Serializable]
public class QuestData
{
    public int QuestID; // 퀘스트 ID (1ABB - A: 챕터 번호, BB: 퀘스트 번호)
    public int QuestSubID;
    public int QuestType;
    public string QuestTitle;
    public string Description; // 퀘스트 설명
    public string QuestGoal;
    public int QuestItemID; // 필요한 ID (고기 10개 가져오기, 스컹크 5마리 잡기 등)   
    public int QuestItemID2;
    public int QuestItemID3;
    public int GoalCount; // GoalCount 필요한 개수
    public int GoalCount2;
    public int GoalCount3;
    public int RewardID; // 보상 ID
    public int RewardID2;
    public int RewardID3;
    public int RewardID4;
    public int RewardID5;
    public string RewardItem;
    public string RewardItem2;
    public string RewardItem3;
    public string RewardItem4;
    public string RewardItem5;
    public float RewardCount; // 보상 개수
    public int RewardCount2;
    public int RewardCount3;
    public int RewardCount4;
    public int RewardCount5;
    public string ChapterName;
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
