using System.Collections.Generic;
using UnityEngine;

public class SpawnData
{
    public int SpotID;
    public Vector3 MonsterSpot;
    public float Radius;
    public int[] MonsterID;

    public GameObject Prefab;
}

[SerializeField]
public class MonsterSpawnDatabase : DataBase<int, SpawnData>
{
    public List<SpawnData> SpawnData;

    protected override void LoadData()
    {
        foreach (SpawnData spanData in SpawnData)
        {
            data.Add(spanData.SpotID, spanData);
        }
    }
}
