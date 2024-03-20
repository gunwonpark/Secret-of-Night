using UnityEngine;

public class MonsterSpot : MonoBehaviour
{
    MonsterInfo monsterInfo;

    [SerializeField] public string monsterName;
    [SerializeField] int monsterCount;

    private void Start()
    {

    }

    public void MonsterSpawn(MonsterInfo monsterInfo)
    {
        //monsterSpawner가 준 내 몬스터 정보
        this.monsterInfo = monsterInfo;

        //생성
        GameObject go = Instantiate(monsterInfo.prefab, transform);
        FieldMonsters fieldMonsters = go.GetComponent<FieldMonsters>();

        //fieldMonsters 시작?
        fieldMonsters.Init(monsterInfo);

    }
}
