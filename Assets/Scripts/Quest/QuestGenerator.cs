using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGenerator : MonoBehaviour
{
    public List<Quest> tempQuests = new List<Quest>();    

    private void Awake()
    {        
        var newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1001))
        {            
            // "배를 채울만한 것을 찾아보자<버섯 1개 획득 및 사용>",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100101)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100102)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100103)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100104)),
            },
            isContinue = true,            
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1002))
        {            
            // Description = "주변을 둘러보자<이동>",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100201)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100202)),
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1003,
            Description = "묵을 만한 곳을 찾아보자<마을 발견>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "(저 멀리 불빛이 보이는 것 같아!)" },
                new Dialogue { TalkerKo = "주인공", Scripts = "(마을이면 좋을텐데.. 일단 가보자)" }
            },
            isContinue = true,
            rewardType = RewardType.Item,
            RewardID = 1,
            RewardCount = 1,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1004,
            Description = "마을 입구 NPC와 대화",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "NPC", Scripts = "어!? 거기 누구야!" },
                new Dialogue { TalkerKo = "주인공", Scripts = "아..안녕하세요 불빛이 보여서왔어요..길을 잃었습니다." },
                new Dialogue { TalkerKo = "주인공", Scripts = "(응..? 사람의 형상이 아닌 것 같은데..?)" },
                new Dialogue { TalkerKo = "NPC", Scripts = "우리 마을은 길 잃은 나그네를 그냥 보내는 박한 마을이 아니야! 어서와~" }
            },
            isDirectClear = true,
            isContinue = true,
        };
        tempQuests.Add(newQuest);


        newQuest = new Quest
        {
            QuestID = 1005,
            Description = "촌장에게<촌장에게 말 걸기>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "여관 NPC(하이하이)", Scripts = "어머~~ 우리마을에 손님은 정말 오랜만이야!! 잘잤니?" },
                new Dialogue { TalkerKo = "주인공", Scripts = "아..안녕하세요. 어젯밤에 신세 많이 졌습니다." },
                new Dialogue { TalkerKo = "주인공", Scripts = "(여관 주인 분도 모습이 이상해..)" },
                new Dialogue { TalkerKo = "여관 NPC", Scripts = "아니야아니야~ 새로운 사람은 늘 환영이란다!" },
                new Dialogue { TalkerKo = "여관 NPC", Scripts = "아참! 우리 마을의 촌장님이 널 보고 싶어 하시는데 한번 가볼래?" }
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1006,
            Description = "게로게로에게<게로게로에게 말 걸기>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "안녕하세요 촌장님. 저를 보고 싶어 하신다고 해서 왔어요." },
                new Dialogue { TalkerKo = "주인공", Scripts = "(촌장도..? 확실히 이상해)" },
                new Dialogue { TalkerKo = "촌장", Scripts = "안녕하신가 젊으니 허허. 나는 이 마을의 촌장이네" },
                new Dialogue { TalkerKo = "촌장", Scripts = "정말 오랜만에 마을에 손님이 찾아와 한번 보고 싶었네." },
                new Dialogue { TalkerKo = "촌장", Scripts = "다른 주민들도 보고 싶어 하는 것 같은데 게로게로와 이야기를 해보게." }
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1007,
            Description = "뽀롱뽀롱에게<뽀롱뽀롱에게 말 걸기>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "안녕! 게로게로..?" },
                new Dialogue { TalkerKo = "게로게로", Scripts = "안녀어어엉~~~! 내가 바로 게로게로야!" },
                new Dialogue { TalkerKo = "게로게로", Scripts = " 이렇게 만난 것도 인연인데 서리서리 놀리러 가지 않을래?" },
                new Dialogue { TalkerKo = "게로게로", Scripts = "서리서리가 어제 버섯을 캐왔는데 내가 몰래 다 먹어서 지금쯤 엄청 씩씩대고 있을 거야" },
                new Dialogue { TalkerKo = "게로게로", Scripts = "지금이 놀려먹을 시점이라고!!" },
                new Dialogue { TalkerKo = "주인공", Scripts = "어.. 음.. 앗! 나 갑자기 상점에 볼일이 있어서 가볼게!" }
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1008,
            Description = "서리서리에게<서리서리에게 말 걸기>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "휴.. 아! 안녕하세요! 여긴 상점인가 봐요?" },
                new Dialogue { TalkerKo = "뽀롱뽀롱", Scripts = "안녕하세요~ 저는 상점 주인인 뽀롱뽀롱이에요!" },
                new Dialogue { TalkerKo = "뽀롱뽀롱", Scripts = "어제 오셨다던 용사님이시군요!" },
                new Dialogue { TalkerKo = "주인공", Scripts =  "(응..? 내가 언제 용사가 된 거지)" },
                new Dialogue { TalkerKo = "뽀롱뽀롱", Scripts = "저는 마을에서 여러 가지 물건을 사고팔고 있어요~ 많이 들러주세요!" },
                new Dialogue { TalkerKo = "뽀롱뽀롱", Scripts = "앗 서리서리 안녕~?" }
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1009,
            Description = "서리서리, 뽀롱뽀롱과 대화나누기",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "서리서리", Scripts = "씨익씨익 누가 내 버섯을 다 먹었어!!" },
                new Dialogue { TalkerKo = "서리서리", Scripts = "뽀롱뽀롱은 알아??" },
                new Dialogue { TalkerKo = "뽀롱뽀롱", Scripts = "어머 누가 그런 짓을 했니? 버섯이라면 하나에 10원에 팔 수 있었을 텐데" },
                new Dialogue { TalkerKo = "서리서리", Scripts = "내 버섯 가져간 놈 잡히기만 해봐! 어? 너는 못 보던 얼굴인데?" },
                new Dialogue { TalkerKo = "주인공", Scripts =  "아.. 안녕? " },
                new Dialogue { TalkerKo = "서리서리", Scripts = "설마 내 버섯에 손을 댄 사람이 너야!???" },
                new Dialogue { TalkerKo = "주인공", Scripts = "난 아니야! (화가 많이 났나 보다)" },
                new Dialogue { TalkerKo = "", Scripts = "서리서리는 씩씩대며 사라졌다." },
                new Dialogue { TalkerKo = "주인공", Scripts = "..." },
                new Dialogue { TalkerKo = "뽀롱뽀롱", Scripts = "호호.. 늘 있는 일이니까 신경 쓰지 않아도 돼! 만나서 반가웠어." },
            },
            isDirectClear = true,
        };
        tempQuests.Add(newQuest);
    }
}
