using UnityEngine;

public abstract class StateMachine
{
    protected IState currentState;

    public void ChangeState(IState newState)
    {
        currentState?.Exit();
        Debug.Log("1");
        currentState = newState;
        Debug.Log(currentState);
        Debug.Log(newState);
        currentState?.Enter();
        Debug.Log("3");
    }

    public void HandleInput()
    {
        currentState?.HandleInput();
    }

    public void Update()
    {
        currentState?.Update();
    }

    public void PhysicsUpdate()
    {
        currentState?.PhysicsUpdate();
    }
}


