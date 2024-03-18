public class MonsterIdleState : MonsterBaseState
{

    public MonsterIdleState(MonsterStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();

        monsterStateMachine.MovementSpeedModifier = 0f;

        monsterStateMachine.FieldMonsters.monsterAnimation.StartIdleAnimation();
    }

    public override void Exit()
    {
        base.Exit();

        monsterStateMachine.FieldMonsters.monsterAnimation.StopIdleAnimation();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void PhysicsUpdate()
    {

    }

    //�ִϸ��̼�
    //protected void StartAnimation(int animationHash)
    //{
    //    stateMachine.FieldMonsters.Animator.SetBool(animationHash, true);
    //}

    //protected void StopAnimation(int animationHash)
    //{
    //    stateMachine.FieldMonsters.Animator.SetBool(animationHash, false);
    //}

    //protected float GetNormalizedTime(Animator animator, string tag)
    //{
    //    AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
    //    AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);

    //    if (animator.IsInTransition(0) && nextInfo.IsTag(tag))
    //    {
    //        return nextInfo.normalizedTime;
    //    }
    //    else if (!animator.IsInTransition(0) && currentInfo.IsTag(tag))
    //    {
    //        return currentInfo.normalizedTime;
    //    }
    //    else
    //    {
    //        return 0f;
    //    }
    //}
}
