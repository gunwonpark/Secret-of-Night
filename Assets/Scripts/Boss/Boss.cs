using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [field: Header("Refernces")]
    [field: SerializeField] public BossSO Data { get; private set; }

    [field: Header("Animations")]
    [field: SerializeField] public BossAnimationData AnimationData { get; private set; }

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public BossForceReceiver ForceReceiver { get; private set; }
    public CharacterController Controller { get; private set; }

    private BossStateMachine stateMachine;

    private void Awake()
    {
        AnimationData = new BossAnimationData();

        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();
        Controller = GetComponent<CharacterController>();
        ForceReceiver = GetComponent<BossForceReceiver>();
        stateMachine = new BossStateMachine(this);
        
    }

	private void Start()
	{
        stateMachine.ChangeState(stateMachine.IdlingState);
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
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, (stateMachine.Target.transform.position - stateMachine.Boss.transform.position).sqrMagnitude);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Data.AttackRange);
    }
}
