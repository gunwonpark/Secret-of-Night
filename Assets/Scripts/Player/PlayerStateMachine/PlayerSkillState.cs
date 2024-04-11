public class PlayerSkillState : PlayerBaseState
{
    public PlayerSkillState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.Player.MovementSpeedModifier = 0f;

        //Object.Instantiate(GameManager.Instance.playerManager.GetSkillEffect(skillKey + 100),stateMachine.Player.transform.position + Vector3.up, stateMachine.Player.transform.rotation);

        StartAnimation(stateMachine.Player.AnimationData.Skill1);
    }
    public override void Exit()
    {
        base.Exit();
        stateMachine.Player.DoSkill = false;
        StopAnimation(stateMachine.Player.AnimationData.Skill1);
    }
    public override void Update()
    {
        base.Update();
        float normalizedTime = GetNormalizedTime(stateMachine.Player.Animator, "Skill");

        if (normalizedTime > 1f)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
}
