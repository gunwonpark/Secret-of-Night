public class MonsterDyingState : MonsterBaseState
{

    public MonsterDyingState(MonsterStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        monsterStateMachine.MovementSpeedModifier = 0;

        monsterStateMachine.FieldMonsters.monsterAnimation.StartDieAnimation();


    }

    public override void Exit()
    {
        base.Exit();

        //destroy
    }
}
