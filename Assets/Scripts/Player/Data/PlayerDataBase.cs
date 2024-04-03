using System.Collections.Generic;

[System.Serializable]
public class PlayerLevelData
{
    public int Level;
    public int Exp;
    public float HP;
    public float Damage;
    public float Def;
}

[System.Serializable]
public class PlayerSkillData
{
    public int SkillID;
    public string Name;
    public string Description;
    public string SkillType;
    public int DelayTime;
    public int Damage;
    public string PrefabPath;
}
[System.Serializable]
public class PlayerStatData
{
    public int CharacterID;
    public string Name;
    public string CharacterType;
    public float HP;
    public float MP;
    public float SP;
    public float Damage;
    public float DamageSpeed;
    public float CriDamage;
    public float Def;
    public float MoveSpeed;
    public int[] Skills;
    public string PrefabPath;
    public int Gold;
}

[System.Serializable]
public class PlayerLevelDataBase : DataBase<int, PlayerLevelData>
{
    public List<PlayerLevelData> PlayerLevel;
    protected override void LoadData()
    {
        foreach (PlayerLevelData levelData in PlayerLevel)
        {
            data.Add(levelData.Level, levelData);
        }
    }
}

[System.Serializable]
public class PlayerSkillDataBase : DataBase<int, PlayerSkillData>
{
    public List<PlayerSkillData> PlayerSkill;
    protected override void LoadData()
    {
        foreach (PlayerSkillData skillData in PlayerSkill)
        {
            data.Add(skillData.SkillID, skillData);
        }
    }
}

[System.Serializable]
public class PlayerStatDataBase : DataBase<int, PlayerStatData>
{
    public List<PlayerStatData> PlayerStat;
    protected override void LoadData()
    {
        foreach (PlayerStatData statData in PlayerStat)
        {
            data.Add(statData.CharacterID, statData);
        }
    }
}
