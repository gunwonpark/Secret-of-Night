public class MonsterAttackState : MonsterIdleState
{
    private bool alreadyAppliedForce;

    public MonsterAttackState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0;
        base.Enter();
        //StartAnimation(stateMachine.Enemy.AnimationData.AttackParameterHash);
        //StartAnimation(stateMachine.Enemy.AnimationData.BaseAttackParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        //StopAnimation(stateMachine.Enemy.AnimationData.AttackParameterHash);
        //StopAnimation(stateMachine.Enemy.AnimationData.BaseAttackParameterHash);

    }

    public override void Update()
    {
        base.Update();

        ForceMove();

        float normalizedTime = 0;/*GetNormalizedTime(stateMachine.Enemy.Animator, "Attack");*/
        if (normalizedTime < 1f)
        {
            if (normalizedTime >= 0 /*stateMachine.FieldMonsters.Data.ForceTransitionTime*/)
                TryApplyForce();

        }
        else
        {
            if (IsInChaseRange())
            {
                stateMachine.ChangeState(stateMachine.ChasingState);
                return;
            }
            else
            {
                stateMachine.ChangeState(stateMachine.IdleState);
                return;
            }
        }

    }

    private void TryApplyForce()
    {
        if (alreadyAppliedForce) return;
        alreadyAppliedForce = true;

        //stateMachine.Enemy.ForceReceiver.Reset();

        //stateMachine.Enemy.ForceReceiver.AddForce(stateMachine.Enemy.transform.forward * stateMachine.Enemy.Data.Force);

    }

}
