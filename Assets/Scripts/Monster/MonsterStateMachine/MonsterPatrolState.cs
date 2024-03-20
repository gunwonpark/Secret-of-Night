public class MonsterPatrolState : MonsterBaseState
{
    public MonsterPatrolState(MonsterStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.MovementSpeedModifier = 0.5f;
        stateMachine.FieldMonsters.monsterAnimation.StartWalkAnimation();
        //기존타겟포지션 저장
        //Vector3 targetPosition = stateMachine.Target.position;
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.FieldMonsters.monsterAnimation.StopWalkAnimation();
        //기존타겟포지션 다시 넣어둠
    }

    public override void Update()
    {
        base.Update();
        Move();

        //원래 포지션으로 가면 -> idle State로 바꿈
    }

}
