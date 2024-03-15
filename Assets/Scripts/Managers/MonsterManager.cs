using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public MonsterData dataManager;

    public void Initialize()
    {
        dataManager = new MonsterData();
        dataManager.Initialize();
    }
    public MonsterInfo GetMonsterInfoByKey(string name)
    {
        return dataManager.monsterDatabase.GetMonsterInfoByKey(name);
    }

    //몬스터 생성
    //몬스터 다이
    //몬스터 스폰
}
