using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    MonsterManager monsterManager;
    MonsterSpot[] spotPoint;//가져온 monsterSpot들의 배열

    // Start is called before the first frame update
    void Start()
    {
        //GetMonsterInfoByKey메서드를 가져오기 위해 몬스터매니저도 가져옴
        monsterManager = GameManager.Instance.monsterManager;

        //내 자식들의 monsterSpot을 가져온다.
        spotPoint = GetComponentsInChildren<MonsterSpot>();


        for (int i = 0; i < spotPoint.Length; i++)
        {
            //이름 가져오기
            int MonsterID = spotPoint[i].MonsterID;//i번째의 몬스터 이름을
            MonsterInfo monsterInfo = monsterManager.GetMonsterInfoByKey(MonsterID);//여기에 넣어 i번째 몬스터 정보를 가져옴

            //monsterSpot에 정보 넘겨줌
            spotPoint[i].MonsterSpawn(monsterInfo);
        }
    }
}
