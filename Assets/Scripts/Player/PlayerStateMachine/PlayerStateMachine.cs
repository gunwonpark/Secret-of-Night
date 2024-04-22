using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public PlayerController Player { get; }
    public PlayerIdleState IdleState { get; set; }
    public PlayerWalkState WalkState { get; set; }
    public PlayerRunState RunState { get; set; }
    public PlayerJumpState JumpState { get; set; }
    public PlayerDodgeState DodgeState { get; set; }
    public PlayerAttackState AttackState { get; set; }
    public PlayerSkillState SkillState { get; set; }
    public Vector2 MovementInput { get; set; }
    public Transform MainCameraTransform { get; private set; }
    public CameraTPP cameraScript { get; private set; }

    //TODO have to make as DataScripts

    public PlayerStateMachine(PlayerController player)
    {
        this.Player = player;

        IdleState = new PlayerIdleState(this);
        WalkState = new PlayerWalkState(this);
        RunState = new PlayerRunState(this);
        JumpState = new PlayerJumpState(this);
        DodgeState = new PlayerDodgeState(this);
        AttackState = new PlayerAttackState(this);
        SkillState = new PlayerSkillState(this);

        MainCameraTransform = Camera.main.transform;
        cameraScript = MainCameraTransform.GetComponent<CameraTPP>();
    }

}
