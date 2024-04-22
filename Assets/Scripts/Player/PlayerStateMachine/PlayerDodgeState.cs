public class PlayerDodgeState : PlayerBaseState
{


    public PlayerDodgeState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        AddDodgeForce();
        stateMachine.Player.Animator.SetTrigger(stateMachine.Player.AnimationData.DodgeParameter);
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.Player.IsDodgeing = false;
        stateMachine.Player.ForceReceiver.Reset();

    }
    public override void Update()
    {
        base.Update();
        float normalizedTime = GetNormalizedTime(stateMachine.Player.Animator, "Dodge");
        if (normalizedTime >= 0.5f)
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
