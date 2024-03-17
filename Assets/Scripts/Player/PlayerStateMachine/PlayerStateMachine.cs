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
    public PlayerSkill1State Skill1State { get; set; }
    public PlayerSkill2State Skill2State { get; set; }
    public Vector2 MovementInput { get; set; }
    public Transform MainCameraTransform { get; set; }

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
        Skill1State = new PlayerSkill1State(this);
        Skill2State = new PlayerSkill2State(this);

        MainCameraTransform = Camera.main.transform;
    }
}
