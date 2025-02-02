public class MonsterChasingState : MonsterBaseState
{
    public MonsterChasingState(MonsterStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();

        stateMachine.MovementSpeedModifier = 1;
        stateMachine.FieldMonsters.monsterAnimation.StartRunAnimation();
        stateMachine.FieldMonsters.OnCaution();
    }

    public override void Exit()
    {
        base.Exit();

        stateMachine.FieldMonsters.monsterAnimation.StopRunAnimation();
        stateMachine.FieldMonsters.OffCaution();
    }

    public override void Update()
    {
        base.Update();

        Move();

        if (!IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.PatrolState);
            return;
        }
        else if (IsInAttackRange())
        {
            stateMachine.ChangeState(stateMachine.AttackState);
            return;
        }
    }

    private bool IsInAttackRange()//v
    {
        // if (stateMachine.Target.IsDead) { return false; }

        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.FieldMonsters.transform.position).sqrMagnitude;
        return playerDistanceSqr <= stateMachine.FieldMonsters.myInfo.AtkRange * stateMachine.FieldMonsters.myInfo.AtkRange;
    }
}
