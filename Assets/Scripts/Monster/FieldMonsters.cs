using System;
using UnityEngine;

public class FieldMonsters : MonoBehaviour, IDamageable
{

    //[field: Header("Animations")]
    //[field: SerializeField] public MonsterAnimationData AnimationData { get; private set; }
    [field: Header("Reference")]
    [field: SerializeField] public MonsterInfo myInfo;
    //[field: SerializeField] public float targetRange = 5f;
    //[field: SerializeField] public float rotationDamping = 10f;
    public float HP = 0;
    //public MonsterManager monsterManager;

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public ForceReceiver forceReceiver { get; private set; }
    public CharacterController controller { get; private set; }
    public BoxCollider attackCollider;

    public MonsterAnimation monsterAnimation;

    private MonsterStateMachine stateMachine;

    public Vector3 originalPosition;

    public event Action<float> OnDamage;
    public event Action<GameObject> OnAttack;

    private void Awake()
    {
        //AnimationData.Initialize();

        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
        forceReceiver = GetComponent<ForceReceiver>();
        controller = GetComponent<CharacterController>();
        monsterAnimation = GetComponent<MonsterAnimation>();
        attackCollider = GetComponent<BoxCollider>();
    }

    public void Init(MonsterInfo monsterInfo)
    {

        myInfo = monsterInfo;

        HP = myInfo.HP;

        stateMachine = new MonsterStateMachine(this);
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void Update()
    {
        stateMachine?.HandleInput();
        stateMachine?.Update();

        //Debug.Log(originalPosition);
    }

    private void FixedUpdate()
    {
        stateMachine?.PhysicsUpdate();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, myInfo.TargetRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, myInfo.AtkRange);
    }

    public void SetPosition(Vector3 position)
    {
        originalPosition = position;
    }

    //base에 있는 takedamage구독
    public void TakeDamage(float Damage)
    {
        OnDamage?.Invoke(Damage);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("부딫힘");
        OnAttack?.Invoke(other.gameObject);
    }
}
