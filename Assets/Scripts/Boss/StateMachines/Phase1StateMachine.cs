using UnityEngine;
using UnityEngine.AI;

public enum BossState
{
    Idle,
    Moving,
    Attacking,
    Dying
}

public class Phase1StateMachine : MonoBehaviour
{
    public BossState currentState = BossState.Idle;
    public Transform playerTransform;
    public Animator animator;
    private NavMeshAgent agent;

    // 보스 스탯
    public float health = 10;
    public float attackDamage = 1;
    public float defense = 1;
    public float moveSpeed = 1;
    public float attackRange = 1.5f; // 공격 범위

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        switch (currentState)
        {
            case BossState.Idle:
                if (distanceToPlayer > attackRange)
                {
                    currentState = BossState.Moving;
                }
                break;
            case BossState.Moving:
                MoveTowardsPlayer(distanceToPlayer);
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
        if (distanceToPlayer > attackRange)
        {
            agent.SetDestination(playerTransform.position);
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
            currentState = BossState.Attacking;
        }
    }

    void AttackPlayer(float distanceToPlayer)
    {
        if (distanceToPlayer <= attackRange)
        {            
            animator.SetBool("IsAttack", true);
        }
        else
        {
            animator.SetBool("IsAttack", false);
            currentState = BossState.Moving;
        }
    }

    //public void TakeDamage(float damage)
    //{
    //    health -= damage / defense;
    //    if (health <= 0)
    //    {
    //        Die();
    //    }
    //}

    void Die()
    {
        animator.SetTrigger("Die");
        agent.isStopped = true;
        
    }
}
