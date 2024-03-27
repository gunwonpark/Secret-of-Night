using UnityEngine;

public class MonsterAttackState : MonsterBaseState
{
    private bool alreadyAppliedForce;

    public MonsterAttackState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.MovementSpeedModifier = 0;

        //stateMachine.FieldMonsters.monsterAnimation.StartAttackAnimation();//[todo]공격할때만

        stateMachine.FieldMonsters.OnAttack += NomalAttack;
    }

    public override void Exit()
    {
        base.Exit();

        stateMachine.FieldMonsters.monsterAnimation.StopAttackAnimation();

        stateMachine.FieldMonsters.OnAttack -= NomalAttack;
    }

    public override void Update()
    {
        base.Update();
        //공격함수

        if (stateMachine.FieldMonsters.myInfo.AtkStance == false)//false가 0, true가 1
        {
            if (IsInChaseRange())
            {
                stateMachine.ChangeState(stateMachine.ChasingState);
                return;
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        ForceMove();

        float normalizedTime = 0.1f;/*GetNormalizedTime(stateMachine.Enemy.Animator, "Attack");*/
        if (normalizedTime < 1f)
        {
            if (normalizedTime >= 0 /*stateMachine.FieldMonsters.Data.ForceTransitionTime*/)
                TryApplyForce();
        }
        else
        {
            if (IsInChaseRange())
            {
                stateMachine.ChangeState(stateMachine.ChasingState);
                return;
            }
            else
            {
                stateMachine.ChangeState(stateMachine.PatrolState);
                return;
            }
        }
    }

    private void TryApplyForce()
    {
        if (alreadyAppliedForce) return;
        alreadyAppliedForce = true;

        //stateMachine.FieldMonsters.ForceReceiver.Reset();

        //stateMachine.Enemy.ForceReceiver.AddForce(stateMachine.Enemy.transform.forward * stateMachine.Enemy.Data.Force);

    }

    public void NomalAttack(GameObject other)
    {
        stateMachine.FieldMonsters.monsterAnimation.StartAttackAnimation();

        other.TryGetComponent<IDamageable>(out IDamageable go);

        Debug.Log(stateMachine.FieldMonsters.myInfo.Damage);
        go.TakeDamage(stateMachine.FieldMonsters.myInfo.Damage);
    }
}
