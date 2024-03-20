using UnityEngine;


[RequireComponent(typeof(CharacterController), typeof(PlayerInput), typeof(ForceReceiver))]
public class PlayerController : MonoBehaviour, IDamageable
{
    #region PlayerData
    [field: Header("PlayerData")]
    [field: SerializeField] public PlayerGameData PlayerData { get; set; }
    [field: SerializeField] public float MovementSpeedModifier { get; set; }

    public float walkSpeed = 2.0f;
    public float runSpeed = 4.0f;
    public float rotationDamping = 10f;
    public float jumpForce = 4f;
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
    #endregion

    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerInput Input { get; private set; }
    public CharacterController Controller { get; private set; }
    public ForceReceiver ForceReceiver { get; private set; }
    public StaminaSystem StaminaSystem { get; private set; }
    private PlayerStateMachine stateMachine;

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

        PlayerData.OnDie += OnPlayerDie;
    }
    private void Update()
    {
        stateMachine.HandleInput();
        stateMachine.Update();
    }
    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.14f);
    }

    public void TakeDamage(float damage)
    {
        float finalDamage = damage / PlayerData.Def;
        PlayerData.HPChange(-finalDamage);
    }

    private void OnPlayerDie()
    {
        Animator.SetTrigger(AnimationData.Die);
        Debug.Log("PlayerDie");
        Input.enabled = false;
    }

}
