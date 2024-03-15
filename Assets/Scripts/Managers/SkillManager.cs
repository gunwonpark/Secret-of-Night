using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    Dictionary<int, PlayerSkillData> useableSkills = new Dictionary<int, PlayerSkillData>();
    PlayerSkillDataBase playerSkillDataBase = GameManager.Instance.dataManager.playerSkillDataBase;

    public void Initalize()
    {
        playerSkillDataBase = GameManager.Instance.dataManager.playerSkillDataBase;
    }
    public void AddSkill(int id)
    {
        useableSkills.Add(id, playerSkillDataBase.GetData(id));
    }
    public PlayerSkillData GetSkill(int id)
    {
        if (useableSkills.ContainsKey(id))
        {
            return useableSkills[id];
        }
        return null;
    }
}
