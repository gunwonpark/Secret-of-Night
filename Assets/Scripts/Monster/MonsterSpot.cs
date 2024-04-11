using UnityEngine;



public class MonsterSpot : MonoBehaviour
{
    public MonsterManager manager;
    public SpawnData spawnData;
    public MonsterInfo monsterInfo;

    int monsterNumber;
    int maxMonsterNumber = 10;

    public void Initialize(MonsterManager manager, SpawnData spawnData)
    {
        this.manager = manager;
        this.spawnData = spawnData;

        transform.position = spawnData.spotVector;
    }

    private void Start()
    {
        //SpawnAllMonster();
    }

    public void SpawnAllMonster()
    {
        if (monsterNumber <= maxMonsterNumber)
        {
            for (int i = 0; i <= spawnData.MonsterID.Length; i++)
            {
                int ID = spawnData.MonsterID[i];

                monsterInfo = manager.monsterData.monsterDatabase.GetMonsterInfoByKey(ID);//몬스터 정보 불러오기
                Vector3 spawnPoint = GetRandomPointInCircle(spawnData.spotVector, spawnData.Radius);
                spawnPoint.y = spawnData.spotVector.y;
                GameObject go = Instantiate(monsterInfo.prefab, spawnPoint, Quaternion.identity);
                monsterNumber++;

                FieldMonsters fieldMonster = go.GetComponent<FieldMonsters>();
                fieldMonster.SetPosition(spawnPoint);//포지션 전달
                fieldMonster.Init(monsterInfo);

                fieldMonster.circlePosition = transform.position;
                fieldMonster.circleRadius = spawnData.Radius;

                Debug.Log(monsterNumber);
                Debug.Log(spawnPoint);
            }
        }
    }

    public Vector3 GetRandomPointInCircle(Vector3 center, float radius)//랜덤한 스폰지점
    {
        //[todo]랜덤지점에 뭐가 없을때만 반환
        float angle = Random.Range(0f, Mathf.PI * 2f); // 랜덤한 각도 생성
        float distance = Mathf.Sqrt(Random.Range(0f, 1f)) * radius; // 랜덤한 거리 생성
        float x = center.x + distance * Mathf.Cos(angle); // x 좌표 계산
        float z = center.z + distance * Mathf.Sin(angle); // z 좌표 계산
        return new Vector3(x, center.y, z); // 랜덤 지점 반환
    }
}
