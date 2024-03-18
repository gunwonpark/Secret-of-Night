using UnityEngine;

public class MonsterBaseState : IState
{
    protected MonsterStateMachine monsterStateMachine;

    public MonsterBaseState(MonsterStateMachine stateMachine)
    {
        monsterStateMachine = stateMachine;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void HandleInput()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    //애니메이션
    protected void StartAnimation(int animationHash)
    {
        monsterStateMachine.FieldMonsters.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        monsterStateMachine.FieldMonsters.Animator.SetBool(animationHash, false);
    }

    protected void Move()//v
    {
        Vector3 movementDirection = GetMovementDirection();

        Rotate(movementDirection);
        Move(movementDirection);
    }

    protected void ForceMove()//네브메쉬로 수정 고려
    {
        monsterStateMachine.FieldMonsters.controller.Move(monsterStateMachine.FieldMonsters.forceReceiver.Movement * Time.deltaTime);
    }


    private void Move(Vector3 direction)//v
    {
        float movementSpeed = GetMovementSpeed();
        monsterStateMachine.FieldMonsters.controller.Move(((direction * movementSpeed) + monsterStateMachine.FieldMonsters.forceReceiver.Movement) * Time.deltaTime);
    }

    private void Rotate(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            direction.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            monsterStateMachine.FieldMonsters.transform.rotation = Quaternion.Slerp(monsterStateMachine.FieldMonsters.transform.rotation, targetRotation, monsterStateMachine.rotationDamping * Time.deltaTime);
        }
    }

    private Vector3 GetMovementDirection()//v
    {
        return (monsterStateMachine.Target.transform.position - monsterStateMachine.FieldMonsters.transform.position).normalized;
    }

    private float GetMovementSpeed()//v
    {
        float movementSpeed = monsterStateMachine.MovementSpeed * monsterStateMachine.MovementSpeedModifier;

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
        float playerDistanceSqr = (monsterStateMachine.Target.transform.position - monsterStateMachine.FieldMonsters.transform.position).sqrMagnitude;

        return playerDistanceSqr <= monsterStateMachine.FieldMonsters.targetRange * monsterStateMachine.FieldMonsters.targetRange;
    }
}
