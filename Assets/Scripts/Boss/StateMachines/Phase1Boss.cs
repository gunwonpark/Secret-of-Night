using UnityEngine;
using UnityEngine.AI;

public class Phase1Boss : MonoBehaviour
{
	[Header("References")]
	public BossState currentState = BossState.Idle;
	public Transform playerTransform;
	public Animator animator;
	private NavMeshAgent agent;

	[Header("MonsterData")]
	[SerializeField] private BossMonsterGameData bossMonsterData;

	public float dashdistance = 3f;

	private void Awake()
	{
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		animator = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();

		int monsterID = 1;
		bossMonsterData = new BossMonsterGameData(monsterID);

		if (bossMonsterData != null)
		{
			agent.speed = bossMonsterData.MoveSpeed; // 스피드 직접 참조
		}
	}

	private void Update()
	{		
		if (bossMonsterData == null) return;

		float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

		switch (currentState)
		{
			case BossState.Idle:
				if (distanceToPlayer > dashdistance)
				{
					currentState = BossState.Moving;
				}
				break;
			case BossState.Moving:
				MoveTowardsPlayer(distanceToPlayer);
				break;
			case BossState.Dashing:
				DashTowardsPlayer();
				break;

			case BossState.Attacking:
				AttackPlayer(distanceToPlayer);
				break;
			case BossState.Dying:
				// 사망 로직 처리
				break;
		}
	}

	void MoveTowardsPlayer(float distanceToPlayer)
	{
		if (distanceToPlayer > dashdistance)
		{
			agent.SetDestination(playerTransform.position);
			animator.SetBool("IsRunning", true);
		}
		else if (distanceToPlayer <= dashdistance)
		{			
			currentState = BossState.Dashing;			
		}
		else if (distanceToPlayer <= bossMonsterData.Range)
		{			
			currentState = BossState.Attacking;
		}
	}

	void DashTowardsPlayer()
	{
		agent.speed = 5f;
		agent.SetDestination(playerTransform.position);
		animator.SetBool("IsDashing", true);

		currentState = BossState.Attacking;
	}

	void AttackPlayer(float distanceToPlayer)
	{
		
		if (distanceToPlayer <= bossMonsterData.Range)
		{
			agent.speed = bossMonsterData.MoveSpeed;
			animator.SetBool("IsRunning", false);
			animator.SetBool("IsDashing", false);
			animator.SetBool("IsAttack", true);
		}
		else
		{
			animator.SetBool("IsAttack", false);
			currentState = BossState.Moving;
		}
	}

	void Die()
	{
		animator.SetTrigger("Die");
		agent.isStopped = true;
		currentState = BossState.Dying;
	}
}
