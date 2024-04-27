using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuriGuriBoss : MonoBehaviour, IDamageable
{
    [Header("References")]
    public BossState currentState = BossState.Idle;
    public Transform playerTransform;
    private Animator animator;
    //public Texture2D damageTexture;
    //public Texture2D originalTexture;
    private NavMeshAgent agent;
    private SkinnedMeshRenderer[] meshRenderers;
    SMRAfterImageCreator aic;

    [field: Header("MonsterData")]
    [field: SerializeField] public BossMonsterGameData bossMonsterData { get; private set; }

    public float maxHP;
    public float dashdistance = 3f;

    private bool canPlayDamageAnimation = true;

    private float actualSlowMotionCharge = 0f;
    private float maxSlowMotionCharge = 100f;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        meshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();

        int monsterID = 2;
        bossMonsterData = new BossMonsterGameData(monsterID);
        maxHP = bossMonsterData.HP;

        if (bossMonsterData != null)
        {
            agent.speed = bossMonsterData.MoveSpeed; // 스피드 직접 참조
        }

        CreateAfterImages();
    }

    private void Update()
    {
        if (bossMonsterData == null) return;


        if (currentState != BossState.Dying)
        {
            transform.LookAt(playerTransform.position);
        }

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
        
        else if (distanceToPlayer <= bossMonsterData.Range)
        {
            currentState = BossState.Attacking;
        }
    }
    

    public void AfterImageTrue()
    {
        aic.Create(true);
    }

    public void AfterImageFalse()
    {
        aic.Create(false);
    }

    void AttackPlayer(float distanceToPlayer)
    {
        if (distanceToPlayer <= bossMonsterData.Range)
        {
            agent.speed = bossMonsterData.MoveSpeed;
            animator.SetBool("IsRunning", false);            
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
        Debug.Log("맞았다");
        bossMonsterData.HP -= (damage / bossMonsterData.Def);
        if (bossMonsterData.HP <= 0)
        {
            Die();
            bossMonsterData.HP = 0;
        }
        aic.Create(false);

        DamageFlash();
    }

    public void DamageFlash()
    {
        //meshRenderers[0].material.mainTexture = damageTexture;
        Invoke("ResetTexture", 0.5f);
        if (canPlayDamageAnimation)
        {
            if (currentState == BossState.Dying)
                return; // 죽은 상태라면 데미지 애니메이션 실행을 건너뜁니다.

            animator.SetTrigger("Damage"); // Trigger Damage animation
            canPlayDamageAnimation = false;
            StartCoroutine(ResetDamageAnimation());
        }
    }

    IEnumerator ResetDamageAnimation()
    {
        yield return new WaitForSeconds(1f); // Wait for 1seconds
        canPlayDamageAnimation = true; // Allow Damage animation to be played again
    }

    public void ResetTexture()
    {
        //meshRenderers[0].material.mainTexture = originalTexture;
    }

    void CreateAfterImages()
    {
        aic = GetComponent<SMRAfterImageCreator>();
        aic.Setup(transform.GetComponentInChildren<SkinnedMeshRenderer>(), 5, 1.4f);
        actualSlowMotionCharge = maxSlowMotionCharge;
    }

    void Die()
    {
        if (currentState != BossState.Dying) // 이미 죽은 상태인지 확인
        {
            animator.SetTrigger("Die");
            agent.isStopped = true;
            currentState = BossState.Dying;
            DropItem();
            QuestManager.I.QuestClear();
        }
    }

    public void DropItem()
    {
        Vector3 throwPosition = transform.position;

        Instantiate(Resources.Load<GameObject>("Prefabs/Quest/Gemstone"), throwPosition, Quaternion.identity);
    }
}
