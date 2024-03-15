public class MonsterChasingState : MonsterIdleState
{
    public MonsterChasingState(MonsterStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 1;
        base.Enter();
        //애니메이션
        //StartAnimation(stateMachine.Enemy.AnimationData.GroundParameterHash);
        //StartAnimation(stateMachine.Enemy.AnimationData.RunParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        //애니메이션
        //StopAnimation(stateMachine.Enemy.AnimationData.GroundParameterHash);
        //StopAnimation(stateMachine.Enemy.AnimationData.RunParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (!IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.IdleState);
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

        return playerDistanceSqr <= stateMachine.FieldMonsters.myInfo.Range * stateMachine.FieldMonsters.myInfo.Range;
    }


}
