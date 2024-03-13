using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossBaseState
{
    public BossAttackState(BossStateMachine BossStateMachine) : base(BossStateMachine)
    {
    }
    private bool alreadyAppliedForce;
    private bool alreadyAppliedDealing;
    public override void Enter()
    {
        alreadyAppliedForce = false;
        alreadyAppliedDealing = false;

        stateMachine.MovementSpeedModifier = 0;
        base.Enter();
        StartAnimation(stateMachine.Boss.AnimationData.AttackParameter);        
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Boss.AnimationData.AttackParameter);        
    }

    public override void Update()
    {
        base.Update();

        ForceMove();

        float normalizedTime = GetNormalizedTime(stateMachine.Boss.Animator, "Attack");
        if (normalizedTime < 1f)
        {
            Debug.Log("Attack");
			if (normalizedTime >= stateMachine.Boss.Data.ForceTransitionTime)
				TryApplyForce();

			//if (!alreadyAppliedDealing && normalizedTime >= stateMachine.Boss.Data.Dealing_Start_TransitionTime)
			//{
			//    stateMachine.Boss.Weapon.SetAttack(stateMachine.Boss.Data.Damage, stateMachine.Boss.Data.Force);
			//    stateMachine.Boss.Weapon.gameObject.SetActive(true);
			//    alreadyAppliedDealing = true;
			//}
			//if (alreadyAppliedDealing && normalizedTime >= stateMachine.Boss.Data.Dealing_End_TransitionTime)
			//{
			//    stateMachine.Boss.Weapon.gameObject.SetActive(false);
			//}
		}
        else
        {
            Debug.Log("hi");
            if (IsInChaseRange())
            {
                Debug.Log("changestate");
                stateMachine.ChangeState(stateMachine.ChasingState);
                return;
            }
            else
            {
                stateMachine.ChangeState(stateMachine.IdlingState);
                return;
            }
        }
    }
    private void TryApplyForce()
    {
        if (alreadyAppliedForce) return;
        alreadyAppliedForce = true;

        stateMachine.Boss.ForceReceiver.Reset();

        stateMachine.Boss.ForceReceiver.AddForce(stateMachine.Boss.transform.forward * stateMachine.Boss.Data.Force);
    }
}
