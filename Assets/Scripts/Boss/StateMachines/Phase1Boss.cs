using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Phase1Boss : MonoBehaviour, IDamageable
{
    [Header("References")]
    public BossState currentState = BossState.Idle;
    public Transform playerTransform;
    public Animator animator;
    private NavMeshAgent agent;
    private SkinnedMeshRenderer[] meshRenderers;

    [Header("MonsterData")]
    [SerializeField] private BossMonsterGameData bossMonsterData;

    public float dashdistance = 3f;

    private void Awake()
    {
    }

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        meshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();

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
        agent.speed = 3f;
        agent.SetDestination(playerTransform.position);
        animator.SetBool("IsDashing", true);

        currentState = BossState.Attacking;
    }

    void AttackPlayer(float distanceToPlayer)
    {

        if (bossMonsterData.HP <= 5.0f && Random.Range(0, 100) < 25 && distanceToPlayer <= bossMonsterData.Range)
        {
            // 난사 공격 애니메이션 실행
            animator.SetTrigger("ATK4");
        }
        else if (distanceToPlayer <= bossMonsterData.Range)
        {
            agent.speed = bossMonsterData.MoveSpeed;
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsDashing", false);
            animator.SetBool("IsAttack", true);
        }
        else if (distanceToPlayer > bossMonsterData.Range)
        {
            animator.SetBool("IsAttack", false);
            currentState = BossState.Moving;
        }
    }

    public void TakeDamage(float damage)
    {
        bossMonsterData.HP -= damage;
        if (bossMonsterData.HP <= 0)
            Die();

        StartCoroutine(DamageFlash());
    }

    IEnumerator DamageFlash()
    {
        for (int x = 0; x < meshRenderers.Length; x++)
            meshRenderers[x].material.color = new Color(1.0f, 0.6f, 0.6f);

        yield return new WaitForSeconds(0.1f);
        for (int x = 0; x < meshRenderers.Length; x++)
            meshRenderers[x].material.color = Color.white;
    }

    void Die()
    {
        animator.SetTrigger("Die");
        agent.isStopped = true;
        currentState = BossState.Dying;
    }
}
