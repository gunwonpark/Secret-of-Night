using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleInfo
{
    public Vector3 center;
    public float radius;
    public List<MonsterInfo> monsterID = new List<MonsterInfo>();

    public CircleInfo(Vector3 centerPosition, float circleRadius)
    {
        center = centerPosition;
        radius = circleRadius;
    }

    //각 원에 스폰될 몬스터를 ID로 분류하여 넣어주기
    public void AddMonsterInfo(MonsterInfo ID)
    {
        int monsterNumber;
        monsterID.Add(ID);
    }
}

public class MonsterSpawner : MonoBehaviour
{
    MonsterManager monsterManager;

    MonsterInfo monsterInfo;

    public List<CircleInfo> MonsterSpot = new List<CircleInfo>();
    public int monsterNumber = 10;//각 몬스터 개체수

    void Start()
    {
        //GetMonsterInfoByKey메서드를 가져오기 위해 몬스터매니저도 가져옴
        monsterManager = GameManager.Instance.monsterManager;

        AddInfo();

        StartCoroutine(SpawnMonster());
    }

    //스폰 및 무브 범위 정보 추가
    public void AddMonsterSpot(Vector3 center, float radius)
    {
        MonsterSpot.Add(new CircleInfo(center, radius));
    }

    IEnumerator SpawnMonster()
    {
        while (true)//[todo]각 원의 몬스터 개체수가 꽉 차지 않았을때
        {
            // 각 원의 스폰지점
            foreach (CircleInfo circle in MonsterSpot)
            {
                foreach (MonsterInfo monster in circle.monsterID)
                {
                    Vector3 spawnPoint = GetRandomPointInCircle(circle.center, circle.radius);
                    spawnPoint.y = 0f; // y 값을 0으로 설정
                    Instantiate(monster.prefab, spawnPoint, Quaternion.identity);
                }
                // Debug.Log(spawnPoint);
            }
            yield return new WaitForSeconds(3f); // 3초 마다 1개씩
        }
    }

    Vector3 GetRandomPointInCircle(Vector3 center, float radius)
    {
        //[todo]랜덤지점에 뭐가 없을때만 반환
        float angle = Random.Range(0f, Mathf.PI * 2f); // 랜덤한 각도 생성
        float distance = Mathf.Sqrt(Random.Range(0f, 1f)) * radius; // 랜덤한 거리 생성
        float x = center.x + distance * Mathf.Cos(angle); // x 좌표 계산
        float z = center.z + distance * Mathf.Sin(angle); // z 좌표 계산
        return new Vector3(x, center.y, z); // 랜덤 지점 반환
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        foreach (CircleInfo circle in MonsterSpot)
        {
            Gizmos.DrawWireSphere(circle.center, circle.radius);
        }
    }

    void AddInfo()
    {
        //스팟추가
        //[todo]스팟은 맵에 추가
        AddMonsterSpot(new Vector3(3.2f, 0f, 69f), 30f);
        AddMonsterSpot(new Vector3(-58.9f, 0f, 121.8f), 30f);
        AddMonsterSpot(new Vector3(50.3f, 0f, 118.1f), 15f);
        AddMonsterSpot(new Vector3(84.6f, 0f, 180.3f), 15f);
        AddMonsterSpot(new Vector3(98.7f, 0f, 94.5f), 20f);
        AddMonsterSpot(new Vector3(116.6f, 0f, 170.8f), 35f);
        AddMonsterSpot(new Vector3(66.8f, 0f, 247.5f), 20f);
        AddMonsterSpot(new Vector3(31.7f, 0f, 292.1f), 30f);

        //각 스팟 몬스터 정보 추가
        MonsterSpot[0].AddMonsterInfo(monsterManager.GetMonsterInfoByKey(2));
        //MonsterSpot[0].AddMonsterInfo(monsterManager.GetMonsterInfoByKey(8));
        MonsterSpot[0].AddMonsterInfo(monsterManager.GetMonsterInfoByKey(3));
        MonsterSpot[1].AddMonsterInfo(monsterManager.GetMonsterInfoByKey(2));
        //MonsterSpot[1].AddMonsterInfo(monsterManager.GetMonsterInfoByKey(8));
        MonsterSpot[1].AddMonsterInfo(monsterManager.GetMonsterInfoByKey(3));
        MonsterSpot[2].AddMonsterInfo(monsterManager.GetMonsterInfoByKey(1));
        MonsterSpot[2].AddMonsterInfo(monsterManager.GetMonsterInfoByKey(2));
        MonsterSpot[2].AddMonsterInfo(monsterManager.GetMonsterInfoByKey(4));
        MonsterSpot[3].AddMonsterInfo(monsterManager.GetMonsterInfoByKey(1));
        MonsterSpot[3].AddMonsterInfo(monsterManager.GetMonsterInfoByKey(3));
        MonsterSpot[3].AddMonsterInfo(monsterManager.GetMonsterInfoByKey(4));
        MonsterSpot[4].AddMonsterInfo(monsterManager.GetMonsterInfoByKey(7));
        MonsterSpot[5].AddMonsterInfo(monsterManager.GetMonsterInfoByKey(7));
        MonsterSpot[6].AddMonsterInfo(monsterManager.GetMonsterInfoByKey(5));
        MonsterSpot[7].AddMonsterInfo(monsterManager.GetMonsterInfoByKey(6));
    }
}
