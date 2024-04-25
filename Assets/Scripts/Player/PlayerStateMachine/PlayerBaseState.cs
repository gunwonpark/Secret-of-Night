using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine stateMachine;
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
        GroundedCheck();
        Move();
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
        stateMachine.Player.Input.PlayerActions.Skill1.started += OnSkill1Started;
        stateMachine.Player.Input.PlayerActions.Skill2.started += OnSkill2Started;
        stateMachine.Player.Input.PlayerActions.Skill3.started += OnSkill3Started;
        stateMachine.Player.Input.PlayerActions.Skill4.started += OnSkill4Started;
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
        stateMachine.Player.Input.PlayerActions.Skill1.started -= OnSkill1Started;
        stateMachine.Player.Input.PlayerActions.Skill2.started -= OnSkill2Started;
        stateMachine.Player.Input.PlayerActions.Skill3.started -= OnSkill3Started;
        stateMachine.Player.Input.PlayerActions.Skill4.started -= OnSkill4Started;
    }
    #region addevent
    private void OnSkill1Started(InputAction.CallbackContext obj)
    {
        if (stateMachine.Player.DoSkill == false)
        {
            stateMachine.Player.DoSkill = true;
            SkillTrigger(0);
        }

    }
    private void OnSkill2Started(InputAction.CallbackContext obj)
    {
        if (stateMachine.Player.DoSkill == false)
        {
            stateMachine.Player.DoSkill = true;
            SkillTrigger(1);
        }
    }
    private void OnSkill3Started(InputAction.CallbackContext obj)
    {
        if (stateMachine.Player.DoSkill == false)
        {
            stateMachine.Player.DoSkill = true;
            SkillTrigger(2);
        }
    }
    private void OnSkill4Started(InputAction.CallbackContext obj)
    {
        if (stateMachine.Player.DoSkill == false)
        {
            stateMachine.Player.DoSkill = true;
            SkillTrigger(3);
        }
    }
    protected virtual void OnJumpStarted(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        stateMachine.Player.IsJumping = true;
    }

    protected virtual void OnRunStarted(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        stateMachine.Player.IsRunning = true;
    }

    private void OnDodgeStarted(InputAction.CallbackContext obj)
    {
        if (stateMachine.Player.IsDodgeing == false)
        {
            stateMachine.Player.IsDodgeing = true;
            stateMachine.ChangeState(stateMachine.DodgeState);
        }
    }
    protected virtual void OnAttackStarted(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        stateMachine.Player.IsAttacking = true;
    }
    protected virtual void OnAttackCanceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        stateMachine.Player.IsAttacking = false;
    }
    protected virtual void OnRunCanceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        stateMachine.Player.IsRunning = false;
    }
    protected virtual void OnMovementCanceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {

    }
    #endregion
    //Read InputActions
    private void ReadMovementInput()
    {
        stateMachine.MovementInput = stateMachine.Player.Input.PlayerActions.Movement.ReadValue<Vector2>();
    }

    Vector3 moveDirection = Vector3.zero;
    private float SpeedChangeRate = 10f;
    private void Move()
    {
        if (stateMachine.MovementInput != Vector2.zero)
            moveDirection = MoveDirection_Ver_Camera();

        float targetSpeed = GetMovementSpeed();

        float currentHorizontalSpeed = new Vector3(stateMachine.Player.Controller.velocity.x, 0.0f, stateMachine.Player.Controller.velocity.z).magnitude;

        float speedOffset = 0.1f;

        if (currentHorizontalSpeed < targetSpeed - speedOffset ||
                currentHorizontalSpeed > targetSpeed + speedOffset)
        {
            stateMachine.Player.speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed,
                Time.deltaTime * SpeedChangeRate);

            stateMachine.Player.speed = Mathf.Round(stateMachine.Player.speed * 1000f) / 1000f;
        }
        else
        {
            stateMachine.Player.speed = targetSpeed;
        }

        stateMachine.Player.Controller.Move(((moveDirection * stateMachine.Player.speed) + stateMachine.Player.ForceReceiver.Movement) * Time.deltaTime);

        if (stateMachine.MovementInput != Vector2.zero)
            Rotate(moveDirection);
    }

    private bool CanMove()
    {
        return stateMachine.MovementInput != Vector2.zero && !stateMachine.Player.IsDodgeing && !stateMachine.Player.IsJumping;
    }
    // 카메라 방향으로 이동하는 방식
    private Vector3 MoveDirection_Ver_Camera()
    {
        Vector3 moveDirection = stateMachine.MainCameraTransform.right * stateMachine.MovementInput.x;
        moveDirection += stateMachine.MainCameraTransform.forward * stateMachine.MovementInput.y;
        moveDirection.y = 0;
        moveDirection = moveDirection.normalized;
        return moveDirection;
    }
    // 키 입력 방향으로 이동하는 방식
    private Vector3 MoveDirection_Ver_Key() // test
    {
        Vector3 moveDirection = new Vector3(stateMachine.MovementInput.x, 0, stateMachine.MovementInput.y);
        return moveDirection.normalized;
    }
    protected bool lockRotation = false;
    protected void Rotate(Vector3 lookDirection)
    {
        if (lockRotation)
            return;
        lookDirection = new Vector3(lookDirection.x, lookDirection.y, lookDirection.z); // test
        Quaternion lookRotation = Quaternion.LookRotation(lookDirection);
        stateMachine.Player.transform.rotation = Quaternion.Slerp(stateMachine.Player.transform.rotation,
            lookRotation, Time.deltaTime * stateMachine.Player.rotationDamping);

    }
    private void GroundedCheck()
    {
        Vector3 spherePosition = stateMachine.Player.transform.position;
        stateMachine.Player.IsGrounded = Physics.CheckSphere(spherePosition + Vector3.up * stateMachine.Player.Controller.bounds.extents.x * 0.5f, stateMachine.Player.Controller.bounds.extents.x + stateMachine.Player.Controller.bounds.extents.x, stateMachine.Player.GroundLayerMask,
                QueryTriggerInteraction.Ignore);
    }
    protected float GetMovementSpeed()
    {
        return stateMachine.Player.PlayerData.MoveSpeed * stateMachine.Player.MovementSpeedModifier;
    }
    protected void StartAnimation(int animationHash)
    {
        stateMachine.Player.Animator?.SetBool(animationHash, true);
    }
    protected void StopAnimation(int animationHash)
    {
        stateMachine.Player.Animator?.SetBool(animationHash, false);
    }

    protected void SkillTrigger(int number)
    {
        if (GameManager.Instance.playerManager.CheckSkillIsDeActive(number))
        {
            stateMachine.Player.DoSkill = false;
            return;
        }
        int skillID = GameManager.Instance.playerManager.skillSlots[number].skillID;
        string skillname = GameManager.Instance.playerManager.playerSkillList[skillID].playerSkillData.Name;
        GameManager.Instance.playerManager.skillSlots[number].Execute();
        stateMachine.Player.Animator.SetTrigger(skillname);
        stateMachine.ChangeState(stateMachine.SkillState);
    }
}
