using UnityEngine;

public class MonsterPatrolState : MonsterBaseState
{
    public MonsterPatrolState(MonsterStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.MovementSpeedModifier = 0.5f;
        stateMachine.patrolPosition = stateMachine.FieldMonsters.GetNewMovePoint();
        stateMachine.FieldMonsters.monsterAnimation.StartWalkAnimation();
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.patrolPosition = Vector3.zero;
        stateMachine.FieldMonsters.monsterAnimation.StopWalkAnimation();
    }

    public override void Update()
    {
        base.Update();
        IsInMyPosition();
    }

    private void IsInMyPosition()
    {
        Move();
        Vector3 newMovePosition = stateMachine.patrolPosition;
        Vector3 currentPosition = stateMachine.FieldMonsters.transform.position;
        Vector3 moveDirection = (newMovePosition - currentPosition).normalized;
        bool isObstacle = IsObstacle(currentPosition, moveDirection);

        newMovePosition.y = 0f;
        currentPosition.y = 0f;

        float distance = (currentPosition - newMovePosition).sqrMagnitude;

        //원래 포지션으로 가면 -> idle State로 바꿈
        if (distance <= 0.5f || isObstacle)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }

    public LayerMask obstacle;

    private bool IsObstacle(Vector3 point, Vector3 direction)
    {
        RaycastHit hit;
        Debug.DrawRay(point, direction * 1.5f, Color.red);

        //레이로 쏜 곳에 다른 오브젝트가 있으면 true
        if (Physics.Raycast(point, direction, 1.5f, LayerMask.GetMask("obstacle"))/* || Physics.Raycast(point, direction, 1.5f, LayerMask.GetMask("Monster"))*/)
        {
            return true;
        }
        return false;
    }
}
