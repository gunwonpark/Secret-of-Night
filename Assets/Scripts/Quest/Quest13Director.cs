using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Quest13Director : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform targetPos;       
    private MonsterInfo monsterInfo;
    private int maxCount = 1;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();       
    }

    private void Update()
    {
        if(QuestManager.I.currentQuest.QuestID == 1012)
        {
            if (DialogueHandler.I.dialogueIndex == 2)
            {
                agent.SetDestination(targetPos.position);
                //for (int i = 0; i < maxCount; i++)
                //{
                //    SpawnMonster();
                //    maxCount--;
                //}
                
            }
        }          
    }

    //public void SpawnMonster()
    //{
    //    monsterInfo = GameManager.Instance.monsterManager.monsterData.monsterDatabase.GetMonsterInfoByKey(10);
    //    GameObject go = Instantiate(monsterInfo.prefab, new Vector3(-61.29049f, 1.010074f, 81.39434f), Quaternion.identity);

    //    FieldMonsters fieldMonsters = go.GetComponent<FieldMonsters>();

    //    fieldMonsters.Init(monsterInfo);
    //}
}
