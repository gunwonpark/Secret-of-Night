public class MonsterIdleState : MonsterBaseState
{

    public MonsterIdleState(MonsterStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();

        stateMachine.MovementSpeedModifier = 0f;

        stateMachine.FieldMonsters.monsterAnimation.StartIdleAnimation();
    }

    public override void Exit()
    {
        base.Exit();

        stateMachine.FieldMonsters.monsterAnimation.StopIdleAnimation();
    }

    public override void Update()
    {
        base.Update();
        if (stateMachine.FieldMonsters.myInfo.MonsterID != 10)
        {
            stateMachine.ChangeState(stateMachine.PatrolState);
        }        
    }

    public override void PhysicsUpdate()
    {

    }
}
