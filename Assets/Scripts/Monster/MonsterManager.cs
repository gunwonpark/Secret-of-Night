using System;
using System.Collections.Generic;
using UnityEngine;




[Serializable]
public class FieldMonster
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
public class Monsters
{
    public List<FieldMonster> FieldMonster;
}

public class MonsterManager : MonoBehaviour
{
    void Start()
    {
        TextAsset test = Resources.Load<TextAsset>("Json/FieldMonster_Data");
        Debug.Log(test.text);
        Monsters fieldMonster = JsonUtility.FromJson<Monsters>(test.text);
        //Debug.Log(classToJson);

        foreach (var monster in fieldMonster.FieldMonster)
        {

            Debug.Log(monster.name);
        }
    }

}
