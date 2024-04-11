using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public MonsterData monsterData;
    public MonsterSpawnDatabase spawnDatabase;
    public DataManager dataManager;

    public void Initialize()
    {
        monsterData = new MonsterData();
        monsterData.Initialize();

        dataManager = GameManager.Instance.dataManager;

        spawnDatabase = dataManager.monsterSpawnDatabase;

        CreatMonsterSpot();
    }

    public MonsterInfo GetMonsterInfoByKey(int MonsterID)
    {
        return monsterData.monsterDatabase.GetMonsterInfoByKey(MonsterID);
    }

    public void CreatMonsterSpot()
    {
        foreach (SpawnData data in spawnDatabase.FieldMonsterSpwan)
        {
            GameObject go = new GameObject();

            MonsterSpot monsterSpot = go.AddComponent<MonsterSpot>();

            monsterSpot.Initialize(this, data);
        }
    }
}
