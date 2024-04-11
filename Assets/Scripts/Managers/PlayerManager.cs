using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerGameData playerData;
    public Dictionary<int, PlayerGameData> playerDatas = new Dictionary<int, PlayerGameData>(); // 불러오기 데이터 캐싱용

    private PlayerSkillDataBase _playerSkillDataBase;
    private PlayerStatDataBase _playerStatDataBase;

    private Dictionary<int, Skill> _playerSkillList = new Dictionary<int, Skill>();
    private int[] _skillSlots = new int[4];
    public void Initialize(int CharacterID)
    {
        _playerSkillDataBase = GameManager.Instance.dataManager.playerSkillDataBase;
        _playerStatDataBase = GameManager.Instance.dataManager.playerStatDataBase;

        if (playerData == null)
        {
            playerData = new PlayerGameData();
            playerData.Initialize();
        }

        InitSkillListByPlayerID(CharacterID);
    }

    //test용
    public void Init(int slotNumber)
    {
        playerData = playerDatas[slotNumber];
    }

    #region Player Skill
    //플레이어가 소지 할 수 있는 스킬 리스트를 받아온다
    private void InitSkillListByPlayerID(int id)
    {
        if (_playerSkillList.Count != 0)
            return;

        var skillList = _playerStatDataBase.GetData(id).Skills;
        foreach (int skillID in skillList)
        {
            Skill skill = new Skill();
            skill.Initialize(_playerSkillDataBase.GetData(skillID));
            _playerSkillList.Add(skillID, skill);
        }
    }
    public void UnlockSkill(int id)
    {
        if (_playerSkillList.ContainsKey(id) == false)
            return;

        _playerSkillList[id].Active();
    }
    public bool IsActive(int id)
    {
        return _playerSkillList[id].IsActive;
    }
    public PlayerSkillData GetSkillData(int id)
    {
        if (_playerSkillList.ContainsKey(id) == false)
            return null;

        return _playerSkillList[id].PlayerSkillData;
    }
    public GameObject GetSkillEffect(int id)
    {
        if (_playerSkillList.ContainsKey(id) == false)
            return null;

        string path = _playerSkillDataBase.GetData(id).PrefabPath;

        return Resources.Load<GameObject>($"Prefabs/Skills/{path}");
    }
    #endregion;
}
