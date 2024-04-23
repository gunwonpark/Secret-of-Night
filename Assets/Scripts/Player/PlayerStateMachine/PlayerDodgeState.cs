using UnityEngine;

public class PlayerDodgeState : PlayerBaseState
{


    public PlayerDodgeState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        AddDodgeForce();
        lockRotation = true;
        stateMachine.Player.Animator.SetTrigger(stateMachine.Player.AnimationData.DodgeParameter);
    }
    public override void Exit()
    {
        base.Exit();
        lockRotation = false;
        stateMachine.Player.IsDodgeing = false;
        stateMachine.Player.ForceReceiver.Reset();

    }
    public override void Update()
    {
        base.Update();
        AnimatorStateInfo info = stateMachine.Player.Animator.GetCurrentAnimatorStateInfo(0);
        if (info.IsTag("Dodge") && stateMachine.Player.Animator.IsInTransition(0))
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
    private void AddDodgeForce()
    {
        stateMachine.Player.ForceReceiver.Jump(stateMachine.Player.dodgeHeihgt);
        stateMachine.Player.ForceReceiver.AddForce(stateMachine.Player.transform.forward * stateMachine.Player.dodgeForce);
    }
}
