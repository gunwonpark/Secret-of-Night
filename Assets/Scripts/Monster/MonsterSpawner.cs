using System.Collections.Generic;
using UnityEngine;

public class CircleInfo
{
    public Vector3 center;
    public float radius;

    public CircleInfo(Vector3 centerPosition, float circleRadius)
    {
        center = centerPosition;
        radius = circleRadius;
    }
}

public class MonsterSpawner : MonoBehaviour
{
    MonsterManager monsterManager;
    //MonsterSpot[] spotPoint;//가져온 monsterSpot들의 배열

    MonsterInfo monsterInfo;

    public List<CircleInfo> MonsterSpot = new List<CircleInfo>();
    public int monsterNumber = 10;

    void Start()
    {
        //GetMonsterInfoByKey메서드를 가져오기 위해 몬스터매니저도 가져옴
        monsterManager = GameManager.Instance.monsterManager;

        AddMonsterSpot(new Vector3(3.2f, 0f, 69f), 30f);
        AddMonsterSpot(new Vector3(-58.9f, 0f, 121.8f), 30f);
        AddMonsterSpot(new Vector3(50.3f, 0f, 118.1f), 15f);
        AddMonsterSpot(new Vector3(84.6f, 0f, 180.3f), 15f);
        AddMonsterSpot(new Vector3(98.7f, 0f, 94.5f), 20f);
        AddMonsterSpot(new Vector3(116.6f, 0f, 170.8f), 35f);
        AddMonsterSpot(new Vector3(66.8f, 0f, 247.5f), 20f);
        AddMonsterSpot(new Vector3(31.7f, 0f, 292.1f), 30f);


        //내 자식들의 monsterSpot을 가져온다.
        //spotPoint = GetComponentsInChildren<MonsterSpot>();

        //for (int i = 0; i < spotPoint.Length; i++)
        //{
        ////    //이름 가져오기
        ////    int MonsterID = spotPoint[i].MonsterID;//i번째의 몬스터 이름을
        //    MonsterInfo monsterInfo = monsterManager.GetMonsterInfoByKey(MonsterID);//여기에 넣어 i번째 몬스터 정보를 가져옴

        //    //monsterSpot에 정보 넘겨줌
        //    //spotPoint[i].MonsterSpawn(monsterInfo);

        //    Spawn(monsterInfo);
        //}
    }

    //스폰 및 무브 범위 정보 추가
    public void AddMonsterSpot(Vector3 center, float radius)
    {
        MonsterSpot.Add(new CircleInfo(center, radius));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        foreach (CircleInfo circle in MonsterSpot)
        {
            Gizmos.DrawWireSphere(circle.center, circle.radius);
        }
    }

    //몬스터 스폰
    public void Spawn(MonsterInfo monsterInfo)
    {
        int monsterID = monsterInfo.MonsterID;
        Vector3 pos;

        switch (monsterID)
        {
            case 1:
                pos = (Random.insideUnitCircle * 30f);
                pos.y = 0;
                GameObject ob = Instantiate(monsterInfo.prefab, pos, Quaternion.identity);
                break;
        }
    }
}
