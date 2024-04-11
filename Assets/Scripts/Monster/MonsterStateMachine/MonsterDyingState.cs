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
        stateMachine.FieldMonsters.DropData();

        QuestManager.I.CheckCount(stateMachine.FieldMonsters.myInfo.MonsterID);
    }
}
