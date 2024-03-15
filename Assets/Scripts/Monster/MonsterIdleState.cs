using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MonsterIdleState : IState
{
    protected MonsterStateMachine stateMachine;

    public MonsterIdleState(MonsterStateMachine monsterStateMachine)
    {
        stateMachine = monsterStateMachine;

    }

    public virtual void Enter()
    {
        stateMachine.MovementSpeedModifier = 1;

        //[추가] 애니메이션
    }

    public virtual void Exit()
    {
        //[추가] 애니메이션
    }

    public virtual void HandleInput()
    {

    }

    public virtual void Update()
    {

        if (IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.ChasingState);
            Debug.Log("chasing");
            Move();
            return;
        }
    }

    public virtual void PhysicsUpdate()
    {

    }

    //애니메이션

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

    protected void ForceMove()//네브메쉬로 수정 고려
    {
        stateMachine.FieldMonsters.controller.Move(stateMachine.FieldMonsters.forceReceiver.Movement * Time.deltaTime);
        Debug.Log("Attack");
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

            //stateMachine.FieldMonsters.transform.rotation = Quaternion.Slerp(stateMachine.FieldMonsters.transform.rotation, targetRotation, stateMachine.RotationDamping * Time.deltaTime);
        }
    }

    private Vector3 GetMovementDirection()//v
    {
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
