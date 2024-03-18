using System.IO;
using UnityEngine;

[System.Serializable]
public struct PlayerStat
{
    public int Level;
    public int MaxExp;
    public int CurExp;
    public float MaxHP;
    public float CurHP;
    public float MaxMP;
    public float CurMP;
    public float MaxSP;
    public float CurSP;
    public float Damage;
    public float DamageSpeed;
    public float CriDamage;
    public float Def;
    public float MoveSpeed;
}
/// <summary>
/// PlayerGameData를 생성 한 다음 Initialize를 통해 데이터를 불러오거나 
/// 기본 데이터로 초기화 해둘 수 있다.
/// </summary>
[System.Serializable]
public class PlayerGameData
{
    private string _jsonDataPath;
    private DataManager dataManager;
    //한글이 안보여
    [Header("PlayerInfo")]
    public string CharacterType;
    public int ID; // 로그인 할때 필요하면 사용할 ID -> 현재 미사용
    public int CharacterID; // 캐릭터 ID -> 어떤 종류의 캐릭터인지 결정

    [Header("PlayerStat")]
    public PlayerStat stat = new PlayerStat();
    public int Level;
    public int MaxExp;
    public int CurExp;
    public float MaxHP;
    public float CurHP;
    public float MaxMP;
    public float CurMP;
    public float MaxSP;
    public float CurSP;
    public float Damage;
    public float DamageSpeed;
    public float CriDamage;
    public float Def;
    public float MoveSpeed;

    public PlayerGameData()
    {
        _jsonDataPath = $"{Application.dataPath}/Datas/PlayerData";
    }
    /// <summary>
    /// 현재는 어떤 종류의 캐릭터인지에 따라 데이터를 초기화 시켜준다
    /// </summary>
    /// <param name="CharacterID">캐릭터의 종류</param>
    public void Initialize(int CharacterID)
    {
        dataManager = GameManager.Instance.dataManager;
        this.CharacterID = CharacterID;
        // 파일이 있으면 파일Json데이터 불러오기
        if (File.Exists(_jsonDataPath))
        {
            string json = File.ReadAllText(_jsonDataPath);
            JsonUtility.FromJsonOverwrite(json, this);
            return;
        }
        // 파일이 없으면 기본 데이터 불러오기
        LoadDefaultData();
    }
    public void LoadDefaultData()
    {
        //defualtDataSetting
        if (dataManager != null)
        {
            PlayerStatData statData = dataManager.playerStatDataBase.GetData(CharacterID);
            Level = 1;
            CurExp = 0;
            if (statData != null)
            {
                CharacterType = statData.CharacterType;
                CharacterID = statData.CharacterID;
                MaxHP = statData.HP;
                CurHP = MaxHP;
                MaxMP = statData.MP;
                CurMP = MaxMP;
                MaxSP = statData.SP;
                CurSP = MaxSP;
                Damage = statData.Damage;
                DamageSpeed = statData.DamageSpeed;
                CriDamage = statData.CriDamage;
                Def = statData.Def;
                MoveSpeed = statData.MoveSpeed;
            }
        }
    }
    public void HPChange(int change)
    {
        CurHP += change;
        if (CurHP > MaxHP)
        {
            CurHP = MaxHP;
        }
        else if (CurHP < 0)
        {
            //플레이어 사망
            CurHP = 0;
        }
    }
    public void LevelUp()
    {
        Level++;
        CurExp = 0;

        PlayerLevelData playerLevelData = dataManager.playerLevelDataBase.GetData(Level);

        if (playerLevelData != null)
        {
            MaxExp = playerLevelData.Exp;
            MaxHP += playerLevelData.HP;
            CurHP = MaxHP;
            CurMP = MaxMP;
            Damage += playerLevelData.Damage;
            Def += playerLevelData.Def;
        }
        SaveData();
    }

    public void SaveData()
    {
        Utility.SaveToJson(this, _jsonDataPath);
    }

    public void DeleteData()
    {
        Utility.DeleteJson(_jsonDataPath);
    }
}

