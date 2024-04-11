using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueData
{
    public int DialogueID; // 대화 번호
    public string Talker;
    public string TalkerKo; // 이름
    public string Scripts; // 대사    
}

[Serializable]
public class DialogueDataBase : DataBase<int, DialogueData>
{
    public List<DialogueData> QuestScript;

    protected override void LoadData()
    {
        foreach (var dialogue in QuestScript)
        {
            data.Add(dialogue.DialogueID, dialogue);
        }
    }
}
