using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class QuestSpawner : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform targetPos;
    public Transform homePos;
    private MonsterInfo monsterInfo;
    private int maxCount = 1;
    
    private Animator animator;
    private GameObject laser;
    private GameObject buggubugguCircle;
    private GameObject hihiCircle;
    private GameObject laser2;
    private List<int> count = new List<int>();


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        count.Add(1);
        for (int i = 0; i < 15; i++)
        {
            count.Add(1);
        }
    }

    private void Update()
    {
        if (QuestManager.I.currentQuest.QuestID == 1013)
        {
            if (DialogueHandler.I.dialogueIndex == 3)
            {
                agent.SetDestination(targetPos.position);
                animator.SetBool("isWalk", true);
            }
        }
        else if (QuestManager.I.currentQuest.QuestID == 1014)
        {
            for (int i = 0; i < maxCount; i++)
            {
                maxCount--;
                QuestSpawnMonster();
            }
        }

        else if (QuestManager.I.currentQuest.QuestID == 1015)
        {
            agent.SetDestination(homePos.position);
        }
        QuestItemSpawner();
    }

    public void QuestSpawnMonster()
    {
        monsterInfo = GameManager.Instance.monsterManager.monsterData.monsterDatabase.GetMonsterInfoByKey(10);
        GameObject go = Instantiate(monsterInfo.prefab, new Vector3(-61.29049f, 1.010074f, 81.39434f), Quaternion.identity);

        FieldMonsters fieldMonsters = go.GetComponent<FieldMonsters>();

        fieldMonsters.Init(monsterInfo);
    }

    private void QuestItemSpawner()
    {
        if (QuestManager.I.currentQuest.QuestID == 1016)
        {

            for (int i = 0; i < count[0]; i++)
            {
                Instantiate(GameManager.Instance.dataManager.itemDataBase.GetData(29).Prefab, new Vector3(77.47961f, 3.13f, 92.70897f), Quaternion.identity);
                count[0]--;
            }
        }

        else if (QuestManager.I.currentQuest.QuestID == 1018)
        {

            for (int i = 0; i < count[1]; i++)
            {
                Instantiate(GameManager.Instance.dataManager.itemDataBase.GetData(30).Prefab, new Vector3(108.9168f, 14.5276f, 34.42586f), Quaternion.Euler(0f, 0f, 30.737f));
                laser = Instantiate(Resources.Load<GameObject>("Prefabs/effects/LaserAOE"), new Vector3(108.8186f, 2.581414f, 34.64442f), Quaternion.identity);
                count[1]--;
            }
        }

        else if (QuestManager.I.currentQuest.QuestID == 1019)
        {

            for (int i = 0; i < count[2]; i++)
            {
                Destroy(laser);
                buggubugguCircle = Instantiate(Resources.Load<GameObject>("Prefabs/effects/HealingCircle"), new Vector3(-5.54f, 0.6747813f, 119.67f), Quaternion.identity);
                count[2]--;
            }
        }

        else if (QuestManager.I.currentQuest.QuestID == 1020)
        {

            for (int i = 0; i < count[3]; i++)
            {
                Destroy(buggubugguCircle);
                count[3]--;
            }
        }

        else if (QuestManager.I.currentQuest.QuestID == 1029)
        {
            for (int i = 0; i < count[4]; i++)
            {
                Instantiate(GameManager.Instance.dataManager.itemDataBase.GetData(28).Prefab, new Vector3(4.59f, 0.71f, 118.44f), Quaternion.identity);
                count[4]--;
            }
        }

        else if (QuestManager.I.currentQuest.QuestID == 1032)
        {
            for (int i = 0; i < count[5]; i++)
            {
                Instantiate(GameManager.Instance.dataManager.itemDataBase.GetData(31).Prefab, new Vector3(134.5635f, 3.719132f, -35.13649f), Quaternion.identity);
                laser2 = Instantiate(Resources.Load<GameObject>("Prefabs/effects/LaserAOE"), new Vector3(134.5635f, 3.719132f, -35.13649f), Quaternion.identity);
                count[5]--;
            }
        }

        else if (QuestManager.I.currentQuest.QuestID == 1033)
        {
            for (int i = 0; i < count[6]; i++)
            {
                Destroy(laser2);

                count[6]--;
            }
        }

        else if (QuestManager.I.currentQuest.QuestID == 1040)
        {

            for (int i = 0; i < count[7]; i++)
            {
                Instantiate(Resources.Load<GameObject>("Prefabs/Quest/woods"), new Vector3(0f, 0f, 0f), Quaternion.identity);
                count[7]--;
            }
        }

        else if (QuestManager.I.currentQuest.QuestID == 1050)
        {

            for (int i = 0; i < count[8]; i++)
            {
                hihiCircle = Instantiate(Resources.Load<GameObject>("Prefabs/effects/HealingCircle"), new Vector3(-1.15f, 0.6747813f, 126.95f), Quaternion.identity);
                count[8]--;
            }
        }
        else if (QuestManager.I.currentQuest.QuestID == 1051)
        {

            for (int i = 0; i < count[9]; i++)
            {
                Destroy(hihiCircle);
                count[9]--;
            }
        }
    }
}
