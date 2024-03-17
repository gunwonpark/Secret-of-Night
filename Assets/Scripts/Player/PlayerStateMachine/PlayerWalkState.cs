using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public PlayerWalkState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.Player.MovementSpeedModifier = stateMachine.Player.walkSpeed;
        StartAnimation(stateMachine.Player.AnimationData.WalkParameter);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.WalkParameter);
    }
    public override void Update()
    {
        base.Update();
        if (stateMachine.Player.IsAttacking)
        {
            stateMachine.ChangeState(stateMachine.AttackState);
            return;
        }
        if (stateMachine.MovementInput == Vector2.zero)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        else if (stateMachine.Player.IsRunning)
        {
            stateMachine.ChangeState(stateMachine.RunState);
        }
    }
}
