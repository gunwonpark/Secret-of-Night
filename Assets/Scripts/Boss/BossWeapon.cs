using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    [SerializeField] private Collider myCollider;

    [Header("MonsterData")]
    [SerializeField] private BossMonsterGameData bossMonsterData;

    private List<Collider> alreadyColliderWith = new List<Collider>();

    private void OnEnable()
    {
        alreadyColliderWith.Clear();
    }

    private void Start()
    {
        int monsterID = 1;
        bossMonsterData = new BossMonsterGameData(monsterID);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == myCollider) return;

        alreadyColliderWith.Add(other);

        if (other.TryGetComponent(out IDamageable health))
        {
            health.TakeDamage(bossMonsterData.Damage);
        }
    }
}


