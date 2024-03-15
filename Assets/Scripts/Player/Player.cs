using UnityEngine;


[RequireComponent(typeof(CharacterController), typeof(PlayerInput), typeof(ForceReceiver))]
public class Player : MonoBehaviour
{
    // PlayerData need
    [field: Header("PlayerData")]
    [field: SerializeField] public PlayerGameData PlayerData { get; set; }

    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerInput Input { get; private set; }
    public CharacterController Controller { get; private set; }
    public ForceReceiver ForceReceiver { get; private set; }

    private PlayerStateMachine stateMachine;

    private void Awake()
    {
        AnimationData = new PlayerAnimationData();

        Animator = GetComponentInChildren<Animator>();
        Input = GetComponent<PlayerInput>();
        Controller = GetComponent<CharacterController>();
        ForceReceiver = GetComponent<ForceReceiver>();
        stateMachine = new PlayerStateMachine(this);
    }

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
        PlayerData = GameManager.Instance.playerManager.playerData;
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
}
