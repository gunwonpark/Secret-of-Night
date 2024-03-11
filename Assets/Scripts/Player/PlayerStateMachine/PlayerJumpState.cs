using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    private float _jumpForce = 4.0f;
    public PlayerJumpState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.Player.ForceReceiver.Jump(_jumpForce);
        Vector3 moveDirection = stateMachine.MainCameraTransform.right * stateMachine.MovementInput.x;
        moveDirection += stateMachine.MainCameraTransform.forward * stateMachine.MovementInput.y;
        moveDirection.y = 0;
        stateMachine.Player.ForceReceiver.AddForce(moveDirection * stateMachine.MovementSpeedModifier);
        StartAnimation(stateMachine.Player.AnimationData.JumpParameter);
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.Player.ForceReceiver.Reset();
        stateMachine.IsJumping = false;
        StopAnimation(stateMachine.Player.AnimationData.JumpParameter);
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.Player.Controller.isGrounded)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
}