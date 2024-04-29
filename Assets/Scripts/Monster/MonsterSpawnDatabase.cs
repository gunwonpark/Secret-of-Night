using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpawnData
{
    public int SpotID;
    public float[] MonsterSpot;
    public float Radius;
    public int[] MonsterID;

    [NonSerialized]
    public Vector3 spotVector;

    [NonSerialized]
    public GameObject Prefab;

    public void init()
    {
        spotVector = new Vector3(MonsterSpot[0], MonsterSpot[1], MonsterSpot[2]);
    }
}

[Serializable]
public class MonsterSpawnDatabase : DataBase<int, SpawnData>
{
    public List<SpawnData> FieldMonsterSpwan;

    protected override void LoadData()
    {
        foreach (SpawnData spawnData in FieldMonsterSpwan)
        {
            data.Add(spawnData.SpotID, spawnData);
            spawnData.init();
        }
    }
}
