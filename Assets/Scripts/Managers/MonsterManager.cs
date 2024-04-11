using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public MonsterData dataManager;
    public MonsterSpawner monsterSpawner;

    public void Initialize()
    {
        dataManager = new MonsterData();
        dataManager.Initialize();


    }

    private void Awake()
    {
        monsterSpawner = gameObject.AddComponent<MonsterSpawner>();
    }

    public MonsterInfo GetMonsterInfoByKey(int MonsterID)
    {
        return dataManager.monsterDatabase.GetMonsterInfoByKey(MonsterID);
    }
}
