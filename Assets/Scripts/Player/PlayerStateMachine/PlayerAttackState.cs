// TODO 공격 모션 수정 요망

using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    private Animator ani;
    private int aniComboCount = 0;
    public PlayerAttackState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
        ani = stateMachine.Player.Animator;
    }
    public override void Enter()
    {
        base.Enter();
        lockRotation = true;
        stateMachine.Player.MovementSpeedModifier = 0f;
        aniComboCount = 1;
        stateMachine.Player.Animator.SetInteger(stateMachine.Player.AnimationData.Combo, aniComboCount);
    }

    public override void Exit()
    {
        base.Exit();
        lockRotation = false;
        aniComboCount = 0;
        stateMachine.Player.Animator.SetInteger(stateMachine.Player.AnimationData.Combo, aniComboCount);
        StopAnimation(stateMachine.Player.AnimationData.AttackParameter);
    }

    public override void Update()
    {
        base.Update();

        AnimatorStateInfo stateInfo = stateMachine.Player.Animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsTag("Attack"))
        {
            if (stateInfo.normalizedTime > 0.8f)
            {
                if (ani.IsInTransition(0))
                {
                    return;
                }
                stateMachine.ChangeState(stateMachine.IdleState);
            }
        }
        if (stateMachine.Player.IsAttacking)
        {
            if (stateInfo.normalizedTime > 0.5f)
            {
                if (ani.IsInTransition(0))
                    return;

                ++aniComboCount;
                stateMachine.Player.Animator.SetInteger(stateMachine.Player.AnimationData.Combo, aniComboCount);
            }
        }
    }
}
