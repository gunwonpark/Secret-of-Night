using UnityEngine;

public class MonsterSpot : MonoBehaviour
{
    MonsterInfo monsterInfo;
    GameObject go;

    [SerializeField] public string monsterName;
    [SerializeField] int monsterCount;

    public Vector3 MyOriginalPosition;

    public void MonsterSpawn(MonsterInfo monsterInfo)
    {
        //monsterSpawner가 준 내 몬스터 정보
        this.monsterInfo = monsterInfo;

        //생성
        go = Instantiate(monsterInfo.prefab, transform);

        MyOriginalPosition = go.transform.position;
        Debug.Log(MyOriginalPosition);
        //OriginalPosition(MyOriginalPosition);

        FieldMonsters fieldMonsters = go.GetComponent<FieldMonsters>();

        //fieldMonsters 시작?
        fieldMonsters.Init(monsterInfo);
    }

    public void OriginalPosition(Vector3 position)
    {

    }
}
