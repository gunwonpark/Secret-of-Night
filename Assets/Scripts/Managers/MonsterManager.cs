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

    public void DestroyMonster()
    {
        Destroy(gameObject, 1f);
    }
}
