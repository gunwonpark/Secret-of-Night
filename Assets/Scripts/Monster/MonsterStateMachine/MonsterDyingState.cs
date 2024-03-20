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

        //destroy
    }

    void DeleteMonster()
    {

    }
}
