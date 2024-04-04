using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class FieldMonsters : MonoBehaviour, IDamageable
{


    [field: Header("Reference")]
    [field: SerializeField] public MonsterInfo myInfo;
    public float HP = 0;

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
        //[todo]플레이어 콜라이더만
        OnAttack?.Invoke(other.gameObject);
    }

    public void dropItem(Item _item)
    {
        Vector3 throwPosition = transform.position + transform.forward * Random.Range(0.5f, 0.5f);

        Instantiate(_item.Prefab, throwPosition, Quaternion.identity);
    }
}
