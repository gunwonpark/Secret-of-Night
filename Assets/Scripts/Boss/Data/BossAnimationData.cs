using System;
using UnityEngine;

[Serializable]
public class BossAnimationData
{
    
    [SerializeField] private string _runHash = "Run";
    [SerializeField] private string _idleHash = "Idle";
    [SerializeField] private string _dashHash = "Dash";
    [SerializeField] private string _attackHash = "Attack";

    public int WalkParameter { get; private set; }
    public int RunParameter { get; private set; }
    public int IdleParameter { get; private set; }
    public int DashParameter { get; private set; }
    public int AttackParameter { get; private set; }
    public BossAnimationData()
    {
        
        RunParameter = Animator.StringToHash(_runHash);
        IdleParameter = Animator.StringToHash(_idleHash);
        DashParameter = Animator.StringToHash(_dashHash);
        AttackParameter = Animator.StringToHash(_attackHash);
    }
}