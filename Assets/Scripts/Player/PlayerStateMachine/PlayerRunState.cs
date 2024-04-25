using UnityEngine;



public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.Player.MovementSpeedModifier = stateMachine.Player.runSpeed;
        StartAnimation(stateMachine.Player.AnimationData.RunParameter);
    }
    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.RunParameter);
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
            return;
        }
        else if (!stateMachine.Player.IsRunning)
        {
            stateMachine.ChangeState(stateMachine.WalkState);
            return;
        }
        if (stateMachine.Player.IsGrounded && stateMachine.Player.IsJumping == true)
        {
            stateMachine.ChangeState(stateMachine.JumpState);
        }
    }
}
