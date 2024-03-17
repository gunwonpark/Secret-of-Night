public class PlayerDodgeState : PlayerBaseState
{
    private float _dodgeHeihgt = 2.0f;
    private float _dodgeForce = -4.0f;
    private float _dodgeTime = 0.3f;
    private float _passedTime = 0.0f;
    public PlayerDodgeState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        _passedTime = 0;
        stateMachine.Player.ForceReceiver.Jump(_dodgeHeihgt);
        stateMachine.Player.ForceReceiver.AddForce(stateMachine.Player.transform.forward * _dodgeForce);
        StartAnimation(stateMachine.Player.AnimationData.DodgeParameter);
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.Player.IsDodgeing = false;
        stateMachine.Player.ForceReceiver.Reset();
        StopAnimation(stateMachine.Player.AnimationData.DodgeParameter);
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
}
