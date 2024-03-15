using System.Collections.Generic;

[System.Serializable]
public class BossMonsterStatData
{
    public int BossID;
    public string Name;
    public int HP;
    public int Damage;
    public int Def;
    public float MoveSpeed;
    public float Range;
}

[System.Serializable]
public class BossMonsterStatDatabase : DataBase<int, BossMonsterStatData>
{
    public List<BossMonsterStatData> BossMonster;

    protected override void LoadData()
    {
        foreach (var boss in BossMonster)
        {
            data.Add(boss.BossID, boss);
        }
    }
}
