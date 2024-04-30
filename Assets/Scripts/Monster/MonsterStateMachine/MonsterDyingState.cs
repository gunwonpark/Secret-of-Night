using UnityEngine;

public class MonsterDyingState : MonsterBaseState
{

    public MonsterDyingState(MonsterStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.MovementSpeedModifier = 0;
        stateMachine.FieldMonsters.monsterAnimation.StartDieAnimation();

        DeleteMonster();
    }

    public override void Exit()
    {
        base.Exit();
    }

    private void DeleteMonster()
    {
        Object.Destroy(this.stateMachine.FieldMonsters.gameObject, 2f);

        if (stateMachine.FieldMonsters.myInfo.MonsterID != 10)
        {
            stateMachine.FieldMonsters.DropData();
            if (stateMachine.FieldMonsters.monsterSpot != null)
            {
                stateMachine.FieldMonsters.monsterSpot.Remove(stateMachine.FieldMonsters);
            }            
        }

        Debug.Log("죽음");
        if (QuestManager.I.currentQuest.QuestType == 1 || QuestManager.I.currentQuest.QuestType == 4)
        {
            QuestManager.I.CheckCount(stateMachine.FieldMonsters.myInfo.MonsterID);
        }
    }
}
