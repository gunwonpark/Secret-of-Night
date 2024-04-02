using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGenerator : MonoBehaviour
{
    public List<Quest> tempQuests = new List<Quest>();

    private void Awake()
    {
        var newQuest = new Quest
        {
            questID = 10101,
            questDescription = "배를 채울만한 것을 찾아보자<버섯 1개 획득 및 사용>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { name = "주인공", dialogue = "(여긴.. 어디지?)" },
                new Dialogue { name = "주인공", dialogue = "(꽤 오랫동안 잔 것 같은데 이곳은 기억이 나지 않아..)" },
                new Dialogue { name = "주인공", dialogue = "(꼬르륵..)" },
                new Dialogue { name = "주인공", dialogue = "(일단 배가 너무 고파..이 주변에 먹을 만한 것이 있을까?)" }
            },
            isContinue = true
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            questID = 10102,
            questDescription = "주변을 둘러보자<이동>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { name = "주인공", dialogue = "(버섯이 꽤 맛있는걸!)" },
                new Dialogue { name = "주인공", dialogue = "(배도 채웠고..계속 여기 있을 수는 없으니 좀 둘러봐야겠어.)" }
            },
            isContinue = true,
            rewardType = RewardType.Item,
            rewardID = 1,
            rewardCount = 1,

        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            questID = 10103,
            questDescription = "묵을 만한 곳을 찾아보자<마을 발견>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { name = "주인공", dialogue = "(저 멀리 불빛이 보이는 것 같아!)" },
                new Dialogue { name = "주인공", dialogue = "(마을이면 좋을텐데.. 일단 가보자)" }
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            questID = 10104,
            questDescription = "마을 입구 NPC와 대화",
            dialogues = new List<Dialogue>
            {
                new Dialogue { name = "NPC", dialogue = "어!? 거기 누구야!" },
                new Dialogue { name = "주인공", dialogue = "아..안녕하세요 불빛이 보여서왔어요..길을 잃었습니다." },
                new Dialogue { name = "주인공", dialogue = "(응..? 사람의 형상이 아닌 것 같은데..?)" },
                new Dialogue { name = "NPC", dialogue = "우리 마을은 길 잃은 나그네를 그냥 보내는 박한 마을이 아니야! 어서와~" }
            },
            isDirectClear = true
        };
        tempQuests.Add(newQuest);


        newQuest = new Quest
        {
            questID = 10201,
            questDescription = "마을 입구 NPC와 대화",
            dialogues = new List<Dialogue>
            {
                new Dialogue { name = "여관 NPC(하이하이)", dialogue = "어머~~ 우리마을에 손님은 정말 오랜만이야!! 잘잤니?" },
                new Dialogue { name = "주인공", dialogue = "아..안녕하세요. 어젯밤에 신세 많이 졌습니다." },
                new Dialogue { name = "주인공", dialogue = "(여관 주인 분도 모습이 이상해..)" },
                new Dialogue { name = "여관 NPC", dialogue = "아니야아니야~ 새로운 사람은 늘 환영이란다!" },
                new Dialogue { name = "여관 NPC", dialogue = "아참! 우리 마을의 촌장님이 널 보고 싶어 하시는데 한번 가볼래?" }
            }
        };
        tempQuests.Add(newQuest);
    }
}
