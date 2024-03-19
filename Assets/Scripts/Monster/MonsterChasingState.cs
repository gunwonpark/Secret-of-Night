public class MonsterChasingState : MonsterBaseState
{
    public MonsterChasingState(MonsterStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        monsterStateMachine.MovementSpeedModifier = 1;

        monsterStateMachine.FieldMonsters.monsterAnimation.StartRunAnimation();
    }

    public override void Exit()
    {
        base.Exit();

        monsterStateMachine.FieldMonsters.monsterAnimation.StopRunAnimation();
    }

    public override void Update()
    {
        base.Update();

        Move();

        if (!IsInChaseRange())
        {
            //[todo]원래위치로 돌아가는 코드

            monsterStateMachine.ChangeState(monsterStateMachine.IdleState);
            return;
        }
        else if (IsInAttackRange())
        {
            monsterStateMachine.ChangeState(monsterStateMachine.AttackState);
            return;
        }
    }

    private bool IsInAttackRange()//v
    {
        // if (stateMachine.Target.IsDead) { return false; }

        float playerDistanceSqr = (monsterStateMachine.Target.transform.position - monsterStateMachine.FieldMonsters.transform.position).sqrMagnitude;
        return playerDistanceSqr <= monsterStateMachine.FieldMonsters.myInfo.Range * monsterStateMachine.FieldMonsters.myInfo.Range;
    }


}
