public class MonsterAttackState : MonsterBaseState
{
    private bool alreadyAppliedForce;

    public MonsterAttackState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        monsterStateMachine.MovementSpeedModifier = 0;

        monsterStateMachine.FieldMonsters.monsterAnimation.StartAttackAnimation();
    }

    public override void Exit()
    {
        base.Exit();

        monsterStateMachine.FieldMonsters.monsterAnimation.StopAttackAnimation();
    }

    public override void Update()
    {
        base.Update();


    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        ForceMove();

        float normalizedTime = 0.1f;/*GetNormalizedTime(stateMachine.Enemy.Animator, "Attack");*/
        if (normalizedTime < 1f)
        {
            if (normalizedTime >= 0 /*stateMachine.FieldMonsters.Data.ForceTransitionTime*/)
                TryApplyForce();
        }
        else
        {
            if (IsInChaseRange())
            {
                monsterStateMachine.ChangeState(monsterStateMachine.ChasingState);
                return;
            }
            else
            {
                monsterStateMachine.ChangeState(monsterStateMachine.IdleState);
                return;
            }
        }
    }

    private void TryApplyForce()
    {
        if (alreadyAppliedForce) return;
        alreadyAppliedForce = true;

        //stateMachine.FieldMonsters.ForceReceiver.Reset();

        //stateMachine.Enemy.ForceReceiver.AddForce(stateMachine.Enemy.transform.forward * stateMachine.Enemy.Data.Force);

    }

}
