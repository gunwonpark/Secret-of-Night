using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    MonsterManager monsterManager;
    MonsterSpot[] spotPoint;

    Transform spot;

    // Start is called before the first frame update
    void Start()
    {
        monsterManager = GameManager.Instance.monsterManager;

        //내 자식들의 monsterSpot을 가져온다.
        spotPoint = GetComponentsInChildren<MonsterSpot>();


        for (int i = 0; i < spotPoint.Length; i++)
        {
            //이름 가져오기
            string name = spotPoint[i].monsterName;
            MonsterInfo monsterInfo = monsterManager.GetMonsterInfoByKey(name);

            spotPoint[i].MonsterSpawn(monsterInfo);



        }
    }



    // Update is called once per frame
    void Update()
    {

    }
}
