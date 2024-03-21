using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private PlayerSkillDataBase _playerSkillDataBase;
    /// <summary>
    /// 사용 가능한 스킬을 보관해 둔다
    /// </summary>
    private Dictionary<int, Skill> _skillList = new Dictionary<int, Skill>();

    //Player가 생성될때 실행해주면 된다
    public void Initalize(int id)
    {
        _playerSkillDataBase = GameManager.Instance.dataManager.playerSkillDataBase;
        GetSkillListByPlayerID(id);
    }
    private void GetSkillListByPlayerID(int id)
    {
        var skillList = GameManager.Instance.dataManager.playerStatDataBase.GetData(id).Skills;
        foreach (int skillID in skillList)
        {
            Skill skill = new Skill(skillID);
            _skillList.Add(skillID, skill);
        }
    }
    public void AquireSkill(int id)
    {
        if (_skillList.ContainsKey(id) == false)
            return;

        _skillList[id].Active();
    }
    public bool IsActive(int id)
    {
        return _skillList[id].IsActive;
    }
    public GameObject GetSkill(int id)
    {
        if (_skillList.ContainsKey(id) == false)
            return null;

        string path = _playerSkillDataBase.GetData(id).PrefabPath;

        return Resources.Load<GameObject>($"Prefabs/Skills/{path}");
    }
}
