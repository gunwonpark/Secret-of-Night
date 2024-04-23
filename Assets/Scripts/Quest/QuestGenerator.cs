using System.Collections.Generic;
using UnityEngine;
public class QuestGenerator : MonoBehaviour
{
    public List<Quest> tempQuests = new List<Quest>();
    private void Start()
    {
        var newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1001))
        {
            // "배를 채울만한 것을 찾아보기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100101)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100102)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100103)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100104)),
            },
            isContinue = true,
            QuestType = 6,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1002))
        {
            // "주운 버섯을 사용하기",           
            isNoScript = true,
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1003))
        {
            // Description = "주변을 둘러보기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100301)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100302)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100303)),
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1004))
        {
            // Description = "묵을 만한 곳을 찾아보기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100401)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100402)),
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1005))
        {
            // Description = "묵을 만한 곳을 찾아보기",

            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100501)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100502)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100503)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100504)),
            },
            isDirectClear = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1006))
        {
            // Description = "마을의 촌장님에게 찾아가기",
            NextQuestGuide = "여관 주인에게 감사 인사를 표하기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100601)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100602)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100603)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100604)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100605)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100606)),
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1007))
        {
            // Description = "연두색 개구리 게로게로에게 인사하기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100701)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100702)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100703)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100704)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100705)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100706)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100707)),
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1008))
        {
            // Description = "마을 중심에 있는 뽀롱뽀롱에게 인사하기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100801)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100802)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100803)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100804)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100805)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100806)),
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1009))
        {
            // Description = "화가 난 서리서리와 대화하기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100901)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100902)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100903)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100904)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100905)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(100906)),

            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1010))
        {
            // Description = "노란색 개구리 부꾸부꾸에게 인사하기",            
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101001)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101002)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101003)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101004)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101005)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101006)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101007)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101008)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101009)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101010)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101011)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101012)),
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1011))
        {
            // Description = "구리구리에게 돌아가기",            
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101101)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101102)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101103)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101104)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101105)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101106)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101107)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101108)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101109)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101110)),
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1012))
        {
            // Description = "입구에 있는 띠리띠리와 대화하기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101201)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101202)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101203)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101204)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101205)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101206)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101207)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101208)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101209)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101210)),
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1013))
        {
            // 띠리띠리와 함께 마을을 순찰하기
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101301)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101302)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101303)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101304)),
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1014))
        {
            // Description = "띠리띠리를 공격하는 포악한 스컹크를 처치하기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101401)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101402)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101403)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101404)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101405)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101406)),
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1015))
        {
            //Description = "마을 순찰에 대한 보고를 구리구리에게 하러가기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101501)),
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1016))
        {
            // Description = "카멜레온 주변에 있는 부꾸부꾸의 애착단지 찾기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101601)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101602)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101603)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101604)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101605)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101606)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101607)),
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1017))
        {
            // Description = "카멜레온을 무서워하는 부꾸부꾸를 구하기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101701)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101702)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101703)),
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1018))
        {
            // Description = "쓰러진 부꾸부꾸를 데리고 마을로 복귀하기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101801)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101802)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101803)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(101804)),
            },
            isContinue = true,
            QuestType = 6,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1019))
        {
            // Description = "쓰러진 부꾸부꾸를 데리고 마을로 복귀하기",
            isNoScript = true,
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1020))
        {
            // Description = "부꾸부꾸의 복귀 사실을 구리구리에게 말하기",
            isNoScript = true,
            isContinue = true,            
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1021))
        {
            // Description = "마을의 숨은 고수 뚜쉬뚜쉬 찾아가기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102101)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102102)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102103)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102104)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102105)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102106)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102107)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102108)),
            },
            isContinue = true,            
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1022))
        {
            // Description = "마을의 숨은 고수 뚜쉬뚜쉬 찾아가기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102201)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102202)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102203)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102204)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102205)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102206)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102207)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102208)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102209)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102210)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102211)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102212)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102213)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102214)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102215)),
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1023))
        {
            // Description = "마을의 숨은 고수 뚜쉬뚜쉬 찾아가기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102301)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102302)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102303)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102304)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102305)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102306)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102307)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102308)),
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1024))
        {
            // Description = "마을의 숨은 고수 뚜쉬뚜쉬 찾아가기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102401)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102402)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102403)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102404)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102405)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102406)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102407)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102408)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102409)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102410)),                
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1025))
        {
            // Description = "마을의 숨은 고수 뚜쉬뚜쉬 찾아가기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102501)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102502)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102503)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102504)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102505)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102506)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102507)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102508)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102509)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102510)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102511)),
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1026))
        {
            // Description = "마을의 숨은 고수 뚜쉬뚜쉬 찾아가기",
            isNoScript = true,
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1027))
        {
            // Description = "마을의 숨은 고수 뚜쉬뚜쉬 찾아가기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102701)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102702)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102703)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102704)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102705)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102706)),                
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1028))
        {
            // Description = "마을의 숨은 고수 뚜쉬뚜쉬 찾아가기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102801)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102802)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102803)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102804)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102805)),                
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1029))
        {
            // Description = "마을의 숨은 고수 뚜쉬뚜쉬 찾아가기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102901)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102902)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102903)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102904)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102905)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(102906)),
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1030))
        {
            // Description = "마을의 숨은 고수 뚜쉬뚜쉬 찾아가기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(103001)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(103002)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(103003)),                
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1031))
        {
            // Description = "마을의 숨은 고수 뚜쉬뚜쉬 찾아가기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(103101)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(103102)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(103103)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(103104)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(103105)),
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1032))
        {
            // Description = "마을의 숨은 고수 뚜쉬뚜쉬 찾아가기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(103101)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(103102)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(103103)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(103104)),                
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1033))
        {
            isNoScript = true,
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1034))
        {
            isNoScript = true,
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1035))
        {
            // Description = "마을의 숨은 고수 뚜쉬뚜쉬 찾아가기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(103501)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(103502)),                
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1036))
        {
            // Description = "마을의 숨은 고수 뚜쉬뚜쉬 찾아가기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(103601)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(103602)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(103603)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(103604)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(103605)),
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1037))
        {
            // Description = "마을의 숨은 고수 뚜쉬뚜쉬 찾아가기",
            dialogues = new List<Dialogue>
            {
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(103701)),
                new Dialogue (GameManager.Instance.dataManager.dialogueDataBase.GetData(103702)),                
            },
            isContinue = true,
        };
        tempQuests.Add(newQuest);

        newQuest = new Quest(GameManager.Instance.dataManager.questDataBase.GetData(1038))
        {
            isNoScript = true,
            isContinue = true,
        };
        tempQuests.Add(newQuest);
    }
}