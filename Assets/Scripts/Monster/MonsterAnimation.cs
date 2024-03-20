using UnityEngine;

public class MonsterAnimation : MonoBehaviour
{
    public Animator animator;

    private static readonly int _Idle = Animator.StringToHash("Idle");
    private static readonly int _Run = Animator.StringToHash("Run");
    private static readonly int _Attack = Animator.StringToHash("Attack");
    private static readonly int _Die = Animator.StringToHash("Die");
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void StartIdleAnimation()
    {
        animator.SetBool(_Idle, true);
    }

    public void StopIdleAnimation()
    {
        animator.SetBool(_Idle, false);
    }

    public void StartRunAnimation()
    {
        animator.SetBool(_Run, true);
    }

    public void StopRunAnimation()
    {
        animator.SetBool(_Run, false);
    }

    public void StartAttackAnimation()
    {
        animator.SetBool(_Attack, true);
    }

    public void StopAttackAnimation()
    {
        animator.SetBool(_Attack, false);
    }

    public void StartDieAnimation()
    {
        animator.SetTrigger(_Die);
    }


}
