using UnityEngine;

public class FieldMonsters : MonoBehaviour
{

    [field: Header("Animations")]
    //[field: SerializeField] public MonsterAnimationData AnimationData { get; private set; }

    public MonsterManager monsterManager;
    public MonsterInfo myInfo;
    public string monsterName;//나자신의 이름 가져오게 하기

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }

    private MonsterStateMachine stateMachine;


    private void Awake()
    {
        //AnimationData.Initialize();

        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();

        stateMachine = new MonsterStateMachine(this);
    }

    private void Start()
    {
        //stateMachine.ChasingState(stateMachine.IdleState);
        myInfo = monsterManager.GetMonsterInfoByKey(monsterName);

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
