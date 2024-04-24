public class PlayerSkillState : PlayerBaseState
{
    public PlayerSkillState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.Player.MovementSpeedModifier = 0f;
        lockRotation = true;
        StartAnimation(stateMachine.Player.AnimationData.Skill1);
    }
    public override void Exit()
    {
        base.Exit();
        stateMachine.Player.DoSkill = false;
        lockRotation = false;
        StopAnimation(stateMachine.Player.AnimationData.Skill1);
    }
    public override void Update()
    {
        base.Update();
        float normalizedTime = GetNormalizedTime(stateMachine.Player.Animator, "Skill");

        if (normalizedTime > 0.5f)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
}
