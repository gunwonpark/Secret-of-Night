using UnityEngine;


public class Skill : MonoBehaviour
{
    [SerializeField] private bool _isActive;
    public PlayerSkillData PlayerSkillData { get; private set; }
    public bool IsActive => _isActive;

    public void Initialize(PlayerSkillData playerSkillData)
    {
        PlayerSkillData = playerSkillData;
    }

    public void Active()
    {
        _isActive = true;
    }

}
