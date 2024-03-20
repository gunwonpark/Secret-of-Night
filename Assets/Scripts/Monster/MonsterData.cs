using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MonsterInfo
{
    public int MonsterID;
    public string Name;
    public int Level;
    public float Exp;
    public bool AtkStance;
    public float HP;
    public float Damage;
    public float Daf;
    public float DmgSpeed;
    public float CriDamage;
    public float MoveSpeed;
    public float RunSpeed;
    public float Range;

    public string PrefabPath;

    public GameObject prefab;
}
//변하는 데이터 -> HP
//몬스터cs 상위에 HP만 변할수 있도록 따로 적어둬야함
//건원님 DataManager에 합쳐보자.

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
            //fieldMonster.Init();
            fieldMonDic.Add(fieldMonster.Name, fieldMonster);
            fieldMonster.prefab = Resources.Load<GameObject>(fieldMonster.PrefabPath);
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

public class MonsterData
{
    public MonsterDataBase monsterDatabase;

    public void Initialize()
    {
        TextAsset fieldMonData = Resources.Load<TextAsset>("Json/FieldMonster_Data");
        monsterDatabase = JsonUtility.FromJson<MonsterDataBase>(fieldMonData.text);
        monsterDatabase.Initialize();
    }
}
