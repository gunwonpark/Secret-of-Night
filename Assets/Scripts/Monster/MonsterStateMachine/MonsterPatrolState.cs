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
        //Patrol();
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

        newMovePosition.y = 0f;
        currentPosition.y = 0f;

        float distance = (currentPosition - newMovePosition).sqrMagnitude;

        //원래 포지션으로 가면 -> idle State로 바꿈
        if (distance <= 0.5f)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }



    //private void Patrol()
    //{
    //    Move();
    //    Vector3 PatrolPosition = stateMachine.FieldMonsters.GetNewMovePoint();
    //    Vector3 currentPosition = stateMachine.FieldMonsters.transform.position;

    //    float distance = (currentPosition - PatrolPosition).sqrMagnitude;
    //}

}
