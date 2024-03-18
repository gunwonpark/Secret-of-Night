public class MonsterIdleState : MonsterBaseState
{

    public MonsterIdleState(MonsterStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();

        monsterStateMachine.MovementSpeedModifier = 0f;

        monsterStateMachine.FieldMonsters.monsterAnimation.StartIdleAnimation();
    }

    public override void Exit()
    {
        base.Exit();

        monsterStateMachine.FieldMonsters.monsterAnimation.StopIdleAnimation();
    }

    public override void Update()
    {
        base.Update();

        if (IsInChaseRange())
        {
            monsterStateMachine.ChangeState(monsterStateMachine.ChasingState);
            return;
        }
    }

    public override void PhysicsUpdate()
    {

    }
}
