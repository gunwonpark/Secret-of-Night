using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public PlayerWalkState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.MovementSpeedModifier = stateMachine.walkSpeed;
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
        if (stateMachine.MovementInput == Vector2.zero)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        else if (stateMachine.IsRunning)
        {
            stateMachine.ChangeState(stateMachine.RunState);
        }
    }
}
