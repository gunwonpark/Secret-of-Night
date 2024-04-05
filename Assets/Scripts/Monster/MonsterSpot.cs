using UnityEngine;

public class MonsterSpot : MonoBehaviour
{
    MonsterInfo monsterInfo;
    GameObject go;

    [SerializeField] public int MonsterID;
    [SerializeField] int monsterCount;

    public Vector3 MyOriginalPosition;

    public void MonsterSpawn(MonsterInfo monsterInfo)
    {
        //monsterSpawner가 준 내 몬스터 정보
        this.monsterInfo = monsterInfo;
        MonsterID = monsterInfo.MonsterID;

        //생성
        go = Instantiate(monsterInfo.prefab, transform);

        go.GetComponent<FieldMonsters>().SetPosition(transform.position);

        MyOriginalPosition = go.transform.position;

        FieldMonsters fieldMonsters = go.GetComponent<FieldMonsters>();

        //fieldMonsters 시작?
        fieldMonsters.Init(monsterInfo);
    }
}
