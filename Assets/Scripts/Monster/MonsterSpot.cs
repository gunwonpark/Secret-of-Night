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
        this.monsterInfo = monsterInfo;
        //생성
        Debug.Log(monsterInfo.Name);
        GameObject go = Instantiate(monsterInfo.prefab, transform);
        FieldMonsters fieldMonsters = go.GetComponent<FieldMonsters>();

        fieldMonsters.Init(monsterInfo);

    }
}
