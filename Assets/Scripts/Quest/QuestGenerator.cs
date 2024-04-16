using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGenerator : MonoBehaviour
{
    public List<Quest> tempQuests = new List<Quest>();    

    private void Start()
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
            rewardType = RewardType.Item,
            RewardID = 1,
            RewardCount = 10,
            QuestType =2,
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
            rewardType = RewardType.Item,
            RewardID = 10,
            RewardCount = 1,
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
                
            },
            isContinue = true,
            isDirectClear = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1009,
            Description = "서리서리, 뽀롱뽀롱과 대화나누기",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "뽀롱뽀롱", Scripts = "앗 서리서리 안녕~?" },
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

        newQuest = new Quest
        {
            QuestID = 1010,
            Description = "촌장에게<촌장에게 말 걸기>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "(앗 저 개구리.. 아니 저 사람이 이 마을의 마지막 주민인 것 같아.)" },
                new Dialogue { TalkerKo = "부꾸부꾸", Scripts = "부꾸~부꾸~내 이름은 부꾸부꾸~" },
                new Dialogue { TalkerKo = "주인공", Scripts = "안녕! 부꾸부꾸?" },
                new Dialogue { TalkerKo = "부꾸부꾸", Scripts = "안녕! 내 이름을 어떻게 알았어? 너는 음.. 게로게로구나!" },
                new Dialogue { TalkerKo = "주인공", Scripts =  "엥 난 어제 왔는걸? 게로게로는 저쪽에 있잖아." },
                new Dialogue { TalkerKo = "부꾸부꾸", Scripts = "아 맞다! 게로게로는 저기 있지!" },
                new Dialogue { TalkerKo = "부꾸부꾸", Scripts = "안녕?" },
                new Dialogue { TalkerKo = "주인공", Scripts = "응.. 안녕.. (여기 주민들 상태가 좀 이상해)" },
                new Dialogue { TalkerKo = "주인공", Scripts = "(촌장님한테 돌아가야겠어)" },
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1011,
            Description = "띠리띠리에게<띠리띠리에게 말걸기>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "촌장", Scripts = "주민들과 인사는 했는가?" },
                new Dialogue { TalkerKo = "촌장", Scripts = "혹시 괜찮다면 이 늙은이의 이야기를 들어줄 수 있겠나?" },
                new Dialogue { TalkerKo = "주인공", Scripts = "네. 말씀하세요." },
                new Dialogue { TalkerKo = "촌장", Scripts = "우리가 이런 모습인 것이 의아할 걸세" },
                new Dialogue { TalkerKo = "주인공", Scripts =  "헉 표정관리가 안 됐나요..? 사실.. 네 의아합니다." },
                new Dialogue { TalkerKo = "촌장", Scripts = "우리도 자세한 이유는 모르겠지만 얼마 전부터 이렇게 됐네.." },
                new Dialogue { TalkerKo = "촌장", Scripts = "우리는 그 이유를 마을 밖 동물들이 난폭해진 것과 연관이 있다고 생각하네." },
                new Dialogue { TalkerKo = "촌장", Scripts = "그래서 첫 만남에 무리한 부탁인데.. 띠리띠리와 상황을 보고 와줄 수 있겠나?" },
                new Dialogue { TalkerKo = "촌장", Scripts = "띠리띠리는 마을 입구에서 마을을 지키고 있을 걸세. 한 번 가보게나." },
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1012,
            Description = "띠리띠리와 마을 순찰하기",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "띠리띠리", Scripts = "아.. 안녕. 네가 어젯밤에 온 사람이었지." },
                new Dialogue { TalkerKo = "띠리띠리", Scripts = "뭐 그건 관심 없고, 혼자서도 갔다 올 수 있지만 촌장님의 지시니까.." },
                new Dialogue { TalkerKo = "띠리띠리", Scripts = "일단 가보자. 따라와."},
                new Dialogue { TalkerKo = "주인공", Scripts = "(뭐야 저 무관심한 말투는..)" },                
            },               
            isContinue = true,                
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1013,
            Description = "띠리띠리와 순찰<퀘스트용 포악해진 몬스터 처치>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "띠리띠리", Scripts = "저기 저 동물이 보여?" },
                new Dialogue { TalkerKo = "주인공", Scripts = "응?" },
                new Dialogue { TalkerKo = "띠리띠리", Scripts = "요즘 동물들이 포악해져서 쉽게 다가갈수가 없어." },
                new Dialogue { TalkerKo = "주인공", Scripts = "괜찮아 보이는데?" },
                new Dialogue { TalkerKo = "띠리띠리", Scripts =  "(스컹크가 갑자기 공격을 해온다) 앗! 아파! 왜 이러는 거야!" },
                new Dialogue { TalkerKo = "띠리띠리", Scripts = "너! 보고만 있지 말고 어떻게 좀 해봐!" },                
            },            
            isContinue= true,
            QuestItemID = 10,
            GoalCount = 1,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1014,
            Description = "촌장에게<촌장에게 돌아가기>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "띠리띠리", Scripts = "역시나 스컹크가 공격을...? 촌장님에게 돌아가야겠어!" },                               
            },
            isContinue = true,
            rewardType = RewardType.Item,
            RewardID = 21,
            RewardCount = 1,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1015,
            Description = "사라진 부꾸부꾸<부꾸부꾸의 애장품 획득>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "띠리띠리", Scripts = "촌장님! 마을 밖에 동물들이.." },
                new Dialogue { TalkerKo = "촌장", Scripts = "자네들 돌아왔구먼! 지금 큰일이 생겼네!" },
                new Dialogue { TalkerKo = "주인공", Scripts = "무슨 일이죠?" },
                new Dialogue { TalkerKo = "촌장", Scripts = "부꾸부꾸가 마을 안에서 보이지 않아! 마을 밖으론 절대 나가지 않는 아이인데.." },
                new Dialogue { TalkerKo = "촌장", Scripts = "젊은이! 부탁을 계속해서 미안하네만 부꾸부꾸를 좀 찾아주지 않겠나?" },
                new Dialogue { TalkerKo = "촌장", Scripts = "순찰을 보내기 전에 부꾸부꾸의 애착 가방이 없어졌단 소리를 했던 것 같네." },
                new Dialogue { TalkerKo = "촌장", Scripts = "뜬금없이 카멜레온 이야기도 했던 것 같고.." },
                new Dialogue { TalkerKo = "촌장", Scripts = "부꾸부꾸는 오렌지를 좋아하니 한번 갖고 가보게나." },
            },
            isContinue = true,
            QuestType = 3,
            QuestItemID = 21,
            GoalCount = 10,            
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1016,
            Description = "사라진 부꾸부꾸<부꾸부꾸를 찾아라> 카멜레온 10마리 처치",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "앗 저쪽에서 부꾸부꾸의 소리가 들리는 것 같아!" },
                new Dialogue { TalkerKo = "주인공", Scripts = "부꾸부꾸!!" },                
                new Dialogue { TalkerKo = "부꾸부꾸", Scripts = "카멜레온이 너무 무서워!" },
            },
            isContinue = true,
            QuestItemID = 2,
            GoalCount = 1,  // 추후 10으로 변경
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1017,
            Description = "사라진 부꾸부꾸<부꾸부꾸 마을로 데려오기>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "부꾸부꾸! 왜 여기 있는 거야?" },
                new Dialogue { TalkerKo = "부꾸부꾸", Scripts = "부꾸부꾸는 몰라.. 카멜레온이 무서워" },
                new Dialogue { TalkerKo = "부꾸부꾸", Scripts = "부꾸부꾸는 아무것도 몰라" },
                new Dialogue { TalkerKo = "", Scripts = "부꾸부꾸는 쓰러졌다." },
                new Dialogue { TalkerKo = "주인공", Scripts =  "일단 마을로 데려가야겠어!" },
                new Dialogue { TalkerKo = "주인공", Scripts = "촌장님! 부꾸부꾸를 찾아왔어요. 산속 근처인데 왜 그곳에 있었는지는.." },
                new Dialogue { TalkerKo = "촌장", Scripts = "오오.. 우리 부꾸부꾸를 찾아주어서 정말 고맙네 젊은이." },                
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1018,
            Description = "촌장의 이야기<촌장과 대화>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "저..촌장님. 마을과 마을밖의 분위기가 심상치 않은데 이유를 더 말씀해주실 수 있을까요?" },
                new Dialogue { TalkerKo = "촌장", Scripts = "" },
                new Dialogue { TalkerKo = "촌장", Scripts = "더 강해질 수 있게 만들어 줄 사람이 있네." },
                new Dialogue { TalkerKo = "촌장", Scripts = "강가에 사는 뚜쉬뚜쉬를 찾아가보도록 하게나." },
                new Dialogue { TalkerKo = "촌장", Scripts = "아 찾아갈 때 이것을 갖고 가게." },                
            },
            isContinue = true,
            isDirectClear = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1019,
            Description = "스승 찾아 삼만리<스승과 대화>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "뚜쉬뚜쉬...? 특이한 이름을 가졌네." },
                new Dialogue { TalkerKo = "주인공", Scripts = "그나저나 뚜쉬뚜쉬님은 대체 어디에 계시는거야??" },
                new Dialogue { TalkerKo = "주인공", Scripts = "뚜쉬뚜쉬님에게 배운다면 설마 나도 빠샤빠샤?" },
                new Dialogue { TalkerKo = "주인공", Scripts = "멋진데?" },                
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1020,
            Description = "스승과의 수련<강화 수련 1>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "...뚜쉬뚜쉬님?" },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "너 뭐야? 이몸을 어떻게 알지?" },
                new Dialogue { TalkerKo = "주인공", Scripts = "저희 마을 촌장님이 뚜쉬뚜쉬님을 찾아가보라고 하셨습니다." },
                new Dialogue { TalkerKo = "주인공", Scripts = "더 강해지고 싶어 뚜쉬뚜쉬님을 찾아 왔습니다." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "강해져? 풉.. 안돼 돌아가. " },
                new Dialogue { TalkerKo = "주인공", Scripts =  "저희 마을이 요즘 이상합니다.." },
                new Dialogue { TalkerKo = "주인공", Scripts =  "마을을 지키기 위해 제가 강해져야 합니다!!" },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "있잖아. 강해지는 건 쉬운 게 아니야." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "애. 송. 이." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "난 갈테니 알아서 가도록." },
                new Dialogue { TalkerKo = "주인공", Scripts = "뚜쉬뚜쉬.. 아니 스승님!" },
                new Dialogue { TalkerKo = "주인공", Scripts = "앞으로 스승님이라고 부르겠습니다. 부탁드립니다!!" },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "....." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "마을이 위험하다니 내 이번만은 들어주지." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "ㅋ..크흠. 스승이라고 해서 들어주는 건 절대 아니야." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "가서 카멜레온이랑 놀아봐." },
            },            
            QuestItemID = 2,
            GoalCount = 5,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1021,
            Description = "스승과의 수련<강화 수련 2>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "야레야레.. 느려." },
                new Dialogue { TalkerKo = "주인공", Scripts = "...." },                
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "대답." },
                new Dialogue { TalkerKo = "주인공", Scripts =  "...." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "포기하겠다는건가? 잘가고." },
                new Dialogue { TalkerKo = "주인공", Scripts = "아..아닙니다!! 잠시 숨 좀 돌리느라.." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "그래? 그럼 카멜레온으로." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "아 그리고 오리너구리도 잡아와." },
                new Dialogue { TalkerKo = "주인공", Scripts = "네..?" },
            },            
            QuestItemID = 1,
            GoalCount = 7,
            QuestItemID2 = 2,
            GoalCount2 = 5,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1022,
            Description = "스승과의 수련<강화 수련 3>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "스승님 다 잡아왔습니다!" },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "그래. 잘 했군." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "지금까진 너의 실력을 테스트 했다." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "이번엔 조금 난이도를 올려보지." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts =  "그래봤자 나한텐 한 주먹이지만 후후." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "미어캣을 잡아봐." },
                new Dialogue { TalkerKo = "주인공", Scripts = "네 스승님!" },                
            },
            QuestItemID = 3,
            GoalCount = 10,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1023,
            Description = "스승과의 수련<강화 수련 4>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "어이어이 오소이.(느려)" },
                new Dialogue { TalkerKo = "주인공", Scripts = "(속삭이며) 한번도 쉬지 않고 잡았는데.." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "뭐라고?" },
                new Dialogue { TalkerKo = "주인공", Scripts = "역시 스승님은 대단하신 분이라고 했습니다!" },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts =  "크크.. 이미 알고 있다." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "다음은 고슴도치다. 얼른 움직여." },
                new Dialogue { TalkerKo = "주인공", Scripts = "ㄴ..넵!" },                
            },
            QuestItemID = 4,
            GoalCount = 10,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1024,
            Description = "스승과의 수련<강화 수련 5>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "스승님.. 저 왔습니다." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "자 다음은.." },
                new Dialogue { TalkerKo = "주인공", Scripts = "스승님! 조금만 쉬었다가 하면 안되겠습니까?" },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "너. 강해졌다고 생각하면 착각이다." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts =  " 앞으로 2번의 수련을 마치면 대단한 걸 알려주지." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "스컹크를 잡아오되 그 냄새는 좀 빼고 오도록." },
                new Dialogue { TalkerKo = "주인공", Scripts = "넵 알겠습니다." },
                new Dialogue { TalkerKo = "주인공", Scripts = "(대단한 게 뭐지...? 조금만 더 힘내보자)" },                
            },
            QuestItemID = 5,
            GoalCount = 7,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1025,
            Description = "스승과의 수련<강화 수련 6 : 스킬 획득>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "오 왔군." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "아. 냄새 좀 빼고 오라니깐." },
                new Dialogue { TalkerKo = "주인공", Scripts = "(무시하며) 스승님 대체 대단한 게 뭡니까?" },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "마을 밖에는 많은 몬스터들이 있지." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts =  "그 중에서도 황소를 잡을 수 있다면 어느정도 강해졌단 얘기야." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "늑대를 잡아오면 황소를 잡을 수 있는 기술을 알려주지." },
                new Dialogue { TalkerKo = "주인공", Scripts = "늑대라면.. 위험한 몬스터로 알고 있는데..." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "뭐야? 이 몸처럼 강해지고 싶은게 아닌가?" },
                new Dialogue { TalkerKo = "주인공", Scripts = "ㅇ..아닙니다! 다녀 오겠습니다." },
            },
            QuestItemID = 6,
            GoalCount = 5,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1026,
            Description = "스승과의 수련<강화 수련 최종>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = " (얼레벌레 달려오며) 스승님..! 저 왔습니다." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "오호. 이제 좀 내 제자 같군." },
                new Dialogue { TalkerKo = "주인공", Scripts = " (감격한다.)" },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "이제 최종 수련이다." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts =  "내가 알려준 기술은 잘 기억하고 있지?" },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = " 그래. 황소가 많으면 말이야." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = " 내 집이 망가진다고.. 반드시 잡도록." },
                new Dialogue { TalkerKo = "주인공", Scripts = "아 집이..." },
                new Dialogue { TalkerKo = "주인공", Scripts = "아닙니다! 집을 부수는 황소는 제가 모조리 잡겠습니다!" },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "그래 내 제자여. 다녀오도록." },      
            },
            QuestItemID = 7,
            GoalCount = 3,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1027,
            Description = "마을에서 생긴 일<촌장과 대화>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "스승님! 다음은 뭐죠!? 확실히 강해진 것 같습니다" },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "훗..마을로 가보도록." },
                new Dialogue { TalkerKo = "주인공", Scripts = "네?" },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "지금. 내 귀에 마을의 절규가 들린다. 넌 아무것도 안들리는가" },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts =  "폭풍이..오려하는군." },
                new Dialogue { TalkerKo = "주인공", Scripts = "...네 (촌장님께 가봐야겠어)" },              
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1028,
            Description = "사라진 게로게로<서리서리와 대화>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "촌장", Scripts = "자네! 어찌 이 타이밍에 돌아왔는가?" },
                new Dialogue { TalkerKo = "주인공", Scripts = "스승님이 가보라고 해서..그건 그렇고 마을이 왜 이렇게 어수선하죠?" },
                new Dialogue { TalkerKo = "촌장", Scripts = " 우리마을의 귀염둥이 게로게로가 사라졌다네!" },
                new Dialogue { TalkerKo = "촌장", Scripts = " 서리서리를 놀리다가 혼이 났는데 그 후로 보이지가 않는다네.." },
                new Dialogue { TalkerKo = "촌장", Scripts =  "서리서리에게 가보겠나?" },                
            },
            isContinue = true,
            rewardType = RewardType.Item,
            RewardID = 24,
            RewardCount = 1,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1029,
            Description = "사라진 게로게로<게로게로의 애장품>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "서리서리! 이게 무슨일이야?" },
                new Dialogue { TalkerKo = "서리서리", Scripts = "게로게로가 내 버섯을 훔쳐먹어서..(훌쩍)" },
                new Dialogue { TalkerKo = "서리서리", Scripts = "그냥 평소처럼 화를 조금 냈어(훌쩍)" },
                new Dialogue { TalkerKo = "서리서리", Scripts = "게로게로는 원래 화를 내도 변함없이 날 놀리고 다녔는데(훌쩍)" },
                new Dialogue { TalkerKo = "서리서리", Scripts = "아주 잠깐 눈을 돌린 사이에 사라져 버렸어(훌쩍)" },
                new Dialogue { TalkerKo = "서리서리", Scripts = "마을안을 모조리 찾아봤는데 보이지가 않아..제발 게로게로를 찾아줘(엉엉)" },                
            },
            isContinue = true,
            QuestItemID = 24,
            GoalCount = 10,
            // 케이크 10개와 게로게로의 주머니1개 얻으면 클리어
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1030,
            Description = "사라진 게로게로<게로게로를 찾아라>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "(정말 마을안에는 게로게로가 없잖아?)" },
                new Dialogue { TalkerKo = "주인공", Scripts = "(마을 밖으로 나간게 분명해!)" },
                new Dialogue { TalkerKo = "주인공", Scripts = "게로게로!!!!!어딨어!!" },
                new Dialogue { TalkerKo = "게로게로", Scripts = "늑대가 너무 무서워" },
                new Dialogue { TalkerKo = "주인공", Scripts =  "!?" },
                new Dialogue { TalkerKo = "주인공", Scripts = "방금 게로게로의 목소리가 들린 것 같아" },
                new Dialogue { TalkerKo = "주인공", Scripts = "근데 방향이..부끄부끄가 사라졌었던 곳이 잖아!?" },                
            },            
            QuestItemID = 5,
            GoalCount= 10,
            QuestItemID2 = 6,
            GoalCount2 = 10,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1031,
            Description = "사라진 게로게로<게로게로를 마을로 데려가기>,<서리서리와 대화>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "이 장소는..부끄부끄를 발견했던 장소야." },
                new Dialogue { TalkerKo = "주인공", Scripts = "게로게로! 왜 여기 있는거야?" },
                new Dialogue { TalkerKo = "게로게로", Scripts = "나..나는 서리서리를 놀리려고 했는데 으아앙~~몰라" },                
                new Dialogue { TalkerKo = "", Scripts =  "게로게로는 쓰러졌다." },
                new Dialogue { TalkerKo = "주인공", Scripts = "(어서 마을로 데려가야겠어. 촌장님께 이상한 점을 말해야해)" },
              
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1032,
            Description = "사라진 게로게로<촌장에게 이상한 점 말하기>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "서리서리", Scripts = "게로게로!!" },
                new Dialogue { TalkerKo = "서리서리", Scripts = "게로게로를 찾아줘서 정말 고마워!" },
                new Dialogue { TalkerKo = "주인공", Scripts = "촌장님! 게로게로를 찾았는데 이상한 점이 있습니다." },
                new Dialogue { TalkerKo = "주인공", Scripts = "부꾸부꾸와 같은 장소에서 발견이 되었어요!" },
                new Dialogue { TalkerKo = "주인공", Scripts =  "그런데 게로게로도 왜 거기 있는지는 모른다고 합니다." },
                new Dialogue { TalkerKo = "촌장", Scripts = "아니 이런 해괴한일이 있나...아무튼 게로게로까지 찾아주다니, 고맙네 젊은이!" },
                new Dialogue { TalkerKo = "주인공", Scripts = "아닙니다. (이 마을에서 이상한 일이 벌어지고 있는 것이 분명해)" },                
            },
            isContinue = true,
            isDirectClear = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1033,
            Description = "띠리띠리의 이상행동<띠리띠리 찾아가기>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "하이하이", Scripts = "촌장님! 용사님! 띠리띠리가 이상해요!" },
                new Dialogue { TalkerKo = "촌장", Scripts = "이건 또 무슨일인가..!? 어서 가보세!" },
                new Dialogue { TalkerKo = "띠리띠리", Scripts = "크크큭 고기!! 고기를 가져와!" },
                new Dialogue { TalkerKo = "띠리띠리", Scripts = "나님에게 고기를 바쳐라. 어리석은 것들아! 내 흑염룡을 맛보고 싶은것이냐!" },
                new Dialogue { TalkerKo = "주인공", Scripts =  "띠리띠리!? 왜 그러는거야!" },
                new Dialogue { TalkerKo = "띠리띠리", Scripts = "왜라니 나에게 감히 왜라는 단어를 쓴거야?" },
                new Dialogue { TalkerKo = "띠리띠리", Scripts = "크으으으..내안에서 또다른 내가 살아난다!!!!" },
                
            },
            isContinue = true,
            rewardType = RewardType.Item,
            QuestType = 3,
            RewardID =  16,
            RewardCount = 10,
            QuestItemID = 14,
            GoalCount = 10,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1034,
            Description = "띠리띠리의 이상행동<띠리띠리 잠재우기>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "비켜." },
                new Dialogue { TalkerKo = "주인공", Scripts = "스승님?" },
                new Dialogue { TalkerKo = "띠리띠리", Scripts = "크하핫 나에게 도전장을 내미는 놈은 살아돌아가지 못할 ㄱ.." },
                new Dialogue { TalkerKo = "", Scripts = "뚜쉬뚜쉬의 한방에 띠리띠리는 기절했다." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts =  "오랜만에 용의 힘을 개방했더니 좀 피곤하군. " },
                new Dialogue { TalkerKo = "주인공", Scripts = "어떻게 된 일이죠?" },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "녀석을 잠재웠다. 내 할일은 끝났으니 뒷일을 책임지도록." },
                new Dialogue { TalkerKo = "주인공", Scripts = "(스승님이 뭔가를 알고 계신걸까?)" },                
            },            
            // QuestItemID = 당근, 도넛
            // GoalCount = 10, 5
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1035,
            Description = "마을의 비밀<뚜쉬뚜쉬와 대화>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "스승님! 아까의 일에 대해 여쭤보러 왔습니다!" },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "난 그저 기의 흐름을 읽어 응답했을 뿐." },
                new Dialogue { TalkerKo = "뚜쉬뚜쉬", Scripts = "마을에 답이 있다. 그 이상 내가 해줄 수 있는 말은 없다." },                
                new Dialogue { TalkerKo = "주인공", Scripts =  "(마을..?)" },                
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1036,
            Description = "마을의 비밀<촌장과 대화>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "저..촌장님! 마을내에서 일어나는 사건들에 대해 아시는 것이 없습니까?" },
                new Dialogue { TalkerKo = "촌장", Scripts = "허허이 생각을 해보겠네. 음료수라도 마시면서 대화를 나누지 않겠는가?" },
                new Dialogue { TalkerKo = "촌장", Scripts = "조금 춥기도 하니 땔감도 좀 구해다 주게." },
            },                
            isContinue = true,
            // QuestItemID = 음료수, 나무
            // 촌장과 상호작용

        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1037,
            Description = "마을의 비밀<촌장에게 단서 획득하기>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "촌장", Scripts = "사실 우리가 왜 이런 모습인지, 최근에 나타나는 기이한 일이 무엇인지는 모른다네" },
                new Dialogue { TalkerKo = "촌장", Scripts = "일주일 전 쯤인가..밤에 불빛이 번쩍 거린 적은 있었지만 아마도 번개였을테지" },
                new Dialogue { TalkerKo = "주인공", Scripts = " (불빛..?)" },
                new Dialogue { TalkerKo = "촌장", Scripts = "어쩌면 자네가 우리 마을을 구원해줄 이가 아닌가 혼자 생각해본다네 껄껄" },
                new Dialogue { TalkerKo = "촌장", Scripts =  "염치없지만.. 도와주게나.." },
                new Dialogue { TalkerKo = "촌장", Scripts = "그리고 여관으로 돌아가는 길이면 이것을 좀 전해주겠나?" },                
            },
            isContinue = true,
            // 보상: 하이하이 여관의 맥주컵
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1038,
            Description = "마을의 비밀<하이하이에게 단서 획득하기>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "하이하이", Scripts = "어머~~이제 오니? 얼른 씻고 푹 쉬려무나!" },
                new Dialogue { TalkerKo = "주인공", Scripts = "안녕하세요! 촌장님이 이걸 전해드리라고 하셔서요!" },
                new Dialogue { TalkerKo = "하이하이", Scripts = "우리 여관의 맥주컵! 깜박하고 있었구나~깔깔깔~~! 정말 고마워!" },
                new Dialogue { TalkerKo = "하이하이", Scripts = "오늘은 참 기이한 하루이지 않았니? 어쩜 그런일들이 일어났을까?" },
                new Dialogue { TalkerKo = "하이하이", Scripts =  "항상 조심해요! 알았죠?" },
                new Dialogue { TalkerKo = "주인공", Scripts = " (말이 너무 많다..) 네~! 그나저나 혹시 최근들어 이상한걸 보셨다거나..뭐 그런 적ㅇ.." },
                new Dialogue { TalkerKo = "하이하이", Scripts = "글세 말하다 보면 있었을지도? 그나저나 배 안고프니? 특별히 맛있는 것을 해줄게!" },
                new Dialogue { TalkerKo = "하이하이", Scripts = " 준비하는 동안 생선을 몇마리 구해다 줄래?" },
                new Dialogue { TalkerKo = "하이하이", Scripts = "이왕이면 다른 맥주컵도 같이 가져와줘~ 부탁할께!" },                
            },
            isContinue = true,
            // 생선 10개
            // 맥주컵 5개
            // 하이하이와 상호작용
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1039,
            Description = "마을의 비밀<하이하이와 저녁식사>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "하이하이", Scripts = "어서 맛있게 먹자구~~ 특별소스를 넣어 조리했어!" },
                new Dialogue { TalkerKo = "주인공", Scripts = "잘먹겠습니다!" },
                new Dialogue { TalkerKo = "하이하이", Scripts = "오늘은 정말 다이나믹한 하루였어~~그렇지 않니? " },
                new Dialogue { TalkerKo = "하이하이", Scripts = "모두들 무사해서 정말정말 다행이야." },
                new Dialogue { TalkerKo = "하이하이", Scripts =  "그래서 내가 맥주한잔씩 돌린거란다~" },
                new Dialogue { TalkerKo = "하이하이", Scripts = "어라? 근데 왜 이 맥주컵은 검정색으로 물들었지? 산지 얼마 안된건데?" },
                new Dialogue { TalkerKo = "하이하이", Scripts = "불량품이 섞여있었다니!" },
                new Dialogue { TalkerKo = "주인공", Scripts = "(검정색으로 물들었다고..?)" },
                new Dialogue { TalkerKo = "", Scripts = "하이하이는 투덜대며 또 다른 이야기를 잔뜩 늘어놓았다." },
                new Dialogue { TalkerKo = "주인공", Scripts = "(...피곤하다) 내일은 띠리띠리가 괜찮은지 가봐야겠어요." },
                new Dialogue { TalkerKo = "하이하이", Scripts = "(조잘조잘..) 어머 그러면 저번에 띠리띠리가 맡겨놓은 당근 좀 같이 가져다줄래?" },
            },
            isDirectClear = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1040,
            Description = "마을의 비밀<띠리띠리에게 단서 획득하기>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "띠리띠리..? 몸은 좀 어때? 괜찮아?" },
                new Dialogue { TalkerKo = "띠리띠리", Scripts = "어..안녕. 하이하이의 도넛 덕분인가, 몸은 괜찮은데 아무것도 기억이 나지 않네." },
                new Dialogue { TalkerKo = "주인공", Scripts = "그럼 혹시 마지막 기억은 뭐였는지 물어봐도 돼?" },
                new Dialogue { TalkerKo = "띠리띠리", Scripts = "나는 그냥 하이하이한테 가는 길이었는데..으음...." },
                new Dialogue { TalkerKo = "띠리띠리", Scripts =  "용을 별로 좋아하진 않는데 갑자기 머릿속에 용이 날아다녔어." },
                new Dialogue { TalkerKo = "띠리띠리", Scripts = "뭐 그냥 뜬금없이 잡생각을 했었나봐. 그러고는 눈뜨니 집이었어." },
                new Dialogue { TalkerKo = "주인공", Scripts = " (용..?)" },
                
            },
            isContinue = true,
            // 보상 당근 5개
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1041,
            Description = "사라진 하이하이<하이하이의 애장품>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "촌장", Scripts = "젊은이 여기있었나? 또 일이 일어났네. 이번엔 하이하이가 사라졌어!" },
                new Dialogue { TalkerKo = "띠리띠리", Scripts = "뭐!!!?? 안돼!! 하이하이!" },
                new Dialogue { TalkerKo = "주인공", Scripts = "아침까지만 해도 여관에 계셨는데요..?" },
                new Dialogue { TalkerKo = "주인공", Scripts = "제가 찾아볼게요!" },
                new Dialogue { TalkerKo = "띠리띠리", Scripts =  "꼭 찾아줘!! 하이하이가 없으면 안돼!" },
                
            },
            isContinue = true,
            // 생선 10개
            // 하이하이의 주방그릇 1개
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1042,
            Description = "사라진 하이하이<하이하이를 찾아라>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = " (이번에도 그 장소 일거야)" },
                new Dialogue { TalkerKo = "주인공", Scripts = "하이하이!" },
                new Dialogue { TalkerKo = "하이하이", Scripts = "어머어머 여긴 어디야..? 무서워.." },
                new Dialogue { TalkerKo = "", Scripts = "하이하이는 기절했다." },
                new Dialogue { TalkerKo = "주인공", Scripts =  "(이 장소에 확실히 뭔가 있어!  일단 하이하이를 마을로 데려가자)" },              
            },            
            //스컹크 20마리 처치
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1043,
            Description = "마을의 비밀<서리서리에게서 단서 획득하기>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "촌장", Scripts = "이번에도 사라진 우리 주민을 찾아주어 고맙네! " },
                new Dialogue { TalkerKo = "주인공", Scripts = "아닙니다! 촌장님 제가 곧 찾아뵐게요" },
                new Dialogue { TalkerKo = "주인공", Scripts = "(지나가는 서리서리) 앗 서리서리 잠깐만!" },                
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1044,
            Description = "마을의 비밀<서리서리에게서 단서 획득하기>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "서리서리", Scripts = "뭐야!?" },
                new Dialogue { TalkerKo = "주인공", Scripts = "잠깐 이야기 좀 할 수 있어?" },
                new Dialogue { TalkerKo = "서리서리", Scripts = "난 지금 버섯을 캐러 가야한다구! 바빠!" },
                new Dialogue { TalkerKo = "서리서리", Scripts = "하지만 저번에 게로게로를 구해주었으니 시간을 내줄게" },
                new Dialogue { TalkerKo = "서리서리", Scripts =  "그 대신 버섯을 좀 가져와 줘!" },                
            },
            isContinue = true,
            // 버섯 10개, 서리서리와 상호작용
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1045,
            Description = "마을의 비밀<서리서리와 이야기 해보기>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "서리서리", Scripts = "오호? 버섯 고마워 잘 먹을게" },
                new Dialogue { TalkerKo = "주인공", Scripts = " 휴우.. 이제 질문 좀 해도 될까..?" },
                new Dialogue { TalkerKo = "서리서리", Scripts = "해도 되는데 빨리 해줬으면 좋겠어! 빨리빨리!" },
                new Dialogue { TalkerKo = "주인공", Scripts = "(항상 화가 나있네..) 아 음! 너도 알다시피 최근에 마을에 이상한 일이 생겼잖아" },
                new Dialogue { TalkerKo = "주인공", Scripts =  "그 와중에 혹시 기억에 남거나 특이한 어떤 것이 없었어?" },
                new Dialogue { TalkerKo = "서리서리", Scripts = "그런 건 딱히 없었는데 신기한 건 본적이 있어!" },
                new Dialogue { TalkerKo = "서리서리", Scripts = "강가쪽에서 보랏빛의 오로라가 반짝이는 걸 보았어!" },
                new Dialogue { TalkerKo = "서리서리", Scripts = "혹시 100년만에 나타났던 자연현상 같은거였을까?" },
                new Dialogue { TalkerKo = "주인공", Scripts = "(보랏빛의 오로라..?)" },
                new Dialogue { TalkerKo = "서리서리", Scripts = "후후..왠지 웃음이 나지 않나? 보랏빛의 자연현상이라니..쿡" },
                new Dialogue { TalkerKo = "주인공", Scripts = "?" },
            },
            isContinue = true,
            isDirectClear = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1046,
            Description = "서리서리의 이상행동",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "서리서리...?" },
                new Dialogue { TalkerKo = "서리서리", Scripts = "내 이름을 함부로 부르지마라..애송이" },
                new Dialogue { TalkerKo = "서리서리", Scripts = "내이름은 함부로 부른 자 중에 살아남은 자는 없다" },
                new Dialogue { TalkerKo = "서리서리", Scripts = "특별히 나의 흑염의 파멸검으로 너의 마지막을 장식해주마." },
                new Dialogue { TalkerKo = "서리서리", Scripts =  "하앗!" },
                new Dialogue { TalkerKo = "", Scripts = "서리서리가 갑자기 공격을 해온다." },              
            },
            isContinue = true,
            isDirectClear = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1047,
            Description = "서리서리의 이상행동<서리서리 제압>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "크윽!" },
                new Dialogue { TalkerKo = "서리서리", Scripts = "호오..수련의 성과인가? 내 파멸검의 공격을 버티다니" },
                new Dialogue { TalkerKo = "서리서리", Scripts = "오랜만에 나의 깊은 심연에서 용의 소용돌이가 느껴지는구나" },
                new Dialogue { TalkerKo = "서리서리", Scripts = "개.방.하.겠.다." },
                new Dialogue { TalkerKo = "주인공", Scripts = "(거친 숨을 쉬며)하아하아 서리서리.." },
            },
            isContinue = true,
            isDirectClear = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1048,
            Description = "촌장에게<촌장이랑 대화>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = " (띠리띠리가 이상해졌을 때와 너무도 흡사해!)" },
                new Dialogue { TalkerKo = "주인공", Scripts = "(지금까지의 의문점과 단서들을 추리해봤을때...)" },
                new Dialogue { TalkerKo = "주인공", Scripts = "(번쩍거렸던 불빛, 검정색으로 물든 맥주잔, 머릿속에 갑자기 떠오른 용, 보랏빛의 오로라)" },
                new Dialogue { TalkerKo = "주인공", Scripts = " (그리고 실종되었던 사람들이 발견된 같은장소)" },
                new Dialogue { TalkerKo = "주인공", Scripts =  " (얼른 촌장님을 만나뵈어야겠어!)" },                
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1049,
            Description = "촌장에게<마을의 비밀>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "촌장님!" },
                new Dialogue { TalkerKo = "촌장", Scripts = "무슨 일인가?" },
                new Dialogue { TalkerKo = "주인공", Scripts = "마을사람들의 모습이 변하고, 사라지고, 이상행동을 하는 것은 고대 마왕의 저주와 비슷해요." },
                new Dialogue { TalkerKo = "주인공", Scripts = "제 오래된 기억에 의하면 저희 왕국이 마왕과 전쟁을 벌일 적이 있어요." },
                new Dialogue { TalkerKo = "주인공", Scripts =  "전쟁 중 정신이 없었지만 이 마을에서 일어난 일과 비슷한 일들이 벌어졌어요." },
                new Dialogue { TalkerKo = "주인공", Scripts = "마을 주민들은 자각 못했지만 나눴던 말 중에 힌트가 있었어요." },
                new Dialogue { TalkerKo = "촌장", Scripts = "뭐?? 그럼 우리 마을이 마왕의 저주라도 받았다는 말인가?" },
                new Dialogue { TalkerKo = "촌장", Scripts = "그럴리는 없네! 무슨 말도 안되는 얘기인가!" },
                new Dialogue { TalkerKo = "촌장", Scripts = "내가 자네를 너무 믿었구만.. 그런 실없는 이야기일 줄이야.. 우리마을에서 나가주게!" },
            },
            isContinue = true,
            isDirectClear = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1050,
            Description = "스승님 찾아가기<뚜쉬뚜쉬의 집으로 가기>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "(왜 촌장님이 저렇게 적대적이신거지..?)" },
                new Dialogue { TalkerKo = "주인공", Scripts = "(어쩌면 스승님은 알고 계실까?)" },               
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1051,
            Description = "사라진 뚜쉬뚜쉬<뚜쉬뚜쉬의 행방>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "스승님~!!!" },                
                new Dialogue { TalkerKo = "주인공", Scripts = "스승님!!!!! 스승님~~!!!!!?" },
                new Dialogue { TalkerKo = "주인공", Scripts = "이럴수가 이번엔 스승님이 사라지셨어!" },
                new Dialogue { TalkerKo = "주인공", Scripts = "어서 '그 장소'로 가봐야 겠어!" },
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1052,
            Description = "사라진 뚜쉬뚜쉬<사라짐의 예외>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "", Scripts = "'그 장소' 에는 아무것도 없었다." },
                new Dialogue { TalkerKo = "주인공", Scripts = "분명 스승님이 여기 계셔야 할...아니!? 어떻게 된거지?" },
                new Dialogue { TalkerKo = "주인공", Scripts = "왜 스승님만...?" },
                new Dialogue { TalkerKo = "주인공", Scripts = "(촌장님은 떠나라고 하셨지만..이 마을을 이대로 둘 순 없어)" },
                new Dialogue { TalkerKo = "주인공", Scripts = "(스승님이 아예 사라지신 지금이 제일 위험할거야.)" },
                new Dialogue { TalkerKo = "주인공", Scripts = "(어떻게든 마을에서 단서를 더 찾아봐야해!)" },
               
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1053,
            Description = "촌장설득하기<촌장과 대화>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "촌장님!" },
                new Dialogue { TalkerKo = "촌장", Scripts = "아니 자네 아직도 안떠났는가?" },
                new Dialogue { TalkerKo = "주인공", Scripts = "저의 스승님이 사라지셨습니다. 부꾸부꾸나 게로게로를 찾은 장소에 가봐도 보이질 않아요!" },
                new Dialogue { TalkerKo = "촌장", Scripts = "이제 자네와 상관없는 일 일세! 우리가 알아서 할테니 신경쓰지말게!" },
                new Dialogue { TalkerKo = "주인공", Scripts =  "스승님은 촌장님이 소개시켜 주셨잖아요. 그리고 마을의 이상한 일도.." },
                new Dialogue { TalkerKo = "촌장", Scripts = " 또 마왕의 저주니 뭐니 그런 시덥잖은 이야기를 하는 겐가!? " },
                new Dialogue { TalkerKo = "촌장", Scripts = "생각해보니 자네가 온 이후로 이상해진 건 아닌가! 어서 마을을 떠나주게!" },
                new Dialogue { TalkerKo = "촌장", Scripts = "이제 자네와 이야기를 하지 않겠네!" },
                new Dialogue { TalkerKo = "", Scripts = "촌장을 매정하게 가버린다." },
            },
            isContinue = true,
            isDirectClear = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1054,
            Description = "촌장 설득하기<촌장이 좋아하는 것>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = " ... 촌장님이 뭔가 잘못 생각하고 계신것 같아." },
                new Dialogue { TalkerKo = "주인공", Scripts = "촌장님을 설득하기 위해 뭐라도 해야겠어!" },                
            },
            isContinue = true,
            // 음료수 10개, 맥주컵 1개 나무 5개, 촌장과 상호작용
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1055,
            Description = "촌장 설득하기<촌장과 대화>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "촌장님.. 약소하지만 좋아하시는 것들 몇개 챙겨왔어요" },
                new Dialogue { TalkerKo = "촌장", Scripts = "..." },
                new Dialogue { TalkerKo = "주인공", Scripts = "제 생각에는 마을이 정말 위험한 것같아요. 제가 도와드릴게요!" },
                new Dialogue { TalkerKo = "촌장", Scripts = "..." },
                new Dialogue { TalkerKo = "주인공", Scripts =  "(부족한걸까..뭔가 마을을 위한 것을 해야겠어)" },                
            },
            isContinue = true,
            isDirectClear=true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1056,
            Description = "촌장 설득하기<마을 주변 몬스터 퇴치>",
            dialogues = new List<Dialogue>
            {                
                new Dialogue { TalkerKo = "주인공", Scripts = "(마을 주변 동물들이 난폭해졌다고 하셨었지)" },
                new Dialogue { TalkerKo = "주인공", Scripts = "(마을의 안전을 위해 동물들을 진정시켜야겠어)" },
            },
            isContinue = true,
            // 오리너구리 10마리
            // 카멜레온 10마리
            // 미어캣 10말
            //고슴도치 10마리
            // 스컹크 10마리
            // 촌장과 상호작용
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1057,
            Description = "촌장 설득하기<더 위험한 몬스터 퇴치>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "촌장님. 마을 주변에 있는 동물들을 많이 진정시켰어요." },
                new Dialogue { TalkerKo = "촌장", Scripts = "..." },
                new Dialogue { TalkerKo = "주인공", Scripts = "더 위험한 동물들은 아직 남아있어요.. 마저 진정시키고 올게요!" },
                new Dialogue { TalkerKo = "촌장", Scripts = "..." },             
            },
            isContinue = true,
            // 늑대 20, 황소 20
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1058,
            Description = "촌장 설득하기<촌장 제압>",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "촌장님! 이 근처 위험했던 동물들이 대부분 진정이 됐어요!" },
                new Dialogue { TalkerKo = "주인공", Scripts = "이젠 당분간 큰 위험은 없을 것 같습니다." },
                new Dialogue { TalkerKo = "촌장", Scripts = "..." },
                new Dialogue { TalkerKo = "주인공", Scripts = "저는 마을에 도움이 되고 싶어요.." },
                new Dialogue { TalkerKo = "촌장", Scripts =  "자네 말귀를 참 못알아듣는구만! 혼나야 정신을 차릴게냐!" },
                new Dialogue { TalkerKo = "", Scripts = "촌장이 달려든다." },                
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1059,
            Description = "빛나는 아티펙트(1)",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "죄송합니다 촌장님.." },                
                new Dialogue { TalkerKo = "주인공", Scripts = "(촌장님한테도 아티펙트가 떨어졌잖아!?)" },               
                new Dialogue { TalkerKo = "주인공", Scripts = "(처음 내가 갖고있었던 것, 서리서리에게 떨어진 것, 촌장님한테 떨어진 것 총 세개야)" },
                new Dialogue { TalkerKo = "주인공", Scripts = "(앗 희미하게 빛을 내고 있잖아?)" },
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1060,
            Description = "빛나는 아티펙트(2)",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "(하나가 모자른 것 같은데..?)" },
                new Dialogue { TalkerKo = "주인공", Scripts = "(맞아! 처음에 띠리띠리에게서 나온 아티펙트는 스승님이 가져가셨어.)" },
                new Dialogue { TalkerKo = "주인공", Scripts = "(스승님을 찾아야해! )" },
                new Dialogue { TalkerKo = "", Scripts = "밤이 찾아온다." },
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest
        {
            QuestID = 1061,
            Description = "빛나는 아티펙트(3)",
            dialogues = new List<Dialogue>
            {
                new Dialogue { TalkerKo = "주인공", Scripts = "(흠..아티펙트들이 빛을 내고 있긴 한데 뭘 의미하는 걸까..)" },
                new Dialogue { TalkerKo = "주인공", Scripts = "(스승님은 어디 계신걸까..)" },
                new Dialogue { TalkerKo = "", Scripts = "그때 마을 밖에서 빛기둥이 올라온다." },
                new Dialogue { TalkerKo = "주인공", Scripts = "(앗 저 빛은 뭐지!? '그 장소'쪽 이야. 내일 아침 날이 밝으면 찾아가보자!)" },               
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);
    }
}