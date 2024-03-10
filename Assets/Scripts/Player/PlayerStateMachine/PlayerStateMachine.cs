using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }
    public PlayerIdleState IdleState { get; set; }
    public PlayerWalkState WalkState { get; set; }
    public PlayerRunState RunState { get; set; }
    public PlayerJumpState JumpState { get; set; }
    public PlayerDodgeState DodgeState { get; set; }
    public Vector2 MovementInput { get; set; }

    #region StateCheckcing
    public bool IsAttacking { get; set; }
    public bool IsRunning { get; set; }
    public bool IsJumping { get; set; }
    public bool IsDodgeing { get; set; }
    #endregion

    public Transform MainCameraTransform { get; set; }

    //TODO have to make as DataScripts
    public float MovementSpeed { get; private set; }
    public float MovementSpeedModifier { get; set; }
    public float walkSpeed = 3.0f;
    public float runSpeed = 6.0f;
    public float RotationDamping { get; set; }
    public float JumpForce { get; set; }
    public PlayerStateMachine(Player player)
    {
        this.Player = player;

        IdleState = new PlayerIdleState(this);
        WalkState = new PlayerWalkState(this);
        RunState = new PlayerRunState(this);
        JumpState = new PlayerJumpState(this);
        DodgeState = new PlayerDodgeState(this);

        MainCameraTransform = Camera.main.transform;
        RotationDamping = 10f;
    }
}
