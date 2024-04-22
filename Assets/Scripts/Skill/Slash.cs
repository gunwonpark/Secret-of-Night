using UnityEngine;

public class Slash : MonoBehaviour
{
    public float attackRadius = 5f;
    public float attackAngle = 180f;

    public int damage = 10;

    public void PerformAttack()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, attackRadius, LayerMask.NameToLayer("Monster"));

        foreach (var hit in hits)
        {
            Vector3 directionToTarget = (hit.transform.position - transform.position).normalized;
            float angleBetweenPlayerAndTarget = Vector3.Angle(transform.forward, directionToTarget);

            if (angleBetweenPlayerAndTarget < attackAngle / 2)  // Divide by 2 to get half angle on each side
            {
                // Apply damage
                if (hit.transform.TryGetComponent<IDamageable>(out IDamageable enemy))
                {
                    enemy.TakeDamage(damage);
                }
            }
        }
    }
}
