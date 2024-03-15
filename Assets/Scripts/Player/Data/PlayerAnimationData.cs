using System;
using UnityEngine;

[Serializable]
public class PlayerAnimationData
{
    [SerializeField] private string _walkHash = "Walk";
    [SerializeField] private string _runHash = "Run";
    [SerializeField] private string _idleHash = "Idle";
    [SerializeField] private string _jumpHash = "Jump";
    [SerializeField] private string _dodgeHash = "Dodge";
    [SerializeField] private string _attackHash = "Attack";
    [SerializeField] private string _Skill1 = "Skill1";
    [SerializeField] private string _Skill2 = "Skill2";

    public int WalkParameter { get; private set; }
    public int RunParameter { get; private set; }
    public int IdleParameter { get; private set; }
    public int JumpParameter { get; private set; }
    public int DodgeParameter { get; private set; }
    public int AttackParameter { get; private set; }
    public int Skill1 { get; private set; }
    public int Skill2 { get; private set; }
    public PlayerAnimationData()
    {
        WalkParameter = Animator.StringToHash(_walkHash);
        RunParameter = Animator.StringToHash(_runHash);
        IdleParameter = Animator.StringToHash(_idleHash);
        JumpParameter = Animator.StringToHash(_jumpHash);
        DodgeParameter = Animator.StringToHash(_dodgeHash);
        AttackParameter = Animator.StringToHash(_attackHash);
        Skill1 = Animator.StringToHash(_Skill1);
        Skill2 = Animator.StringToHash(_Skill2);
    }
}