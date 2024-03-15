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

	public float dashdistance = 5f;

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
				DashTowardsPlayer(distanceToPlayer);
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
			Debug.Log("dashstate");
		}
		else if (distanceToPlayer <= bossMonsterData.Range)
		{
			Debug.Log("dd");
			currentState = BossState.Attacking;
		}
	}

	void DashTowardsPlayer(float distanceToPlayer)
	{
		agent.speed = 10f;
		agent.SetDestination(playerTransform.position);
		animator.SetBool("IsDashing", true);
		Debug.Log(dashdistance);
		Debug.Log(distanceToPlayer);
		Debug.Log(bossMonsterData.Range);
		if (distanceToPlayer <= bossMonsterData.Range)
		{
			
			animator.SetBool("IsAttack", true);
		}
	}

	void AttackPlayer(float distanceToPlayer)
	{
		if (distanceToPlayer <= bossMonsterData.Range)
		{
			animator.SetBool("IsAttack", true);
		}
		else
		{
			animator.SetBool("IsAttack", false);
			currentState = BossState.Moving;
		}
	}

	public void TakeDamage(float damage)
	{
		bossMonsterData.HP -= damage / bossMonsterData.Def;
		if (bossMonsterData.HP <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		animator.SetTrigger("Die");
		agent.isStopped = true;
		currentState = BossState.Dying;
	}
}
