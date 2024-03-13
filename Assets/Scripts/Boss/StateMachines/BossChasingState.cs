using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChasingState : BossBaseState
{
    public BossChasingState(BossStateMachine BossStateMachine) : base(BossStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 1;
        base.Enter();
        StartAnimation(stateMachine.Boss.AnimationData.RunParameter);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Boss.AnimationData.RunParameter);
    }

    public override void Update()
    {
        base.Update();
        Debug.Log(IsInAttackRange());
        if (!IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.IdlingState);
            return;
        }
        else if (IsInAttackRange())
        {
            stateMachine.ChangeState(stateMachine.AttackState);
            return;
        }
    }

    private bool IsInAttackRange()
    {
        // if (stateMachine.Target.IsDead) { return false; }
        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.Boss.transform.position).sqrMagnitude;
        return playerDistanceSqr <= stateMachine.Boss.Data.AttackRange * stateMachine.Boss.Data.AttackRange;
    }
}
