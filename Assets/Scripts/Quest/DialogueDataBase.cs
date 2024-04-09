using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueData
{
    public int DialogueID; // 대화 번호
    public string Talker;
    public string TalkerKo; // 이름
    public string Scripts; // 대사    
}

public class DialogueDataBase : DataBase<int, DialogueData>
{
    public List<DialogueData> dialogues; // 대화 데이터를 담을 리스트

    protected override void LoadData()
    {
        foreach (DialogueData dialogue in dialogues)
        {
            data.Add(dialogue.DialogueID, dialogue);
        }
    }
}
