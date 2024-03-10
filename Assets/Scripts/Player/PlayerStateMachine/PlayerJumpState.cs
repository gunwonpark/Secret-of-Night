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
        stateMachine.Player.ForceReceiver.AddForce(new Vector3(stateMachine.MovementInput.x, 0, stateMachine.MovementInput.y)
            * stateMachine.MovementSpeedModifier);
        StartAnimation(stateMachine.Player.AnimationData.JumpParameter);
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.Player.ForceReceiver.Reset();
        StopAnimation(stateMachine.Player.AnimationData.JumpParameter);
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.Player.Controller.isGrounded)
        {
            Debug.Log("HI");
            stateMachine.IsJumping = false;
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
}