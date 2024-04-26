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
    private int buggubugguBodyMaxCount = 1;
    private int woodsMaxCount = 1;
    private int healingCircleCount = 1;
    private int hihiCircleCount = 1;
    private Animator animator;
    

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();        
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
            for (int i = 0; i < danjiMaxCount; i++)
            {
                Instantiate(GameManager.Instance.dataManager.itemDataBase.GetData(29).Prefab, new Vector3(77.47961f, 3.13f, 92.70897f), Quaternion.identity);
                danjiMaxCount--;
            }            
        }

        else if (QuestManager.I.currentQuest.QuestID == 1018)
        {
            for (int i = 0; i < buggubugguBodyMaxCount; i++)
            {
                Instantiate(GameManager.Instance.dataManager.itemDataBase.GetData(30).Prefab, new Vector3(108.9168f, 14.5276f, 34.42586f), Quaternion.Euler(0f, 0f, 30.737f));
                Instantiate(Resources.Load<GameObject>("Prefabs/effects/LaserAOE"), new Vector3(108.8186f, 2.581414f, 34.64442f), Quaternion.identity);
                buggubugguBodyMaxCount--;
            }
        }

        else if (QuestManager.I.currentQuest.QuestID == 1019)
        {
            for (int i = 0; i < healingCircleCount; i++)
            {                
                Instantiate(Resources.Load<GameObject>("Prefabs/effects/HealingCircle"), new Vector3(-5.54f, 0.6747813f, 119.67f), Quaternion.identity);
                healingCircleCount--;
            }
        }

        else if (QuestManager.I.currentQuest.QuestID == 1029)
        {
            for (int i = 0; i < moneyBackCount; i++)
            {
                Instantiate(GameManager.Instance.dataManager.itemDataBase.GetData(28).Prefab, new Vector3(4.59f, 0.71f, 118.44f), Quaternion.identity);
                moneyBackCount--;
            }            
        }

        else if (QuestManager.I.currentQuest.QuestID == 1040)
        {
            for(int i = 0;i < woodsMaxCount; i++)
            {                
                // Instantiate(prefab, new Vector3(0f,0f,0f), Quaternion.identity);
            }
        }

        else if (QuestManager.I.currentQuest.QuestID == 1050)
        {
            for (int i = 0; i < hihiCircleCount; i++)
            {
                Instantiate(Resources.Load<GameObject>("Prefabs/effects/HealingCircle"), new Vector3(-1.15f, 0.6747813f, 126.95f), Quaternion.identity);
                hihiCircleCount--;
            }
        }
    }
}
