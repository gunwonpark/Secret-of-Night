using System.Collections.Generic;
using System.IO;
using UnityEngine;

public struct PlayerSkillCache
{
    public PlayerSkillData playerSkillData;
    public GameObject skillEffect;
    public GameObject skillImage;
}
public class PlayerManager : MonoBehaviour
{
    public PlayerGameData playerData = new PlayerGameData();

    public int maxSlotDataNumber => 5;
    public Dictionary<int, PlayerGameData> playerDatas = new Dictionary<int, PlayerGameData>(); // 불러오기 데이터 캐싱용

    private PlayerSkillDataBase _playerSkillDataBase;
    private PlayerStatDataBase _playerStatDataBase;

    public Dictionary<int, PlayerSkillCache> playerSkillList = new Dictionary<int, PlayerSkillCache>();
    public List<SkillSlot> skillSlots = new List<SkillSlot>();

    // 초기 데이터 초기화
    public void Initialize()
    {
        string _jsonDataPath = $"{Application.persistentDataPath}/Datas/PlayerData_";

        _playerSkillDataBase = GameManager.Instance.dataManager.playerSkillDataBase;
        _playerStatDataBase = GameManager.Instance.dataManager.playerStatDataBase;

        for (int slotNumber = 0; slotNumber < 5; slotNumber++)
        {
            if (File.Exists(_jsonDataPath + $"{slotNumber}"))
            {
                if (!GameManager.Instance.playerManager.playerDatas.ContainsKey(slotNumber))
                {
                    GameManager.Instance.playerManager.playerDatas.Add(slotNumber, new PlayerGameData());
                    GameManager.Instance.playerManager.playerDatas[slotNumber].SlotNumber = slotNumber;
                    GameManager.Instance.playerManager.playerDatas[slotNumber].Initialize();
                }
                Debug.Log($"데이터 존재 + {slotNumber}");
            }
        }
    }
    public bool IsSlotHasPlayerData(int slotNumber)
    {
        return playerDatas.ContainsKey(slotNumber);
    }
    // 플레이어 데이터를 불러올대 사용한다
    public void LoadPlayerData(int slotNumber = -1)
    {
        if (playerDatas.ContainsKey(slotNumber))
        {
            playerData = playerDatas[slotNumber];
            InitSkillListByPlayerID(playerData.CharacterID);
        }
        else
        {
            LoadDefaultPlayerData();
        }
    }
    private void LoadDefaultPlayerData()
    {
        playerData.Initialize();
        InitSkillListByPlayerID(playerData.CharacterID);
    }

    #region Player Skill
    //플레이어가 소지 할 수 있는 스킬 리스트를 받아온다
    private void InitSkillListByPlayerID(int characterID)
    {
        playerSkillList.Clear();

        var skillList = _playerStatDataBase.GetData(characterID).Skills;
        foreach (int skillID in skillList)
        {
            PlayerSkillCache cache = new PlayerSkillCache();
            cache.playerSkillData = _playerSkillDataBase.GetData(skillID);
            cache.skillEffect = Resources.Load<GameObject>($"Prefabs/Skills/{cache.playerSkillData.PrefabPath}");
            cache.skillImage = Resources.Load<GameObject>($"Prefabs/Skills/Images/{cache.playerSkillData.PrefabPath}");
            playerSkillList.Add(skillID, cache);
        }
    }
    public GameObject GetSKillImage(int skillID)
    {
        if (playerSkillList.ContainsKey(skillID) == false)
        {
            Debug.LogError("GetSkillImage Error : id is not exist");
            return null;
        }

        return playerSkillList[skillID].skillImage;
    }
    public GameObject GetSkillEffect(int skillID)
    {
        if (playerSkillList.ContainsKey(skillID) == false)
        {
            Debug.LogError("GetSkillImage Error : id is not exist");
            return null;
        }
        return playerSkillList[skillID].skillEffect;
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
    public float GetSkillDamage(int skillID)
    {
        if (playerSkillList.ContainsKey(skillID) == false)
        {
            Debug.LogError("GetSkillDamage Error : id is not exist");
            return 0;
        }
        return playerSkillList[skillID].playerSkillData.Damage;
    }
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
    public bool CheckSkillIsDeActive(int slotNumber)
    {
        return skillSlots[slotNumber].Update || skillSlots[slotNumber].hasSKIll == false;
    }
    public List<int> GetUnlockedSkillSlotNumber()
    {
        List<int> slots = new List<int>();
        for (int i = 0; i < skillSlots.Count; i++)
        {
            if (skillSlots[i].hasSKIll)
            {
                slots.Add(i);
            }
        }
        return slots;
    }
    internal float GetSkillRange(string name)
    {
        foreach (var skill in playerSkillList.Values)
        {
            if (skill.playerSkillData.Name == name)
            {
                return skill.playerSkillData.AttackRange;
            }
        }
        return 0;
    }
    internal float GetSkillAngle(string name)
    {
        foreach (var skill in playerSkillList.Values)
        {
            if (skill.playerSkillData.Name == name)
            {
                return skill.playerSkillData.AttackAngle;
            }
        }
        return 0;
    }
    #endregion;
}
