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
        stateMachine.FieldMonsters.monsterAnimation.StartWalkAnimation();
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.FieldMonsters.monsterAnimation.StopWalkAnimation();
    }

    public override void Update()
    {
        base.Update();
        IsInMyPosition();
        //원래 포지션으로 가면 -> idle State로 바꿈
    }

    private void IsInMyPosition()
    {
        Move();
        Vector3 myOriginalPosition = stateMachine.FieldMonsters.originalPosition;
        Vector3 currentPosition = stateMachine.FieldMonsters.transform.position;

        float distance = (currentPosition - myOriginalPosition).sqrMagnitude;

        if (distance <= 0.5f)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
}