using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine stateMachine;
    protected Vector3 jumpDirection = Vector3.zero;
    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        stateMachine = playerStateMachine;
    }
    public virtual void Enter()
    {
        AddPlayerActionCallbacks();
    }

    public virtual void Exit()
    {
        RemovePlayerActionCallbacks();
    }

    public virtual void HandleInput()
    {
        ReadMovementInput();
    }
    public virtual void PhysicsUpdate()
    {

    }
    public virtual void Update()
    {
        Move();
    }
    protected virtual void AddPlayerActionCallbacks()
    {
        stateMachine.Player.Input.PlayerActions.Movement.canceled += OnMovementCanceled;
        stateMachine.Player.Input.PlayerActions.Run.performed += OnRunStarted;
        stateMachine.Player.Input.PlayerActions.Run.canceled += OnRunCanceled;

        stateMachine.Player.Input.PlayerActions.Jump.started += OnJumpStarted;

        stateMachine.Player.Input.PlayerActions.Dodge.started += OnDodgeStarted;

        stateMachine.Player.Input.PlayerActions.Attack.performed += OnAttackPerformed;
        stateMachine.Player.Input.PlayerActions.Attack.canceled += OnAttackCanceled;
    }

    protected virtual void RemovePlayerActionCallbacks()
    {
        stateMachine.Player.Input.PlayerActions.Movement.canceled -= OnMovementCanceled;
        stateMachine.Player.Input.PlayerActions.Run.started -= OnRunStarted;
        stateMachine.Player.Input.PlayerActions.Run.canceled -= OnRunCanceled;

        stateMachine.Player.Input.PlayerActions.Jump.started -= OnJumpStarted;

        stateMachine.Player.Input.PlayerActions.Dodge.started -= OnDodgeStarted;

        stateMachine.Player.Input.PlayerActions.Attack.performed -= OnAttackPerformed;
        stateMachine.Player.Input.PlayerActions.Attack.canceled -= OnAttackCanceled;
    }
    #region addevent
    protected virtual void OnJumpStarted(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (stateMachine.Player.Controller.isGrounded && stateMachine.IsJumping == false)
        {
            stateMachine.IsJumping = true;
            stateMachine.ChangeState(stateMachine.JumpState);
        }
    }

    protected virtual void OnRunStarted(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        stateMachine.IsRunning = true;
    }

    protected virtual void OnMovementCanceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {

    }
    private void OnDodgeStarted(InputAction.CallbackContext obj)
    {
        if (stateMachine.IsDodgeing == false)
        {
            stateMachine.IsDodgeing = true;
            stateMachine.ChangeState(stateMachine.DodgeState);
        }
    }
    protected virtual void OnAttackPerformed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        stateMachine.IsAttacking = true;
    }
    protected virtual void OnAttackCanceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        stateMachine.IsAttacking = false;
    }
    protected virtual void OnRunCanceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        stateMachine.IsRunning = false;
    }
    #endregion
    //Read InputActions
    private void ReadMovementInput()
    {
        stateMachine.MovementInput = stateMachine.Player.Input.PlayerActions.Movement.ReadValue<Vector2>();
    }

    private void Move()
    {
        stateMachine.Player.Controller.Move(stateMachine.Player.ForceReceiver.Movement * Time.deltaTime);
        if (stateMachine.MovementInput != Vector2.zero && !stateMachine.IsDodgeing)
        {
            if (stateMachine.Player.Controller.isGrounded)
            {
                Vector3 moveDirection = new Vector3(stateMachine.MovementInput.x, 0, stateMachine.MovementInput.y);
                float moveSpeed = GetMovementSpeed();
                stateMachine.Player.Controller.Move(((moveDirection * moveSpeed) + stateMachine.Player.ForceReceiver.Movement) * Time.deltaTime);
            }
            Rotate();
        }
    }
    private void Rotate()
    {
        Vector3 lookDirection = new Vector3(stateMachine.MovementInput.x, 0, stateMachine.MovementInput.y);
        Quaternion lookRotation = Quaternion.LookRotation(lookDirection);
        stateMachine.Player.transform.rotation = Quaternion.Slerp(stateMachine.Player.transform.rotation,
            lookRotation, Time.deltaTime * stateMachine.RotationDamping);
    }
    private float GetMovementSpeed()
    {
        return stateMachine.MovementSpeed + stateMachine.MovementSpeedModifier;
    }
    protected void StartAnimation(int animationHash)
    {
        stateMachine.Player.Animator.SetBool(animationHash, true);
    }
    protected void StopAnimation(int animationHash)
    {
        stateMachine.Player.Animator.SetBool(animationHash, false);
    }
}
