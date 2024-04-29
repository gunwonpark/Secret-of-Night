using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    // 다양한 자막 키와 그에 해당하는 자막 텍스트를 저장하는 딕셔너리
    private Dictionary<string, string> subtitleDictionary = new Dictionary<string, string>();

    // 자막 키와 자막 텍스트를 추가하는 함수
    public void AddSubtitle(string key, string text)
    {
        if (!subtitleDictionary.ContainsKey(key))
        {
            subtitleDictionary.Add(key, text);
        }
        else
        {
            Debug.LogWarning("Subtitle key already exists: " + key);
        }
    }

    private void Start()
    {
        AddSubtitle("Sub1", "크크큭 고기!! 고기를 가져와!");
        AddSubtitle("Sub2", "나님에게 고기를 바쳐라. 어리석은 것들아! 내 흑염룡을 맛보고 싶은것이냐!");
        AddSubtitle("Sub3", "띠리띠리!? 왜 그러는거야!");
        AddSubtitle("Sub4", "왜라니 나에게 감히 왜라는 단어를 쓴거야?");
        AddSubtitle("Sub5", "크으으으..내안에서 또다른 내가 살아난다!!!!");
        AddSubtitle("Sub6", "비켜.");
        AddSubtitle("Sub7", "스승님?");
        AddSubtitle("Sub8", "크하핫 나에게 도전장을 내미는 놈은 살아돌아가지 못할 ㄱ..");
        AddSubtitle("Sub9", "뚜쉬뚜쉬의 한방에 띠리띠리는 기절했다.");
        AddSubtitle("Sub10", "오랜만에 용의 힘을 개방했더니 좀 피곤하군. ");
        AddSubtitle("Sub11", "어떻게 된 일이죠?");
        AddSubtitle("Sub12", "녀석을 잠재웠다. 내 할일은 끝났으니 뒷일을 책임지도록.");
        AddSubtitle("Sub13", "(스승님이 뭔가를 알고 계신걸까?)");

        AddSubtitle("Sub14", "이번에도 사라진 우리 주민을 찾아주어 고맙네!");
        AddSubtitle("Sub15", "아닙니다! 촌장님. 연달아 이런 일이 일어나서...");
        AddSubtitle("Sub16", "아니! 하이하이가 왜 이러고 있어?");
        AddSubtitle("Sub17", "...?");

        AddSubtitle("Sub18", "(거친 숨을 쉬며)하아하아 서리서리...");
        AddSubtitle("Sub19", "응? 이게 뭐지?");

        AddSubtitle("Sub20", "촌장님! 이 근처 위험했던 동물들이 대부분 진정이 됐어요!");
        AddSubtitle("Sub21", "이젠 당분간 큰 위험은 없을 것 같습니다.");
        AddSubtitle("Sub22", "....");
        AddSubtitle("Sub23", "저는 마을에 도움이 되고 싶어요..");
        AddSubtitle("Sub24", "자네 말귀를 참 못 알아 듣는구만! 혼나야 정신을 차릴게냐!");

        AddSubtitle("Sub25", "죄송합니다 촌장님..");
        AddSubtitle("Sub26", "(촌장님한테도 아티펙트가 떨어졌잖아?!");
        AddSubtitle("Sub27", "(처음 내가 갖고 있었던 것, 서리서에게 떨어진 것, 촌장님에게 떨어진 것 총 3개야).");
        AddSubtitle("Sub28", "(앗 희미하게 빛이 나..!)");

        AddSubtitle("Sub29", "여긴 어디지?");
        AddSubtitle("Sub30", "용케 여기까지 찾아왔군.");
        AddSubtitle("Sub31", "스승님??");
        AddSubtitle("Sub32", "후후.. 스승이라.. 듣기 좋은 말이지.");
        AddSubtitle("Sub33", "하지만 난 다른 말을 더 좋아하지.");
        AddSubtitle("Sub34", "스승님! 스승님이 사라지셔서 한참을 찾았습니다!");
        AddSubtitle("Sub35", "그리고 마을에도 계속 이상한 일이 일어나는데.. 스승님의 조언이 필요합니다.");
        AddSubtitle("Sub36", "마을의 일은 모두 나의 계획하에 진행된 일이다. 오늘 너의 방문도 내 계획의 일부다!");
        AddSubtitle("Sub37", "???");
        AddSubtitle("Sub38", "크하하 나는 마왕이다! 내 손 안에서 놀아나는 꼴들이 꽤 재밌더군!");
        AddSubtitle("Sub39", "마왕...?");
        AddSubtitle("Sub40", "어디, 나에게 맞설 준비가 되어 있는지 확인 해볼까?");

        AddSubtitle("Sub41", "헉헉.. 끝난건가..?");
        AddSubtitle("Sub42", "끝이라 생각하지 마라.. 아직 저주는 풀리지 않았으니..");
        AddSubtitle("Sub43", "크하하하하하!!!");

    }

    // 자막 키에 해당하는 자막 텍스트를 반환하는 함수
    public string GetSubtitleText(string key)
    {
        if (subtitleDictionary.ContainsKey(key))
        {
            return subtitleDictionary[key];
        }
        else
        {
            Debug.LogWarning("Subtitle key not found: " + key);
            return string.Empty;
        }
    }
}