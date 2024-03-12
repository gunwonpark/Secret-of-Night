using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MonsterInfo
{
    public string name;
    public int level;
    public float exp;
    public bool AtkStance;
    public float HP;
    public float Damage;
    public float Daf;
    public float DmgSpeed;
    public float CriDamage;
    public float Speed;
    public float AtkSpeed;
    public float Range;

}

[Serializable]
public class MonsterDataBase //->실제데이터
{
    public List<MonsterInfo> FieldMonster;
    public Dictionary<string, MonsterInfo> fieldMonDic = new();

    //몬스터리스트를 딕셔너리에 추가
    public void Initialize()
    {
        foreach (MonsterInfo fieldMonster in FieldMonster)
        {
            fieldMonDic.Add(fieldMonster.name, fieldMonster);
        }
    }

    //이름으로 몬스터정보 반환
    public MonsterInfo GetMonsterInfoByKey(string name)
    {
        if (fieldMonDic.ContainsKey(name))
        {
            return fieldMonDic[name];
        }
        return null;
    }
}

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public MonsterDataBase monsterDatabase;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        TextAsset fieldMonData = Resources.Load<TextAsset>("Json/FieldMonster_Data");
        monsterDatabase = JsonUtility.FromJson<MonsterDataBase>(fieldMonData.text);
        monsterDatabase.Initialize();
    }

    private void Start()
    {


    }
}
