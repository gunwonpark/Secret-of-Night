using UnityEngine;

public class FieldMonsters : MonoBehaviour
{

    [field: Header("Animations")]
    //[field: SerializeField] public MonsterAnimationData AnimationData { get; private set; }
    [field: Header("Reference")]
    [field: SerializeField] public MonsterInfo myInfo;
    [field: SerializeField] public float targetRange = 5f;
    [field: SerializeField] public float rotationDamping = 1f;

    //public MonsterManager monsterManager;



    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public ForceReceiver forceReceiver { get; private set; }
    public CharacterController controller { get; private set; }

    public MonsterAnimation monsterAnimation;

    private MonsterStateMachine stateMachine;


    private void Awake()
    {
        //AnimationData.Initialize();

        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
        forceReceiver = GetComponent<ForceReceiver>();
        controller = GetComponent<CharacterController>();
        monsterAnimation = GetComponent<MonsterAnimation>();
    }

    public void Init(MonsterInfo monsterInfo)
    {

        myInfo = monsterInfo;

        stateMachine = new MonsterStateMachine(this);
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void Update()
    {
        stateMachine?.HandleInput();
        stateMachine?.Update();
    }

    private void FixedUpdate()
    {
        stateMachine?.PhysicsUpdate();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, targetRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}
