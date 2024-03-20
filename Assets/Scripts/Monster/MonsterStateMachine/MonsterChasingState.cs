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

    }

    public override void Exit()
    {
        base.Exit();

        stateMachine.FieldMonsters.monsterAnimation.StopRunAnimation();

    }

    public override void Update()
    {
        base.Update();

        Move();

        if (!IsInChaseRange())
        {
            //[todo]원래위치로 돌아가는 코드
            //돌아가는 state를 만들어서 position을 원래위치로 잡고 그쪽으로 이동
            //이동이 끝나면  IdleState

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
        return playerDistanceSqr <= stateMachine.FieldMonsters.myInfo.Range * stateMachine.FieldMonsters.myInfo.Range;
    }

    private void BackToTheOriginalPosition()
    {

    }

}
