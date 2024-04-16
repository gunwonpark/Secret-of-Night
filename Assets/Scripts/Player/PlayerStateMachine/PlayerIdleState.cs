using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.Player.MovementSpeedModifier = 0f;

        //TODO SceneType에 따라 어떤 Idle 상태인지 결정

        StartAnimation(stateMachine.Player.AnimationData.IdleParameter);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.IdleParameter);
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.Player.IsAttacking)
        {
            stateMachine.ChangeState(stateMachine.AttackState);
            return;
        }
        if (stateMachine.MovementInput != Vector2.zero)
        {
            stateMachine.ChangeState(stateMachine.WalkState);
            return;
        }
    }
}
