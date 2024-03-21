// TODO 공격 모션 수정 요망

public class PlayerAttackState : PlayerBaseState
{

    public PlayerAttackState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        stateMachine.Player.MovementSpeedModifier = 0f;
        StartAnimation(stateMachine.Player.AnimationData.AttackParameter);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.AttackParameter);
    }

    public override void Update()
    {
        base.Update();

        if (!stateMachine.Player.IsAttacking)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
}
