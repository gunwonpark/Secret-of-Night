using System;
using System.Numerics;

public class MonsterIdleState : IState
{

    protected MonsterStateMachine StateMachine;


    public void Enter()
    {

    }

    public void Exit()
    {

    }

    public void HandleInput()
    {

    }

    public void PhysicsUpdate()
    {

    }

    void IState.Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 movementDirection = GetMovementDirection();

        Rotate(movementDirection);
        Move(movementDirection);
    }


    private void Move(Vector3 Direction)
    {
        float movementSpeed = GetMovementSpeed();
    }

    private void Rotate(Vector3 Direction)
    {

    }

    private Vector3 GetMovementDirection()
    {
        throw new NotImplementedException();
    }

    private float GetMovementSpeed()
    {
        throw new NotImplementedException();
    }



}
