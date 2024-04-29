using System;
using UnityEngine;


[RequireComponent(typeof(CharacterController), typeof(PlayerInput), typeof(ForceReceiver))]
public class PlayerController : MonoBehaviour, IDamageable
{
    #region PlayerData
    [field: Header("PlayerData")]
    [field: SerializeField] public PlayerGameData PlayerData { get; set; }
    [field: SerializeField] public float MovementSpeedModifier { get; set; }

    public LayerMask groundLayer;
    public int GroundLayerMask => groundLayer.value;

    public float speed = 0;
    public float walkSpeed = 2.0f;
    public float runSpeed = 4.0f;
    public float rotationDamping = 10f;
    public float jumpForce = 4f;
    public float jumpDelayTime = 0.3f;
    public float dodgeHeihgt = 2.0f;
    public float dodgeForce = -4.0f;
    #endregion

    #region StateCheckcing
    [field: Header("State Check")]
    [field: SerializeField] public bool IsAttacking { get; set; }
    [field: SerializeField] public bool IsRunning { get; set; }
    [field: SerializeField] public bool IsJumping { get; set; }
    [field: SerializeField] public bool IsDodgeing { get; set; }
    [field: SerializeField] public bool DoSkill { get; set; }
    [field: SerializeField] public bool IsGrounded { get; set; }
    [field: SerializeField] public bool canRun { get; set; }
    [field: SerializeField] public bool IsTired { get; set; }
    [field: SerializeField] public bool IsDie { get; set; }
    #endregion

    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerInput Input { get; private set; }
    public CharacterController Controller { get; private set; }
    public ForceReceiver ForceReceiver { get; private set; }
    public StaminaSystem StaminaSystem { get; private set; }
    private PlayerStateMachine stateMachine;

    private FieldMonsters _nearestMonster = null;
    private void Awake()
    {
        AnimationData = new PlayerAnimationData();

        Animator = GetComponentInChildren<Animator>();
        Input = GetComponent<PlayerInput>();
        Controller = GetComponent<CharacterController>();
        ForceReceiver = GetComponent<ForceReceiver>();
        StaminaSystem = GetComponent<StaminaSystem>();
        stateMachine = new PlayerStateMachine(this);
    }
    private void Start()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
        PlayerData = GameManager.Instance.playerManager.playerData;
        PlayerData.ResetStatus();
        PlayerData.OnDie += OnPlayerDie;
    }
    private void Update()
    {
        stateMachine.HandleInput();
        stateMachine.Update();
        PlayerData.MPChange(1 * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (Controller == null)
            return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + Vector3.up * Controller.bounds.extents.x * 0.5f, Controller.bounds.extents.x + Controller.skinWidth);
    }
#endif
    public void TakeDamage(float damage)
    {
        float finalDamage = damage / PlayerData.Def;
        PlayerData.HPChange(-finalDamage);
    }

    private void OnPlayerDie()
    {
        if (!IsDie)
        {
            IsDie = true;
            PlayerData.OnDie -= OnPlayerDie;
            Animator.SetTrigger(AnimationData.Die);
            Input.enabled = false;
        }

    }

    public Type GetCurrentState()
    {
        return stateMachine?.GetCurrentState();
    }

    public void FindNearestMonster()
    {
        Collider[] monsters = Physics.OverlapSphere(transform.position, 10f, 1 << LayerMask.NameToLayer("Monster"), QueryTriggerInteraction.Ignore);
        if (monsters.Length > 0)
        {
            FieldMonsters monster = monsters[0].GetComponent<FieldMonsters>();
            if (monster != null && _nearestMonster != monster)
            {
                _nearestMonster = monster;
            }
        }
        else
        {
            _nearestMonster = null;
        }
    }

    private void OnDestroy()
    {
        PlayerData.OnDie -= OnPlayerDie;

    }
}
