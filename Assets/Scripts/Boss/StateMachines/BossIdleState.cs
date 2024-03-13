using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : BossBaseState
{
    public BossIdleState(BossStateMachine BossStateMachine) : base(BossStateMachine)
    {
    }
    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0f;

        base.Enter();
        //StartAnimation(stateMachine.Boss.AnimationData.GroundParameterHash);
        StartAnimation(stateMachine.Boss.AnimationData.IdleParameter);
    }

    public override void Exit()
    {
        base.Exit();
        //StopAnimation(stateMachine.Boss.AnimationData.GroundParameterHash);
        StopAnimation(stateMachine.Boss.AnimationData.IdleParameter);
    }

    public override void Update()
    {
        if (IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.ChasingState);
            return;
        }
    }
}
