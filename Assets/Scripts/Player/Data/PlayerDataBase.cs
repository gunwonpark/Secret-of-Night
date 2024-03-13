using System.Collections.Generic;

[System.Serializable]
public class PlayerLevelData
{
    public int Level;
    public int exp;
    public float HP;
    public float Damage;
    public float Def;
}

[System.Serializable]
public class PlayerSkillData
{
    public string EquipType;
    public string DefaultSkill;
    public string DefaultUnlock;
    public string Skill1;
    public string Skill1Unlock;
    public string Skill2;
    public string Skill2Unlock;
}
[System.Serializable]
public class PlayerStatData
{
    public string CharacterType;
    public float HP;
    public int MP;
    public int SP;
    public float Damage;
    public float DamageSpeed;
    public float CriDamage;
    public float Def;
    public float Speed;
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
public class PlayerSkillDataBase : DataBase<string, PlayerSkillData>
{
    public List<PlayerSkillData> playerSkill;
    protected override void LoadData()
    {
        foreach (PlayerSkillData skillData in playerSkill)
        {
            data.Add(skillData.EquipType, skillData);
        }
    }
}

[System.Serializable]
public class PlayerStatDataBase : DataBase<string, PlayerStatData>
{
    public List<PlayerStatData> playerStat;
    protected override void LoadData()
    {
        foreach (PlayerStatData statData in playerStat)
        {
            data.Add(statData.CharacterType, statData);
        }
    }
}