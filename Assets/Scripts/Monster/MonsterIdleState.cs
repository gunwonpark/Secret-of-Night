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

        if (IsInChaseRange())
        {
            monsterStateMachine.ChangeState(monsterStateMachine.ChasingState);
            return;
        }
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

    private void Move()//v
    {
        Vector3 movementDirection = GetMovementDirection();

        Rotate(movementDirection);
        Move(movementDirection);
    }

    protected void ForceMove()//�׺�޽��� ���� ����
    {
        stateMachine.FieldMonsters.controller.Move(stateMachine.FieldMonsters.forceReceiver.Movement * Time.deltaTime);
    }


    private void Move(Vector3 direction)//v
    {
        float movementSpeed = GetMovementSpeed();
        stateMachine.FieldMonsters.controller.Move(((direction * movementSpeed) + stateMachine.FieldMonsters.forceReceiver.Movement) * Time.deltaTime);
    }

    private void Rotate(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            direction.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            stateMachine.FieldMonsters.transform.rotation = Quaternion.Slerp(stateMachine.FieldMonsters.transform.rotation, targetRotation, stateMachine.rotationDamping * Time.deltaTime);
        }
    }

    private Vector3 GetMovementDirection()//v
    {
        //Debug.Log(stateMachine.Target.localPosition);
        //Debug.Log(stateMachine.Target.position);
        return (stateMachine.Target.transform.position - stateMachine.FieldMonsters.transform.position).normalized;
    }

    private float GetMovementSpeed()//v
    {
        float movementSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;

        return movementSpeed;
    }

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

    protected bool IsInChaseRange()//v
    {
        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.FieldMonsters.transform.position).sqrMagnitude;

        return playerDistanceSqr <= stateMachine.FieldMonsters.targetRange * stateMachine.FieldMonsters.targetRange;
    }
}
