public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        AddJumpForce();
        StartAnimation(stateMachine.Player.AnimationData.JumpParameter);
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.Player.ForceReceiver.Reset();
        stateMachine.Player.IsJumping = false;
        StopAnimation(stateMachine.Player.AnimationData.JumpParameter);
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.Player.IsGrounded && stateMachine.Player.ForceReceiver.Movement.y < 0f)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
    private void AddJumpForce()
    {
        stateMachine.Player.ForceReceiver.Jump(stateMachine.Player.jumpForce);
        stateMachine.Player.ForceReceiver.AddForce(stateMachine.Player.transform.forward * GetMovementSpeed());
    }
}