using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    //public GameObject movePositionObject;
    MonsterDataBase monsterData;

    List<Transform> spawnSpotPosition = new List<Transform>();

    private void Start()
    {
        // movePositionObject = GetComponentsInChildren<Transform>;


        int spawnSpotNum = gameObject.transform.childCount;

        for (int i = 0; i < spawnSpotNum; i++)
        {
            Debug.Log("이름: " + gameObject.transform.GetChild(i).name);
            Debug.Log("포지션: " + gameObject.transform.GetChild(i).transform.position);
            Debug.Log("-------------------");

            spawnSpotPosition.Add(transform.GetChild(i));
        }

        //몬스터인포기준으로 생성


    }

    private void SpawnMonster()
    {

    }
}
