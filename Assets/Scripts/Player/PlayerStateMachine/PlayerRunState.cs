using UnityEngine;



public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.MovementSpeedModifier = stateMachine.runSpeed;
        if (stateMachine.MovementInput != Vector2.zero)
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
        if (stateMachine.MovementInput == Vector2.zero)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        else if (!stateMachine.IsRunning)
        {
            stateMachine.ChangeState(stateMachine.WalkState);
        }
    }

}
