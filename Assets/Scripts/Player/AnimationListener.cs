using System.Collections.Generic;
using UnityEngine;

public class AnimationListener : MonoBehaviour
{
    public Transform[] SlashEffectPos;
    public ParticleSystem[] SlashEffects;
    public Dictionary<int, GameObject> playerSkillList = new Dictionary<int, GameObject>();
    public ParticleSystem JumpSlashEffect;
    public ParticleSystem StoneSlashEffect;
    public float attackRange = 10f;
    public LayerMask enemyLayer;
    public void SlashEffect(int index)
    {
        SlashEffects[index].Play();
    }
    public void SlashAttack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer, QueryTriggerInteraction.Ignore);

        foreach (var hitCollider in hitEnemies)
        {
            Vector3 directionToTarget = (hitCollider.transform.position - transform.position).normalized;
            float angle = Vector3.Angle(transform.forward, directionToTarget);
            if (angle < 90f)
            {
                Debug.Log("SlashAttack: " + hitCollider.name);
                hitCollider.GetComponent<IDamageable>()?.TakeDamage(10f);
            }
        }
    }
    public void ShowPlayerSkill(string name)
    {
        if (name == "JumpAttack")
        {
            JumpSlashEffect.Play();
        }
        else if (name == "StoneSlash")
        {
            StoneSlashEffect.Play();
        }
    }
    public void SkillDamage(string name)
    {
        if (name == "JumpAttack")
        {
            Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer, QueryTriggerInteraction.Ignore);

            foreach (var hitCollider in hitEnemies)
            {
                Vector3 directionToTarget = (hitCollider.transform.position - transform.position).normalized;
                float angle = Vector3.Angle(transform.forward, directionToTarget);
                float distance = Vector3.Distance(hitCollider.transform.position, transform.position);
                Debug.Log(distance);
                if (angle < 45f && distance < 2f)
                {
                    Debug.Log("JumpAttack: " + hitCollider.name);
                    hitCollider.GetComponent<IDamageable>()?.TakeDamage(10f);
                }
            }
        }
        else if (name == "StoneSlash")
        {
            Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer, QueryTriggerInteraction.Ignore);

            foreach (var hitCollider in hitEnemies)
            {
                Vector3 directionToTarget = (hitCollider.transform.position - transform.position).normalized;
                float angle = Vector3.Angle(transform.forward, directionToTarget);
                float distance = Vector3.Distance(hitCollider.transform.position, transform.position);
                Debug.Log(distance);
                if (angle < 45f)
                {
                    Debug.Log("JumpAttack: " + hitCollider.name);
                    hitCollider.GetComponent<IDamageable>()?.TakeDamage(10f);
                }
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        // Draw the attack range arc for visual debugging
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Vector3 forward = transform.forward * attackRange;
        Vector3 right = Quaternion.Euler(0, 90, 0) * forward;
        Vector3 left = Quaternion.Euler(0, -90, 0) * forward;

        Gizmos.DrawLine(transform.position, transform.position + forward);
        Gizmos.DrawLine(transform.position, transform.position + right);
        Gizmos.DrawLine(transform.position, transform.position + left);
    }
}
