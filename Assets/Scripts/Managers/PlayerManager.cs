using System.Collections.Generic;
using UnityEngine;

public struct PlayerSkillCache
{
    public PlayerSkillData playerSkillData;
    public GameObject skillEffect;
    public GameObject skillImage;
}
public class PlayerManager : MonoBehaviour
{
    public PlayerGameData playerData;

    public int maxSlotDataNumber => 5;
    public Dictionary<int, PlayerGameData> playerDatas = new Dictionary<int, PlayerGameData>(); // 불러오기 데이터 캐싱용

    private PlayerSkillDataBase _playerSkillDataBase;
    private PlayerStatDataBase _playerStatDataBase;

    public Dictionary<int, PlayerSkillCache> playerSkillList = new Dictionary<int, PlayerSkillCache>();
    public List<SkillSlot> skillSlots = new List<SkillSlot>();
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
        if (playerSkillList.Count != 0)
            return;

        var skillList = _playerStatDataBase.GetData(id).Skills;
        foreach (int skillID in skillList)
        {
            PlayerSkillCache cache = new PlayerSkillCache();
            cache.playerSkillData = _playerSkillDataBase.GetData(skillID);
            cache.skillEffect = Resources.Load<GameObject>($"Prefabs/Skills/{cache.playerSkillData.PrefabPath}");
            cache.skillImage = Resources.Load<GameObject>($"Prefabs/Skills/Images/{cache.playerSkillData.PrefabPath}");
            playerSkillList.Add(skillID, cache);
        }
    }
    public GameObject GetSKillImage(int id)
    {
        if (playerSkillList.ContainsKey(id) == false)
        {
            Debug.LogError("GetSkillImage Error : id is not exist");
            return null;
        }

        return playerSkillList[id].skillImage;
    }
    public GameObject GetSkillEffect(int id)
    {
        if (playerSkillList.ContainsKey(id) == false)
        {
            Debug.LogError("GetSkillImage Error : id is not exist");
            return null;
        }
        return playerSkillList[id].skillEffect;
    }
    public float GetSkillDamage(string name)
    {
        foreach (var skill in playerSkillList.Values)
        {
            if (skill.playerSkillData.Name == name)
            {
                return skill.playerSkillData.Damage;
            }
        }
        return 0;
    }
    //i want using skillslotid and get skillDamage
    public float GetSkillDamage(int id)
    {
        if (playerSkillList.ContainsKey(id) == false)
        {
            Debug.LogError("GetSkillDamage Error : id is not exist");
            return 0;
        }
        return playerSkillList[id].playerSkillData.Damage;
    }
    //추후 이를 통해서 스킬을 추가할 수 있도록 한다
    private int FirstSkillIndex => _playerStatDataBase.GetData(playerData.CharacterID).Skills[0];
    public void ActiveSkillSlot(int slotNumber)
    {
        if (slotNumber < 0 || slotNumber >= 4)
        {
            Debug.LogError("SetSkillSlot Error : slotNumber is out of range");
            return;
        }
        skillSlots[slotNumber].SetSlot(slotNumber + FirstSkillIndex);
    }
    #endregion;
}
