using UnityEngine;

public class FieldMonsters : MonoBehaviour
{

    [field: Header("Animations")]
    //[field: SerializeField] public MonsterAnimationData AnimationData { get; private set; }
    [field: Header("Reference")]
    [field: SerializeField] public MonsterInfo myInfo;
    [field: SerializeField] public float targetRange = 5f;

    public MonsterManager monsterManager;
    public string monsterName;// to do 나자신의 이름 가져오게 하기

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public ForceReceiver forceReceiver { get; private set; }
    public CharacterController controller { get; private set; }

    private MonsterStateMachine stateMachine;


    private void Awake()
    {
        //AnimationData.Initialize();

        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
        forceReceiver = GetComponent<ForceReceiver>();
        controller = GetComponent<CharacterController>();

    }

    private void Start()
    {
        monsterName = gameObject.name;
        myInfo = monsterManager.GetMonsterInfoByKey(monsterName);

        stateMachine = new MonsterStateMachine(this);
        stateMachine.ChangeState(stateMachine.IdleState);
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
