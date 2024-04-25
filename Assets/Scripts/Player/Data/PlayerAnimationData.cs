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
    [SerializeField] private string _combo = "Combo";
    [SerializeField] private string _die = "Die";

    public int WalkParameter { get; private set; }
    public int RunParameter { get; private set; }
    public int IdleParameter { get; private set; }
    public int JumpParameter { get; private set; }
    public int DodgeParameter { get; private set; }
    public int AttackParameter { get; private set; }
    public int Skill1 { get; private set; }
    public int Skill2 { get; private set; }
    public int Skill3 { get; private set; }
    public int Combo { get; private set; }
    public int Die { get; private set; }
    public PlayerAnimationData()
    {
        WalkParameter = Animator.StringToHash(_walkHash);
        RunParameter = Animator.StringToHash(_runHash);
        IdleParameter = Animator.StringToHash(_idleHash);
        JumpParameter = Animator.StringToHash(_jumpHash);
        DodgeParameter = Animator.StringToHash(_dodgeHash);
        AttackParameter = Animator.StringToHash(_attackHash);
        Combo = Animator.StringToHash(_combo);
        Die = Animator.StringToHash(_die);
    }
}