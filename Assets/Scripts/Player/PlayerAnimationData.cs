using System;
using UnityEngine;

[Serializable]
public class PlayerAnimationData
{
    [SerializeField] private string walkHash = "Walk";
    [SerializeField] private string runHash = "Run";
    [SerializeField] private string idleHash = "Idle";
    [SerializeField] private string jumpHash = "Jump";
    [SerializeField] private string dodgehash = "Dodge";

    public int WalkParameter { get; private set; }
    public int RunParameter { get; private set; }
    public int IdleParameter { get; private set; }
    public int JumpParameter { get; private set; }
    public int DodgeParameter { get; private set; }
    public PlayerAnimationData()
    {
        WalkParameter = Animator.StringToHash(walkHash);
        RunParameter = Animator.StringToHash(runHash);
        IdleParameter = Animator.StringToHash(idleHash);
        JumpParameter = Animator.StringToHash(jumpHash);
        DodgeParameter = Animator.StringToHash(dodgehash);
    }
}