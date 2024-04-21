using UnityEngine;
using UnityEngine.AI;

public class QuestSpawner : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform targetPos;
    public Transform homePos;
    private MonsterInfo monsterInfo;
    private int maxCount = 1;
    private int danjiMaxCount = 1;
    private int moneyBackCount = 1;
    private Animator animator;
    

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (QuestManager.I.currentQuest.QuestID == 1012)
        {
            if (DialogueHandler.I.dialogueIndex == 2)
            {
                agent.SetDestination(targetPos.position);
                animator.SetBool("isWalk", true);
            }
        }
        else if (QuestManager.I.currentQuest.QuestID == 1013)
        {
            for (int i = 0; i < maxCount; i++)
            {
                maxCount--;
                QuestSpawnMonster();
            }            
        }

        else if (QuestManager.I.currentQuest.QuestID == 1014)
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
        if (QuestManager.I.currentQuest.QuestID == 1015)
        {
            for (int i = 0; i < danjiMaxCount; i++)
            {
                Instantiate(GameManager.Instance.dataManager.itemDataBase.GetData(29).Prefab, new Vector3(0.088769f, 1.571416f, 65.8601f), Quaternion.Euler(0f, 167.323f, 0f));
                danjiMaxCount--;
            }            
        }        

        if (QuestManager.I.currentQuest.QuestID == 1029)
        {
            for (int i = 0; i < moneyBackCount; i++)
            {
                Instantiate(GameManager.Instance.dataManager.itemDataBase.GetData(28).Prefab, new Vector3(4.59f, 0.71f, 118.44f), Quaternion.identity);
                moneyBackCount--;
            }            
        }
    }
}
