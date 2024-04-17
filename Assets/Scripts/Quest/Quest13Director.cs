using UnityEngine;
using UnityEngine.AI;

public class Quest13Director : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform targetPos;
    public Transform homePos;
    private MonsterInfo monsterInfo;
    private int maxCount = 1;
    private int CameleonMaxCount = 10;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (QuestManager.I.currentQuest.QuestID == 1012)
        {
            if (DialogueHandler.I.dialogueIndex == 2)
            {
                agent.SetDestination(targetPos.position);
                for (int i = 0; i < maxCount; i++)
                {
                    QuestSpawnMonster();
                    maxCount--;
                }

            }
        }
        else if (QuestManager.I.currentQuest.QuestID == 1014)
        {
            agent.SetDestination(homePos.position);
        }
    }

    public void QuestSpawnMonster()
    {
        monsterInfo = GameManager.Instance.monsterManager.monsterData.monsterDatabase.GetMonsterInfoByKey(10);
        GameObject go = Instantiate(monsterInfo.prefab, new Vector3(-61.29049f, 1.010074f, 81.39434f), Quaternion.identity);

        FieldMonsters fieldMonsters = go.GetComponent<FieldMonsters>();

        fieldMonsters.Init(monsterInfo);
    }
}
