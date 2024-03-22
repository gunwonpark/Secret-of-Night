using UnityEngine;

[System.Serializable]
public struct Skill
{
    [SerializeField] private int _id;
    //[SerializeField] private int _index; // 몇번째 스킬인지 인지한다
    [SerializeField] private bool _isActive;

    public int ID => _id;
    //public int Index => _index;
    public bool IsActive => _isActive;
    public Skill(int id, bool isActive = false)
    {
        _id = id;
        _isActive = isActive;
    }

    public void Active()
    {
        _isActive = true;
    }
}
public class BaseSkill : MonoBehaviour
{
    private float _damage;
    public float Damage => _damage;
}
