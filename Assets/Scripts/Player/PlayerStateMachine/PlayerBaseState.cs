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
        if (stateMachine.IsAttacking && !stateMachine.IsDodgeing)
        {
            Attack();
            return;
        }
    }
    protected virtual void AddPlayerActionCallbacks()
    {
        stateMachine.Player.Input.PlayerActions.Movement.canceled += OnMovementCanceled;
        stateMachine.Player.Input.PlayerActions.Run.performed += OnRunStarted;
        stateMachine.Player.Input.PlayerActions.Run.canceled += OnRunCanceled;

        stateMachine.Player.Input.PlayerActions.Jump.started += OnJumpStarted;

        stateMachine.Player.Input.PlayerActions.Dodge.started += OnDodgeStarted;

        stateMachine.Player.Input.PlayerActions.Attack.started += OnAttackStarted;
        stateMachine.Player.Input.PlayerActions.Attack.canceled += OnAttackCanceled;
    }

    protected virtual void RemovePlayerActionCallbacks()
    {
        stateMachine.Player.Input.PlayerActions.Movement.canceled -= OnMovementCanceled;
        stateMachine.Player.Input.PlayerActions.Run.started -= OnRunStarted;
        stateMachine.Player.Input.PlayerActions.Run.canceled -= OnRunCanceled;

        stateMachine.Player.Input.PlayerActions.Jump.started -= OnJumpStarted;

        stateMachine.Player.Input.PlayerActions.Dodge.started -= OnDodgeStarted;

        stateMachine.Player.Input.PlayerActions.Attack.started -= OnAttackStarted;
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
        if (stateMachine.IsDodgeing == false && stateMachine.IsJumping == false)
        {
            stateMachine.IsDodgeing = true;
            stateMachine.ChangeState(stateMachine.DodgeState);
        }
    }
    protected virtual void OnAttackStarted(UnityEngine.InputSystem.InputAction.CallbackContext context)
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
            Vector3 moveDirection = stateMachine.MainCameraTransform.right * stateMachine.MovementInput.x;
            moveDirection += stateMachine.MainCameraTransform.forward * stateMachine.MovementInput.y;
            moveDirection.y = 0;
            if (stateMachine.Player.Controller.isGrounded)
            {
                float moveSpeed = GetMovementSpeed();
                stateMachine.Player.Controller.Move(((moveDirection * moveSpeed) + stateMachine.Player.ForceReceiver.Movement) * Time.deltaTime);
            }
            Rotate(moveDirection);
        }
    }
    private void Rotate(Vector3 lookDirection)
    {
        Quaternion lookRotation = Quaternion.LookRotation(lookDirection);
        stateMachine.Player.transform.rotation = Quaternion.Slerp(stateMachine.Player.transform.rotation,
            lookRotation, Time.deltaTime * stateMachine.RotationDamping);
    }
    private void Attack()
    {
        stateMachine.ChangeState(stateMachine.AttackState);
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
    protected float GetNormalizedTime(Animator animator, string tag)
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);

        if (animator.IsInTransition(0) && nextInfo.IsTag(tag))
        {
            return nextInfo.normalizedTime;
        }
        else if (!animator.IsInTransition(0) && currentInfo.IsTag(tag))
        {
            return currentInfo.normalizedTime;
        }
        else
        {
            return 0f;
        }
    }
}
