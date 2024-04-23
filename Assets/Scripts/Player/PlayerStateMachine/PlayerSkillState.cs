using UnityEngine;

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
        StartAnimation(stateMachine.Player.AnimationData.Skill2);
    }
    public override void Exit()
    {
        base.Exit();
        stateMachine.Player.DoSkill = false;
        lockRotation = false;
        StopAnimation(stateMachine.Player.AnimationData.Skill2);
    }
    public override void Update()
    {
        base.Update();
        AnimatorStateInfo stateInfo = stateMachine.Player.Animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsTag("Skill"))
        {
            if (stateInfo.normalizedTime > 0.8f)
            {
                stateMachine.ChangeState(stateMachine.IdleState);
            }
        }
    }
}
